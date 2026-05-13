using Microsoft.AspNetCore.Authorization;

namespace RajMango.WebApi.Authorization
{
    /// <summary>
    /// Enforces a named permission on a controller action.
    /// Usage: [RequirePermission(Permissions.Orders.Create)]
    /// </summary>
    public class RequirePermissionAttribute : AuthorizeAttribute
    {
        public RequirePermissionAttribute(string permission) : base(permission) { }
    }
}
