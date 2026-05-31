using RajMango.Shared.Enums;

namespace RajMango.Application.DTOs.Order
{
    public class AdminOrderListDto
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

        // --- Customer ---
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }

        // --- Receiver (resolved by ReceiverType) ---
        public ReceiverType ReceiverType { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMobile { get; set; }

        // --- Courier / Delivery ---
        public string CourierProviderName { get; set; }
        public string CourierStationName { get; set; }
        public string CourierStationAddress { get; set; }
        public string DeliveryArea { get; set; }

        // --- Financials ---
        public int TotalQuantity { get; set; }
        public decimal ProductTotal { get; set; }
        public decimal CourierCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }

        // --- Status ---
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }

        // --- Flags ---
        public bool IsCourierEligible { get; set; }
        public string MangoTypeName { get; set; }
    }
}
