using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.UserPermission.Commands;
using RajMango.Application.Features.UserPermission.Queries;
using RajMango.Shared;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users/{userId:int}/permissions")]
    public class UserPermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserPermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Get all direct (override) permissions for a user.</summary>
        [HttpGet]
        [RequirePermission(Permissions.UserPermissions.View)]
        public async Task<ActionResult<Result<List<UserPermissionDto>>>> GetDirectPermissions(int userId)
        {
            return await _mediator.Send(new GetUserDirectPermissionsQuery(userId));
        }

        /// <summary>Grant a permission override to a user (grants extra or re-grants a revoked permission).</summary>
        [HttpPost]
        [RequirePermission(Permissions.UserPermissions.Grant)]
        public async Task<ActionResult<Result<int>>> Grant(int userId, [FromBody] GrantPermissionRequest request)
        {
            return await _mediator.Send(new GrantUserPermissionCommand
            {
                UserId = userId,
                PermissionId = request.PermissionId,
            });
        }

        /// <summary>Revoke a permission for a user, overriding the role-based grant.</summary>
        [HttpPut("{permissionId:int}/revoke")]
        [RequirePermission(Permissions.UserPermissions.Revoke)]
        public async Task<ActionResult<Result<int>>> Revoke(int userId, int permissionId)
        {
            return await _mediator.Send(new RevokeUserPermissionCommand
            {
                UserId = userId,
                PermissionId = permissionId,
            });
        }

        /// <summary>Remove a user-level permission override, restoring role-based behavior.</summary>
        [HttpDelete("{permissionId:int}")]
        [RequirePermission(Permissions.UserPermissions.Revoke)]
        public async Task<ActionResult<Result<int>>> DeleteOverride(int userId, int permissionId)
        {
            return await _mediator.Send(new DeleteUserPermissionOverrideCommand
            {
                UserId = userId,
                PermissionId = permissionId,
            });
        }
    }

    public class GrantPermissionRequest
    {
        public int PermissionId { get; set; }
    }
}
