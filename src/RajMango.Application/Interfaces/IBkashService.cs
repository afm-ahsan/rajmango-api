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

    /// <summary>Response from POST /checkout/general/searchTran (search by trxID).</summary>
    public record BkashSearchTransactionResponse(
        string TrxId,
        string PaymentId,
        string Amount,
        string Currency,
        string TransactionType,
        string TransactionStatus,
        string InitiationTime,
        string CompletionTime,
        string StatusCode,
        string StatusMessage);

    /// <summary>Response from POST /checkout/payment/refund.</summary>
    public record BkashRefundPaymentResponse(
        string OriginalPaymentId,
        string OriginalTrxId,
        string RefundTrxId,
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

        /// <summary>
        /// Query a payment's current status directly from bKash.
        /// Uses POST /checkout/payment/status per the bKash Tokenized Checkout v1.2.0-beta spec.
        /// </summary>
        Task<BkashQueryPaymentResponse> QueryPaymentAsync(
            string paymentId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Search a bKash transaction by trxID.
        /// Uses POST /checkout/general/searchTran.
        /// Admin diagnostic tool — never call during a customer payment flow.
        /// </summary>
        Task<BkashSearchTransactionResponse> SearchTransactionAsync(
            string trxId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Initiate a full refund for a completed bKash payment.
        /// Uses POST /checkout/payment/refund.
        /// Requires the original paymentID, trxID, and the amount to refund.
        /// </summary>
        Task<BkashRefundPaymentResponse> RefundPaymentAsync(
            string paymentId,
            string trxId,
            decimal amount,
            string sku,
            string reason,
            CancellationToken cancellationToken = default);
    }
}
