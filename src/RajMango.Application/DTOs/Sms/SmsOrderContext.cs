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

        // ---------------------------------------------------------------------------
        // Recipient control (admin order status update only)
        // Defaults preserve existing behaviour for all other callers.
        // ---------------------------------------------------------------------------

        /// <summary>Send SMS to the delivery receiver (gift recipient's number, or sender's number for self orders).</summary>
        public bool ShouldNotifyReceiver { get; init; } = true;

        /// <summary>Send SMS to the order placer (customer/sender) instead of the receiver.</summary>
        public bool ShouldNotifySender { get; init; } = false;

        /// <summary>
        /// Delivery receiver's mobile number (set for gift orders; null for self orders).
        /// When null and ShouldNotifyReceiver is true, falls back to the sender's number.
        /// </summary>
        public string ReceiverMobileNumber { get; init; }
    }

    public class SmsOrderItem
    {
        public string MangoTypeName { get; init; } = "";
        public int WeightKg { get; init; }
    }
}
