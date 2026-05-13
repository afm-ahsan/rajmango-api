using AutoMapper;
using FluentAssertions;
using Moq;
using RajMango.Application.Features.Commands;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Role
{
    public class RoleCacheInvalidationTests
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

        [Fact]
        public async Task UpdateRoleHandler_InvalidatesCacheForAllUsersInRole()
        {
            using var db = TestDbContextFactory.Create();
            var (roleId, userIds) = SeedRoleWithUsers(db, userCount: 2);
            var permSvc = NoOpPermissionService();

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<Domain.Entities.Role>(It.IsAny<UpdateRoleCommand>()))
                .Returns((UpdateRoleCommand cmd) => new Domain.Entities.Role { Id = cmd.Id, Name = cmd.Name ?? "Updated", Code = "test" });

            var handler = new UpdateRoleCommandHandler(NoOpErrorHandler(), db, mapper.Object, permSvc.Object);
            var command = new UpdateRoleCommand { Id = roleId, Name = "Updated Role", IsActive = true };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            foreach (var userId in userIds)
            {
                permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(userId, It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        [Fact]
        public async Task UpdateRoleHandler_RoleNotFound_DoesNotCallCacheInvalidation()
        {
            using var db = TestDbContextFactory.Create();
            var permSvc = NoOpPermissionService();

            var mapper = new Mock<IMapper>();
            var handler = new UpdateRoleCommandHandler(NoOpErrorHandler(), db, mapper.Object, permSvc.Object);
            var command = new UpdateRoleCommand { Id = 9999, Name = "Ghost" };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeleteRoleHandler_InvalidatesCacheForAllUsersInRole()
        {
            using var db = TestDbContextFactory.Create();
            var (roleId, userIds) = SeedRoleWithUsers(db, userCount: 3);
            var permSvc = NoOpPermissionService();

            var handler = new DeleteRoleCommandHandler(NoOpErrorHandler(), db, permSvc.Object);

            var result = await handler.Handle(new DeleteRoleCommand { Id = roleId }, CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            foreach (var userId in userIds)
            {
                permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(userId, It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        [Fact]
        public async Task DeleteRoleHandler_RoleNotFound_DoesNotCallCacheInvalidation()
        {
            using var db = TestDbContextFactory.Create();
            var permSvc = NoOpPermissionService();
            var handler = new DeleteRoleCommandHandler(NoOpErrorHandler(), db, permSvc.Object);

            var result = await handler.Handle(new DeleteRoleCommand { Id = 9999 }, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            permSvc.Verify(x => x.InvalidateUserPermissionCacheAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        private static (int roleId, List<int> userIds) SeedRoleWithUsers(
            RajMango.DataAccess.Contexts.AppDbContext db, int userCount)
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

            var userIds = new List<int>();
            for (int i = 0; i < userCount; i++)
            {
                var user = new AppUser
                {
                    UserName = $"user{i}_{role.Id}",
                    FirstName = "Test",
                    LastName = "User",
                    Email = $"user{i}_{role.Id}@test.com",
                    PhoneNumber = $"0170000{i:D4}",
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

                userIds.Add(user.Id);
            }

            return (role.Id, userIds);
        }
    }
}
