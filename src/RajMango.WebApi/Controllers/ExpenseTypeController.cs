using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/expense-type")]
    public class ExpenseTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [RequirePermission(Permissions.ExpenseTypes.View)]
        public async Task<ActionResult<Result<List<GetAllExpenseTypeDto>>>> Get()
        {
            return await _mediator.Send(new GetAllExpenseTypeQuery());
        }

        [HttpGet("{id}")]
        [RequirePermission(Permissions.ExpenseTypes.View)]
        public async Task<ActionResult<Result<GetExpenseTypeByIdDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetExpenseTypeByIdQuery(id));
        }

        [HttpGet("count")]
        [RequirePermission(Permissions.ExpenseTypes.View)]
        public async Task<ActionResult<Result<GetExpenseTypeCountDto>>> GetCount()
        {
            return await _mediator.Send(new GetExpenseTypeCountQuery());
        }

        [HttpGet]
        [Route("paged")]
        [RequirePermission(Permissions.ExpenseTypes.View)]
        public async Task<ActionResult<PaginatedResult<GetExpenseTypeWithPaginationDto>>> GetExpenseTypeWithPagination([FromQuery] GetExpenseTypeWithPaginationQuery query)
        {
            var validator = new GetExpenseTypeWithPaginationValidator();
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpPost]
        [RequirePermission(Permissions.ExpenseTypes.Create)]
        public async Task<ActionResult<Result<int>>> Create(CreateExpenseTypeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [RequirePermission(Permissions.ExpenseTypes.Update)]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateExpenseTypeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [RequirePermission(Permissions.ExpenseTypes.Delete)]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteExpenseTypeCommand { Id = id });
        }
    }
}
