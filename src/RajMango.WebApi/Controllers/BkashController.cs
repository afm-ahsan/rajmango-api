using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Bkash;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/bkash")]
    public class BkashController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BkashController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Step 1: Initiate a bKash payment for an order.
        /// Returns a paymentId and bkashUrl to redirect the user to bKash.
        /// </summary>
        [HttpPost("initiate")]
        public async Task<ActionResult<Result<InitiateBkashPaymentResponse>>> Initiate(
            [FromBody] InitiateBkashPaymentCommand command, CancellationToken cancellationToken)
        {
            var validator = new InitiateBkashPaymentCommandValidator();
            var result = validator.Validate(command);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            return await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// Step 2: Execute the bKash payment after the user approves on the bKash page.
        /// The frontend sends back the paymentId received from the bKash callback URL.
        /// </summary>
        [HttpPost("execute")]
        public async Task<ActionResult<Result<int>>> Execute(
            [FromBody] ExecuteBkashPaymentCommand command, CancellationToken cancellationToken)
        {
            var validator = new ExecuteBkashPaymentCommandValidator();
            var result = validator.Validate(command);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            return await _mediator.Send(command, cancellationToken);
        }
    }
}
