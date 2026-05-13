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
    [Route("api/expense")]
    public class ExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ExpenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [RequirePermission(Permissions.Expenses.View)]
        public async Task<ActionResult<Result<List<GetAllExpenseDto>>>> Get()
        {
            return await _mediator.Send(new GetAllExpenseQuery());
        }

        [HttpGet("{id}")]
        [RequirePermission(Permissions.Expenses.View)]
        public async Task<ActionResult<Result<GetExpenseByIdDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetExpenseByIdQuery(id));
        }

        [HttpGet("count")]
        [RequirePermission(Permissions.Expenses.View)]
        public async Task<ActionResult<Result<GetExpenseCountDto>>> GetCount()
        {
            return await _mediator.Send(new GetExpenseCountQuery());
        }

        [HttpGet]
        [Route("paged")]
        [RequirePermission(Permissions.Expenses.View)]
        public async Task<ActionResult<PaginatedResult<GetExpenseWithPaginationDto>>> GetExpenseWithPagination([FromQuery] GetExpenseWithPaginationQuery query)
        {
            var validator = new GetExpenseWithPaginationValidator();

            // Call Validate or ValidateAsync and pass the object which needs to be validated
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        //[HttpGet]
        //[Route("GetPagedAndSortedResult")]
        //public async Task<IEnumerable<ExpenseInformationDto>> GetPagedAndSortedResult([FromQuery] PagedAndSortedDto inputDto)
        //{
        //    try
        //    {
        //        var userInfo = await _userInformationRepository.GetAsync(filter: x => x.deleted_at == null,
        //                                                        orderBy: x => x.OrderBy(o => o.id),
        //                                                        inputDto.SkipCount,
        //                                                        inputDto.MaxResultCount);
        //        var mappedInfo = _mapper.Map<IEnumerable<ExpenseInformationDto>>(userInfo);
        //        return mappedInfo;
        //    }
        //    catch (Exception ex)
        //    {
        //        _errorHandler.Handle(ex);
        //        throw;
        //    }
        //}

        [HttpPost]
        [RequirePermission(Permissions.Expenses.Create)]
        public async Task<ActionResult<Result<int>>> Create(CreateExpenseCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [RequirePermission(Permissions.Expenses.Update)]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateExpenseCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [RequirePermission(Permissions.Expenses.Delete)]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteExpenseCommand { Id = id });
        }
    }
}