using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    /// <summary>
    /// One-time data-repair tooling for the bKash payment-sync bug fixed alongside this controller.
    /// System Admin only — this is a raw cross-order data-fix tool, not a routine admin feature.
    /// Also gated by Maintenance:PaymentSyncBackfillEnabled — off by default in production; flip on
    /// only while a backfill is actively being run, then flip back off. Always on in Development.
    /// </summary>
    [ApiController]
    [Route("api/payment-maintenance")]
    [Authorize(Roles = "system_admin")]
    public class PaymentMaintenanceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public PaymentMaintenanceController(
            IMediator mediator,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            _mediator = mediator;
            _configuration = configuration;
            _environment = environment;
        }

        private bool IsEnabled =>
            _environment.IsDevelopment() || _configuration.GetValue<bool>("Maintenance:PaymentSyncBackfillEnabled");

        /// <summary>
        /// Dry-run — read-only. Lists orders whose stored payment summary disagrees with what
        /// the sync logic would compute from their Paid payments today.
        /// </summary>
        [HttpGet("payment-sync-drift")]
        public async Task<ActionResult<Result<List<OrderPaymentSyncDriftDto>>>> GetDrift(
            CancellationToken cancellationToken)
        {
            if (!IsEnabled) return NotFound();
            return await _mediator.Send(new GetOrderPaymentSyncDriftQuery(), cancellationToken);
        }

        /// <summary>
        /// Applies the fix. Pass the exact order IDs from the dry-run's output; an empty/omitted
        /// list applies to every currently-drifted order.
        /// </summary>
        [HttpPost("payment-sync-backfill")]
        public async Task<ActionResult<Result<List<int>>>> ApplyBackfill(
            [FromBody] List<int> orderIds,
            CancellationToken cancellationToken)
        {
            if (!IsEnabled) return NotFound();
            return await _mediator.Send(new BackfillOrderPaymentSyncCommand(orderIds ?? new List<int>()), cancellationToken);
        }
    }
}
