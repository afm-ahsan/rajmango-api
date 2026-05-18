using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RajMango.Application.Interfaces;
using RajMango.DataAccess.Contexts;

namespace RajMango.DataAccess
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "RajMango.WebApi"))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var connectionString = config.GetConnectionString("Default");

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new AppDbContext(options, new DesignTimeCurrentUserService());
        }

        private sealed class DesignTimeCurrentUserService : ICurrentUserService
        {
            public int UserId => 0;
            public string UserName => "design-time";
            public bool IsAuthenticated => false;
            public bool IsAdmin => false;
            public bool IsSuperAdmin => false;
        }
    }
}
