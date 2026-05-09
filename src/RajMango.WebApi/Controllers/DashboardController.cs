using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("customer")]
        public async Task<ActionResult<Result<CustomerDashboardDto>>> GetCustomerDashboard()
        {
            return await _mediator.Send(new GetCustomerDashboardQuery());
        }

        [HttpGet("admin")]
        [Authorize(Roles = "system_admin,admin")]
        public async Task<ActionResult<Result<AdminDashboardDto>>> GetAdminDashboard()
        {
            return await _mediator.Send(new GetAdminDashboardQuery());
        }
    }
}
