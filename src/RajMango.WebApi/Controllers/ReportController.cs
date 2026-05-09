using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [Authorize(Roles = "system_admin,admin")]
    [ApiController]
    [Route("api/reports")]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("orders")]
        public async Task<ActionResult<Result<OrderSummaryReportDto>>> GetOrderSummary(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            return await _mediator.Send(new GetOrderSummaryReportQuery { From = from, To = to });
        }

        [HttpGet("payments")]
        public async Task<ActionResult<Result<PaymentSummaryReportDto>>> GetPaymentSummary(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            return await _mediator.Send(new GetPaymentSummaryReportQuery { From = from, To = to });
        }

        [HttpGet("expenses")]
        public async Task<ActionResult<Result<ExpenseSummaryReportDto>>> GetExpenseSummary(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            return await _mediator.Send(new GetExpenseSummaryReportQuery { From = from, To = to });
        }
    }
}
