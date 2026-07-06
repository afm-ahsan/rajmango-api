using FluentAssertions;
using RajMango.Application.Features.Queries;
using RajMango.Shared.Enums;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Payment
{
    public class GetBkashPaymentResultQueryHandlerTests
    {
        private static GetBkashPaymentResultQueryHandler CreateHandler(RajMango.DataAccess.Contexts.AppDbContext db) =>
            new(db);

        [Fact]
        public async Task Handle_PaidPayment_ReturnsCustomerFacingFieldsOnly()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-BKR-1", TotalAmount = 500, PaidAmount = 500, DueAmount = 0, PaymentStatus = PaymentStatus.Paid, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var paidAt = DateTime.UtcNow;
            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Paid,
                GrossAmount = 500,
                NetAmount = 500,
                PaidAmount = 500,
                GatewayPaymentId = "TR-RESULT-1",
                TransactionId = "TRX-RESULT-1",
                PaidAt = paidAt,
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            var handler = CreateHandler(db);
            var result = await handler.Handle(new GetBkashPaymentResultQuery("TR-RESULT-1"), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.OrderNumber.Should().Be("ORD-BKR-1");
            result.Data.Amount.Should().Be(500);
            result.Data.TransactionId.Should().Be("TRX-RESULT-1");
            result.Data.PaymentStatus.Should().Be(PaymentStatus.Paid);
            result.Data.PaymentDate.Should().BeCloseTo(paidAt, TimeSpan.FromSeconds(1));
            result.Data.FailureReason.Should().BeNull();
        }

        [Fact]
        public async Task Handle_FailedPayment_ReturnsFailureReason()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-BKR-2", TotalAmount = 300, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Failed,
                GrossAmount = 300,
                NetAmount = 300,
                PaidAmount = 0,
                GatewayPaymentId = "TR-RESULT-2",
                FailureReason = "Insufficient balance in customer wallet.",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            var handler = CreateHandler(db);
            var result = await handler.Handle(new GetBkashPaymentResultQuery("TR-RESULT-2"), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.Amount.Should().Be(300); // GrossAmount, since nothing was actually paid
            result.Data.FailureReason.Should().Be("Insufficient balance in customer wallet.");
        }

        [Fact]
        public async Task Handle_UnknownPaymentId_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var handler = CreateHandler(db);

            var result = await handler.Handle(new GetBkashPaymentResultQuery("TR-DOES-NOT-EXIST"), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
        }

        [Fact]
        public async Task Handle_EmptyPaymentId_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var handler = CreateHandler(db);

            var result = await handler.Handle(new GetBkashPaymentResultQuery(""), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
        }
    }
}
