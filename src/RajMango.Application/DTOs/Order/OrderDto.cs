using RajMango.Shared.Enums;

namespace RajMango.Application.DTOs.Order
{
    public class OrderDto
    {
        public ReceiverType ReceiverType { get; set; }
        public int Id { get; set; }

        public int UserId { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public int TotalQuantity { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal DueAmount { get; set; }

        public bool IsValidOrder { get; set; }

        public bool IsDelivered { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string TrackingNumber { get; set; }

        public int? CourierStationId { get; set; }

        public string FallbackAddress { get; set; }

        public string ReceiverName { get; set; }

        public string ReceiverMobileNumber { get; set; }

        public string DeliveryNote { get; set; }

        public string Area { get; set; }

        public DeliveryStatus DeliveryStatus { get; set; }

        public IEnumerable<OrderDetailDto> OrderDetails { get; set; }
    }
}
