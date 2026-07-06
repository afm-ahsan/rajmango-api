using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RajMango.Application.Common;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    /// <summary>
    /// PaymentId identifies the internal Payment row (not a bKash gateway ID) — mirrors the full
    /// refund command's contract. Multiple partial refunds are allowed against the same payment
    /// as long as their cumulative total never exceeds what was actually paid.
    /// </summary>
    public record PartialRefundBkashPaymentCommand(int PaymentId, decimal RefundAmount, string Reason)
        : IRequest<Result<BkashPartialRefundResult>>;

    public record BkashPartialRefundResult(
        string OriginalTrxId,
        string RefundTrxId,
        string RefundAmount,
        decimal RemainingRefundableAmount,
        string TransactionStatus,
        string StatusCode,
        string StatusMessage);

    internal class PartialRefundBkashPaymentCommandHandler
        : IRequestHandler<PartialRefundBkashPaymentCommand, Result<BkashPartialRefundResult>>
    {
        private readonly IBkashService _bkash;
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPaymentLock _paymentLock;
        private readonly ILogger<PartialRefundBkashPaymentCommandHandler> _logger;

        public PartialRefundBkashPaymentCommandHandler(
            IBkashService bkash,
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            IPaymentLock paymentLock,
            ILogger<PartialRefundBkashPaymentCommandHandler> logger)
        {
            _bkash = bkash;
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _paymentLock = paymentLock;
            _logger = logger;
        }

        public async Task<Result<BkashPartialRefundResult>> Handle(
            PartialRefundBkashPaymentCommand command, CancellationToken cancellationToken)
        {
            if (command.RefundAmount <= 0)
                return await Result<BkashPartialRefundResult>.FailureAsync("Refund amount must be greater than zero.");

            // Shares the global payment lock with create/callback/refund so this can never race
            // a concurrent callback or another refund attempt for the same payment.
            using (await _paymentLock.AcquireAsync())
            {
                var payment = await _dataContext.Get<Payment>()
                    .Include(p => p.Order)
                    .FirstOrDefaultAsync(p => p.Id == command.PaymentId, cancellationToken);

                if (payment is null)
                    return await Result<BkashPartialRefundResult>.FailureAsync(
                        $"Payment {command.PaymentId} not found.");

                if (payment.PaymentMethod != PaymentMethod.Bkash)
                    return await Result<BkashPartialRefundResult>.FailureAsync(
                        "Only bKash payments can be refunded through this action.");

                // Paid = first refund; PartiallyRefunded = a subsequent refund against the same payment.
                if (payment.PaymentStatus != PaymentStatus.Paid && payment.PaymentStatus != PaymentStatus.PartiallyRefunded)
                    return await Result<BkashPartialRefundResult>.FailureAsync(
                        $"Payment is not in a refundable state (current status: {payment.PaymentStatus}).");

                if (string.IsNullOrWhiteSpace(payment.GatewayPaymentId) || string.IsNullOrWhiteSpace(payment.TransactionId))
                    return await Result<BkashPartialRefundResult>.FailureAsync(
                        "Payment is missing bKash gateway identifiers and cannot be refunded.");

                var remaining = payment.PaidAmount - payment.RefundedAmount;
                if (command.RefundAmount > remaining)
                    return await Result<BkashPartialRefundResult>.FailureAsync(
                        $"Refund amount ({command.RefundAmount}) exceeds the remaining refundable amount ({remaining}).");

                var order = payment.Order;

                _logger.LogInformation(
                    "bKash partial refund initiated: paymentId={PaymentId} gatewayPaymentId={GatewayPaymentId} trxId={TrxId} " +
                    "refundAmount={RefundAmount} remainingBefore={Remaining} byUserId={UserId}",
                    payment.Id, payment.GatewayPaymentId, payment.TransactionId, command.RefundAmount, remaining, _currentUserService.UserId);

                var response = await _bkash.PartialRefundAsync(
                    payment.GatewayPaymentId,
                    payment.TransactionId,
                    command.RefundAmount,
                    sku: order?.OrderNumber ?? string.Empty,
                    reason: command.Reason ?? string.Empty,
                    cancellationToken);

                if (!string.Equals(response.StatusCode, "0000"))
                {
                    _logger.LogWarning(
                        "bKash partial refund not confirmed: paymentId={PaymentId} statusCode={Code} statusMessage={Message}",
                        payment.Id, response.StatusCode, response.StatusMessage);
                    return await Result<BkashPartialRefundResult>.FailureAsync(
                        new BkashPartialRefundResult(
                            response.OriginalTrxId, response.RefundTrxId, response.RefundAmount, remaining,
                            response.TransactionStatus, response.StatusCode, response.StatusMessage),
                        response.StatusMessage ?? "Partial refund was not confirmed by bKash.");
                }

                // Confirmed refunded — update payment (cumulative), recalc order, persist refund audit row.
                payment.RefundedAmount += command.RefundAmount;
                var remainingAfter = payment.PaidAmount - payment.RefundedAmount;
                payment.PaymentStatus = remainingAfter <= 0
                    ? PaymentStatus.Refunded
                    : PaymentStatus.PartiallyRefunded;

                var refund = new Refund
                {
                    PaymentId = payment.Id,
                    RefundAmount = command.RefundAmount,
                    RefundDate = Clock.Now(),
                    RefundReason = command.Reason,
                    RefundedBy = _currentUserService.UserName,
                    RefundReference = response.RefundTrxId,
                    IsGatewayRefunded = true,
                    RefundStatus = RefundStatus.Completed,
                    GatewayResponseMessage = response.StatusMessage,
                    GatewayTransactionId = response.RefundTrxId,
                };

                if (order != null)
                {
                    // Excludes this payment's row, then adds back the in-memory instance just
                    // mutated above — mirrors the same NoTracking-safe pattern used elsewhere.
                    var allPayments = await _dataContext.Get<Payment>()
                        .Where(p => p.OrderId == order.Id && p.Id != payment.Id)
                        .ToListAsync(cancellationToken);
                    allPayments.Add(payment);

                    PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);
                    payment.DueAmount = order.DueAmount;

                    // Order/Delivery status are intentionally left untouched by a refund.
                    _dataContext.Get<Order>().Update(order);
                }

                _dataContext.Get<Payment>().Update(payment);
                _dataContext.Get<Refund>().Add(refund);
                await _dataContext.SaveChangesAsync(cancellationToken);

                _logger.LogInformation(
                    "bKash partial refund recorded: paymentId={PaymentId} refundTrxId={RefundTrxId} " +
                    "remainingAfter={RemainingAfter} newStatus={Status}",
                    payment.Id, response.RefundTrxId, remainingAfter, payment.PaymentStatus);

                return await Result<BkashPartialRefundResult>.SuccessAsync(
                    new BkashPartialRefundResult(
                        response.OriginalTrxId, response.RefundTrxId, response.RefundAmount, remainingAfter,
                        response.TransactionStatus, response.StatusCode, response.StatusMessage),
                    "Partial refund processed successfully.");
            }
        }
    }
}
