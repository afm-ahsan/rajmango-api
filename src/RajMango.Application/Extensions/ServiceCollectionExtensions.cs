using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RajMango.Application.Common;
using RajMango.Application.Features.Services;
using System.Reflection;

namespace RajMango.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMediator();
            services.AddValidators();
            services.RegistrationLock();
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(CachingBehavior<,>));
            });
        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private static void RegistrationLock(this IServiceCollection services)
        {
            services.AddTransient<IRegistrationLock, RegistrationLock>();
        }
    }
}
