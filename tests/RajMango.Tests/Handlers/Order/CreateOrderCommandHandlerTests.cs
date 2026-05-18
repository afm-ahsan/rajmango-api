using FluentAssertions;
using Moq;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Order
{
    public class CreateOrderCommandHandlerTests
    {
        private readonly Mock<IErrorHandler> _errorHandler = new();
        private readonly Mock<INotificationService> _notification = new();
        private readonly Mock<IRealtimeService> _realtime = new();
        private readonly IOrderCreationLock _orderCreationLock = new OrderCreationLock();
        private readonly Mock<IOrderNumberService> _orderNumberService = new();

        public CreateOrderCommandHandlerTests()
        {
            _notification.Setup(x => x.SendOrderConfirmedAsync(
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _realtime.Setup(x => x.SendToAdminsAsync(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _orderNumberService
                .Setup(x => x.GenerateAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync("202605180001");
        }

        [Fact]
        public async Task Handle_ForgedUserId_UsesAuthenticatedUser()
        {
            using var db = TestDbContextFactory.Create();
            var currentUser = new MockCurrentUserService { UserId = 42 };
            SeedAvailableMango(db);

            var handler = new CreateOrderCommandHandler(
                _errorHandler.Object,
                db,
                currentUser,
                _notification.Object,
                _realtime.Object,
                _orderCreationLock,
                _orderNumberService.Object);

            var command = BuildValidCommand(userId: 999);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            db.Get<RajMango.Domain.Entities.Order>().Single().UserId.Should().Be(42);
        }

        [Fact]
        public async Task Handle_UnavailableMango_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var currentUser = new MockCurrentUserService { UserId = 42 };

            db.Get<MangoType>().Add(new MangoType
            {
                Id = 1,
                Name = "Unavailable Mango",
                CreatedBy = 1,
            });
            db.SaveChanges();

            var handler = new CreateOrderCommandHandler(
                _errorHandler.Object,
                db,
                currentUser,
                _notification.Object,
                _realtime.Object,
                _orderCreationLock,
                _orderNumberService.Object);

            var result = await handler.Handle(BuildValidCommand(), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            result.Messages.Should().Contain(m => m.Contains("not currently available"));
            db.Get<RajMango.Domain.Entities.Order>().Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_UnauthenticatedUser_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var currentUser = new MockCurrentUserService
            {
                UserId = 0,
                IsAuthenticated = false,
            };
            SeedAvailableMango(db);

            var handler = new CreateOrderCommandHandler(
                _errorHandler.Object,
                db,
                currentUser,
                _notification.Object,
                _realtime.Object,
                _orderCreationLock,
                _orderNumberService.Object);

            var result = await handler.Handle(BuildValidCommand(), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            result.Messages.Should().Contain(m => m.Contains("authenticated user"));
            db.Get<RajMango.Domain.Entities.Order>().Should().BeEmpty();
        }

        private static CreateOrderCommand BuildValidCommand(int userId = 1)
        {
            return new CreateOrderCommand
            {
                UserId = userId,
                ReceiverName = "Receiver",
                ReceiverMobileNumber = "01700000000",
                FallbackAddress = "Rajshahi",
                OrderDetails = new[]
                {
                    new RajMango.Application.DTOs.Order.OrderDetailInputDto
                    {
                        MangoTypeId = 1,
                        CrateType = CrateType.Crate10Kg,
                        Quantity = 1,
                    }
                }
            };
        }

        private static void SeedAvailableMango(RajMango.DataAccess.Contexts.AppDbContext db)
        {
            var mangoType = new MangoType
            {
                Id = 1,
                Name = "Himsagor",
                CreatedBy = 1,
            };

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
    }
}
