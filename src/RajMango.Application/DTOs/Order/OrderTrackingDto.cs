using RajMango.Shared.Enums;

namespace RajMango.Application.DTOs.Order
{
    public class OrderTrackingDto
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string ReceiverName { get; set; }
        public string DeliveryArea { get; set; }
        public string CourierProviderName { get; set; }
        public string CourierStationName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public List<OrderTrackingTimelineItemDto> Timeline { get; set; } = new();
    }

    public class OrderTrackingTimelineItemDto
    {
        public string TrackingStatus { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
