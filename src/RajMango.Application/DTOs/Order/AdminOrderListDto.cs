using RajMango.Shared.Enums;

namespace RajMango.Application.DTOs.Order
{
    public class AdminOrderListDto
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int TotalQuantity { get; set; }
        public decimal ProductTotal { get; set; }
        public decimal CourierCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public string CourierStationName { get; set; }
        public string CourierProviderName { get; set; }
        public string MangoTypeName { get; set; }
    }
}
