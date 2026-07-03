using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record QueryBkashPaymentQuery(string PaymentId) : IRequest<Result<BkashQueryResult>>;

    public record BkashQueryResult(
        string PaymentId,
        string TrxId,
        string Amount,
        string TransactionStatus,
        string StatusCode,
        string StatusMessage);

    internal class QueryBkashPaymentQueryHandler
        : IRequestHandler<QueryBkashPaymentQuery, Result<BkashQueryResult>>
    {
        private readonly IBkashService _bkash;

        public QueryBkashPaymentQueryHandler(IBkashService bkash)
        {
            _bkash = bkash;
        }

        public async Task<Result<BkashQueryResult>> Handle(
            QueryBkashPaymentQuery request, CancellationToken cancellationToken)
        {
            var response = await _bkash.QueryPaymentAsync(request.PaymentId, cancellationToken);

            var result = new BkashQueryResult(
                PaymentId: response.PaymentId,
                TrxId: response.TrxId,
                Amount: response.Amount,
                TransactionStatus: response.TransactionStatus,
                StatusCode: response.StatusCode,
                StatusMessage: response.StatusMessage);

            return string.Equals(response.StatusCode, "0000")
                ? await Result<BkashQueryResult>.SuccessAsync(result)
                : await Result<BkashQueryResult>.FailureAsync(result, response.StatusMessage ?? "Query failed.");
        }
    }
}
