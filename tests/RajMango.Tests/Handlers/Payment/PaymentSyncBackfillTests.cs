using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared.Enums;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Payment
{
    public class PaymentSyncBackfillTests
    {
        private static RajMango.Domain.Entities.Order SeedDriftedOrder(RajMango.DataAccess.Contexts.AppDbContext db)
        {
            // Simulates an order affected by the pre-fix bug: a Paid bKash payment exists,
            // but the order's stored summary was never updated (still shows Unpaid).
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-DRIFT-1", TotalAmount = 500, PaidAmount = 0, DueAmount = 500, PaymentStatus = PaymentStatus.Unpaid, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            db.Get<RajMango.Domain.Entities.Payment>().Add(new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Paid,
                GrossAmount = 500,
                NetAmount = 500,
                PaidAmount = 500,
                TransactionId = "TRX-DRIFT-1",
                CreatedBy = 1,
            });
            db.SaveChanges();

            return order;
        }

        [Fact]
        public async Task DryRun_FindsOrderWithStalePaymentSummary()
        {
            using var db = TestDbContextFactory.Create();
            var drifted = SeedDriftedOrder(db);

            var handler = new GetOrderPaymentSyncDriftQueryHandler(db);
            var result = await handler.Handle(new GetOrderPaymentSyncDriftQuery(), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.Should().ContainSingle(d => d.OrderId == drifted.Id);
            var entry = result.Data.Single(d => d.OrderId == drifted.Id);
            entry.CurrentPaymentStatus.Should().Be(PaymentStatus.Unpaid);
            entry.ExpectedPaymentStatus.Should().Be(PaymentStatus.Paid);
            entry.ExpectedPaidAmount.Should().Be(500);
        }

        [Fact]
        public async Task DryRun_DoesNotMutateAnyData()
        {
            using var db = TestDbContextFactory.Create();
            var drifted = SeedDriftedOrder(db);

            var handler = new GetOrderPaymentSyncDriftQueryHandler(db);
            await handler.Handle(new GetOrderPaymentSyncDriftQuery(), CancellationToken.None);

            var stillStale = db.Get<RajMango.Domain.Entities.Order>().Single(o => o.Id == drifted.Id);
            stillStale.PaymentStatus.Should().Be(PaymentStatus.Unpaid);
            stillStale.PaidAmount.Should().Be(0);
        }

        [Fact]
        public async Task Backfill_AppliesFixToDriftedOrder_AndIsIdempotentOnSecondRun()
        {
            using var db = TestDbContextFactory.Create();
            var drifted = SeedDriftedOrder(db);

            var handler = new BackfillOrderPaymentSyncCommandHandler(db, NullLogger<BackfillOrderPaymentSyncCommandHandler>.Instance);

            var first = await handler.Handle(new BackfillOrderPaymentSyncCommand(new List<int> { drifted.Id }), CancellationToken.None);
            first.Data.Should().ContainSingle(id => id == drifted.Id);

            var fixedOrder = db.Get<RajMango.Domain.Entities.Order>().Single(o => o.Id == drifted.Id);
            fixedOrder.PaymentStatus.Should().Be(PaymentStatus.Paid);
            fixedOrder.PaidAmount.Should().Be(500);
            fixedOrder.DueAmount.Should().Be(0);

            // Second run over the now-corrected order should find nothing left to fix.
            var second = await handler.Handle(new BackfillOrderPaymentSyncCommand(new List<int> { drifted.Id }), CancellationToken.None);
            second.Data.Should().BeEmpty();
        }

        [Fact]
        public async Task Backfill_LeavesUnaffectedOrdersUntouched()
        {
            using var db = TestDbContextFactory.Create();
            var healthyOrder = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-OK-1", TotalAmount = 300, PaidAmount = 300, DueAmount = 0, PaymentStatus = PaymentStatus.Paid, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(healthyOrder);
            db.SaveChanges();
            db.Get<RajMango.Domain.Entities.Payment>().Add(new RajMango.Domain.Entities.Payment
            {
                OrderId = healthyOrder.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Paid,
                GrossAmount = 300,
                NetAmount = 300,
                PaidAmount = 300,
                TransactionId = "TRX-OK-1",
                CreatedBy = 1,
            });
            db.SaveChanges();

            var handler = new BackfillOrderPaymentSyncCommandHandler(db, NullLogger<BackfillOrderPaymentSyncCommandHandler>.Instance);
            var result = await handler.Handle(new BackfillOrderPaymentSyncCommand(new List<int>()), CancellationToken.None);

            result.Data.Should().BeEmpty();
        }
    }
}
