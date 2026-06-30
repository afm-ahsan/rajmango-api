namespace RajMango.Application.Interfaces
{
    /// <summary>
    /// Thrown when bKash returns a non-success response (HTTP error or missing expected fields).
    /// <see cref="Exception.Message"/> is a clean, safe-to-display description of what bKash reported —
    /// callers may surface it directly to the end user.
    /// <see cref="RawResponse"/> is the raw response body for logging/audit only and must never be
    /// returned to a client.
    /// </summary>
    public class BkashApiException : Exception
    {
        public string RawResponse { get; }

        public BkashApiException(string message, string rawResponse) : base(message)
        {
            RawResponse = rawResponse;
        }
    }

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

    public record BkashQueryPaymentResponse(
        string PaymentId,
        string TrxId,
        string Amount,
        string TransactionStatus,
        string StatusCode,
        string StatusMessage);

    public interface IBkashService
    {
        // Token management is internal; callers do not receive or pass tokens.

        Task<BkashCreatePaymentResponse> CreatePaymentAsync(
            string merchantInvoiceNumber,
            decimal amount,
            string payerReference,
            CancellationToken cancellationToken = default);

        Task<BkashExecutePaymentResponse> ExecutePaymentAsync(
            string paymentId,
            CancellationToken cancellationToken = default);

        Task<BkashQueryPaymentResponse> QueryPaymentAsync(
            string paymentId,
            CancellationToken cancellationToken = default);
    }
}
