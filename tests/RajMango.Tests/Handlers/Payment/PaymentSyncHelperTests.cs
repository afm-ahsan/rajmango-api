using FluentAssertions;
using RajMango.Application.Features.Services;
using RajMango.Shared.Enums;
using Xunit;

namespace RajMango.Tests.Handlers.Payment
{
    public class PaymentSyncHelperTests
    {
        [Fact]
        public void SyncOrderPaymentState_OnlyPaidPayments_CountTowardTotal()
        {
            var order = new RajMango.Domain.Entities.Order { TotalAmount = 1000 };
            var payments = new[]
            {
                new RajMango.Domain.Entities.Payment { PaymentStatus = PaymentStatus.Paid, PaidAmount = 400 },
                new RajMango.Domain.Entities.Payment { PaymentStatus = PaymentStatus.Pending, PaidAmount = 0 },
                new RajMango.Domain.Entities.Payment { PaymentStatus = PaymentStatus.Failed, PaidAmount = 0 },
                new RajMango.Domain.Entities.Payment { PaymentStatus = PaymentStatus.Cancelled, PaidAmount = 0 },
                new RajMango.Domain.Entities.Payment { PaymentStatus = PaymentStatus.Expired, PaidAmount = 0 },
            };

            PaymentSyncHelper.SyncOrderPaymentState(order, payments);

            order.PaidAmount.Should().Be(400);
            order.DueAmount.Should().Be(600);
            order.PaymentStatus.Should().Be(PaymentStatus.Partial);
        }

        [Fact]
        public void SyncOrderPaymentState_RefundedPayment_DoesNotContributeToPaidTotal()
        {
            // Regression guard: a refunded payment must stop counting toward the order's paid
            // total immediately — this was silently broken before the status filter was added.
            var order = new RajMango.Domain.Entities.Order { TotalAmount = 1000 };
            var payments = new[]
            {
                new RajMango.Domain.Entities.Payment { PaymentStatus = PaymentStatus.Refunded, PaidAmount = 1000 },
            };

            PaymentSyncHelper.SyncOrderPaymentState(order, payments);

            order.PaidAmount.Should().Be(0);
            order.DueAmount.Should().Be(1000);
            order.PaymentStatus.Should().Be(PaymentStatus.Unpaid);
        }

        [Fact]
        public void SyncOrderPaymentState_FullyPaid_SetsStatusPaid()
        {
            var order = new RajMango.Domain.Entities.Order { TotalAmount = 500 };
            var payments = new[]
            {
                new RajMango.Domain.Entities.Payment { PaymentStatus = PaymentStatus.Paid, PaidAmount = 500 },
            };

            PaymentSyncHelper.SyncOrderPaymentState(order, payments);

            order.PaidAmount.Should().Be(500);
            order.DueAmount.Should().Be(0);
            order.PaymentStatus.Should().Be(PaymentStatus.Paid);
        }

        [Fact]
        public void SyncOrderPaymentState_MultiplePaidPayments_SumsAcrossAll()
        {
            var order = new RajMango.Domain.Entities.Order { TotalAmount = 1000 };
            var payments = new[]
            {
                new RajMango.Domain.Entities.Payment { PaymentStatus = PaymentStatus.Paid, PaidAmount = 300 },
                new RajMango.Domain.Entities.Payment { PaymentStatus = PaymentStatus.Paid, PaidAmount = 700 },
            };

            PaymentSyncHelper.SyncOrderPaymentState(order, payments);

            order.PaidAmount.Should().Be(1000);
            order.DueAmount.Should().Be(0);
            order.PaymentStatus.Should().Be(PaymentStatus.Paid);
        }

        [Fact]
        public void SyncOrderPaymentState_PartiallyRefundedPayment_ContributesOnlyRemainingAmount()
        {
            var order = new RajMango.Domain.Entities.Order { TotalAmount = 1000 };
            var payments = new[]
            {
                new RajMango.Domain.Entities.Payment
                {
                    PaymentStatus = PaymentStatus.PartiallyRefunded,
                    PaidAmount = 1000,
                    RefundedAmount = 300,
                },
            };

            PaymentSyncHelper.SyncOrderPaymentState(order, payments);

            order.PaidAmount.Should().Be(700);
            order.DueAmount.Should().Be(300);
            order.PaymentStatus.Should().Be(PaymentStatus.Partial);
        }

        [Fact]
        public void SyncOrderPaymentState_FullyRefundedViaPartialRefunds_ContributesNothing()
        {
            var order = new RajMango.Domain.Entities.Order { TotalAmount = 500 };
            var payments = new[]
            {
                new RajMango.Domain.Entities.Payment
                {
                    PaymentStatus = PaymentStatus.Refunded, // cumulative refunds reached PaidAmount
                    PaidAmount = 500,
                    RefundedAmount = 500,
                },
            };

            PaymentSyncHelper.SyncOrderPaymentState(order, payments);

            order.PaidAmount.Should().Be(0);
            order.DueAmount.Should().Be(500);
            order.PaymentStatus.Should().Be(PaymentStatus.Unpaid);
        }
    }
}
