namespace RajMango.Shared.Enums
{
    public enum OrderStatus
    {
        Pending = 0,         // Order placed but not yet confirmed
        Confirmed = 1,       // Manually or automatically confirmed
        Processing = 2,      // Being packed or prepared
        Shipped = 3,         // Handed over to courier
        Delivered = 4,       // Successfully delivered to customer
        Cancelled = 5,       // Cancelled before shipment
        Returned = 6,        // Returned by customer after delivery
        Failed = 7           // Failed during payment or processing
    }
}
