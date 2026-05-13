using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Infrastructure.Services;
using RajMango.Shared;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Authorization
{
    public class PermissionServiceTests
    {
        private static ICacheService NoOpCache()
        {
            var mock = new Mock<ICacheService>();
            mock.Setup(x => x.GetAsync<List<string>>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((List<string>)null);
            mock.Setup(x => x.SetAsync(It.IsAny<string>(), It.IsAny<List<string>>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mock.Setup(x => x.RemoveAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            return mock.Object;
        }

        [Fact]
        public async Task GetUserPermissionsAsync_ReturnsRolePermissions()
        {
            using var db = TestDbContextFactory.Create();
            SeedPermissionData(db, userId: 10, roleId: 20, permissionName: Permissions.Orders.View);

            var service = new PermissionService(db, NoOpCache(), NullLogger<PermissionService>.Instance);

            var result = await service.GetUserPermissionsAsync(10);

            result.Should().Contain(Permissions.Orders.View);
        }

        [Fact]
        public async Task HasPermissionAsync_GrantedPermission_ReturnsTrue()
        {
            using var db = TestDbContextFactory.Create();
            SeedPermissionData(db, userId: 10, roleId: 20, permissionName: Permissions.Orders.Create);

            var service = new PermissionService(db, NoOpCache(), NullLogger<PermissionService>.Instance);

            var result = await service.HasPermissionAsync(10, Permissions.Orders.Create);

            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasPermissionAsync_MissingPermission_ReturnsFalse()
        {
            using var db = TestDbContextFactory.Create();
            SeedPermissionData(db, userId: 10, roleId: 20, permissionName: Permissions.Orders.View);

            var service = new PermissionService(db, NoOpCache(), NullLogger<PermissionService>.Instance);

            var result = await service.HasPermissionAsync(10, Permissions.Orders.Delete);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task HasPermissionAsync_UserWithNoRoles_ReturnsFalse()
        {
            using var db = TestDbContextFactory.Create();

            var service = new PermissionService(db, NoOpCache(), NullLogger<PermissionService>.Instance);

            var result = await service.HasPermissionAsync(99, Permissions.Orders.View);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task HasPermissionAsync_UserPermissionOverride_RevokesRolePermission()
        {
            using var db = TestDbContextFactory.Create();
            SeedPermissionData(db, userId: 10, roleId: 20, permissionName: Permissions.Orders.View);

            // Override: revoke order.view for user 10
            var permission = db.Get<Permission>().First(p => p.Name == Permissions.Orders.View);
            db.Get<UserPermission>().Add(new UserPermission
            {
                UserId = 10,
                PermissionId = permission.Id,
                IsGranted = false
            });
            db.SaveChanges();

            var service = new PermissionService(db, NoOpCache(), NullLogger<PermissionService>.Instance);

            var result = await service.HasPermissionAsync(10, Permissions.Orders.View);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task InvalidateUserPermissionCacheAsync_CallsRemoveOnCache()
        {
            using var db = TestDbContextFactory.Create();
            var cacheMock = new Mock<ICacheService>();
            cacheMock.Setup(x => x.RemoveAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var service = new PermissionService(db, cacheMock.Object, NullLogger<PermissionService>.Instance);

            await service.InvalidateUserPermissionCacheAsync(5);

            cacheMock.Verify(x => x.RemoveAsync(It.Is<string>(k => k.Contains("5")), It.IsAny<CancellationToken>()), Times.Once);
        }

        private static void SeedPermissionData(
            RajMango.DataAccess.Contexts.AppDbContext db,
            int userId, int roleId, string permissionName)
        {
            var permission = new Permission
            {
                Id = 100,
                Name = permissionName,
                Module = permissionName.Split('.')[0],
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            db.Get<Permission>().Add(permission);

            var role = new Role
            {
                Id = roleId,
                Name = "TestRole",
                Code = "test_role",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            db.Get<Role>().Add(role);

            db.Get<RolePermission>().Add(new RolePermission
            {
                RoleId = roleId,
                PermissionId = permission.Id
            });

            var user = new AppUser
            {
                Id = userId,
                UserName = $"user{userId}",
                FirstName = "Test",
                LastName = "User",
                Email = $"user{userId}@test.com",
                PhoneNumber = "01700000000",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            db.Get<AppUser>().Add(user);

            db.Get<UserRole>().Add(new UserRole
            {
                UserId = userId,
                RoleId = roleId,
                AssignedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            });

            db.SaveChanges();
        }
    }
}
