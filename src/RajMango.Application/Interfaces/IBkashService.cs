namespace RajMango.Application.Interfaces
{
    public record BkashTokenResponse(string IdToken, string RefreshToken);

    public record BkashCreatePaymentResponse(
        string PaymentId,
        string BkashUrl,
        string TransactionStatus,
        string StatusCode,
        string StatusMessage);

    public record BkashExecutePaymentResponse(
        string PaymentId,
        string TrxId,
        string CustomerMsisdn,
        string Amount,
        string TransactionStatus,
        string StatusCode,
        string StatusMessage);

    public interface IBkashService
    {
        Task<BkashTokenResponse> GrantTokenAsync(CancellationToken cancellationToken = default);

        Task<BkashCreatePaymentResponse> CreatePaymentAsync(
            string idToken,
            string merchantInvoiceNumber,
            decimal amount,
            string payerReference,
            CancellationToken cancellationToken = default);

        Task<BkashExecutePaymentResponse> ExecutePaymentAsync(
            string idToken,
            string paymentId,
            CancellationToken cancellationToken = default);
    }
}
