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
    /// Full refund only — PaymentId identifies the internal Payment row (not a bKash gateway ID),
    /// so the frontend never needs to know or send bKash's opaque paymentID/trxID/amount fields.
    /// </summary>
    public record RefundBkashPaymentCommand(int PaymentId, string Reason) : IRequest<Result<BkashRefundResult>>;

    public record BkashRefundResult(
        string OriginalPaymentId,
        string OriginalTrxId,
        string RefundTrxId,
        string Amount,
        string TransactionStatus,
        string StatusCode,
        string StatusMessage);

    internal class RefundBkashPaymentCommandHandler
        : IRequestHandler<RefundBkashPaymentCommand, Result<BkashRefundResult>>
    {
        private readonly IBkashService _bkash;
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPaymentLock _paymentLock;
        private readonly ILogger<RefundBkashPaymentCommandHandler> _logger;

        public RefundBkashPaymentCommandHandler(
            IBkashService bkash,
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            IPaymentLock paymentLock,
            ILogger<RefundBkashPaymentCommandHandler> logger)
        {
            _bkash = bkash;
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _paymentLock = paymentLock;
            _logger = logger;
        }

        public async Task<Result<BkashRefundResult>> Handle(
            RefundBkashPaymentCommand command, CancellationToken cancellationToken)
        {
            // Shares the global payment lock with create/callback so a refund can never race
            // a concurrent callback (or a double-click double-refund) for the same payment.
            using (await _paymentLock.AcquireAsync())
            {
                var payment = await _dataContext.Get<Domain.Entities.Payment>()
                    .Include(p => p.Order)
                    .FirstOrDefaultAsync(p => p.Id == command.PaymentId, cancellationToken);

                if (payment is null)
                    return await Result<BkashRefundResult>.FailureAsync(
                        $"Payment {command.PaymentId} not found.");

                if (payment.PaymentMethod != PaymentMethod.Bkash)
                    return await Result<BkashRefundResult>.FailureAsync(
                        "Only bKash payments can be refunded through this action.");

                // PaymentStatus != Paid also covers "already refunded" (status would be Refunded).
                if (payment.PaymentStatus != PaymentStatus.Paid)
                    return await Result<BkashRefundResult>.FailureAsync(
                        $"Payment is not in a refundable state (current status: {payment.PaymentStatus}).");

                if (string.IsNullOrWhiteSpace(payment.GatewayPaymentId) || string.IsNullOrWhiteSpace(payment.TransactionId))
                    return await Result<BkashRefundResult>.FailureAsync(
                        "Payment is missing bKash gateway identifiers and cannot be refunded.");

                var order = payment.Order;
                var amount = payment.PaidAmount; // full refund only — no partial refund support yet

                _logger.LogInformation(
                    "bKash refund initiated: paymentId={PaymentId} gatewayPaymentId={GatewayPaymentId} trxId={TrxId} amount={Amount} byUserId={UserId}",
                    payment.Id, payment.GatewayPaymentId, payment.TransactionId, amount, _currentUserService.UserId);

                var response = await _bkash.RefundPaymentAsync(
                    payment.GatewayPaymentId,
                    payment.TransactionId,
                    amount,
                    sku: order?.OrderNumber ?? string.Empty,
                    reason: command.Reason ?? string.Empty,
                    cancellationToken);

                var result = new BkashRefundResult(
                    OriginalPaymentId: response.OriginalPaymentId,
                    OriginalTrxId: response.OriginalTrxId,
                    RefundTrxId: response.RefundTrxId,
                    Amount: response.Amount,
                    TransactionStatus: response.TransactionStatus,
                    StatusCode: response.StatusCode,
                    StatusMessage: response.StatusMessage);

                if (!string.Equals(response.StatusCode, "0000"))
                {
                    _logger.LogWarning(
                        "bKash refund not confirmed: paymentId={PaymentId} statusCode={Code} statusMessage={Message}",
                        payment.Id, response.StatusCode, response.StatusMessage);
                    return await Result<BkashRefundResult>.FailureAsync(
                        result, response.StatusMessage ?? "Refund was not confirmed by bKash.");
                }

                // Confirmed refunded — update payment, recalc order, persist refund audit row.
                payment.PaymentStatus = PaymentStatus.Refunded;
                payment.RefundedAmount = amount;

                var refund = new Refund
                {
                    PaymentId = payment.Id,
                    RefundAmount = amount,
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
                    // mutated above — mirrors the same NoTracking-safe pattern used by the
                    // bKash callback handler, so the recalculation sees this refund immediately.
                    var allPayments = await _dataContext.Get<Domain.Entities.Payment>()
                        .Where(p => p.OrderId == order.Id && p.Id != payment.Id)
                        .ToListAsync(cancellationToken);
                    allPayments.Add(payment);

                    PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);
                    payment.DueAmount = order.DueAmount;

                    // Order/Delivery status are intentionally left untouched by a refund.
                    _dataContext.Get<Order>().Update(order);
                }

                _dataContext.Get<Domain.Entities.Payment>().Update(payment);
                _dataContext.Get<Refund>().Add(refund);
                await _dataContext.SaveChangesAsync(cancellationToken);

                _logger.LogInformation(
                    "bKash refund recorded: paymentId={PaymentId} refundTrxId={RefundTrxId} orderId={OrderId}",
                    payment.Id, response.RefundTrxId, payment.OrderId);

                return await Result<BkashRefundResult>.SuccessAsync(result, "Refund processed successfully.");
            }
        }
    }
}
