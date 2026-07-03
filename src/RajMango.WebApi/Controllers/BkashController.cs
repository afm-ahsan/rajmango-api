using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs.Bkash;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;

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
        /// Admin: query a payment's current status directly from bKash by paymentID.
        /// Useful for diagnosing payments where the callback was not received.
        /// </summary>
        [Authorize]
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
        /// Admin: search a bKash transaction by trxID.
        /// </summary>
        [Authorize]
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
        /// Admin: initiate a refund for a completed bKash payment.
        /// Requires the original paymentID and trxID from the Payments table.
        /// </summary>
        [Authorize]
        [HttpPost("bkash/refund")]
        public async Task<ActionResult<Result<BkashRefundResult>>> Refund(
            [FromBody] BkashRefundRequest request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request?.PaymentId) || string.IsNullOrWhiteSpace(request.TrxId))
                return BadRequest("paymentId and trxId are required.");

            if (request.Amount <= 0)
                return BadRequest("amount must be greater than zero.");

            return await _mediator.Send(new RefundBkashPaymentCommand(
                request.PaymentId,
                request.TrxId,
                request.Amount,
                request.Sku,
                request.Reason), cancellationToken);
        }
    }

    // ── Request models (thin, bKash-controller-scoped) ──────────────────────────
    public record BkashQueryRequest(string PaymentId);
    public record BkashSearchRequest(string TrxId);
    public record BkashRefundRequest(string PaymentId, string TrxId, decimal Amount, string Sku, string Reason);
}
