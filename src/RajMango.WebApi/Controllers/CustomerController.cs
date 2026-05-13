using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [RequirePermission(Permissions.Customers.View)]
        public async Task<ActionResult<Result<List<GetAllCustomerDto>>>> Get()
        {
            return await _mediator.Send(new GetAllCustomerQuery());
        }

        [HttpGet("{id}")]
        [RequirePermission(Permissions.Customers.View)]
        public async Task<ActionResult<Result<GetCustomerByIdDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetCustomerByIdQuery(id));
        }

        [HttpGet("count")]
        [RequirePermission(Permissions.Customers.View)]
        public async Task<ActionResult<Result<GetCustomerCountDto>>> GetCount()
        {
            return await _mediator.Send(new GetCustomersCountQuery());
        }

        [HttpGet]
        [Route("paged")]
        [RequirePermission(Permissions.Customers.View)]
        public async Task<ActionResult<PaginatedResult<GetCustomerWithPaginationDto>>> GetCustomerWithPagination([FromQuery] GetCustomerWithPaginationQuery query)
        {
            var validator = new GetCustomerWithPaginationValidator();
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpPost]
        [RequirePermission(Permissions.Customers.Create)]
        public async Task<ActionResult<Result<int>>> Create(CreateCustomerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [RequirePermission(Permissions.Customers.Update)]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [RequirePermission(Permissions.Customers.Delete)]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteCustomerCommand { Id = id });
        }
    }
}
