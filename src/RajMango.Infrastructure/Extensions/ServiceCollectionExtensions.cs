using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Infrastructure.Interceptors;
using RajMango.Infrastructure.Services;
using RajMango.Shared;

namespace RajMango.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices(configuration);
        }

        private static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScoped<IMediator, Mediator>()
                .AddScoped<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>()
                .AddTransient<IErrorHandler, ErrorHandler>()
                .AddTransient<IDateTimeService, DateTimeService>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IJwtTokenService, JwtTokenService>()
                .AddTransient<INotificationService, NotificationService>()
                .AddTransient<IBkashService, BkashService>()
                .AddTransient<ISmsService, SmsService>()
                .AddTransient<ICacheService, RedisCacheService>()
                .AddTransient<IFileStorageService, LocalFileStorageService>()
                .AddScoped<IPermissionService, PermissionService>();

            // Register IOptions<BkashSettings> directly so bKash services inject it without
            // going through the parent AppSettings. ValidateOnStart() ensures the application
            // fails immediately at startup if any required credential is missing, rather than
            // failing silently on the first payment attempt.
            services.AddOptions<BkashSettings>()
                .Bind(configuration.GetSection("Bkash"))
                .Validate(
                    s => !string.IsNullOrWhiteSpace(s.BaseUrl)
                      && !string.IsNullOrWhiteSpace(s.AppKey)
                      && !string.IsNullOrWhiteSpace(s.AppSecret)
                      && !string.IsNullOrWhiteSpace(s.Username)
                      && !string.IsNullOrWhiteSpace(s.Password)
                      && !string.IsNullOrWhiteSpace(s.CallbackUrl),
                    "One or more required bKash settings are missing. " +
                    "In Production, set the following environment variables on the server: " +
                    "BKASH__APPKEY, BKASH__APPSECRET, BKASH__USERNAME, BKASH__PASSWORD. " +
                    "In Development, verify appsettings.Development.json contains the sandbox credentials.")
                .ValidateOnStart();

            services.AddHttpClient("Bkash", (sp, client) =>
            {
                var settings = sp.GetRequiredService<IOptions<BkashSettings>>().Value;
                if (!string.IsNullOrEmpty(settings.BaseUrl))
                    client.BaseAddress = new Uri(settings.BaseUrl.TrimEnd('/') + "/");
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromSeconds(settings.TimeoutSeconds > 0 ? settings.TimeoutSeconds : 15);
            });

            // Ghonta SMS: GET {BaseUrl}?toNo=...&msg=...
            // No BaseAddress — the service builds the full URL per call.
            // No Accept header — the provider is queried with GET, no request body.
            services.AddHttpClient("Sms", (sp, client) =>
            {
                var settings = sp.GetRequiredService<IOptions<AppSettings>>().Value.Sms;
                client.Timeout = TimeSpan.FromSeconds(settings?.TimeoutSeconds > 0 ? settings.TimeoutSeconds : 5);
            });

            // Redis or in-memory distributed cache (fallback for dev/test when Redis not configured)
            var redisConnectionString = configuration["Redis:ConnectionString"];
            if (!string.IsNullOrWhiteSpace(redisConnectionString))
                services.AddStackExchangeRedisCache(opts => opts.Configuration = redisConnectionString);
            else
                services.AddDistributedMemoryCache();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuditLogService, AuditLogService>();
            services.AddScoped<AuditInterceptor>();
        }
    }
}
