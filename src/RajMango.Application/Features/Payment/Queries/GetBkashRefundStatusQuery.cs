using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    /// <summary>PaymentId is the internal Payment row (not a bKash gateway ID).</summary>
    public record GetBkashRefundStatusQuery(int PaymentId) : IRequest<Result<BkashRefundStatusDto>>;

    public record RefundHistoryEntryDto(
        decimal RefundAmount,
        DateTime RefundDate,
        string RefundReason,
        string RefundedBy,
        RefundStatus RefundStatus,
        string GatewayTransactionId);

    public record BkashRefundStatusDto(
        int PaymentId,
        decimal PaidAmount,
        decimal RefundedAmount,
        decimal RemainingRefundableAmount,
        PaymentStatus PaymentStatus,
        List<RefundHistoryEntryDto> RefundHistory,
        // Live bKash-side view for the most recent refund transaction, if one exists.
        string BkashTransactionStatus,
        string BkashStatusCode,
        string BkashStatusMessage);

    internal class GetBkashRefundStatusQueryHandler
        : IRequestHandler<GetBkashRefundStatusQuery, Result<BkashRefundStatusDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IBkashService _bkash;

        public GetBkashRefundStatusQueryHandler(IDataContext dataContext, IBkashService bkash)
        {
            _dataContext = dataContext;
            _bkash = bkash;
        }

        public async Task<Result<BkashRefundStatusDto>> Handle(
            GetBkashRefundStatusQuery query, CancellationToken cancellationToken)
        {
            var payment = await _dataContext.Get<Payment>()
                .FirstOrDefaultAsync(p => p.Id == query.PaymentId, cancellationToken);

            if (payment is null)
                return await Result<BkashRefundStatusDto>.FailureAsync($"Payment {query.PaymentId} not found.");

            var refunds = await _dataContext.Get<Refund>()
                .Where(r => r.PaymentId == payment.Id)
                .OrderByDescending(r => r.RefundDate)
                .Select(r => new RefundHistoryEntryDto(
                    r.RefundAmount, r.RefundDate, r.RefundReason, r.RefundedBy, r.RefundStatus, r.GatewayTransactionId))
                .ToListAsync(cancellationToken);

            string bkashTransactionStatus = null, bkashStatusCode = null, bkashStatusMessage = null;

            // Only worth asking bKash if we actually have gateway identifiers and at least one
            // refund on file — otherwise there's nothing for bKash to report on.
            if (!string.IsNullOrWhiteSpace(payment.GatewayPaymentId)
                && !string.IsNullOrWhiteSpace(payment.TransactionId)
                && refunds.Count > 0)
            {
                var response = await _bkash.GetRefundStatusAsync(payment.GatewayPaymentId, payment.TransactionId, cancellationToken);
                bkashTransactionStatus = response.TransactionStatus;
                bkashStatusCode = response.StatusCode;
                bkashStatusMessage = response.StatusMessage;
            }

            var dto = new BkashRefundStatusDto(
                PaymentId: payment.Id,
                PaidAmount: payment.PaidAmount,
                RefundedAmount: payment.RefundedAmount,
                RemainingRefundableAmount: payment.PaidAmount - payment.RefundedAmount,
                PaymentStatus: payment.PaymentStatus,
                RefundHistory: refunds,
                BkashTransactionStatus: bkashTransactionStatus,
                BkashStatusCode: bkashStatusCode,
                BkashStatusMessage: bkashStatusMessage);

            return await Result<BkashRefundStatusDto>.SuccessAsync(dto);
        }
    }
}
