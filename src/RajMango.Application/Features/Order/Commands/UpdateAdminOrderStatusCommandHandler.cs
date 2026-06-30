using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Common;
using RajMango.Application.DTOs.Sms;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using System.Collections.Generic;

namespace RajMango.Application.Features.Commands
{
    internal class UpdateAdminOrderStatusCommandHandler : IRequestHandler<UpdateAdminOrderStatusCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IRealtimeService _realtime;
        private readonly IErrorHandler _errorHandler;
        private readonly IOrderTrackingHistoryService _tracking;
        private readonly ISmsService _smsService;

        public UpdateAdminOrderStatusCommandHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            IRealtimeService realtime,
            IErrorHandler errorHandler,
            IOrderTrackingHistoryService tracking,
            ISmsService smsService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _realtime = realtime;
            _errorHandler = errorHandler;
            _tracking = tracking;
            _smsService = smsService;
        }

        public async Task<Result<int>> Handle(UpdateAdminOrderStatusCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_currentUserService.IsAdmin && !_currentUserService.IsSuperAdmin)
                    return await Result<int>.FailureAsync("Access denied.");

                var order = await _dataContext.Get<Order>()
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.MangoType)
                    .FirstOrDefaultAsync(o => o.Id == command.Id, cancellationToken);

                if (order == null)
                    return await Result<int>.FailureAsync($"Order not found with Id {command.Id}.");

                // Guard: cancelled order cannot become Delivered
                if (order.OrderStatus == OrderStatus.Cancelled && command.DeliveryStatus == DeliveryStatus.Delivered)
                    return await Result<int>.FailureAsync("A cancelled order cannot be marked as Delivered.");

                // Guard: delivered order cannot be cancelled (use return/refund workflow)
                if (order.DeliveryStatus == DeliveryStatus.Delivered && command.OrderStatus == OrderStatus.Cancelled)
                    return await Result<int>.FailureAsync(
                        "A delivered order cannot be cancelled directly. Use the return/refund workflow.");

                // Guard: delivered requires paid payment
                //if (command.DeliveryStatus == DeliveryStatus.Delivered && command.PaymentStatus != PaymentStatus.Paid)
                //    return await Result<int>.FailureAsync(
                //        "Order cannot be marked as Delivered: payment status must be Paid.");

                var prevOrderStatus    = order.OrderStatus;
                var prevPaymentStatus  = order.PaymentStatus;
                var prevDeliveryStatus = order.DeliveryStatus;
                var prevDeliveryDate   = order.DeliveryDate;

                order.OrderStatus = command.OrderStatus;
                order.PaymentStatus = command.PaymentStatus;
                order.DeliveryStatus = command.DeliveryStatus;

                // This command lets admins set PaymentStatus directly, bypassing the normal
                // payment-recording flow (CreatePaymentCommand / bKash callback) — without this sync,
                // Order.PaidAmount/DueAmount go stale and dashboards (which sum those fields) and
                // payments/payment-list (which lists the Payments table) silently disagree with the
                // PaymentStatus badge shown here and on order-list.
                bool createdManualPayment = false;
                if (prevPaymentStatus != command.PaymentStatus)
                {
                    if (command.PaymentStatus == PaymentStatus.Paid && order.DueAmount > 0)
                    {
                        // Record the outstanding balance as a manual payment so payments/payment-list
                        // reflects it too, then resync from the full payment history (correctly handles
                        // orders that already had a partial bKash/manual payment on file).
                        var manualPayment = new Domain.Entities.Payment
                        {
                            OrderId       = order.Id,
                            GrossAmount   = order.DueAmount,
                            NetAmount     = order.DueAmount,
                            PaidAmount    = order.DueAmount,
                            PaymentMethod = PaymentMethod.Cash,
                            PaymentStatus = PaymentStatus.Paid,
                            TransactionId = "ADMIN-STATUS-OVERRIDE",
                            PaidAt        = Clock.Now(),
                        };
                        _dataContext.Get<Domain.Entities.Payment>().Add(manualPayment);

                        var existingPayments = await _dataContext.Get<Domain.Entities.Payment>()
                            .Where(p => p.OrderId == order.Id)
                            .ToListAsync(cancellationToken);
                        existingPayments.Add(manualPayment);
                        PaymentSyncHelper.SyncOrderPaymentState(order, existingPayments);
                        createdManualPayment = true;
                    }
                    else if (command.PaymentStatus is PaymentStatus.Unpaid or PaymentStatus.Pending or PaymentStatus.Failed)
                    {
                        // No amount ambiguity here — these states mean nothing is collected.
                        // Prior payment rows (if any) are kept for audit history, not deleted.
                        order.PaidAmount = 0;
                        order.DueAmount = order.TotalAmount;
                    }
                    // Partial: this command carries no "amount paid" field, so PaidAmount/DueAmount
                    // are intentionally left as-is rather than guessing a number.
                }

                if (command.DeliveryStatus == DeliveryStatus.Dispatched ||
                    command.DeliveryStatus == DeliveryStatus.InTransit || 
                    command.DeliveryStatus == DeliveryStatus.Delivered)
                {
                    var deliveredAt = command.DeliveryDate ?? Clock.Now();
                    var isDelivered = command.DeliveryStatus == DeliveryStatus.Delivered ? true : false;
                    order.IsDelivered = isDelivered;
                    order.DeliveryDate = deliveredAt;

                    foreach (var detail in order.OrderDetails)
                    {
                        detail.IsDelivered = isDelivered;
                        detail.DeliveryDate = deliveredAt;
                    }
                }
                else
                {
                    order.IsDelivered = false;
                    order.DeliveryDate = null;

                    foreach (var detail in order.OrderDetails)
                    {
                        detail.IsDelivered = false;
                        detail.DeliveryDate = null;
                    }
                }

                // Primary operation: commit order update first.
                // All entities loaded via Include are change-tracked; SaveChanges detects all modifications.
                _dataContext.Get<Order>().Update(order);
                await _dataContext.SaveChangesAsync(cancellationToken);

                // Compute delivery date once; shared by notifications and SMS blocks below.
                var newDeliveryDate = command.DeliveryStatus is DeliveryStatus.Dispatched
                    or DeliveryStatus.InTransit or DeliveryStatus.Delivered
                    ? (command.DeliveryDate ?? Clock.Now())
                    : (DateTime?)null;

                // Secondary (best-effort): in-app notifications. Failure must not roll back the order update.
                try
                {
                    var notifications = BuildNotifications(
                        order.UserId, order.Id, order.OrderNumber,
                        prevOrderStatus, command.OrderStatus,
                        prevPaymentStatus, command.PaymentStatus,
                        prevDeliveryStatus, command.DeliveryStatus,
                        prevDeliveryDate, newDeliveryDate);

                    foreach (var notification in notifications)
                        _dataContext.Get<Notification>().Add(notification);

                    if (notifications.Count > 0)
                        await _dataContext.SaveChangesAsync(cancellationToken);
                }
                catch (Exception ex) { _errorHandler.Handle(ex); }

                // Secondary (best-effort): SMS — one message per update, template chosen by SmsService.
                try
                {
                    var userPhone = await _dataContext.Get<AppUser>()
                        .Where(u => u.Id == order.UserId)
                        .Select(u => u.PhoneNumber)
                        .FirstOrDefaultAsync(cancellationToken);

                    var smsItems = order.OrderDetails
                        .Select(d => new SmsOrderItem
                        {
                            MangoTypeName = d.MangoType?.Name ?? "Mango",
                            WeightKg      = CrateWeightKg(d.CrateType) * d.Quantity,
                        })
                        .Where(x => x.WeightKg > 0)
                        .ToList();

                    await _smsService.SendOrderUpdateAsync(
                        order.UserId, userPhone,
                        new SmsOrderContext
                        {
                            OrderNumber           = order.OrderNumber,
                            OrderStatus           = command.OrderStatus,
                            PaymentStatus         = command.PaymentStatus,
                            DeliveryStatus        = command.DeliveryStatus,
                            DeliveryDate          = newDeliveryDate,
                            Items                 = smsItems,
                            OrderStatusChanged    = prevOrderStatus    != command.OrderStatus,
                            PaymentStatusChanged  = prevPaymentStatus  != command.PaymentStatus,
                            DeliveryStatusChanged = prevDeliveryStatus != command.DeliveryStatus,
                            DeliveryDateChanged   = newDeliveryDate.HasValue && newDeliveryDate != prevDeliveryDate,
                            ShouldNotifyReceiver  = command.ShouldNotifyReceiver,
                            ShouldNotifySender    = command.ShouldNotifySender,
                            ReceiverMobileNumber  = order.ReceiverMobileNumber,
                        },
                        cancellationToken);
                }
                catch (Exception ex) { _errorHandler.Handle(ex); }

                // Secondary (best-effort): tracking history.
                try
                {
                    var entries = BuildTrackingEntries(
                        order.Id, prevOrderStatus, command.OrderStatus,
                        prevPaymentStatus, command.PaymentStatus,
                        prevDeliveryStatus, command.DeliveryStatus);

                    foreach (var (trackingStatus, title, description) in entries)
                        await _tracking.InsertIfNewAsync(order.Id, trackingStatus, title, description, cancellationToken);
                }
                catch { /* tracking failure must not block status update */ }

                var payload = new
                {
                    OrderId = order.Id,
                    OrderNumber = order.OrderNumber,
                    Status = command.OrderStatus.ToString(),
                    UserId = order.UserId,
                };
                await _realtime.SendToUserAsync(order.UserId, RealtimeEvents.OrderStatusUpdated, payload, cancellationToken);
                await _realtime.SendToAdminsAsync(RealtimeEvents.OrderStatusUpdated, payload, cancellationToken);

                // Dashboards and payments/payment-list listen for PaymentReceived to auto-refresh —
                // without this, a manual "mark as Paid" override only refreshes order-list (via
                // OrderStatusUpdated above), leaving payment-list/dashboard totals stale on screen
                // until the next manual page reload.
                if (createdManualPayment)
                {
                    var paymentPayload = new { OrderId = order.Id, order.OrderNumber, Amount = order.PaidAmount, order.UserId };
                    await _realtime.SendToUserAsync(order.UserId, RealtimeEvents.PaymentReceived, paymentPayload, cancellationToken);
                    await _realtime.SendToAdminsAsync(RealtimeEvents.PaymentReceived, paymentPayload, cancellationToken);
                }

                return await Result<int>.SuccessAsync(order.Id, "Order statuses updated successfully.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Failed to update order statuses for Id {command.Id}.");
        }

        private static IReadOnlyList<Notification> BuildNotifications(
            int userId, int orderId, string orderNumber,
            OrderStatus prevOrder,   OrderStatus newOrder,
            PaymentStatus prevPay,   PaymentStatus newPay,
            DeliveryStatus prevDel,  DeliveryStatus newDel,
            DateTime? prevDate,      DateTime? newDate)
        {
            var list = new List<Notification>();

            if (prevOrder != newOrder)
            {
                var label = newOrder switch
                {
                    OrderStatus.Confirmed  => "Confirmed",
                    OrderStatus.Processing => "Processing",
                    OrderStatus.Shipped    => "Shipped",
                    OrderStatus.Delivered  => "Delivered",
                    OrderStatus.Cancelled  => "Cancelled",
                    OrderStatus.Returned   => "Returned",
                    OrderStatus.Failed     => "Failed",
                    _                     => newOrder.ToString(),
                };
                list.Add(new Notification
                {
                    UserId           = userId,
                    OrderId          = orderId,
                    OrderNumber      = orderNumber,
                    NotificationType = NotificationType.OrderStatus,
                    Title            = $"Order #{orderNumber} updated",
                    Message          = $"Your order status has been updated to {label}.",
                });
            }

            if (prevPay != newPay)
            {
                var label = newPay switch
                {
                    PaymentStatus.Paid      => "Paid",
                    PaymentStatus.Partial   => "Partially Paid",
                    PaymentStatus.Refunded  => "Refunded",
                    PaymentStatus.Failed    => "Failed",
                    PaymentStatus.Cancelled => "Cancelled",
                    _                      => newPay.ToString(),
                };
                list.Add(new Notification
                {
                    UserId           = userId,
                    OrderId          = orderId,
                    OrderNumber      = orderNumber,
                    NotificationType = NotificationType.PaymentStatus,
                    Title            = $"Order #{orderNumber} payment updated",
                    Message          = $"Your payment status has been updated to {label}.",
                });
            }

            if (prevDel != newDel)
            {
                var label = newDel switch
                {
                    DeliveryStatus.Dispatched => "Dispatched",
                    DeliveryStatus.InTransit  => "In Transit",
                    DeliveryStatus.Delivered  => "Delivered",
                    DeliveryStatus.Failed     => "Failed",
                    DeliveryStatus.Returned   => "Returned",
                    DeliveryStatus.Cancelled  => "Cancelled",
                    _                        => newDel.ToString(),
                };
                list.Add(new Notification
                {
                    UserId           = userId,
                    OrderId          = orderId,
                    OrderNumber      = orderNumber,
                    NotificationType = NotificationType.DeliveryStatus,
                    Title            = $"Order #{orderNumber} delivery updated",
                    Message          = $"Your delivery status has been updated to {label}.",
                });
            }

            if (newDate.HasValue && newDate != prevDate)
            {
                list.Add(new Notification
                {
                    UserId           = userId,
                    OrderId          = orderId,
                    OrderNumber      = orderNumber,
                    NotificationType = NotificationType.DeliveryDate,
                    Title            = $"Order #{orderNumber} delivery date updated",
                    Message          = $"Your expected delivery date has been updated to {newDate.Value:dd MMM yyyy}.",
                });
            }

            return list;
        }

        private static int CrateWeightKg(CrateType crate) => crate switch
        {
            CrateType.Crate10Kg => 10,
            CrateType.Crate20Kg => 20,
            _                   => 0,
        };

        private static IEnumerable<(string status, string title, string description)> BuildTrackingEntries(
            int orderId,
            OrderStatus prevOrder,   OrderStatus newOrder,
            PaymentStatus prevPay,   PaymentStatus newPay,
            DeliveryStatus prevDel,  DeliveryStatus newDel)
        {
            if (prevOrder != newOrder)
            {
                var entry = newOrder switch
                {
                    OrderStatus.Confirmed  => ("OrderConfirmed",  "Order Confirmed",      "Your order has been confirmed."),
                    OrderStatus.Processing => ("OrderProcessing", "Preparing Your Order", "Your order is being packed and prepared."),
                    OrderStatus.Shipped    => ("OrderShipped",    "Order Shipped",        "Your order has been handed over to the courier."),
                    OrderStatus.Delivered  => ("OrderDelivered",  "Order Delivered",      "Your order has been delivered successfully."),
                    OrderStatus.Cancelled  => ("OrderCancelled",  "Order Cancelled",      "Your order has been cancelled."),
                    OrderStatus.Returned   => ("OrderReturned",   "Order Returned",       "Your order has been returned."),
                    _                     => (null, null, null),
                };
                if (entry.Item1 != null) yield return entry;
            }

            if (prevPay != newPay)
            {
                var entry = newPay switch
                {
                    PaymentStatus.Paid    => ("PaymentPaid",    "Payment Confirmed",         "Full payment has been received."),
                    PaymentStatus.Partial => ("PaymentPartial", "Partial Payment Received",  "A partial payment has been recorded."),
                    _                    => (null, null, null),
                };
                if (entry.Item1 != null) yield return entry;
            }

            if (prevDel != newDel)
            {
                var entry = newDel switch
                {
                    DeliveryStatus.Dispatched => ("DeliveryDispatched", "Order Dispatched", "Your order has been dispatched to the courier."),
                    DeliveryStatus.InTransit  => ("DeliveryInTransit",  "In Transit",       "Your order is on its way to you."),
                    DeliveryStatus.Delivered  => ("DeliveryDelivered",  "Delivered",        "Your order has been delivered."),
                    DeliveryStatus.Failed     => ("DeliveryFailed",     "Delivery Failed",  "Delivery was attempted but failed."),
                    DeliveryStatus.Returned   => ("DeliveryReturned",   "Return Initiated", "Your order is being returned."),
                    DeliveryStatus.Cancelled  => ("DeliveryCancelled",  "Delivery Cancelled", "Delivery has been cancelled."),
                    _                         => (null, null, null),
                };
                if (entry.Item1 != null) yield return entry;
            }
        }
    }
}
