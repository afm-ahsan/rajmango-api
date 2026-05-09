using RajMango.Domain.Entities;
using RajMango.Shared.Enums;

using PaymentEntity = RajMango.Domain.Entities.Payment;

namespace RajMango.Application.Features.Services
{
    public static class PaymentSyncHelper
    {
        public static void SyncOrderPaymentState(Order order, IEnumerable<PaymentEntity> allPaymentsForOrder)
        {
            var totalPaid = allPaymentsForOrder.Sum(p => p.PaidAmount);
            order.PaidAmount = totalPaid;
            order.DueAmount = order.TotalAmount - totalPaid;
            order.PaymentStatus = totalPaid <= 0
                ? PaymentStatus.Unpaid
                : totalPaid >= order.TotalAmount
                    ? PaymentStatus.Paid
                    : PaymentStatus.Partial;
        }
    }
}
