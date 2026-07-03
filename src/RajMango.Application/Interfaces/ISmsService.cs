using RajMango.Application.DTOs.Sms;

namespace RajMango.Application.Interfaces
{
    public interface ISmsService
    {
        /// <summary>
        /// Resolves the correct SMS recipient from the context flags, sends the appropriate
        /// message, and logs every outcome to SmsLogs. Never throws.
        ///
        /// Recipient rules (evaluated in order):
        ///   Rule 3 — ShouldNotifyReceiver=false AND ShouldNotifySender=false:
        ///             No SMS sent; a Skipped log entry is written.
        ///   Rule 1 — ShouldNotifyReceiver=true (default):
        ///             Sends to ReceiverMobileNumber if set (gift order),
        ///             otherwise falls back to senderMobileNumber (self order).
        ///   Rule 2 — ShouldNotifySender=true:
        ///             Sends to senderMobileNumber (the order placer).
        ///
        /// No SMS is sent when <see cref="SmsOrderContext.HasAnyChange"/> is false.
        /// </summary>
        Task SendOrderUpdateAsync(
            int userId,
            string senderMobileNumber,
            SmsOrderContext context,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Send a payment-confirmed SMS directly to the customer (sender/order-placer only).
        /// Used exclusively by the bKash callback after a successful Execute Payment so that
        /// the receiver of the delivery does NOT receive a payment notification.
        /// Never throws — any failure is logged internally.
        /// </summary>
        Task SendPaymentConfirmedSmsAsync(
            string customerPhone,
            string orderNumber,
            int userId,
            CancellationToken cancellationToken = default);
    }
}
