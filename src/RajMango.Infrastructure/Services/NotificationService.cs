using Microsoft.Extensions.Logging;
using RajMango.Application.Interfaces;

namespace RajMango.Infrastructure.Services
{
    // Stub — replace with real email/SMS provider (SendGrid, Twilio, etc.)
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(ILogger<NotificationService> logger)
        {
            _logger = logger;
        }

        public Task SendOrderConfirmedAsync(int userId, string orderNumber, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("NOTIFY: Order confirmed — UserId={UserId}, Order={OrderNumber}", userId, orderNumber);
            return Task.CompletedTask;
        }

        public Task SendPaymentReceivedAsync(int userId, string orderNumber, decimal paidAmount, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("NOTIFY: Payment received — UserId={UserId}, Order={OrderNumber}, Amount={Amount}", userId, orderNumber, paidAmount);
            return Task.CompletedTask;
        }

        public Task SendOrderStatusChangedAsync(int userId, string orderNumber, string newStatus, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("NOTIFY: Order status changed — UserId={UserId}, Order={OrderNumber}, Status={Status}", userId, orderNumber, newStatus);
            return Task.CompletedTask;
        }

        public Task SendComplaintStatusChangedAsync(int userId, int complaintId, string newStatus, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("NOTIFY: Complaint status changed — UserId={UserId}, ComplaintId={ComplaintId}, Status={Status}", userId, complaintId, newStatus);
            return Task.CompletedTask;
        }
    }
}
