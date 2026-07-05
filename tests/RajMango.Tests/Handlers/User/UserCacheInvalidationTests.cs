using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using RajMango.Application.Features.Commands;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.User
{
    public class UserCacheInvalidationTests
    {
        private static Mock<IPermissionService> NoOpPermissionService()
        {
            var mock = new Mock<IPermissionService>();
            mock.Setup(x => x.InvalidateUserPermissionCacheAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            return mock;
        }

        private static IErrorHandler NoOpErrorHandler()
        {
            var mock = new Mock<IErrorHandler>();
            mock.Setup(x => x.Handle(It.IsAny<Exception>()));
            return mock.Object;
        }

        private static IPasswordHasher<AppUser> NoOpPasswordHasher()
        {
            var mock = new Mock<IPasswordHasher<AppUser>>();
            mock.Setup(x => x.HashPassword(It.IsAny<AppUser>(), It.IsAny<string>()))
                .Returns("hashed");
            return mock.Object;
        }

        private static ICurrentUserService NonAdminCurrentUserService()
        {
            var mock = new Mock<ICurrentUserService>();
            mock.SetupGet(x => x.IsSuperAdmin).Returns(false);
            mock.SetupGet(x => x.IsAdmin).Returns(false);
            mock.SetupGet(x => x.UserId).Returns(0);
            return mock.Object;
        }

        [Fact]
        public async Task UpdateUserHandler_InvalidatesPermissionCacheForUser()
        {
            using var db = TestDbContextFactory.Create();
            var (user, role) = SeedUserWithRole(db);
            var permSvc = NoOpPermissionService();

            var handler = new UpdateUserCommandHandler(NoOpPasswordHasher(), NoOpErrorHandler(), db, permSvc.Object, NonAdminCurrentUserService());
            var command = new UpdateUserCommand
            {
                Id = user.Id,
                FirstName = "Updated",
                LastName = "Name",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = "NewPass123!",
                IsActive = true,
                RoleId = role.Id,
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(user.Id, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateUserHandler_UserNotFound_DoesNotCallCacheInvalidation()
        {
            using var db = TestDbContextFactory.Create();
            var permSvc = NoOpPermissionService();

            var handler = new UpdateUserCommandHandler(NoOpPasswordHasher(), NoOpErrorHandler(), db, permSvc.Object, NonAdminCurrentUserService());
            var command = new UpdateUserCommand
            {
                Id = 9999,
                FirstName = "Ghost",
                LastName = "User",
                Email = "ghost@test.com",
                PhoneNumber = "01700000000",
                Password = "Pass123!",
                IsActive = true,
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeleteUserHandler_InvalidatesPermissionCacheBeforeDelete()
        {
            using var db = TestDbContextFactory.Create();
            var user = SeedUser(db);
            var permSvc = NoOpPermissionService();

            var handler = new DeleteUserCommandHandler(NoOpErrorHandler(), db, permSvc.Object);

            var result = await handler.Handle(new DeleteUserCommand { Id = user.Id }, CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(user.Id, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteUserHandler_UserNotFound_DoesNotCallCacheInvalidation()
        {
            using var db = TestDbContextFactory.Create();
            var permSvc = NoOpPermissionService();

            var handler = new DeleteUserCommandHandler(NoOpErrorHandler(), db, permSvc.Object);

            var result = await handler.Handle(new DeleteUserCommand { Id = 9999 }, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        private static AppUser SeedUser(RajMango.DataAccess.Contexts.AppDbContext db)
        {
            var user = new AppUser
            {
                UserName = "testuser",
                FirstName = "Test",
                LastName = "User",
                Email = "test@test.com",
                PhoneNumber = "01700000001",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            };
            db.Get<AppUser>().Add(user);
            db.SaveChanges();
            return user;
        }

        private static (AppUser user, Domain.Entities.Role role) SeedUserWithRole(RajMango.DataAccess.Contexts.AppDbContext db)
        {
            var role = new Domain.Entities.Role
            {
                Name = "TestRole",
                Code = "test_role",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            };
            db.Get<Domain.Entities.Role>().Add(role);
            db.SaveChanges();

            var user = new AppUser
            {
                UserName = "testuser2",
                FirstName = "Test",
                LastName = "User",
                Email = "test2@test.com",
                PhoneNumber = "01700000003",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            };
            db.Get<AppUser>().Add(user);
            db.SaveChanges();

            db.Get<UserRole>().Add(new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id,
                AssignedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
            });
            db.SaveChanges();

            return (user, role);
        }
    }
}
