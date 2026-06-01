namespace RajMango.Application.Interfaces
{
    public interface IOrderTrackingHistoryService
    {
        Task InsertIfNewAsync(int orderId, string trackingStatus, string title, string description, CancellationToken cancellationToken);
    }
}
