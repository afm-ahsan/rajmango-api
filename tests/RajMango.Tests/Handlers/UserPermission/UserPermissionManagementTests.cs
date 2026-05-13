using FluentAssertions;
using Moq;
using RajMango.Application.Features.UserPermission.Commands;
using RajMango.Application.Features.UserPermission.Queries;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.UserPermission
{
    public class UserPermissionManagementTests
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

        // ── Grant ─────────────────────────────────────────────────────────────

        [Fact]
        public async Task Grant_CreatesUserPermissionAndInvalidatesCache()
        {
            using var db = TestDbContextFactory.Create();
            var (user, permission) = SeedUserAndPermission(db);
            var permSvc = NoOpPermissionService();

            var handler = new GrantUserPermissionCommandHandler(db, NoOpErrorHandler(), permSvc.Object);
            var result = await handler.Handle(new GrantUserPermissionCommand
            {
                UserId = user.Id,
                PermissionId = permission.Id,
            }, CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            db.Get<Domain.Entities.UserPermission>()
                .Any(up => up.UserId == user.Id && up.PermissionId == permission.Id && up.IsGranted)
                .Should().BeTrue();
            permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(user.Id, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Grant_AlreadyGranted_ReturnsSuccessWithoutDuplicate()
        {
            using var db = TestDbContextFactory.Create();
            var (user, permission) = SeedUserAndPermission(db);
            db.Get<Domain.Entities.UserPermission>().Add(new Domain.Entities.UserPermission
            {
                UserId = user.Id,
                PermissionId = permission.Id,
                IsGranted = true,
            });
            db.SaveChanges();

            var handler = new GrantUserPermissionCommandHandler(db, NoOpErrorHandler(), NoOpPermissionService().Object);
            var result = await handler.Handle(new GrantUserPermissionCommand
            {
                UserId = user.Id,
                PermissionId = permission.Id,
            }, CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            db.Get<Domain.Entities.UserPermission>()
                .Count(up => up.UserId == user.Id && up.PermissionId == permission.Id)
                .Should().Be(1);
        }

        [Fact]
        public async Task Grant_UserNotFound_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var permission = SeedPermission(db);
            var permSvc = NoOpPermissionService();

            var handler = new GrantUserPermissionCommandHandler(db, NoOpErrorHandler(), permSvc.Object);
            var result = await handler.Handle(new GrantUserPermissionCommand
            {
                UserId = 9999,
                PermissionId = permission.Id,
            }, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        // ── Revoke ────────────────────────────────────────────────────────────

        [Fact]
        public async Task Revoke_SetsIsGrantedFalseAndInvalidatesCache()
        {
            using var db = TestDbContextFactory.Create();
            var (user, permission) = SeedUserAndPermission(db);
            var permSvc = NoOpPermissionService();

            var handler = new RevokeUserPermissionCommandHandler(db, NoOpErrorHandler(), permSvc.Object);
            var result = await handler.Handle(new RevokeUserPermissionCommand
            {
                UserId = user.Id,
                PermissionId = permission.Id,
            }, CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            db.Get<Domain.Entities.UserPermission>()
                .Any(up => up.UserId == user.Id && up.PermissionId == permission.Id && !up.IsGranted)
                .Should().BeTrue();
            permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(user.Id, It.IsAny<CancellationToken>()), Times.Once);
        }

        // ── Delete Override ───────────────────────────────────────────────────

        [Fact]
        public async Task DeleteOverride_RemovesRowAndInvalidatesCache()
        {
            using var db = TestDbContextFactory.Create();
            var (user, permission) = SeedUserAndPermission(db);
            db.Get<Domain.Entities.UserPermission>().Add(new Domain.Entities.UserPermission
            {
                UserId = user.Id,
                PermissionId = permission.Id,
                IsGranted = false,
            });
            db.SaveChanges();
            var permSvc = NoOpPermissionService();

            var handler = new DeleteUserPermissionOverrideCommandHandler(db, NoOpErrorHandler(), permSvc.Object);
            var result = await handler.Handle(new DeleteUserPermissionOverrideCommand
            {
                UserId = user.Id,
                PermissionId = permission.Id,
            }, CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            db.Get<Domain.Entities.UserPermission>()
                .Any(up => up.UserId == user.Id && up.PermissionId == permission.Id)
                .Should().BeFalse();
            permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(user.Id, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteOverride_NoOverrideExists_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var (user, permission) = SeedUserAndPermission(db);
            var permSvc = NoOpPermissionService();

            var handler = new DeleteUserPermissionOverrideCommandHandler(db, NoOpErrorHandler(), permSvc.Object);
            var result = await handler.Handle(new DeleteUserPermissionOverrideCommand
            {
                UserId = user.Id,
                PermissionId = permission.Id,
            }, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        // ── Get Direct Permissions ────────────────────────────────────────────

        [Fact]
        public async Task GetDirectPermissions_ReturnsUserOverrides()
        {
            using var db = TestDbContextFactory.Create();
            var (user, permission) = SeedUserAndPermission(db);
            db.Get<Domain.Entities.UserPermission>().Add(new Domain.Entities.UserPermission
            {
                UserId = user.Id,
                PermissionId = permission.Id,
                IsGranted = true,
            });
            db.SaveChanges();

            var handler = new GetUserDirectPermissionsQueryHandler(db, NoOpErrorHandler());
            var result = await handler.Handle(new GetUserDirectPermissionsQuery(user.Id), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.Should().HaveCount(1);
            result.Data[0].PermissionId.Should().Be(permission.Id);
            result.Data[0].IsGranted.Should().BeTrue();
        }

        [Fact]
        public async Task GetDirectPermissions_UserNotFound_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();

            var handler = new GetUserDirectPermissionsQueryHandler(db, NoOpErrorHandler());
            var result = await handler.Handle(new GetUserDirectPermissionsQuery(9999), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private static (AppUser user, Permission permission) SeedUserAndPermission(
            RajMango.DataAccess.Contexts.AppDbContext db)
        {
            var user = new AppUser
            {
                UserName = "testuser_perm",
                FirstName = "Test",
                LastName = "Perm",
                Email = "testperm@test.com",
                PhoneNumber = "01700000002",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            };
            db.Get<AppUser>().Add(user);
            db.SaveChanges();

            var permission = SeedPermission(db);
            return (user, permission);
        }

        private static Permission SeedPermission(RajMango.DataAccess.Contexts.AppDbContext db)
        {
            var permission = new Permission
            {
                Name = "test.permission",
                Module = "test",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            };
            db.Get<Permission>().Add(permission);
            db.SaveChanges();
            return permission;
        }
    }
}
