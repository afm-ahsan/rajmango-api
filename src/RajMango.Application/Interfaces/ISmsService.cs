using RajMango.Application.DTOs.Sms;

namespace RajMango.Application.Interfaces
{
    public interface ISmsService
    {
        /// <summary>
        /// Selects the correct SMS template from the context, sends one customer SMS,
        /// and optionally sends an admin alert. Never throws — all failures are logged to SmsLogs.
        /// No SMS is sent when <see cref="SmsOrderContext.HasAnyChange"/> is false.
        /// </summary>
        Task SendOrderUpdateAsync(
            int userId,
            string mobileNumber,
            SmsOrderContext context,
            CancellationToken cancellationToken = default);
    }
}
