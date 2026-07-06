using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs.Bkash;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Application.Interfaces;
using RajMango.Shared;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class BkashController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BkashController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Initiate a bKash tokenized payment for an order.
        /// Returns the bKash checkout URL; the frontend must redirect the customer there.
        /// </summary>
        [Authorize]
        [HttpPost("bkash/create")]
        public async Task<ActionResult<Result<BkashInitiateResponseDto>>> Create(
            [FromBody] InitiateBkashPaymentCommand command,
            CancellationToken cancellationToken)
        {
            if (command.OrderId <= 0)
                return BadRequest("A valid OrderId is required.");

            return await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// bKash payment callback.
        /// Called by the bKash gateway after the customer completes, cancels, or fails payment.
        /// Always performs a browser redirect — never returns JSON.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("bkash/callback")]
        public async Task<IActionResult> Callback(
            [FromQuery] string paymentID,
            [FromQuery] string status,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new BkashCallbackCommand
            {
                PaymentId = paymentID,
                Status = status,
            }, cancellationToken);

            return Redirect(result.RedirectUrl);
        }

        /// <summary>
        /// Get all payments for a specific order.
        /// Customers see only their own orders; admins see all.
        /// </summary>
        [Authorize]
        [HttpGet("order/{orderId:int}")]
        public async Task<ActionResult<Result<List<GetOrderPaymentDto>>>> GetByOrder(
            int orderId,
            CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetOrderPaymentsQuery(orderId), cancellationToken);
        }

        /// <summary>
        /// Public — backs the /orders/bkash-success|failed|cancelled result pages, which must
        /// render even if the customer's session lapsed during their time on bKash's hosted
        /// checkout page. Read-only "what happened" view keyed by bKash's own paymentID (the only
        /// reference bKash echoes back on redirect); the payment itself is already fully processed
        /// server-side by this point via the callback. Never returns OrderId/UserId/internal Payment.Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("bkash/result")]
        public async Task<ActionResult<Result<BkashPaymentResultDto>>> GetResult(
            // Nullable — a missing paymentId is a normal case (e.g. the frontend query string was
            // stripped/malformed), handled gracefully as a Result<T> failure below rather than an
            // implicit-required 400 (this project has Nullable enabled, which would otherwise
            // reject a non-nullable string parameter before this method body ever runs).
            [FromQuery] string? paymentId,
            CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetBkashPaymentResultQuery(paymentId ?? string.Empty), cancellationToken);
        }

        /// <summary>
        /// System Admin/Admin only: query a payment's current status directly from bKash by
        /// paymentID. Useful for diagnosing payments where the callback was not received.
        /// Read-only — see Reconcile below to actually recover a stuck Pending payment.
        /// </summary>
        [RequirePermission(Permissions.Payments.AdminReconcile)]
        [HttpPost("bkash/query")]
        public async Task<ActionResult<Result<BkashQueryResult>>> QueryPayment(
            [FromBody] BkashQueryRequest request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request?.PaymentId))
                return BadRequest("paymentId is required.");

            return await _mediator.Send(new QueryBkashPaymentQuery(request.PaymentId), cancellationToken);
        }

        /// <summary>
        /// System Admin/Admin only: search a bKash transaction by trxID. Read-only diagnostic —
        /// an arbitrary trxID lookup isn't safely scoped to a specific known payment, so this
        /// never writes back to our data (use Query + Reconcile for a payment we already track).
        /// </summary>
        [RequirePermission(Permissions.Payments.AdminReconcile)]
        [HttpPost("bkash/search")]
        public async Task<ActionResult<Result<BkashSearchTransactionResult>>> SearchTransaction(
            [FromBody] BkashSearchRequest request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request?.TrxId))
                return BadRequest("trxId is required.");

            return await _mediator.Send(new SearchBkashTransactionQuery(request.TrxId), cancellationToken);
        }

        /// <summary>
        /// System Admin/Admin only: explicit, state-changing recovery for a Pending bKash payment
        /// whose callback was never received (network blip, IIS recycle, gateway timeout, etc.).
        /// Deliberately separate from the read-only Query/Search diagnostics above — this is the
        /// only bKash endpoint besides Refund that writes to the database outside the callback.
        ///
        /// Provide exactly one of paymentId or trxId:
        ///   - paymentId: the bKash gateway paymentID (as used by Create/Callback/Query).
        ///   - trxId: a bKash transaction ID — Search Transaction is used only to discover which
        ///     paymentID it belongs to; finalization always goes through a direct Query Payment
        ///     call against that paymentID (Search's own status field is never trusted directly).
        ///
        /// If bKash confirms Completed: updates the Payment record, recalculates the Order's
        /// PaidAmount/DueAmount/PaymentStatus (the same fields dashboards and reports read), and
        /// returns the resulting payment + order status. Idempotent — calling this again for an
        /// already-resolved payment is a no-op; it never duplicates payments, audit entries, or
        /// corrupts totals. Any status other than Completed leaves the payment untouched, since
        /// the customer's checkout may still be in progress.
        /// </summary>
        [RequirePermission(Permissions.Payments.AdminReconcile)]
        [HttpPost("bkash/reconcile")]
        public async Task<ActionResult<Result<BkashReconcileResult>>> Reconcile(
            [FromBody] BkashReconcileRequest request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request?.PaymentId) && string.IsNullOrWhiteSpace(request?.TrxId))
                return BadRequest("Either paymentId or trxId is required.");

            return await _mediator.Send(new ReconcileBkashPaymentCommand(request.PaymentId, request.TrxId), cancellationToken);
        }

        /// <summary>
        /// System Admin/Admin only diagnostic — ensures a bKash token is cached (reuses the cache
        /// or performs a Grant Token), without ever exposing the token itself.
        /// </summary>
        [RequirePermission(Permissions.Payments.AdminReconcile)]
        [HttpPost("bkash/token/ensure")]
        public async Task<ActionResult<BkashTokenStatusResponse>> EnsureToken(
            [FromServices] IBkashService bkash, CancellationToken cancellationToken)
            => await bkash.EnsureTokenAsync(cancellationToken);

        /// <summary>
        /// System Admin/Admin only diagnostic — forces a bKash token refresh cycle (or falls back
        /// to a full Grant Token), without ever exposing the token itself.
        /// </summary>
        [RequirePermission(Permissions.Payments.AdminReconcile)]
        [HttpPost("bkash/token/refresh")]
        public async Task<ActionResult<BkashTokenStatusResponse>> RefreshToken(
            [FromServices] IBkashService bkash, CancellationToken cancellationToken)
            => await bkash.ForceRefreshTokenAsync(cancellationToken);

        /// <summary>
        /// System Admin/Admin only: full refund of a completed bKash payment.
        /// paymentId is the internal Payment.Id (not the bKash gateway paymentID) — the handler
        /// looks up the gateway identifiers and refunds the full remaining paid amount.
        /// For a partial amount, use POST {paymentId}/refund/partial instead.
        /// </summary>
        [RequirePermission(Permissions.Payments.AdminRefund)]
        [HttpPost("{paymentId:int}/refund")]
        public async Task<ActionResult<Result<BkashRefundResult>>> Refund(
            int paymentId,
            [FromBody] BkashRefundRequest request,
            CancellationToken cancellationToken)
        {
            return await _mediator.Send(new RefundBkashPaymentCommand(paymentId, request?.Reason), cancellationToken);
        }

        /// <summary>
        /// System Admin/Admin only: partial refund of a completed (or previously
        /// partially-refunded) bKash payment. paymentId is the internal Payment.Id.
        /// Multiple partial refunds are allowed as long as their cumulative total never exceeds
        /// the amount actually paid.
        /// </summary>
        [RequirePermission(Permissions.Payments.AdminRefund)]
        [HttpPost("{paymentId:int}/refund/partial")]
        public async Task<ActionResult<Result<BkashPartialRefundResult>>> PartialRefund(
            int paymentId,
            [FromBody] BkashPartialRefundRequest request,
            CancellationToken cancellationToken)
        {
            if (request is null || request.RefundAmount <= 0)
                return BadRequest("refundAmount must be greater than zero.");

            return await _mediator.Send(
                new PartialRefundBkashPaymentCommand(paymentId, request.RefundAmount, request.Reason), cancellationToken);
        }

        /// <summary>
        /// System Admin/Admin only: refund history + remaining refundable amount for a payment,
        /// combining our own Refund records with bKash's live refund status.
        /// </summary>
        [RequirePermission(Permissions.Payments.AdminReconcile)]
        [HttpGet("{paymentId:int}/refund/status")]
        public async Task<ActionResult<Result<BkashRefundStatusDto>>> RefundStatus(
            int paymentId,
            CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetBkashRefundStatusQuery(paymentId), cancellationToken);
        }
    }

    // ── Request models (thin, bKash-controller-scoped) ──────────────────────────
    public record BkashQueryRequest(string PaymentId);
    public record BkashSearchRequest(string TrxId);
    // Both nullable — exactly one is required, enforced manually in Reconcile() below. Making
    // these non-nullable would make ASP.NET Core's implicit-required-for-non-nullable-reference-type
    // model validation reject any request that omits either field, before the manual "at least
    // one" check ever runs.
    public record BkashReconcileRequest(string? PaymentId, string? TrxId);
    public record BkashRefundRequest(string Reason);
    public record BkashPartialRefundRequest(decimal RefundAmount, string Reason);
}
