using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RajMango.Shared;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RajMango.WebApi.OpenApi
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly AppSettings _settings;

        public ConfigureSwaggerGenOptions(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public void Configure(SwaggerGenOptions options)
        {
            options.OperationFilter<AuthorizeOperationFilter>();
            options.DescribeAllParametersInCamelCase();
            options.CustomSchemaIds(GenerateSchemaId);
            options.CustomOperationIds(apiDesc =>
            {
                var controller = apiDesc.ActionDescriptor.RouteValues["controller"];
                var action     = apiDesc.ActionDescriptor.RouteValues["action"];
                return $"{controller}_{action}";
            });

            options.SwaggerDoc(_settings.ApiInfo.Version, new OpenApiInfo
            {
                Title       = _settings.ApiInfo.Title,
                Version     = _settings.ApiInfo.Version,
                Description = _settings.ApiInfo.Description,
                Contact     = new OpenApiContact(),
                License     = new OpenApiLicense(),
            });

            // JWT Bearer — paste the token returned by POST /api/auth/login
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type        = SecuritySchemeType.Http,
                Scheme      = "bearer",
                BearerFormat = "JWT",
                Description = "Enter the JWT token returned by POST /api/auth/login.",
            });
        }

        private static string GenerateSchemaId(Type type)
        {
            if (!type.IsGenericType)
                return type.Name;

            var baseName    = type.GetGenericTypeDefinition().Name;
            baseName        = baseName[..baseName.IndexOf('`')];
            var genericArgs = type.GetGenericArguments().Select(GenerateSchemaId);
            return $"{baseName}_{string.Join("_", genericArgs)}";
        }
    }
}
