using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RajMango.Application.Interfaces.Repositories;
using RajMango.DataAccess.Contexts;
using RajMango.DataAccess.Repositories;

namespace RajMango.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMappings();
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        private static void AddMappings(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            //services.AddDbContext<DataContext>(options =>
            //    options.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.Parse("10.4.19-mariadb")), ServiceLifetime.Scoped);
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IDataContext), typeof(AppDbContext))
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //.AddTransient<IPlayerRepository, PlayerRepository>();
        }
    }
}
