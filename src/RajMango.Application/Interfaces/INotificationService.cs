namespace RajMango.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendOrderConfirmedAsync(int userId, string orderNumber, CancellationToken cancellationToken = default);
        Task SendPaymentReceivedAsync(int userId, string orderNumber, decimal paidAmount, CancellationToken cancellationToken = default);
        Task SendOrderStatusChangedAsync(int userId, string orderNumber, string newStatus, CancellationToken cancellationToken = default);
        Task SendComplaintStatusChangedAsync(int userId, int complaintId, string newStatus, CancellationToken cancellationToken = default);
    }
}
