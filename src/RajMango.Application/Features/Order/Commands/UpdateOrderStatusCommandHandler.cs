using MediatR;
using RajMango.Application.Common;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, Result<int>>
    {
        // Defines which status transitions are permitted.
        private static readonly Dictionary<OrderStatus, HashSet<OrderStatus>> AllowedTransitions = new()
        {
            [OrderStatus.Pending]    = new() { OrderStatus.Confirmed, OrderStatus.Cancelled },
            [OrderStatus.Confirmed]  = new() { OrderStatus.Processing, OrderStatus.Cancelled },
            [OrderStatus.Processing] = new() { OrderStatus.Shipped, OrderStatus.Cancelled },
            [OrderStatus.Shipped]    = new() { OrderStatus.Delivered },
            [OrderStatus.Delivered]  = new() { OrderStatus.Returned },
            [OrderStatus.Cancelled]  = new(),
            [OrderStatus.Returned]   = new(),
            [OrderStatus.Failed]     = new(),
        };

        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly INotificationService _notificationService;
        private readonly IRealtimeService _realtime;
        private readonly IOrderTrackingHistoryService _tracking;

        public UpdateOrderStatusCommandHandler(
            IErrorHandler errorHandler,
            IDataContext dataContext,
            INotificationService notificationService,
            IRealtimeService realtime,
            IOrderTrackingHistoryService tracking)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _notificationService = notificationService;
            _realtime = realtime;
            _tracking = tracking;
        }

        public async Task<Result<int>> Handle(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _dataContext.Get<Order>().FindAsync(new object[] { command.Id }, cancellationToken);
                if (order == null)
                    return await Result<int>.FailureAsync($"Order not found with Id {command.Id}.");

                if (!AllowedTransitions.TryGetValue(order.OrderStatus, out var allowed) || !allowed.Contains(command.NewStatus))
                    return await Result<int>.FailureAsync(
                        $"Cannot transition order from {order.OrderStatus} to {command.NewStatus}.");

                if (command.NewStatus == OrderStatus.Delivered && order.PaymentStatus != PaymentStatus.Paid)
                    return await Result<int>.FailureAsync(
                        "Order cannot be delivered: payment has not been completed.");

                order.OrderStatus = command.NewStatus;

                if (!string.IsNullOrWhiteSpace(command.TrackingNumber))
                    order.TrackingNumber = command.TrackingNumber;

                ApplyDeliverySync(order, command.NewStatus);

                _dataContext.Get<Order>().Update(order);
                await _dataContext.SaveChangesAsync(cancellationToken);

                try
                {
                    var (status, title, description) = GetTrackingEntry(command.NewStatus);
                    if (status != null)
                        await _tracking.InsertIfNewAsync(order.Id, status, title, description, cancellationToken);
                }
                catch { /* tracking failure must not block status update */ }

                await _notificationService.SendOrderStatusChangedAsync(
                    order.UserId, order.OrderNumber, command.NewStatus.ToString(), cancellationToken);

                var statusPayload = new { OrderId = order.Id, OrderNumber = order.OrderNumber, Status = command.NewStatus.ToString(), order.UserId };
                await _realtime.SendToUserAsync(order.UserId, RealtimeEvents.OrderStatusUpdated, statusPayload, cancellationToken);
                await _realtime.SendToAdminsAsync(RealtimeEvents.OrderStatusUpdated, statusPayload, cancellationToken);

                return await Result<int>.SuccessAsync(order.Id, $"Order status updated to {command.NewStatus}.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Order status update failed for Id {command.Id}.");
        }

        private static (string status, string title, string description) GetTrackingEntry(OrderStatus orderStatus)
        {
            return orderStatus switch
            {
                OrderStatus.Confirmed  => ("OrderConfirmed",  "Order Confirmed",       "Your order has been confirmed."),
                OrderStatus.Processing => ("OrderProcessing", "Preparing Your Order",  "Your order is being packed and prepared."),
                OrderStatus.Shipped    => ("OrderShipped",    "Order Shipped",         "Your order has been handed over to the courier."),
                OrderStatus.Delivered  => ("OrderDelivered",  "Order Delivered",       "Your order has been delivered successfully."),
                OrderStatus.Cancelled  => ("OrderCancelled",  "Order Cancelled",       "Your order has been cancelled."),
                OrderStatus.Returned   => ("OrderReturned",   "Order Returned",        "Your order has been returned."),
                _                     => (null, null, null),
            };
        }

        private static void ApplyDeliverySync(Order order, OrderStatus newStatus)
        {
            switch (newStatus)
            {
                case OrderStatus.Confirmed:
                    order.DeliveryStatus = DeliveryStatus.Pending;
                    break;
                case OrderStatus.Shipped:
                    order.DeliveryStatus = DeliveryStatus.Dispatched;
                    break;
                case OrderStatus.Delivered:
                    order.DeliveryStatus = DeliveryStatus.Delivered;
                    order.IsDelivered = true;
                    order.DeliveryDate = Clock.Now();
                    break;
                case OrderStatus.Returned:
                    order.DeliveryStatus = DeliveryStatus.Returned;
                    order.IsDelivered = false;
                    break;
                case OrderStatus.Cancelled:
                    order.DeliveryStatus = DeliveryStatus.Cancelled;
                    break;
            }
        }
    }
}
