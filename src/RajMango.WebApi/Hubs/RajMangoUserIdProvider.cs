using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace RajMango.WebApi.Hubs
{
    /// <summary>
    /// Maps the JWT NameIdentifier claim to a SignalR user ID so that
    /// IHubContext.Clients.User(userId.ToString()) targets the correct connection.
    /// </summary>
    public class RajMangoUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
            => connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
