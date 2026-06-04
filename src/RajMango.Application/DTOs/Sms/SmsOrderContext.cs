using RajMango.Shared.Enums;

namespace RajMango.Application.DTOs.Sms
{
    public class SmsOrderContext
    {
        public string OrderNumber { get; init; } = "";
        public OrderStatus OrderStatus { get; init; }
        public PaymentStatus PaymentStatus { get; init; }
        public DeliveryStatus DeliveryStatus { get; init; }
        public DateTime? DeliveryDate { get; init; }

        /// <summary>
        /// One entry per order-detail line, after grouping by MangoType and summing weight.
        /// WeightKg = CrateWeightKg * Quantity for that detail.
        /// </summary>
        public IReadOnlyList<SmsOrderItem> Items { get; init; } = Array.Empty<SmsOrderItem>();

        public bool OrderStatusChanged { get; init; }
        public bool PaymentStatusChanged { get; init; }
        public bool DeliveryStatusChanged { get; init; }
        public bool DeliveryDateChanged { get; init; }

        public bool HasAnyChange =>
            OrderStatusChanged || PaymentStatusChanged || DeliveryStatusChanged || DeliveryDateChanged;
    }

    public class SmsOrderItem
    {
        public string MangoTypeName { get; init; } = "";
        public int WeightKg { get; init; }
    }
}
