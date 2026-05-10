namespace RajMango.Application.Interfaces
{
    public interface IRealtimeService
    {
        Task SendToUserAsync(int userId, string eventName, object payload, CancellationToken ct = default);
        Task SendToAdminsAsync(string eventName, object payload, CancellationToken ct = default);
        Task SendToAllAsync(string eventName, object payload, CancellationToken ct = default);
    }
}
