namespace RajMango.Shared.Enums
{
    public enum CustomerType
    {
        None = 0,         // Default/unassigned

        Regular = 1,      // Standard retail customer
        Wholesale = 2,    // Buys in bulk, may have discounts
        Corporate = 3,    // Business or institutional client
        Distributor = 4,  // Handles regional reselling
        VIP = 5,           // High-value customer (special pricing/treatment)
        Staff = 6          // Internal or privileged access
    }
}
