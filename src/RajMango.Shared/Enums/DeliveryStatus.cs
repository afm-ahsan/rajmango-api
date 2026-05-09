namespace RajMango.Shared.Enums
{
    public enum DeliveryStatus
    {
        None = 0,         // Default/uninitialized state

        Pending = 1,      // Order placed, waiting for dispatch
        Dispatched = 2,   // Handed over to courier or delivery team
        InTransit = 3,    // On the way to customer
        Delivered = 4,    // Successfully delivered
        Failed = 5,       // Attempted delivery failed
        Returned = 6,     // Returned by customer or undeliverable
        Cancelled = 7     // Delivery cancelled before dispatch
    }

}
