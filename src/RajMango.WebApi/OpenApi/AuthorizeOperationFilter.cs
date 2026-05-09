using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;

namespace RajMango.WebApi.OpenApi
{
    public class AuthorizeOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation == null) throw new ArgumentNullException(nameof(operation));
            if (context == null)  throw new ArgumentNullException(nameof(context));

            // AllowAnonymous at method or class level overrides any Authorize
            var hasAllowAnonymous = context.MethodInfo.GetCustomAttributes(true)
                .Union(context.MethodInfo.DeclaringType?.GetCustomAttributes(true) ?? Array.Empty<object>())
                .OfType<AllowAnonymousAttribute>()
                .Any();

            if (hasAllowAnonymous)
                return;

            var hasAuthorize = context.MethodInfo.DeclaringType?.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>()
                .Any() ?? false;

            if (!hasAuthorize)
                return;

            operation.Responses.TryAdd(StatusCodes.Status401Unauthorized.ToString(),
                new OpenApiResponse { Description = nameof(HttpStatusCode.Unauthorized) });
            operation.Responses.TryAdd(StatusCodes.Status403Forbidden.ToString(),
                new OpenApiResponse { Description = nameof(HttpStatusCode.Forbidden) });

            var bearerScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new() { [bearerScheme] = Array.Empty<string>() }
            };
        }
    }
}
