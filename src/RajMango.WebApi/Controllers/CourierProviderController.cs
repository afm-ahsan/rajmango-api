using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs;
using RajMango.Application.Features;
using RajMango.Application.Features.Commands;
using RajMango.Shared;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/courier-provider")]
    public class CourierProviderController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public CourierProviderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [RequirePermission(Permissions.CourierProviders.View)]
        public async Task<ActionResult<Result<List<CourierProviderDto>>>> Get()
        {
            return await _mediator.Send(new GetAllCourierProviderQuery());
        }

        [HttpGet("{id}")]
        [RequirePermission(Permissions.CourierProviders.View)]
        public async Task<ActionResult<Result<CourierProviderDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetCourierProviderByIdQuery(id));
        }

        [HttpGet("count")]
        [RequirePermission(Permissions.CourierProviders.View)]
        public async Task<ActionResult<Result<int>>> GetCount()
        {
            return await _mediator.Send(new GetCourierProviderCountQuery());
        }

        [HttpGet("dropdown")]
        [RequirePermission(Permissions.CourierProviders.View)]
        public async Task<ActionResult<Result<List<CourierProviderDropdownDto>>>> GetDropdown()
        {
            return await _mediator.Send(new GetCourierProviderDropdownQuery());
        }

        [HttpGet]
        [Route("paged")]
        [RequirePermission(Permissions.CourierProviders.View)]
        public async Task<ActionResult<PaginatedResult<CourierProviderDto>>> GetCategoryWithPagination([FromQuery] GetCourierProviderWithPaginationQuery query)
        {
            var validator = new GetCourierProviderWithPaginationValidator();

            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpPost]
        [RequirePermission(Permissions.CourierProviders.Create)]
        public async Task<ActionResult<Result<int>>> Create(CreateCourierProviderCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [RequirePermission(Permissions.CourierProviders.Update)]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateCourierProviderCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [RequirePermission(Permissions.CourierProviders.Delete)]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteCourierProviderCommand { Id = id });
        }
    }
}