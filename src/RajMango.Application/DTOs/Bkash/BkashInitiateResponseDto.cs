namespace RajMango.Application.DTOs.Bkash
{
    public class BkashInitiateResponseDto
    {
        public string BkashUrl { get; set; }
        public string GatewayPaymentId { get; set; }
        public string MerchantInvoiceNumber { get; set; }

        /// <summary>True when this response resumes an existing, not-yet-expired bKash payment
        /// session rather than creating a brand new one — the Web should confirm with the
        /// customer before redirecting ("A payment session already exists. Continue payment?").</summary>
        public bool IsExistingSession { get; set; }
    }
}
