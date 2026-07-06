using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Shared;
using RajMango.Shared.Enums;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Payment
{
    public class BkashCallbackCommandHandlerTests
    {
        private readonly Mock<IBkashService> _bkash = new();
        private readonly Mock<IRealtimeService> _realtime = new();
        private readonly Mock<INotificationService> _notification = new();
        private readonly Mock<ISmsService> _sms = new();
        private readonly IPaymentLock _paymentLock = new PaymentLock();
        private readonly IOptions<BkashSettings> _settings = Options.Create(new BkashSettings
        {
            FrontendSuccessUrl = "https://app.test/orders/bkash-success",
            FrontendFailureUrl = "https://app.test/orders/bkash-failed",
            FrontendCancelUrl = "https://app.test/orders/bkash-cancelled",
        });

        public BkashCallbackCommandHandlerTests()
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

        private BkashCallbackCommandHandler CreateHandler(RajMango.DataAccess.Contexts.AppDbContext db)
        {
            var finalizer = new BkashPaymentFinalizer(
                db, _realtime.Object, _notification.Object, _sms.Object,
                NullLogger<BkashPaymentFinalizer>.Instance);
            return new BkashCallbackCommandHandler(
                db, _bkash.Object, finalizer, _paymentLock, _settings,
                NullLogger<BkashCallbackCommandHandler>.Instance);
        }

        [Fact]
        public async Task Handle_SuccessfulPayment_SyncsOrderPaidAmountAndStatus()
        {
            // Regression test for the root-cause bug: the order used to stay Unpaid/PaidAmount=0
            // even though the payment was correctly marked Paid, because the post-mutation
            // re-query returned a stale (pre-save) copy of the same payment row under NoTracking.
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-1", TotalAmount = 500, DueAmount = 500, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Pending,
                GrossAmount = 500,
                NetAmount = 500,
                PaidAmount = 0,
                GatewayPaymentId = "TR0011",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            _bkash.Setup(x => x.ExecutePaymentAsync("TR0011", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashExecutePaymentResponse("TR0011", "TRX123", "01700000000", "500", "Completed", "0000", "Successful"));

            var handler = CreateHandler(db);
            var result = await handler.Handle(new BkashCallbackCommand { PaymentId = "TR0011", Status = "success" }, CancellationToken.None);

            result.IsSuccess.Should().BeTrue();

            var updatedOrder = db.Get<RajMango.Domain.Entities.Order>().Single(o => o.Id == order.Id);
            updatedOrder.PaymentStatus.Should().Be(PaymentStatus.Paid);
            updatedOrder.PaidAmount.Should().Be(500);
            updatedOrder.DueAmount.Should().Be(0);
            updatedOrder.OrderStatus.Should().Be(OrderStatus.Confirmed);

            var updatedPayment = db.Get<RajMango.Domain.Entities.Payment>().Single(p => p.Id == payment.Id);
            updatedPayment.PaymentStatus.Should().Be(PaymentStatus.Paid);
            updatedPayment.TransactionId.Should().Be("TRX123");
        }

        [Fact]
        public async Task Handle_CalledTwiceForSamePayment_IsIdempotent()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-2", TotalAmount = 200, DueAmount = 200, CreatedBy = 1 };
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
                GatewayPaymentId = "TR0022",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            _bkash.Setup(x => x.ExecutePaymentAsync("TR0022", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashExecutePaymentResponse("TR0022", "TRX999", "01700000000", "200", "Completed", "0000", "Successful"));

            var handler = CreateHandler(db);
            await handler.Handle(new BkashCallbackCommand { PaymentId = "TR0022", Status = "success" }, CancellationToken.None);
            var second = await handler.Handle(new BkashCallbackCommand { PaymentId = "TR0022", Status = "success" }, CancellationToken.None);

            second.IsSuccess.Should().BeTrue();
            _bkash.Verify(x => x.ExecutePaymentAsync("TR0022", It.IsAny<CancellationToken>()), Times.Once);

            var updatedOrder = db.Get<RajMango.Domain.Entities.Order>().Single(o => o.Id == order.Id);
            updatedOrder.PaidAmount.Should().Be(200); // not double-credited
        }

        [Fact]
        public async Task Handle_CallbackStatusNotSuccess_SetsFailedWithReason()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-3", TotalAmount = 100, DueAmount = 100, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Pending,
                GrossAmount = 100,
                NetAmount = 100,
                GatewayPaymentId = "TR0033",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            var handler = CreateHandler(db);
            await handler.Handle(new BkashCallbackCommand { PaymentId = "TR0033", Status = "failure" }, CancellationToken.None);

            var updated = db.Get<RajMango.Domain.Entities.Payment>().Single(p => p.Id == payment.Id);
            updated.PaymentStatus.Should().Be(PaymentStatus.Failed);
            updated.FailureReason.Should().Contain("failure");
        }

        [Fact]
        public async Task Handle_ExecutePaymentThrowsBkashApiException_UsesExceptionMessageAsFailureReason()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-4", TotalAmount = 100, DueAmount = 100, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Pending,
                GrossAmount = 100,
                NetAmount = 100,
                GatewayPaymentId = "TR0044",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            _bkash.Setup(x => x.ExecutePaymentAsync("TR0044", It.IsAny<CancellationToken>()))
                .ThrowsAsync(new BkashApiException("Insufficient balance in customer wallet.", "{}"));

            var handler = CreateHandler(db);
            await handler.Handle(new BkashCallbackCommand { PaymentId = "TR0044", Status = "success" }, CancellationToken.None);

            var updated = db.Get<RajMango.Domain.Entities.Payment>().Single(p => p.Id == payment.Id);
            updated.PaymentStatus.Should().Be(PaymentStatus.Failed);
            updated.FailureReason.Should().Be("Insufficient balance in customer wallet.");
        }

        [Fact]
        public async Task Handle_TransactionNotCompleted_UsesQueryStatusMessageAsFailureReason()
        {
            using var db = TestDbContextFactory.Create();
            var order = new RajMango.Domain.Entities.Order { UserId = 1, OrderNumber = "ORD-5", TotalAmount = 100, DueAmount = 100, CreatedBy = 1 };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();

            var payment = new RajMango.Domain.Entities.Payment
            {
                OrderId = order.Id,
                PaymentMethod = PaymentMethod.Bkash,
                PaymentStatus = PaymentStatus.Pending,
                GrossAmount = 100,
                NetAmount = 100,
                GatewayPaymentId = "TR0055",
                CreatedBy = 1,
            };
            db.Get<RajMango.Domain.Entities.Payment>().Add(payment);
            db.SaveChanges();

            _bkash.Setup(x => x.ExecutePaymentAsync("TR0055", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashExecutePaymentResponse("TR0055", "", "01700000000", "100", "Initiated", "0000", ""));
            _bkash.Setup(x => x.QueryPaymentAsync("TR0055", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BkashQueryPaymentResponse("TR0055", "", "100", "Cancelled", "0000", "Customer cancelled the transaction."));

            var handler = CreateHandler(db);
            await handler.Handle(new BkashCallbackCommand { PaymentId = "TR0055", Status = "success" }, CancellationToken.None);

            var updated = db.Get<RajMango.Domain.Entities.Payment>().Single(p => p.Id == payment.Id);
            updated.PaymentStatus.Should().Be(PaymentStatus.Failed);
            updated.FailureReason.Should().Be("Customer cancelled the transaction.");
        }
    }
}
