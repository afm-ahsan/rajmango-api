using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/mango-availability")]
    public class MangoAvailabilityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MangoAvailabilityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<MangoAvailabilityDto>>>> Get()
        {
            return await _mediator.Send(new GetAllMangoAvailabilityQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<MangoAvailabilityDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetMangoAvailabilityByIdQuery(id));
        }

        /// <summary>
        /// Returns mango types currently Available within today's date range.
        /// Used by the order placement page and the seasonal calendar.
        /// </summary>
        [HttpGet("active")]
        public async Task<ActionResult<Result<List<MangoAvailabilityDto>>>> GetActive()
        {
            return await _mediator.Send(new GetActiveMangoAvailabilityQuery());
        }

        [HttpPost]
        [Authorize(Roles = "system_admin,admin")]
        public async Task<ActionResult<Result<int>>> Create([FromBody] CreateMangoAvailabilityCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "system_admin,admin")]
        public async Task<ActionResult<Result<int>>> Update(int id, [FromBody] UpdateMangoAvailabilityCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return await _mediator.Send(command);
        }

        [HttpPatch("{id}/status")]
        [Authorize(Roles = "system_admin,admin")]
        public async Task<ActionResult<Result<int>>> UpdateStatus(int id, [FromBody] UpdateMangoAvailabilityStatusCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "system_admin,admin")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteMangoAvailabilityCommand { Id = id });
        }
    }
}
