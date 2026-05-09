using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RajMango.Shared;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RajMango.WebApi.OpenApi
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppSettings _settings;
        public ConfigureSwaggerGenOptions(IHttpClientFactory httpClientFactory,
                                          IOptions<AppSettings> settings)
        {
            _httpClientFactory = httpClientFactory;
            _settings = settings.Value;
        }

        public void Configure(SwaggerGenOptions options)
        {
            //var discoveryDocument = GetDiscoveryDocument();

            options.OperationFilter<AuthorizeOperationFilter>();
            options.DescribeAllParametersInCamelCase();
            options.CustomSchemaIds(type => GenerateSchemaId(type));
            options.CustomOperationIds(apiDesc =>
            {
                var controller = apiDesc.ActionDescriptor.RouteValues["controller"];
                var action = apiDesc.ActionDescriptor.RouteValues["action"];
                return $"{controller}_{action}";
            });

            options.SwaggerDoc(_settings.ApiInfo.Version, CreateOpenApiInfo());

            options.AddSecurityDefinition(_settings.Security.Jwt.SecurityScheme, new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,

                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        //AuthorizationUrl = new Uri(discoveryDocument.AuthorizeEndpoint),
                        //TokenUrl = new Uri(discoveryDocument.TokenEndpoint),
                        AuthorizationUrl = new Uri("https://localhost:7215"),
                        TokenUrl = new Uri("https://localhost:7215"),
                        Scopes = new Dictionary<string, string>
                        {
                            { _settings.Security.Jwt.Audience , _settings.ApiInfo.Title }
                        },
                    }
                },
                Description = _settings.Security.Jwt.Description
            });
        }

        private string GenerateSchemaId(Type type)
        {
            if (type.IsGenericType)
            {
                var genericTypeName = type.GetGenericTypeDefinition().Name;
                genericTypeName = genericTypeName[..genericTypeName.IndexOf('`')];

                var genericArgs = type.GetGenericArguments().Select(GenerateSchemaId); // 👈 recursive call

                Console.WriteLine($"{genericTypeName}_{string.Join("_", genericArgs)}");

                return $"{genericTypeName}_{string.Join("_", genericArgs)}";
            }

            Console.WriteLine($"NonGeneric TypeName: {type.Name}");
            return type.Name;
        }

        private DiscoveryDocumentResponse GetDiscoveryDocument()
        {
            return _httpClientFactory
                .CreateClient()
                .GetDiscoveryDocumentAsync(_settings.Security.Jwt.Authority)
                .GetAwaiter()
                .GetResult();
        }

        private OpenApiInfo CreateOpenApiInfo()
        {
            return new OpenApiInfo()
            {
                Title = _settings.ApiInfo.Title,
                Version = _settings.ApiInfo.Version,
                Description = _settings.ApiInfo.Description,
                Contact = new OpenApiContact(),
                License = new OpenApiLicense()
            };
        }
    }
}
