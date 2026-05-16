using FluentAssertions;
using Moq;
using RajMango.Application.Features.Commands;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Shared.Enums;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Payment
{
    public class CreatePaymentCommandHandlerTests
    {
        private readonly Mock<INotificationService> _notification;
        private readonly Mock<IRealtimeService> _realtime;

        public CreatePaymentCommandHandlerTests()
        {
            _notification = new Mock<INotificationService>();
            _notification.Setup(x => x.SendPaymentReceivedAsync(It.IsAny<int>(), It.IsAny<string>(),
                It.IsAny<decimal>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            _realtime = new Mock<IRealtimeService>();
            _realtime.Setup(x => x.SendToUserAsync(It.IsAny<int>(), It.IsAny<string>(),
                It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            _realtime.Setup(x => x.SendToAdminsAsync(It.IsAny<string>(),
                It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        }

        [Fact]
        public async Task Handle_OrderNotFound_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var handler = new CreatePaymentCommandHandler(db, _notification.Object, _realtime.Object);
            var command = new CreatePaymentCommand { OrderId = 999, PaidAmount = 100, PaymentMethod = PaymentMethod.Cash };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            result.Messages.Should().Contain(m => m.Contains("not found"));
        }

        [Fact]
        public async Task Handle_OrderAlreadyPaid_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var order = SeedOrder(db, totalAmount: 500, dueAmount: 0);
            var handler = new CreatePaymentCommandHandler(db, _notification.Object, _realtime.Object);
            var command = new CreatePaymentCommand { OrderId = order.Id, PaidAmount = 100, PaymentMethod = PaymentMethod.Cash };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            result.Messages.Should().Contain(m => m.Contains("fully paid"));
        }

        [Fact]
        public async Task Handle_AmountExceedsDue_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var order = SeedOrder(db, totalAmount: 500, dueAmount: 200);
            var handler = new CreatePaymentCommandHandler(db, _notification.Object, _realtime.Object);
            var command = new CreatePaymentCommand { OrderId = order.Id, PaidAmount = 300, PaymentMethod = PaymentMethod.Cash };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            result.Messages.Should().Contain(m => m.Contains("exceeds"));
        }

        [Fact]
        public async Task Handle_ValidPayment_CreatesPaymentAndReturnsSuccess()
        {
            using var db = TestDbContextFactory.Create();
            var order = SeedOrder(db, totalAmount: 500, dueAmount: 500);
            var handler = new CreatePaymentCommandHandler(db, _notification.Object, _realtime.Object);
            var command = new CreatePaymentCommand { OrderId = order.Id, PaidAmount = 200, PaymentMethod = PaymentMethod.Cash, TransactionId = "TXN001" };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            db.Get<RajMango.Domain.Entities.Payment>().Count().Should().Be(1);
            _notification.Verify(x => x.SendPaymentReceivedAsync(It.IsAny<int>(), It.IsAny<string>(), 200m, It.IsAny<CancellationToken>()), Times.Once);
        }

        private static RajMango.Domain.Entities.Order SeedOrder(RajMango.DataAccess.Contexts.AppDbContext db, decimal totalAmount, decimal dueAmount)
        {
            var order = new RajMango.Domain.Entities.Order
            {
                UserId = 1,
                OrderNumber = "TEST001",
                TotalAmount = totalAmount,
                DueAmount = dueAmount,
                PaidAmount = totalAmount - dueAmount,
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();
            return order;
        }
    }
}
