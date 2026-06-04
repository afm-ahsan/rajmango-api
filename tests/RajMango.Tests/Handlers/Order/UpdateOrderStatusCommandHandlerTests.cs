using FluentAssertions;
using Moq;
using RajMango.Application.DTOs.Sms;
using RajMango.Application.Features.Commands;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Shared.Enums;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Order
{
    public class UpdateOrderStatusCommandHandlerTests
    {
        private readonly Mock<IErrorHandler> _errorHandler = new();
        private readonly Mock<INotificationService> _notification = new();
        private readonly Mock<IRealtimeService> _realtime = new();
        private readonly Mock<IOrderTrackingHistoryService> _tracking = new();
        private readonly Mock<ISmsService> _sms = new();

        public UpdateOrderStatusCommandHandlerTests()
        {
            _notification.Setup(x => x.SendOrderStatusChangedAsync(
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _realtime.Setup(x => x.SendToUserAsync(
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _realtime.Setup(x => x.SendToAdminsAsync(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _tracking
                .Setup(x => x.InsertIfNewAsync(
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _sms.Setup(x => x.SendOrderUpdateAsync(
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsOrderContext>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
        }

        [Fact]
        public async Task Handle_InvalidTransition_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order
            {
                UserId = 1,
                OrderNumber = "TEST-001",
                OrderStatus = OrderStatus.Pending,
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var handler = new UpdateOrderStatusCommandHandler(
                _errorHandler.Object,
                db,
                _notification.Object,
                _realtime.Object,
                _tracking.Object,
                _sms.Object);

            var result = await handler.Handle(new UpdateOrderStatusCommand
            {
                Id = order.Id,
                NewStatus = OrderStatus.Delivered,
            }, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            result.Messages.Should().Contain(m => m.Contains("Cannot transition order"));
        }
    }
}
