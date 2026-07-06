using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    /// <summary>
    /// Admin-triggered recovery for a Pending bKash payment whose callback was never received.
    /// Explicit state-changing operation — kept separate from the read-only Query/Search
    /// diagnostics. Exactly one of PaymentId (bKash gateway paymentID) or TrxId (bKash transaction
    /// ID) must be provided:
    ///   - PaymentId: the payment is looked up directly and its live status re-checked with bKash.
    ///   - TrxId: bKash's Search Transaction is used only to discover which paymentID the
    ///     transaction belongs to; the actual "is it Completed" decision is always made via a
    ///     direct Query Payment call against that paymentID, regardless of entry path — Search's
    ///     own transactionStatus field is not trusted for finalization since it isn't documented
    ///     as being as authoritative as the dedicated status endpoint.
    /// </summary>
    public record ReconcileBkashPaymentCommand(string PaymentId, string TrxId) : IRequest<Result<BkashReconcileResult>>;

    public record BkashReconcileResult(
        string GatewayPaymentId,
        string PreviousStatus,
        string NewStatus,
        string BkashTransactionStatus,
        bool WasFinalized,
        int? OrderId,
        string OrderNumber,
        string OrderPaymentStatus,
        decimal? OrderPaidAmount,
        decimal? OrderDueAmount);

    internal class ReconcileBkashPaymentCommandHandler
        : IRequestHandler<ReconcileBkashPaymentCommand, Result<BkashReconcileResult>>
    {
        private readonly IDataContext _dataContext;
        private readonly IBkashService _bkash;
        private readonly IBkashPaymentFinalizer _finalizer;
        private readonly IPaymentLock _paymentLock;
        private readonly ILogger<ReconcileBkashPaymentCommandHandler> _logger;

        public ReconcileBkashPaymentCommandHandler(
            IDataContext dataContext,
            IBkashService bkash,
            IBkashPaymentFinalizer finalizer,
            IPaymentLock paymentLock,
            ILogger<ReconcileBkashPaymentCommandHandler> logger)
        {
            _dataContext = dataContext;
            _bkash = bkash;
            _finalizer = finalizer;
            _paymentLock = paymentLock;
            _logger = logger;
        }

        public async Task<Result<BkashReconcileResult>> Handle(
            ReconcileBkashPaymentCommand command, CancellationToken cancellationToken)
        {
            var hasPaymentId = !string.IsNullOrWhiteSpace(command.PaymentId);
            var hasTrxId = !string.IsNullOrWhiteSpace(command.TrxId);

            if (!hasPaymentId && !hasTrxId)
                return await Result<BkashReconcileResult>.FailureAsync("Either paymentId or trxId is required.");

            // Shares the global payment lock with create/callback/refund so this can never race
            // an in-flight callback for the same payment.
            using (await _paymentLock.AcquireAsync())
            {
                var gatewayPaymentId = command.PaymentId;

                if (!hasPaymentId)
                {
                    // Discovery only — the trxID tells us which paymentID to reconcile; the actual
                    // Completed/not-Completed decision still comes from Query Payment below.
                    var searchResponse = await _bkash.SearchTransactionAsync(command.TrxId, cancellationToken);
                    if (string.IsNullOrWhiteSpace(searchResponse.PaymentId))
                    {
                        _logger.LogWarning(
                            "bKash reconcile: Search Transaction for trxID={TrxId} did not return an associated paymentID. statusMessage={Message}",
                            command.TrxId, searchResponse.StatusMessage);
                        return await Result<BkashReconcileResult>.FailureAsync(
                            $"bKash did not return an associated paymentID for trxID '{command.TrxId}'. " +
                            $"{searchResponse.StatusMessage}".Trim());
                    }
                    gatewayPaymentId = searchResponse.PaymentId;
                }

                var payment = await _dataContext.Get<Payment>()
                    .Include(p => p.Order)
                    .FirstOrDefaultAsync(p => p.GatewayPaymentId == gatewayPaymentId, cancellationToken);

                if (payment is null)
                {
                    var viaTrx = hasPaymentId ? string.Empty : $" (discovered via trxID '{command.TrxId}')";
                    return await Result<BkashReconcileResult>.FailureAsync(
                        $"No payment found for gateway paymentID '{gatewayPaymentId}'{viaTrx}. " +
                        "This transaction may not have originated from this system — manual investigation required.");
                }

                var previousStatus = payment.PaymentStatus.ToString();

                // Already resolved (by the real callback, a prior reconcile, or an admin refund) —
                // idempotent no-op, just report current state without touching anything. Guarantees
                // this can be called repeatedly without duplicating payments, audit entries, or
                // corrupting totals.
                if (payment.PaymentStatus != PaymentStatus.Pending)
                {
                    return await Result<BkashReconcileResult>.SuccessAsync(
                        BuildResult(payment, gatewayPaymentId, previousStatus, previousStatus, null, false),
                        $"Payment already in status {previousStatus}; nothing to reconcile.");
                }

                var queryResponse = await _bkash.QueryPaymentAsync(gatewayPaymentId, cancellationToken);

                if (string.Equals(queryResponse.TransactionStatus, "Completed", StringComparison.OrdinalIgnoreCase))
                {
                    _logger.LogInformation(
                        "bKash reconcile: paymentID={PaymentId} confirmed Completed via Query — finalizing.",
                        gatewayPaymentId);

                    await _finalizer.FinalizeAsPaidAsync(payment, queryResponse.TrxId, cancellationToken);

                    return await Result<BkashReconcileResult>.SuccessAsync(
                        BuildResult(payment, gatewayPaymentId, previousStatus, PaymentStatus.Paid.ToString(), queryResponse.TransactionStatus, true),
                        "Payment reconciled and marked Paid. Order, dashboards, and reports reflect it immediately since they all read the same synced Order fields.");
                }

                // Anything other than a positive "Completed" confirmation is left untouched —
                // the customer's checkout may still be in progress in another tab/session, so this
                // admin tool deliberately never marks a payment Failed/Cancelled on its own. Stale
                // Pending payments are already handled by the existing PendingPaymentExpiryMinutes
                // mechanism when the customer reopens checkout.
                _logger.LogInformation(
                    "bKash reconcile: paymentID={PaymentId} not Completed at bKash (transactionStatus={Status}); left Pending.",
                    gatewayPaymentId, queryResponse.TransactionStatus);

                return await Result<BkashReconcileResult>.SuccessAsync(
                    BuildResult(payment, gatewayPaymentId, previousStatus, previousStatus, queryResponse.TransactionStatus, false),
                    $"bKash reports transactionStatus={queryResponse.TransactionStatus}; payment left Pending.");
            }
        }

        private static BkashReconcileResult BuildResult(
            Payment payment, string gatewayPaymentId, string previousStatus, string newStatus,
            string bkashTransactionStatus, bool wasFinalized)
        {
            var order = payment.Order;
            return new BkashReconcileResult(
                gatewayPaymentId, previousStatus, newStatus, bkashTransactionStatus, wasFinalized,
                order?.Id, order?.OrderNumber, order?.PaymentStatus.ToString(), order?.PaidAmount, order?.DueAmount);
        }
    }
}
