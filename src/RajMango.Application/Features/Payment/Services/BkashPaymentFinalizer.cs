using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RajMango.Application.Common;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Services
{
    /// <summary>
    /// Shared "mark this Pending bKash payment as Paid" logic — used by both the bKash callback
    /// handler and the admin-triggered reconciliation command, so the two entry points can never
    /// drift apart on how a payment is finalized (order sync, notifications, SMS).
    /// </summary>
    public interface IBkashPaymentFinalizer
    {
        /// <summary>
        /// Caller must already hold the payment lock, have confirmed bKash reports the transaction
        /// as Completed, and have loaded <paramref name="payment"/> with its Order included while
        /// its status is still Pending.
        /// </summary>
        Task FinalizeAsPaidAsync(Payment payment, string trxId, CancellationToken cancellationToken);
    }

    internal class BkashPaymentFinalizer : IBkashPaymentFinalizer
    {
        private readonly IDataContext _dataContext;
        private readonly IRealtimeService _realtime;
        private readonly INotificationService _notification;
        private readonly ISmsService _sms;
        private readonly ILogger<BkashPaymentFinalizer> _logger;

        public BkashPaymentFinalizer(
            IDataContext dataContext,
            IRealtimeService realtime,
            INotificationService notification,
            ISmsService sms,
            ILogger<BkashPaymentFinalizer> logger)
        {
            _dataContext = dataContext;
            _realtime = realtime;
            _notification = notification;
            _sms = sms;
            _logger = logger;
        }

        public async Task FinalizeAsPaidAsync(Payment payment, string trxId, CancellationToken cancellationToken)
        {
            payment.PaymentStatus = PaymentStatus.Paid;
            payment.GatewayTransactionId = trxId;
            // Only backfill TransactionId if it's not already set.
            if (string.IsNullOrEmpty(payment.TransactionId))
            {
                payment.TransactionId = trxId;
            }
            payment.PaidAmount = payment.GrossAmount;
            payment.PaidAt = Clock.Now();

            var order = payment.Order;
            try
            {
                // Excludes this payment's row, then adds back the in-memory instance just
                // mutated above — under NoTracking a re-query would return a stale copy
                // (PaidAmount still 0) since these edits haven't been saved yet.
                var allPayments = await _dataContext.Get<Payment>()
                    .Where(p => p.OrderId == order.Id && p.Id != payment.Id)
                    .ToListAsync(cancellationToken);
                allPayments.Add(payment);

                PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);
                payment.DueAmount = order.DueAmount;

                _dataContext.Get<Payment>().Update(payment);

                // Promote order status on full payment
                if (order.PaymentStatus == PaymentStatus.Paid
                    && order.OrderStatus == OrderStatus.Pending)
                {
                    order.OrderStatus = OrderStatus.Confirmed;
                }

                _dataContext.Get<Order>().Update(order);
                await _dataContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                // CRITICAL: bKash confirmed and charged the customer, but our database failed to
                // record it. Requires manual reconciliation — search this trxId/paymentId in
                // bKash's merchant portal and re-apply the payment by hand.
                _logger.LogCritical(ex,
                    "RECONCILIATION REQUIRED: bKash confirmed payment but DB persist failed. " +
                    "gatewayPaymentId={GatewayPaymentId} orderId={OrderId} trxId={TrxId} amount={Amount}",
                    payment.GatewayPaymentId, order.Id, trxId, payment.GrossAmount);
                return;
            }

            _logger.LogInformation(
                "bKash payment completed: orderId={OrderId} orderNumber={OrderNumber} trxId={TrxId} amount={Amount}",
                order.Id, order.OrderNumber, trxId, payment.PaidAmount);

            // In-app notification + real-time push (fire-and-forget — matches existing handlers)
            var payload = new { PaymentId = payment.Id, order.OrderNumber, Amount = payment.PaidAmount, order.UserId };
            _ = _notification.SendPaymentReceivedAsync(order.UserId, order.OrderNumber, payment.PaidAmount, cancellationToken);
            _ = _realtime.SendToUserAsync(order.UserId, RealtimeEvents.PaymentReceived, payload, cancellationToken);
            _ = _realtime.SendToAdminsAsync(RealtimeEvents.PaymentReceived, payload, cancellationToken);

            // SMS — sent only to the customer (order placer / sender), never to the delivery
            // receiver or admin. Customer phone is loaded here because it is not on the Order entity.
            var customerPhone = await _dataContext.Get<AppUser>()
                .Where(u => u.Id == order.UserId)
                .Select(u => u.PhoneNumber)
                .FirstOrDefaultAsync(cancellationToken);

            if (!string.IsNullOrWhiteSpace(customerPhone))
                _ = _sms.SendPaymentConfirmedSmsAsync(customerPhone, order.OrderNumber, order.UserId, cancellationToken);
            else
                _logger.LogWarning(
                    "bKash payment SMS skipped: customer has no phone. orderId={OrderId} userId={UserId}",
                    order.Id, order.UserId);
        }
    }
}
