using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RajMango.Shared;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;

namespace RajMango.WebApi.OpenApi
{
    public class AuthorizeOperationFilter : IOperationFilter
    {
        private readonly AppSettings _settings;
        public AuthorizeOperationFilter(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation == null) { throw new ArgumentNullException(nameof(operation)); }
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (context.MethodInfo == null) { throw new ArgumentNullException(nameof(context.MethodInfo)); }
            if (context.MethodInfo.DeclaringType == null) { throw new ArgumentNullException(nameof(context.MethodInfo.DeclaringType)); }

            var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                            .Union(context.MethodInfo.GetCustomAttributes(true))
                            .OfType<AuthorizeAttribute>();

            if (authAttributes.Any())
            {
                operation.Responses.Add(StatusCodes.Status401Unauthorized.ToString(), new OpenApiResponse { Description = nameof(HttpStatusCode.Unauthorized) });
                operation.Responses.Add(StatusCodes.Status403Forbidden.ToString(), new OpenApiResponse { Description = nameof(HttpStatusCode.Forbidden) });
            }

            if (authAttributes.Any())
            {
                operation.Security = new List<OpenApiSecurityRequirement>();

                var oauth2SecurityScheme = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference { 
                        Type = ReferenceType.SecurityScheme, 
                        Id = _settings.Security.Jwt.SecurityScheme },
                };


                operation.Security.Add(new OpenApiSecurityRequirement()
                {
                    [oauth2SecurityScheme] = new[] { _settings.Security.Jwt.SecurityScheme }
                });
            }
        }
    }
}
