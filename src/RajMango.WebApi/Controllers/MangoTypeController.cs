using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/mango-type")]
    public class MangoTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public MangoTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllMangoTypeDto>>>> Get()
        {
            return await _mediator.Send(new GetAllMangoTypeQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetMangoTypeByIdDto>>> GetById(int id) 
        {
            return await _mediator.Send(new GetMangoTypeByIdQuery(id));
        }

        [HttpGet("count")]
        public async Task<ActionResult<Result<GetMangoTypeCountDto>>> GetCount()
        {
            return await _mediator.Send(new GetMangoTypeCountQuery());
        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult<PaginatedResult<GetMangoTypeWithPaginationDto>>> GetCategoryWithPagination([FromQuery] GetMangoTypeWithPaginationQuery query)
        {
            var validator = new GetMangoTypeWithPaginationValidator();

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
        //public async Task<IEnumerable<CategoryInformationDto>> GetPagedAndSortedResult([FromQuery] PagedAndSortedDto inputDto)
        //{
        //    try
        //    {
        //        var userInfo = await _userInformationRepository.GetAsync(filter: x => x.deleted_at == null,
        //                                                        orderBy: x => x.OrderBy(o => o.id),
        //                                                        inputDto.SkipCount,
        //                                                        inputDto.MaxResultCount);
        //        var mappedInfo = _mapper.Map<IEnumerable<CategoryInformationDto>>(userInfo);
        //        return mappedInfo;
        //    }
        //    catch (Exception ex)
        //    {
        //        _errorHandler.Handle(ex);
        //        throw;
        //    }
        //}

        [HttpPost]
        [Authorize(Roles = "system_admin,admin")]
        public async Task<ActionResult<Result<int>>> Create(CreateMangoTypeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "system_admin,admin")]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateMangoTypeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "system_admin,admin")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteMangoTypeCommand { Id = id });
        }
    }
}