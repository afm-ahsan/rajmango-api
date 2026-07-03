using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using System.Text.Json;

namespace RajMango.Application.Features.Commands
{
    public record RefundBkashPaymentCommand(
        string PaymentId,
        string TrxId,
        decimal Amount,
        string Sku,
        string Reason) : IRequest<Result<BkashRefundResult>>;

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
        private readonly ILogger<RefundBkashPaymentCommandHandler> _logger;

        public RefundBkashPaymentCommandHandler(
            IBkashService bkash,
            IDataContext dataContext,
            ILogger<RefundBkashPaymentCommandHandler> logger)
        {
            _bkash = bkash;
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<Result<BkashRefundResult>> Handle(
            RefundBkashPaymentCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(command.PaymentId) || string.IsNullOrWhiteSpace(command.TrxId))
                return await Result<BkashRefundResult>.FailureAsync("PaymentId and TrxId are required.");

            if (command.Amount <= 0)
                return await Result<BkashRefundResult>.FailureAsync("Refund amount must be greater than zero.");

            // Verify the payment exists and is in Paid status before attempting refund.
            var payment = await _dataContext.Get<Domain.Entities.Payment>()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.GatewayPaymentId == command.PaymentId, cancellationToken);

            if (payment is null)
                return await Result<BkashRefundResult>.FailureAsync(
                    $"No payment record found for paymentID '{command.PaymentId}'.");

            if (payment.PaymentStatus != PaymentStatus.Paid)
                return await Result<BkashRefundResult>.FailureAsync(
                    $"Payment is not in Paid status (current: {payment.PaymentStatus}). Only Paid payments can be refunded.");

            if (command.Amount > payment.PaidAmount)
                return await Result<BkashRefundResult>.FailureAsync(
                    $"Refund amount ({command.Amount}) exceeds paid amount ({payment.PaidAmount}).");

            _logger.LogInformation(
                "bKash refund initiated: paymentId={PaymentId} trxId={TrxId} amount={Amount} reason={Reason}",
                command.PaymentId, command.TrxId, command.Amount, command.Reason);

            var response = await _bkash.RefundPaymentAsync(
                command.PaymentId, command.TrxId, command.Amount,
                command.Sku ?? string.Empty, command.Reason ?? string.Empty, cancellationToken);

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
                    command.PaymentId, response.StatusCode, response.StatusMessage);
                return await Result<BkashRefundResult>.FailureAsync(
                    result, response.StatusMessage ?? "Refund was not confirmed by bKash.");
            }

            // Update payment record to Refunded so dashboards and reports reflect the change.
            var tracked = await _dataContext.Get<Domain.Entities.Payment>()
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.GatewayPaymentId == command.PaymentId, cancellationToken);

            if (tracked != null)
            {
                tracked.PaymentStatus = PaymentStatus.Refunded;
                tracked.RawExecuteResponse = JsonSerializer.Serialize(response); // reuse field for refund response
                _dataContext.Get<Domain.Entities.Payment>().Update(tracked);
                await _dataContext.SaveChangesAsync(cancellationToken);

                _logger.LogInformation(
                    "bKash refund recorded: paymentId={PaymentId} refundTrxId={RefundTrxId} orderId={OrderId}",
                    command.PaymentId, response.RefundTrxId, tracked.OrderId);
            }

            return await Result<BkashRefundResult>.SuccessAsync(result, "Refund processed successfully.");
        }
    }
}
