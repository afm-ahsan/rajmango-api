using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using RajMango.Application.Interfaces;
using System.Security.Claims;

namespace RajMango.WebApi.Authorization
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IPermissionService _permissionService;
        private readonly ILogger<PermissionAuthorizationHandler> _logger;

        public PermissionAuthorizationHandler(
            IPermissionService permissionService,
            ILogger<PermissionAuthorizationHandler> logger)
        {
            _permissionService = permissionService;
            _logger = logger;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            if (context.User.Identity?.IsAuthenticated != true)
                return;

            // SuperAdmin bypasses all permission checks
            if (context.User.IsInRole("system_admin"))
            {
                context.Succeed(requirement);
                return;
            }

            if (!int.TryParse(
                    context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    out var userId))
                return;

            var hasPermission = await _permissionService.HasPermissionAsync(userId, requirement.Permission);
            if (hasPermission)
            {
                context.Succeed(requirement);
            }
            else
            {
                _logger.LogWarning(
                    "Access denied — user {UserId} missing permission '{Permission}'",
                    userId, requirement.Permission);
            }
        }
    }
}
