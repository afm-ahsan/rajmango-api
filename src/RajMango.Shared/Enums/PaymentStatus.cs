namespace RajMango.Shared.Enums
{
    public enum PaymentStatus
    {
        Unpaid = 0,       // Order placed but not paid
        Paid = 1,         // Full amount paid
        Partial = 2,      // Partial payment received
        Failed = 3,       // Payment attempt failed
        Refunded = 4,     // Full or partial refund issued
        Cancelled = 5,    // Payment process was cancelled
        Pending = 6       // Payment initiated with gateway, awaiting callback confirmation
    }

}
