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
    public class ReconcileBkashPaymentCommandHandlerTests
    {
        private readonly Mock<IBkashService> _bkash = new();
        private readonly Mock<IRealtimeService> _realtime = new();
        private readonly Mock<INotificationService> _notification = new();
        private readonly Mock<ISmsService> _sms = new();
        private readonly IPaymentLock _paymentLock = new PaymentLock();

        public ReconcileBkashPaymentCommandHandlerTests()
        {
            _realtime.Setup(x => x.SendToUserAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            _realtime.Setup(x => x.SendToAdminsAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            _notification.Setup(x => x.SendPaymentReceivedAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            _sms.Setup(x => x.SendPaymentConfirmedSmsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
        }

        private ReconcileBkashPaymentCommandHandler CreateHandler(RajMango.DataAccess.Contexts.AppDbContext db)
        {
            var finalizer = new BkashPaymentFinalizer(
                db, _realtime.Object, _notification.Object, _sms.Object,
                NullLogger<BkashPaymentFinalizer>.Instance);
            return new ReconcileBkashPaymentCommandHandler(
                db, _bkash.Object, finalizer, _paymentLock,
                NullLogger<ReconcileBkashPaymentCommandHandler>.Instance);
        }

        [Fact]
        public async Task Handle_BkashReportsCompleted_FinalizesPendingPaymentAsPaid()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-REC-1", TotalAmount = 400, DueAmount = 400, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Pending,
                GrossAmount = 400,
                NetAmount = 400,
                PaidAmount = 0,
                GatewayPaymentId = "TR-LOST-CB",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            _bkash.Setup(x => x.QueryPaymentAsync("TR-LOST-CB", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashQueryPaymentResponse("TR-LOST-CB", "TRX-LOST-1", "400", "Completed", "0000", "Successful"));

            var handler = CreateHandler(db);
            var result = await handler.Handle(new ReconcileBkashPaymentCommand("TR-LOST-CB", null), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.WasFinalized.Should().BeTrue();

            var updatedOrder = db.Get<RajMango.Domain.Entities.Order>().Single(o => o.Id == order.Id);
            updatedOrder.PaymentStatus.Should().Be(PaymentStatus.Paid);
            updatedOrder.PaidAmount.Should().Be(400);

            var updatedPayment = db.Get<RajMango.Domain.Entities.Payment>().Single(p => p.Id == payment.Id);
            updatedPayment.PaymentStatus.Should().Be(PaymentStatus.Paid);
            updatedPayment.TransactionId.Should().Be("TRX-LOST-1");
        }

        [Fact]
        public async Task Handle_BkashReportsNotCompleted_LeavesPaymentPending()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-REC-2", TotalAmount = 200, DueAmount = 200, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Pending,
                GrossAmount = 200,
                NetAmount = 200,
                PaidAmount = 0,
                GatewayPaymentId = "TR-INPROG",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            _bkash.Setup(x => x.QueryPaymentAsync("TR-INPROG", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashQueryPaymentResponse("TR-INPROG", "", "200", "Initiated", "0000", "In progress"));

            var handler = CreateHandler(db);
            var result = await handler.Handle(new ReconcileBkashPaymentCommand("TR-INPROG", null), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.WasFinalized.Should().BeFalse();

            var stillPending = db.Get<RajMango.Domain.Entities.Payment>().Single(p => p.Id == payment.Id);
            stillPending.PaymentStatus.Should().Be(PaymentStatus.Pending);
        }

        [Fact]
        public async Task Handle_PaymentAlreadyResolved_IsIdempotentNoOp()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-REC-3", TotalAmount = 100, PaidAmount = 100, DueAmount = 0, PaymentStatus = PaymentStatus.Paid, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Paid,
                GrossAmount = 100,
                NetAmount = 100,
                PaidAmount = 100,
                GatewayPaymentId = "TR-ALREADY",
                TransactionId = "TRX-ALREADY",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            var handler = CreateHandler(db);
            var result = await handler.Handle(new ReconcileBkashPaymentCommand("TR-ALREADY", null), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.WasFinalized.Should().BeFalse();
            _bkash.Verify(x => x.QueryPaymentAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_ViaTrxId_UsesSearchToDiscoverPaymentId_ThenQueryToFinalize()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-REC-4", TotalAmount = 300, DueAmount = 300, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Pending,
                GrossAmount = 300,
                NetAmount = 300,
                PaidAmount = 0,
                GatewayPaymentId = "TR-VIA-TRX",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            // Search only discovers the paymentID — its own transactionStatus is deliberately
            // ignored by the handler, which always re-confirms via a direct Query Payment call.
            _bkash.Setup(x => x.SearchTransactionAsync("TRX-VIA-1", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashSearchTransactionResponse("TRX-VIA-1", "TR-VIA-TRX", "300", "BDT", "bKash_to_Merchant", "Unknown", "", "", "0000", "Successful"));
            _bkash.Setup(x => x.QueryPaymentAsync("TR-VIA-TRX", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashQueryPaymentResponse("TR-VIA-TRX", "TRX-VIA-1", "300", "Completed", "0000", "Successful"));

            var handler = CreateHandler(db);
            var result = await handler.Handle(new ReconcileBkashPaymentCommand(null, "TRX-VIA-1"), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.WasFinalized.Should().BeTrue();
            result.Data.GatewayPaymentId.Should().Be("TR-VIA-TRX");
            result.Data.OrderPaymentStatus.Should().Be(PaymentStatus.Paid.ToString());
            result.Data.OrderPaidAmount.Should().Be(300);

            var updatedPayment = db.Get<RajMango.Domain.Entities.Payment>().Single(p => p.Id == payment.Id);
            updatedPayment.PaymentStatus.Should().Be(PaymentStatus.Paid);

            _bkash.Verify(x => x.QueryPaymentAsync("TR-VIA-TRX", It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ViaTrxId_CalledTwice_IsIdempotent_NoDoubleCredit()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-REC-5", TotalAmount = 150, DueAmount = 150, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Pending,
                GrossAmount = 150,
                NetAmount = 150,
                PaidAmount = 0,
                GatewayPaymentId = "TR-VIA-TRX-2",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            _bkash.Setup(x => x.SearchTransactionAsync("TRX-VIA-2", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashSearchTransactionResponse("TRX-VIA-2", "TR-VIA-TRX-2", "150", "BDT", "bKash_to_Merchant", "Unknown", "", "", "0000", "Successful"));
            _bkash.Setup(x => x.QueryPaymentAsync("TR-VIA-TRX-2", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashQueryPaymentResponse("TR-VIA-TRX-2", "TRX-VIA-2", "150", "Completed", "0000", "Successful"));

            var handler = CreateHandler(db);
            var first = await handler.Handle(new ReconcileBkashPaymentCommand(null, "TRX-VIA-2"), CancellationToken.None);
            first.Data.WasFinalized.Should().BeTrue();

            var second = await handler.Handle(new ReconcileBkashPaymentCommand(null, "TRX-VIA-2"), CancellationToken.None);
            second.Succeeded.Should().BeTrue();
            second.Data.WasFinalized.Should().BeFalse(); // already resolved — no-op, not re-finalized

            var updatedOrder = db.Get<RajMango.Domain.Entities.Order>().Single(o => o.Id == order.Id);
            updatedOrder.PaidAmount.Should().Be(150); // not double-credited

            _bkash.Verify(x => x.QueryPaymentAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_SearchReturnsNoPaymentId_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            _bkash.Setup(x => x.SearchTransactionAsync("TRX-UNKNOWN", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashSearchTransactionResponse("TRX-UNKNOWN", "", "", "BDT", "", "", "", "", "2001", "Transaction not found"));

            var handler = CreateHandler(db);
            var result = await handler.Handle(new ReconcileBkashPaymentCommand(null, "TRX-UNKNOWN"), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            _bkash.Verify(x => x.QueryPaymentAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_NeitherPaymentIdNorTrxIdProvided_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var handler = CreateHandler(db);

            var result = await handler.Handle(new ReconcileBkashPaymentCommand(null, null), CancellationToken.None);

            result.Succeeded.Should().BeFalse();
        }
    }
}
