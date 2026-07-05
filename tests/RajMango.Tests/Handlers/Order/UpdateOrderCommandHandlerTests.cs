using FluentAssertions;
using Moq;
using RajMango.Application.Features.Commands;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Order
{
    public class UpdateOrderCommandHandlerTests
    {
        private readonly Mock<IErrorHandler> _errorHandler = new();

        private static UpdateOrderCommandHandler BuildHandler(
            RajMango.DataAccess.Contexts.AppDbContext db,
            MockCurrentUserService user)
            => new(new Mock<IErrorHandler>().Object, db, user);

        private static UpdateOrderCommand ValidCommand(int orderId, int mangoTypeId = 1)
            => new()
            {
                Id = orderId,
                OrderDetails = new[]
                {
                    new RajMango.Application.DTOs.Order.OrderDetailInputDto
                    {
                        MangoTypeId = mangoTypeId,
                        CrateType = CrateType.Crate10Kg,
                        Quantity = 1,
                    }
                }
            };

        private static void SeedAvailableMango(RajMango.DataAccess.Contexts.AppDbContext db, int mangoTypeId = 1)
        {
            var mangoType = new MangoType { Id = mangoTypeId, Name = "Himsagor", CreatedBy = 1 };
            db.Get<MangoType>().Add(mangoType);
            db.Get<MangoAvailability>().Add(new MangoAvailability
            {
                MangoTypeId = mangoType.Id,
                MangoType = mangoType,
                SeasonYear = Clock.Now().Year,
                StartDate = Clock.Now().Date.AddDays(-1),
                EndDate = Clock.Now().Date.AddDays(1),
                PricePerKg = 120,
                Status = MangoAvailabilityStatus.Available,
                CreatedBy = 1,
            });
            db.SaveChanges();
        }

        private static RajMango.Domain.Entities.Order SeedOrder(
            RajMango.DataAccess.Contexts.AppDbContext db,
            int userId,
            OrderStatus status = OrderStatus.Pending)
        {
            var order = new RajMango.Domain.Entities.Order
            {
                UserId = userId,
                OrderNumber = "ORD-001",
                OrderStatus = status,
                TotalAmount = 0,
                PaidAmount = 0,
                DueAmount = 0,
                CreatedBy = userId,
            };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();
            return order;
        }

        [Fact]
        public async Task Handle_CustomerOwner_PendingOrder_Succeeds()
        {
            using var db = TestDbContextFactory.Create();
            SeedAvailableMango(db);
            var order = SeedOrder(db, userId: 10, OrderStatus.Pending);
            var user = new MockCurrentUserService { UserId = 10, IsAdmin = false };
            var handler = BuildHandler(db, user);

            var result = await handler.Handle(ValidCommand(order.Id), CancellationToken.None);

            result.Succeeded.Should().BeTrue(because: result.Messages?.FirstOrDefault());
        }

        [Fact]
        public async Task Handle_CustomerOwner_ConfirmedOrder_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            SeedAvailableMango(db);
            var order = SeedOrder(db, userId: 10, OrderStatus.Confirmed);
            var user = new MockCurrentUserService { UserId = 10, IsAdmin = false };
            var handler = BuildHandler(db, user);

            var result = await handler.Handle(ValidCommand(order.Id), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            result.Messages.Should().Contain(m => m.Contains("no longer be edited"));
        }

        [Fact]
        public async Task Handle_CustomerNonOwner_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            SeedAvailableMango(db);
            var order = SeedOrder(db, userId: 10, OrderStatus.Pending);
            var user = new MockCurrentUserService { UserId = 99, IsAdmin = false };
            var handler = BuildHandler(db, user);

            var result = await handler.Handle(ValidCommand(order.Id), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            result.Messages.Should().Contain(m => m.Contains("not authorized"));
        }

        [Fact]
        public async Task Handle_Admin_ConfirmedOrder_Succeeds()
        {
            using var db = TestDbContextFactory.Create();
            SeedAvailableMango(db);
            var order = SeedOrder(db, userId: 10, OrderStatus.Confirmed);
            var user = new MockCurrentUserService { UserId = 1, IsAdmin = true };
            var handler = BuildHandler(db, user);

            var result = await handler.Handle(ValidCommand(order.Id), CancellationToken.None);

            result.Succeeded.Should().BeTrue(because: result.Messages?.FirstOrDefault());
        }

        [Fact]
        public async Task Handle_Admin_ShippedOrder_Succeeds()
        {
            // Admins may edit any order regardless of status, including terminal statuses
            // such as Shipped — this allows correcting pricing or delivery details post-dispatch.
            using var db = TestDbContextFactory.Create();
            SeedAvailableMango(db);
            var order = SeedOrder(db, userId: 10, OrderStatus.Shipped);
            var user = new MockCurrentUserService { UserId = 1, IsAdmin = true };
            var handler = BuildHandler(db, user);

            var result = await handler.Handle(ValidCommand(order.Id), CancellationToken.None);

            result.Succeeded.Should().BeTrue(because: result.Messages?.FirstOrDefault());
        }
    }
}
