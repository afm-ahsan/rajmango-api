using FluentAssertions;
using Moq;
using RajMango.Application.Features.Queries;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Shared.Enums;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Payment
{
    public class GetBkashRefundStatusQueryHandlerTests
    {
        private readonly Mock<IBkashService> _bkash = new();

        private GetBkashRefundStatusQueryHandler CreateHandler(RajMango.DataAccess.Contexts.AppDbContext db) =>
            new(db, _bkash.Object);

        [Fact]
        public async Task Handle_PaymentWithNoRefunds_ReturnsZeroRefundedAndSkipsGatewayCall()
        {
            using var db = TestDbContextFactory.Create();
            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = 1,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Paid,
                GrossAmount = 500,
                NetAmount = 500,
                PaidAmount = 500,
                GatewayPaymentId = "TR-STATUS-1",
                TransactionId = "TRX-STATUS-1",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            var handler = CreateHandler(db);
            var result = await handler.Handle(new GetBkashRefundStatusQuery(payment.Id), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.RefundedAmount.Should().Be(0);
            result.Data.RemainingRefundableAmount.Should().Be(500);
            result.Data.RefundHistory.Should().BeEmpty();
            _bkash.Verify(x => x.GetRefundStatusAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_PaymentWithPriorRefunds_ReturnsHistoryAndQueriesGateway()
        {
            using var db = TestDbContextFactory.Create();
            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = 1,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.PartiallyRefunded,
                GrossAmount = 1000,
                NetAmount = 1000,
                PaidAmount = 1000,
                RefundedAmount = 300,
                GatewayPaymentId = "TR-STATUS-2",
                TransactionId = "TRX-STATUS-2",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            db.Get<Refund>().Add(new Refund
            {
                PaymentId = payment.Id,
                RefundAmount = 300,
                RefundDate = DateTime.UtcNow,
                RefundReason = "test",
                RefundedBy = "admin",
                RefundStatus = RefundStatus.Completed,
                GatewayTransactionId = "REFTRX-1",
            });
            db.SaveChanges();

            _bkash.Setup(x => x.GetRefundStatusAsync("TR-STATUS-2", "TRX-STATUS-2", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashRefundStatusResponse("TR-STATUS-2", "TRX-STATUS-2", "REFTRX-1", "300", "", "Completed", "0000", "Successful"));

            var handler = CreateHandler(db);
            var result = await handler.Handle(new GetBkashRefundStatusQuery(payment.Id), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.RefundedAmount.Should().Be(300);
            result.Data.RemainingRefundableAmount.Should().Be(700);
            result.Data.RefundHistory.Should().ContainSingle();
            result.Data.BkashTransactionStatus.Should().Be("Completed");
        }

        [Fact]
        public async Task Handle_PaymentNotFound_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var handler = CreateHandler(db);

            var result = await handler.Handle(new GetBkashRefundStatusQuery(999), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
        }
    }
}
