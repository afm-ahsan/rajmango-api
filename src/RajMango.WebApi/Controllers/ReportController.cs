using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Queries;
using RajMango.Shared;
using RajMango.WebApi.Services;

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

        [HttpGet("orders/export")]
        public async Task<IActionResult> ExportOrders(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            var result = await _mediator.Send(new GetOrderSummaryReportQuery { From = from, To = to });
            if (!result.Succeeded) return BadRequest(result.Messages);

            var bytes = ExcelExportService.ExportOrderSummary(result.Data);
            var fileName = $"orders_{from:yyyyMMdd}_{to:yyyyMMdd}.xlsx";
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        [HttpGet("payments")]
        public async Task<ActionResult<Result<PaymentSummaryReportDto>>> GetPaymentSummary(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            return await _mediator.Send(new GetPaymentSummaryReportQuery { From = from, To = to });
        }

        [HttpGet("payments/export")]
        public async Task<IActionResult> ExportPayments(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            var result = await _mediator.Send(new GetPaymentSummaryReportQuery { From = from, To = to });
            if (!result.Succeeded) return BadRequest(result.Messages);

            var bytes = ExcelExportService.ExportPaymentSummary(result.Data);
            var fileName = $"payments_{from:yyyyMMdd}_{to:yyyyMMdd}.xlsx";
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        [HttpGet("expenses")]
        public async Task<ActionResult<Result<ExpenseSummaryReportDto>>> GetExpenseSummary(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            return await _mediator.Send(new GetExpenseSummaryReportQuery { From = from, To = to });
        }

        [HttpGet("expenses/export")]
        public async Task<IActionResult> ExportExpenses(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            var result = await _mediator.Send(new GetExpenseSummaryReportQuery { From = from, To = to });
            if (!result.Succeeded) return BadRequest(result.Messages);

            var bytes = ExcelExportService.ExportExpenseSummary(result.Data);
            var fileName = $"expenses_{from:yyyyMMdd}_{to:yyyyMMdd}.xlsx";
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
