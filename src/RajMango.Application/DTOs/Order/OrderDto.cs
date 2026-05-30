using RajMango.Shared.Enums;

namespace RajMango.Application.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalQuantity { get; set; }

        // --- Financials ---
        public decimal ProductTotalAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }

        // --- Courier charge snapshot ---
        public int? CourierProviderId { get; set; }
        public CourierLocationType? CourierLocationType { get; set; }
        public decimal CourierRatePerKg { get; set; }
        public decimal CourierCharge { get; set; }
        public decimal? CourierChargeOverrideAmount { get; set; }
        public bool IsCourierChargeOverridden { get; set; }
        public string CourierChargeNote { get; set; }

        /// <summary>Override amount if overridden, otherwise the calculated courier charge.</summary>
        public decimal FinalCourierCharge => IsCourierChargeOverridden && CourierChargeOverrideAmount.HasValue
            ? CourierChargeOverrideAmount.Value
            : CourierCharge;

        // --- Status & delivery ---
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public bool IsValidOrder { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string TrackingNumber { get; set; }

        // --- Delivery details ---
        public int? CourierStationId { get; set; }
        public string CourierStationName { get; set; }
        public string FallbackAddress { get; set; }
        public ReceiverType ReceiverType { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMobileNumber { get; set; }
        public string DeliveryNote { get; set; }
        public string Area { get; set; }

        public IEnumerable<OrderDetailDto> OrderDetails { get; set; }
    }
}
