using RajMango.Shared.Enums;

namespace RajMango.Application.DTOs.Order
{
    public class AdminOrderDetailsDto
    {
        // --- Summary ---
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalQuantity { get; set; }

        // --- Customer info ---
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }

        // --- Financials ---
        public decimal ProductTotal { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }

        // --- Status ---
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }

        // --- Delivery info ---
        public string TrackingNumber { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string FallbackAddress { get; set; }
        public ReceiverType ReceiverType { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMobileNumber { get; set; }
        public string DeliveryNote { get; set; }

        // --- Courier info ---
        public int? CourierProviderId { get; set; }
        public string CourierProviderName { get; set; }
        public int? CourierStationId { get; set; }
        public string CourierStationName { get; set; }
        public string CourierStationAddress { get; set; }
        public string DeliveryArea { get; set; }
        public CourierLocationType? CourierLocationType { get; set; }

        // --- Eligibility ---
        public bool IsCourierEligible { get; set; }

        // --- Courier charge breakdown ---
        public decimal CourierRatePerKg { get; set; }
        public decimal CourierChargeCalculated { get; set; }
        public decimal? CourierChargeOverrideAmount { get; set; }
        public bool IsCourierChargeOverridden { get; set; }
        public string CourierChargeNote { get; set; }
        public decimal FinalCourierCharge => IsCourierChargeOverridden && CourierChargeOverrideAmount.HasValue
            ? CourierChargeOverrideAmount.Value
            : CourierChargeCalculated;

        // --- Order items ---
        public List<AdminOrderItemDto> OrderItems { get; set; } = new();

        // --- Payments ---
        public List<AdminOrderPaymentDto> Payments { get; set; } = new();

        // --- Audit ---
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class AdminOrderItemDto
    {
        public int Id { get; set; }
        public int MangoTypeId { get; set; }
        public string MangoTypeName { get; set; }
        public CrateType CrateType { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Note { get; set; }
    }

    public class AdminOrderPaymentDto
    {
        public int Id { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal NetAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
