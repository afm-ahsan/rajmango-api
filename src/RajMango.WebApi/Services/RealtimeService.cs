using Microsoft.AspNetCore.SignalR;
using RajMango.Application.Interfaces;
using RajMango.WebApi.Hubs;

namespace RajMango.WebApi.Services
{
    /// <summary>
    /// IRealtimeService implementation using SignalR IHubContext.
    /// Lives in WebApi (not Infrastructure) to avoid a circular project reference,
    /// following the same pattern as CurrentUserService.
    /// </summary>
    public class RealtimeService : IRealtimeService
    {
        private readonly IHubContext<RajMangoHub> _hub;

        public RealtimeService(IHubContext<RajMangoHub> hub)
        {
            _hub = hub;
        }

        public Task SendToUserAsync(int userId, string eventName, object payload, CancellationToken ct = default)
            => _hub.Clients.User(userId.ToString()).SendAsync(eventName, payload, ct);

        public Task SendToAdminsAsync(string eventName, object payload, CancellationToken ct = default)
            => _hub.Clients.Group("Admins").SendAsync(eventName, payload, ct);

        public Task SendToAllAsync(string eventName, object payload, CancellationToken ct = default)
            => _hub.Clients.All.SendAsync(eventName, payload, ct);
    }
}
