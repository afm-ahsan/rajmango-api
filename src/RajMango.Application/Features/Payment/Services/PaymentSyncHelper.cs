using RajMango.Domain.Entities;
using RajMango.Shared.Enums;

using PaymentEntity = RajMango.Domain.Entities.Payment;

namespace RajMango.Application.Features.Services
{
    public static class PaymentSyncHelper
    {
        public static void SyncOrderPaymentState(Order order, IEnumerable<PaymentEntity> allPaymentsForOrder)
        {
            var totalPaid       = allPaymentsForOrder.Sum(p => p.PaidAmount);
            var totalDiscounted = allPaymentsForOrder.Sum(p => p.DiscountAmount);
            var totalCovered    = totalPaid + totalDiscounted;

            // PaidAmount = cash received only (used for "collected" reporting on dashboard).
            // DueAmount  = remaining obligation after both cash and discounts.
            order.PaidAmount = totalPaid;
            order.DueAmount  = order.TotalAmount - totalCovered;

            order.PaymentStatus = totalCovered <= 0
                ? PaymentStatus.Unpaid
                : totalCovered >= order.TotalAmount
                    ? PaymentStatus.Paid
                    : PaymentStatus.Partial;
        }
    }
}
