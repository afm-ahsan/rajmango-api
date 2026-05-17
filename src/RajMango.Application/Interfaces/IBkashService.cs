namespace RajMango.Application.Interfaces
{
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
