namespace RajMango.Shared.Enums
{
    public enum DiscountType
    {
        None = 0,           // No discount applied

        Percentage = 1,     // e.g., 10% off
        FlatAmount = 2,     // e.g., 50 BDT off
        BuyOneGetOne = 3,   // Buy one, get one free
        Seasonal = 4,       // Tied to seasonal campaigns
        Loyalty = 5         // Based on repeat purchases or customer tier
    }
}
