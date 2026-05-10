using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Complaint.Commands;
using RajMango.Application.Features.Complaint.Queries;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/complaint")]
    public class ComplaintController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComplaintController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Submit a complaint against an order (customer).</summary>
        [HttpPost]
        public async Task<ActionResult<Result<int>>> Submit([FromBody] SubmitComplaintCommand command)
        {
            var validator = new SubmitComplaintCommandValidator();
            var result = validator.Validate(command);

            if (!result.IsValid)
                return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToList());

            return await _mediator.Send(command);
        }

        /// <summary>Get my own complaints (customer).</summary>
        [HttpGet("mine")]
        public async Task<ActionResult<Result<List<ComplaintDto>>>> GetMine()
        {
            return await _mediator.Send(new GetMyComplaintsQuery());
        }

        /// <summary>Get a complaint by Id (own complaint for customer, any for admin).</summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<ComplaintDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetComplaintByIdQuery(id));
        }

        /// <summary>Get all complaints (admin only).</summary>
        [HttpGet]
        [Authorize(Roles = "system_admin,admin")]
        public async Task<ActionResult<Result<List<ComplaintDto>>>> GetAll()
        {
            return await _mediator.Send(new GetAllComplaintsQuery());
        }

        /// <summary>Update complaint status (admin only).</summary>
        [HttpPatch("{id}/status")]
        [Authorize(Roles = "system_admin,admin")]
        public async Task<ActionResult<Result<int>>> UpdateStatus(int id, [FromBody] UpdateComplaintStatusCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return await _mediator.Send(command);
        }
    }
}
