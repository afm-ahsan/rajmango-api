using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    /// <summary>
    /// Public, unauthenticated lookup for the bKash result pages — by the time these pages load,
    /// the payment has already been fully processed server-side via the callback; this is a
    /// read-only "what happened" view keyed by bKash's own long, gateway-generated paymentID
    /// (the only reference bKash echoes back on redirect). Deliberately excludes OrderId/UserId/
    /// internal Payment.Id — only customer-facing fields are returned.
    /// </summary>
    public record GetBkashPaymentResultQuery(string GatewayPaymentId) : IRequest<Result<BkashPaymentResultDto>>;

    public record BkashPaymentResultDto(
        string OrderNumber,
        decimal Amount,
        string TransactionId,
        DateTime? PaymentDate,
        PaymentStatus PaymentStatus,
        string FailureReason);

    internal class GetBkashPaymentResultQueryHandler
        : IRequestHandler<GetBkashPaymentResultQuery, Result<BkashPaymentResultDto>>
    {
        private readonly IDataContext _dataContext;

        public GetBkashPaymentResultQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<BkashPaymentResultDto>> Handle(
            GetBkashPaymentResultQuery query, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(query.GatewayPaymentId))
                return await Result<BkashPaymentResultDto>.FailureAsync("paymentId is required.");

            var payment = await _dataContext.Get<Payment>()
                .AsNoTracking()
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.GatewayPaymentId == query.GatewayPaymentId, cancellationToken);

            if (payment is null)
                return await Result<BkashPaymentResultDto>.FailureAsync("We couldn't find details for this payment.");

            var dto = new BkashPaymentResultDto(
                OrderNumber: payment.Order?.OrderNumber,
                Amount: payment.PaymentStatus == PaymentStatus.Paid || payment.PaymentStatus == PaymentStatus.PartiallyRefunded
                    ? payment.PaidAmount
                    : payment.GrossAmount,
                TransactionId: payment.TransactionId,
                PaymentDate: payment.PaidAt ?? payment.UpdatedAt ?? payment.CreatedAt,
                PaymentStatus: payment.PaymentStatus,
                FailureReason: payment.FailureReason);

            return await Result<BkashPaymentResultDto>.SuccessAsync(dto);
        }
    }
}
