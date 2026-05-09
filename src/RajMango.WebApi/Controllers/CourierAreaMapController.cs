using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs;
using RajMango.Application.Features;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [Authorize(Roles = "system_admin,admin")]
    [ApiController]
    [Route("api/courier-area-map")]
    public class CourierAreaMapController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public CourierAreaMapController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<CourierAreaMapDto>>>> Get()
        {
            return await _mediator.Send(new GetAllCourierAreaMapQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<CourierAreaMapDto>>> GetById(int id) 
        {
            return await _mediator.Send(new GetCourierAreaMapByIdQuery(id));
        }

        [HttpGet("count")]
        public async Task<ActionResult<Result<int>>> GetCount()
        {
            return await _mediator.Send(new GetCourierAreaMapCountQuery());
        }

        [HttpGet("dropdown")]
        public async Task<ActionResult<Result<List<CourierAreaDropdownDto>>>> GetDropdown()
        {
            return await _mediator.Send(new GetCourierAreaDropdownQuery());
        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult<PaginatedResult<CourierAreaMapDto>>> GetCategoryWithPagination([FromQuery] GetCourierAreaMapWithPaginationQuery query)
        {
            var validator = new GetCourierAreaMapWithPaginationValidator();

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
        //                                                        orderBy: x => x.CourierAreaMapBy(o => o.id),
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
        public async Task<ActionResult<Result<int>>> Create(CreateCourierAreaMapCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateCourierAreaMapCommand command)
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
            return await _mediator.Send(new DeleteCourierProviderCommand { Id = id });
        }
    }
}