using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.DataAccess.Contexts;
using RajMango.Domain.Entities;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Auth
{
    public class RegisterUserCommandHandlerTests
    {
        private static IRegistrationLock NoOpLock()
        {
            var handle = new Mock<IDisposable>();
            var mock = new Mock<IRegistrationLock>();
            mock.Setup(x => x.AcquireAsync()).ReturnsAsync(handle.Object);
            return mock.Object;
        }

        private static IErrorHandler NoOpErrorHandler()
        {
            var mock = new Mock<IErrorHandler>();
            mock.Setup(x => x.Handle(It.IsAny<Exception>()));
            return mock.Object;
        }

        private static AppDbContext CreateUnauthenticatedDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var mockUserService = new Mock<ICurrentUserService>();
            mockUserService.Setup(x => x.UserId).Returns(0);
            mockUserService.Setup(x => x.IsAuthenticated).Returns(false);
            return new AppDbContext(options, mockUserService.Object);
        }

        [Fact]
        public async Task Register_NewUser_Succeeds()
        {
            using var db = TestDbContextFactory.Create();
            var handler = new RegisterUserCommandHandler(
                new PasswordHasher<AppUser>(),
                NoOpLock(),
                NoOpErrorHandler(),
                db);

            var command = new RegisterUserCommand
            {
                FirstName   = "Test",
                LastName    = "User",
                Email       = "test@example.com",
                PhoneNumber = "01700000001",
                Password    = "Test@1234",
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeTrue(because: result.Messages?.FirstOrDefault() ?? "unknown failure");
            db.Get<AppUser>().Count().Should().Be(1);
            db.Get<AppUser>().First().CreatedBy.Should().BeGreaterThan(0, "audit user must be set server-side");
        }

        [Fact]
        public async Task Register_Unauthenticated_Succeeds()
        {
            using var db = CreateUnauthenticatedDb();
            var handler = new RegisterUserCommandHandler(
                new PasswordHasher<AppUser>(),
                NoOpLock(),
                NoOpErrorHandler(),
                db);

            var command = new RegisterUserCommand
            {
                FirstName   = "Self",
                LastName    = "Register",
                Email       = "self@example.com",
                PhoneNumber = "01700000099",
                Password    = "Test@1234",
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeTrue(because: result.Messages?.FirstOrDefault() ?? "unauthenticated registration must succeed");
            db.Get<AppUser>().Count().Should().Be(1);
            db.Get<AppUser>().First().CreatedBy.Should().Be(1, "unauthenticated saves fall back to SystemUserId=1");
        }

        [Fact]
        public async Task Register_DuplicateEmail_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var handler = new RegisterUserCommandHandler(
                new PasswordHasher<AppUser>(),
                NoOpLock(),
                NoOpErrorHandler(),
                db);

            var command = new RegisterUserCommand
            {
                FirstName   = "Test",
                LastName    = "User",
                Email       = "dup@example.com",
                PhoneNumber = "01700000001",
                Password    = "Test@1234",
            };

            await handler.Handle(command, CancellationToken.None);

            var command2 = command with { PhoneNumber = "01700000002" };
            var result2 = await handler.Handle(command2, CancellationToken.None);

            result2.Succeeded.Should().BeFalse();
            result2.Messages.Should().Contain(m => m.Contains("email", StringComparison.OrdinalIgnoreCase));
        }
    }
}
