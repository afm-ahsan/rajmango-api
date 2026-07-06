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
    public class PartialRefundBkashPaymentCommandHandlerTests
    {
        private readonly Mock<IBkashService> _bkash = new();
        private readonly Mock<ICurrentUserService> _currentUser = new();
        private readonly IPaymentLock _paymentLock = new PaymentLock();

        public PartialRefundBkashPaymentCommandHandlerTests()
        {
            _currentUser.Setup(x => x.UserId).Returns(2);
            _currentUser.Setup(x => x.UserName).Returns("admin@rajmango.com");
        }

        private PartialRefundBkashPaymentCommandHandler CreateHandler(RajMango.DataAccess.Contexts.AppDbContext db) =>
            new(_bkash.Object, db, _currentUser.Object, _paymentLock, NullLogger<PartialRefundBkashPaymentCommandHandler>.Instance);

        private static (RajMango.Domain.Entities.Order order, RajMango.Domain.Entities.Payment payment) SeedPaidBkashPayment(
            RajMango.DataAccess.Contexts.AppDbContext db, decimal amount = 1000)
        {
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-PR-1", TotalAmount = amount, PaidAmount = amount, DueAmount = 0, PaymentStatus = PaymentStatus.Paid, CreatedBy = 1 };
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
                GatewayPaymentId = "TR-PARTIAL-1",
                TransactionId = "TRX-PARTIAL-1",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            return (order, payment);
        }

        [Fact]
        public async Task Handle_FirstPartialRefund_SetsStatusPartiallyRefunded_AndNetsOrderAmount()
        {
            using var db = TestDbContextFactory.Create();
            var (order, payment) = SeedPaidBkashPayment(db, amount: 1000);

            _bkash.Setup(x => x.PartialRefundAsync("TR-PARTIAL-1", "TRX-PARTIAL-1", 300, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashPartialRefundResponse("TRX-PARTIAL-1", "REFTRX-1", "300", "", "Completed", "0000", "Successful"));

            var handler = CreateHandler(db);
            var result = await handler.Handle(new PartialRefundBkashPaymentCommand(payment.Id, 300, "Item out of stock"), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.RemainingRefundableAmount.Should().Be(700);

            var updatedPayment = db.Get<RajMango.Domain.Entities.Payment>().Single(p => p.Id == payment.Id);
            updatedPayment.PaymentStatus.Should().Be(PaymentStatus.PartiallyRefunded);
            updatedPayment.RefundedAmount.Should().Be(300);

            var updatedOrder = db.Get<RajMango.Domain.Entities.Order>().Single(o => o.Id == order.Id);
            updatedOrder.PaidAmount.Should().Be(700);
            updatedOrder.DueAmount.Should().Be(300);
            updatedOrder.PaymentStatus.Should().Be(PaymentStatus.Partial);

            var refundRecord = db.Get<Refund>().Single(r => r.PaymentId == payment.Id);
            refundRecord.RefundAmount.Should().Be(300);
        }

        [Fact]
        public async Task Handle_SecondPartialRefund_ReachingFullAmount_SetsStatusRefunded()
        {
            using var db = TestDbContextFactory.Create();
            var (_, payment) = SeedPaidBkashPayment(db, amount: 1000);

            _bkash.Setup(x => x.PartialRefundAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((string p, string t, decimal amt, string sku, string reason, CancellationToken ct) =>
                    new BkashPartialRefundResponse(t, "REFTRX-X", amt.ToString("F2"), "", "Completed", "0000", "Successful"));

            var handler = CreateHandler(db);

            var first = await handler.Handle(new PartialRefundBkashPaymentCommand(payment.Id, 600, "reason 1"), CancellationToken.None);
            first.Succeeded.Should().BeTrue();

            var second = await handler.Handle(new PartialRefundBkashPaymentCommand(payment.Id, 400, "reason 2"), CancellationToken.None);
            second.Succeeded.Should().BeTrue();
            second.Data.RemainingRefundableAmount.Should().Be(0);

            var updatedPayment = db.Get<RajMango.Domain.Entities.Payment>().Single(p => p.Id == payment.Id);
            updatedPayment.PaymentStatus.Should().Be(PaymentStatus.Refunded);
            updatedPayment.RefundedAmount.Should().Be(1000);

            db.Get<Refund>().Count(r => r.PaymentId == payment.Id).Should().Be(2);
        }

        [Fact]
        public async Task Handle_RefundAmountExceedsRemaining_ReturnsFailure_NoBkashCallMade()
        {
            using var db = TestDbContextFactory.Create();
            var (_, payment) = SeedPaidBkashPayment(db, amount: 500);

            var handler = CreateHandler(db);
            var result = await handler.Handle(new PartialRefundBkashPaymentCommand(payment.Id, 600, "too much"), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            _bkash.Verify(x => x.PartialRefundAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_ZeroOrNegativeAmount_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var (_, payment) = SeedPaidBkashPayment(db, amount: 500);

            var handler = CreateHandler(db);
            var result = await handler.Handle(new PartialRefundBkashPaymentCommand(payment.Id, 0, "reason"), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
        }
    }
}
