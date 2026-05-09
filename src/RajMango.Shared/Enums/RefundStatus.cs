namespace RajMango.Shared.Enums
{
    public enum RefundStatus
    {
        None = 0,          // Default or not yet set

        Pending = 1,       // Refund requested but not processed yet
        Approved = 2,      // Approved for processing
        Processing = 3,    // Actively being handled (manual or gateway)
        Completed = 4,     // Refund successfully processed
        Failed = 5,        // Refund failed (e.g., gateway/network issue)
        Cancelled = 6,     // Request canceled (by customer or admin)
        Rejected = 7       // Refund denied (policy or validation issue)
    }
}
