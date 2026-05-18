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
                .AddTransient<ICacheService, RedisCacheService>()
                .AddTransient<IFileStorageService, LocalFileStorageService>()
                .AddTransient<ITurnstileVerificationService, TurnstileVerificationService>()
                .AddScoped<IPermissionService, PermissionService>();

            services.AddHttpClient("Turnstile", (_, client) =>
            {
                client.BaseAddress = new Uri("https://challenges.cloudflare.com/turnstile/v0/");
            });

            services.AddHttpClient("Bkash", (sp, client) =>
            {
                var settings = sp.GetRequiredService<IOptions<AppSettings>>().Value.Bkash;
                if (!string.IsNullOrEmpty(settings?.BaseUrl))
                    client.BaseAddress = new Uri(settings.BaseUrl.TrimEnd('/') + "/");
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });

            // Redis or in-memory distributed cache (fallback for dev/test when Redis not configured)
            var redisConnectionString = configuration["Redis:ConnectionString"];
            if (!string.IsNullOrWhiteSpace(redisConnectionString))
                services.AddStackExchangeRedisCache(opts => opts.Configuration = redisConnectionString);
            else
                services.AddDistributedMemoryCache();

            //Later
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuditLogService, AuditLogService>();
            services.AddScoped<AuditInterceptor>();
        }
    }
}
