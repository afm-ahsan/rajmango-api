using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs;
using RajMango.Application.Features;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
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
        [RequirePermission(Permissions.CourierAreaMaps.View)]
        public async Task<ActionResult<Result<List<CourierAreaMapDto>>>> Get()
        {
            return await _mediator.Send(new GetAllCourierAreaMapQuery());
        }

        [HttpGet("{id}")]
        [RequirePermission(Permissions.CourierAreaMaps.View)]
        public async Task<ActionResult<Result<CourierAreaMapDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetCourierAreaMapByIdQuery(id));
        }

        [HttpGet("count")]
        [RequirePermission(Permissions.CourierAreaMaps.View)]
        public async Task<ActionResult<Result<int>>> GetCount()
        {
            return await _mediator.Send(new GetCourierAreaMapCountQuery());
        }

        [HttpGet("dropdown")]
        public async Task<ActionResult<Result<List<CourierAreaDropdownDto>>>> GetDropdown()
        {
            return await _mediator.Send(new GetCourierAreaDropdownQuery());
        }

        [HttpGet("search")]
        public async Task<ActionResult<Result<List<CourierAreaDropdownDto>>>> Search([FromQuery] string q, [FromQuery] int limit = 20)
        {
            return await _mediator.Send(new SearchCourierAreaQuery { Q = q, Limit = limit });
        }

        [HttpGet]
        [Route("paged")]
        [RequirePermission(Permissions.CourierAreaMaps.View)]
        public async Task<ActionResult<PaginatedResult<CourierAreaMapDto>>> GetCategoryWithPagination([FromQuery] GetCourierAreaMapWithPaginationQuery query)
        {
            var validator = new GetCourierAreaMapWithPaginationValidator();
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpPost]
        [RequirePermission(Permissions.CourierAreaMaps.Create)]
        public async Task<ActionResult<Result<int>>> Create(CreateCourierAreaMapCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [RequirePermission(Permissions.CourierAreaMaps.Update)]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateCourierAreaMapCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [RequirePermission(Permissions.CourierAreaMaps.Delete)]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteCourierAreaMapCommand { Id = id });
        }
    }
}
