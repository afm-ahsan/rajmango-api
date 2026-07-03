using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record SearchBkashTransactionQuery(string TrxId) : IRequest<Result<BkashSearchTransactionResult>>;

    public record BkashSearchTransactionResult(
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

    internal class SearchBkashTransactionQueryHandler
        : IRequestHandler<SearchBkashTransactionQuery, Result<BkashSearchTransactionResult>>
    {
        private readonly IBkashService _bkash;

        public SearchBkashTransactionQueryHandler(IBkashService bkash)
        {
            _bkash = bkash;
        }

        public async Task<Result<BkashSearchTransactionResult>> Handle(
            SearchBkashTransactionQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.TrxId))
                return await Result<BkashSearchTransactionResult>.FailureAsync("TrxId is required.");

            var response = await _bkash.SearchTransactionAsync(request.TrxId, cancellationToken);

            var result = new BkashSearchTransactionResult(
                TrxId: response.TrxId,
                PaymentId: response.PaymentId,
                Amount: response.Amount,
                Currency: response.Currency,
                TransactionType: response.TransactionType,
                TransactionStatus: response.TransactionStatus,
                InitiationTime: response.InitiationTime,
                CompletionTime: response.CompletionTime,
                StatusCode: response.StatusCode,
                StatusMessage: response.StatusMessage);

            return string.Equals(response.StatusCode, "0000")
                ? await Result<BkashSearchTransactionResult>.SuccessAsync(result)
                : await Result<BkashSearchTransactionResult>.FailureAsync(
                    result, response.StatusMessage ?? "Transaction not found.");
        }
    }
}
