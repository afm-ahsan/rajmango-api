using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Infrastructure.Interceptors;
using RajMango.Infrastructure.Services;

namespace RajMango.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IMediator, Mediator>()
                .AddScoped<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>()
                .AddTransient<IErrorHandler, ErrorHandler>()
                .AddTransient<IDateTimeService, DateTimeService>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IJwtTokenService, JwtTokenService>()
                .AddTransient<INotificationService, NotificationService>();

            //Later
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuditLogService, AuditLogService>();
            services.AddScoped<AuditInterceptor>();
        }
    }
}
