using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RajMango.WebApi.Controllers
{
    [Authorize(Roles = "system_admin,admin")]
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllPaymentDto>>>> Get()
        {
            return await _mediator.Send(new GetAllPaymentQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetPaymentByIdDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetPaymentByIdQuery(id));
        }

        [HttpGet("count")]
        public async Task<ActionResult<Result<GetPaymentCountDto>>> GetCount()
        {
            return await _mediator.Send(new GetPaymentCountQuery());
        }

        [HttpGet("paged")]
        public async Task<ActionResult<PaginatedResult<GetPaymentWithPaginationDto>>> GetPaged([FromQuery] GetPaymentWithPaginationQuery query)
        {
            var validator = new GetPaymentWithPaginationValidator();
            var result = validator.Validate(query);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(errorMessages);
            }

            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create([FromBody] CreatePaymentCommand command)
        {
            var validator = new CreatePaymentCommandValidator();
            var result = validator.Validate(command);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(errorMessages);
            }

            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdatePaymentCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var validator = new UpdatePaymentCommandValidator();
            var result = validator.Validate(command);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(errorMessages);
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeletePaymentCommand { Id = id });
        }
    }
}
