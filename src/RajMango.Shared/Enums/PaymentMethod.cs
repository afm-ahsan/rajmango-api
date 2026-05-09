namespace RajMango.Shared.Enums
{
    public enum PaymentMethod
    {
        Unknown = 0,          // Default / not selected

        Cash = 1,          // Cash on delivery or in person
        BankTransfer = 2,  // Manual deposit or wire transfer
        MobilePayment = 3, // bKash, Nagad, Rocket, etc.
        CreditCard = 4,    // Credit Card
        DebitCard = 5,     // Debit Card
        VisaCard = 6,      // Visa Card
        MasterCard = 7,    // Master Card
        Wallet = 8         // In-app or system wallet
    }
}
