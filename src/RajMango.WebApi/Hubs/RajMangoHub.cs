using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace RajMango.WebApi.Hubs
{
    /// <summary>
    /// Central SignalR hub. Clients connect with a valid JWT.
    /// Admin users are automatically added to the "Admins" group on connect.
    /// Frontend: connect to /hubs/rajmango and subscribe to RealtimeEvents constants.
    /// </summary>
    [Authorize]
    public class RajMangoHub : Hub
    {
        private const string AdminGroup = "Admins";

        public override async Task OnConnectedAsync()
        {
            if (Context.User?.IsInRole("system_admin") == true ||
                Context.User?.IsInRole("admin") == true)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, AdminGroup);
            }

            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
            => base.OnDisconnectedAsync(exception);
    }
}
