using Microsoft.EntityFrameworkCore;
using Moq;
using RajMango.Application.Interfaces;
using RajMango.DataAccess.Contexts;

namespace RajMango.Tests.Helpers
{
    /// <summary>
    /// Creates an isolated in-memory AppDbContext for each test.
    /// Each call gets a unique database name to prevent test bleed.
    /// </summary>
    public static class TestDbContextFactory
    {
        public static AppDbContext Create(string dbName = null)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(dbName ?? Guid.NewGuid().ToString())
                .Options;

            var mockUserService = new Mock<ICurrentUserService>();
            mockUserService.Setup(x => x.UserId).Returns(1);
            mockUserService.Setup(x => x.UserName).Returns("test-user");
            mockUserService.Setup(x => x.IsAuthenticated).Returns(true);
            mockUserService.Setup(x => x.IsAdmin).Returns(false);
            mockUserService.Setup(x => x.IsSuperAdmin).Returns(false);

            return new AppDbContext(options, mockUserService.Object);
        }
    }
}
