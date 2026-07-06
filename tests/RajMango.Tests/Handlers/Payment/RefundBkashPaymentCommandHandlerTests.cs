using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Shared.Enums;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Payment
{
    public class RefundBkashPaymentCommandHandlerTests
    {
        private readonly Mock<IBkashService> _bkash = new();
        private readonly Mock<ICurrentUserService> _currentUser = new();
        private readonly IPaymentLock _paymentLock = new PaymentLock();

        public RefundBkashPaymentCommandHandlerTests()
        {
            _currentUser.Setup(x => x.UserId).Returns(2);
            _currentUser.Setup(x => x.UserName).Returns("admin@rajmango.com");
        }

        private RefundBkashPaymentCommandHandler CreateHandler(RajMango.DataAccess.Contexts.AppDbContext db) =>
            new(_bkash.Object, db, _currentUser.Object, _paymentLock, NullLogger<RefundBkashPaymentCommandHandler>.Instance);

        private static (RajMango.Domain.Entities.Order order, RajMango.Domain.Entities.Payment payment) SeedPaidBkashPayment(
            RajMango.DataAccess.Contexts.AppDbContext db, decimal amount = 500)
        {
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-R1", TotalAmount = amount, PaidAmount = amount, DueAmount = 0, PaymentStatus = PaymentStatus.Paid, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Paid,
                GrossAmount = amount,
                NetAmount = amount,
                PaidAmount = amount,
                GatewayPaymentId = "TR-REF-1",
                TransactionId = "TRX-ORIG-1",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            return (order, payment);
        }

        [Fact]
        public async Task Handle_SuccessfulRefund_UpdatesPaymentOrderAndCreatesRefundRecord()
        {
            using var db = TestDbContextFactory.Create();
            var (order, payment) = SeedPaidBkashPayment(db);

            _bkash.Setup(x => x.RefundPaymentAsync("TR-REF-1", "TRX-ORIG-1", 500, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashRefundPaymentResponse("TR-REF-1", "TRX-ORIG-1", "REFTRX-1", "500", "Completed", "0000", "Successful"));

            var handler = CreateHandler(db);
            var result = await handler.Handle(new RefundBkashPaymentCommand(payment.Id, "Customer requested cancellation"), CancellationToken.None);

            result.Succeeded.Should().BeTrue();

            var updatedPayment = db.Get<RajMango.Domain.Entities.Payment>().Single(p => p.Id == payment.Id);
            updatedPayment.PaymentStatus.Should().Be(PaymentStatus.Refunded);

            var updatedOrder = db.Get<RajMango.Domain.Entities.Order>().Single(o => o.Id == order.Id);
            updatedOrder.PaymentStatus.Should().Be(PaymentStatus.Unpaid);
            updatedOrder.PaidAmount.Should().Be(0);
            updatedOrder.DueAmount.Should().Be(order.TotalAmount);
            updatedOrder.OrderStatus.Should().Be(OrderStatus.Pending); // Order/Delivery status untouched by refund

            var refundRecord = db.Get<Refund>().SingleOrDefault(r => r.PaymentId == payment.Id);
            refundRecord.Should().NotBeNull();
            refundRecord!.RefundAmount.Should().Be(500);
            refundRecord.RefundReason.Should().Be("Customer requested cancellation");
            refundRecord.RefundStatus.Should().Be(RefundStatus.Completed);
        }

        [Fact]
        public async Task Handle_PaymentAlreadyRefunded_ReturnsFailure_NoDoubleRefund()
        {
            using var db = TestDbContextFactory.Create();
            var (_, payment) = SeedPaidBkashPayment(db);

            _bkash.Setup(x => x.RefundPaymentAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashRefundPaymentResponse("TR-REF-1", "TRX-ORIG-1", "REFTRX-1", "500", "Completed", "0000", "Successful"));

            var handler = CreateHandler(db);
            var first = await handler.Handle(new RefundBkashPaymentCommand(payment.Id, "First attempt"), CancellationToken.None);
            first.Succeeded.Should().BeTrue();

            var second = await handler.Handle(new RefundBkashPaymentCommand(payment.Id, "Second attempt"), CancellationToken.None);

            second.Succeeded.Should().BeFalse();
            _bkash.Verify(x => x.RefundPaymentAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_NonBkashPayment_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-R2", TotalAmount = 300, PaidAmount = 300, DueAmount = 0, PaymentStatus = PaymentStatus.Paid, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Cash,
                PaymentStatus = PaymentStatus.Paid,
                GrossAmount = 300,
                NetAmount = 300,
                PaidAmount = 300,
                TransactionId = "MANUAL-1",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            var handler = CreateHandler(db);
            var result = await handler.Handle(new RefundBkashPaymentCommand(payment.Id, "reason"), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            _bkash.Verify(x => x.RefundPaymentAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_PaymentNotFound_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var handler = CreateHandler(db);

            var result = await handler.Handle(new RefundBkashPaymentCommand(999, "reason"), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
        }
    }
}
