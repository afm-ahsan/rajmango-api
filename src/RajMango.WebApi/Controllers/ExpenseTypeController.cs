using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [Authorize(Roles = "system_admin,admin")]
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
        public async Task<ActionResult<Result<List<GetAllExpenseTypeDto>>>> Get()
        {
            return await _mediator.Send(new GetAllExpenseTypeQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetExpenseTypeByIdDto>>> GetById(int id) 
        {
            return await _mediator.Send(new GetExpenseTypeByIdQuery(id));
        }

        [HttpGet("count")]
        public async Task<ActionResult<Result<GetExpenseTypeCountDto>>> GetCount()
        {
            return await _mediator.Send(new GetExpenseTypeCountQuery());
        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult<PaginatedResult<GetExpenseTypeWithPaginationDto>>> GetExpenseTypeWithPagination([FromQuery] GetExpenseTypeWithPaginationQuery query)
        {
            var validator = new GetExpenseTypeWithPaginationValidator();

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
        //public async Task<IEnumerable<ExpenseTypeInformationDto>> GetPagedAndSortedResult([FromQuery] PagedAndSortedDto inputDto)
        //{
        //    try
        //    {
        //        var userInfo = await _userInformationRepository.GetAsync(filter: x => x.deleted_at == null,
        //                                                        orderBy: x => x.OrderBy(o => o.id),
        //                                                        inputDto.SkipCount,
        //                                                        inputDto.MaxResultCount);
        //        var mappedInfo = _mapper.Map<IEnumerable<ExpenseTypeInformationDto>>(userInfo);
        //        return mappedInfo;
        //    }
        //    catch (Exception ex)
        //    {
        //        _errorHandler.Handle(ex);
        //        throw;
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateExpenseTypeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateExpenseTypeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteExpenseTypeCommand { Id = id });
        }
    }
}