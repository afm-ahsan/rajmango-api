using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs;
using RajMango.Application.Features;
using RajMango.Application.Features.Commands;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [Authorize(Roles = "system_admin,admin")]
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
        public async Task<ActionResult<Result<List<CourierProviderDto>>>> Get()
        {
            return await _mediator.Send(new GetAllCourierProviderQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<CourierProviderDto>>> GetById(int id) 
        {
            return await _mediator.Send(new GetCourierProviderByIdQuery(id));
        }

        [HttpGet("count")]
        public async Task<ActionResult<Result<int>>> GetCount()
        {
            return await _mediator.Send(new GetCourierProviderCountQuery());
        }

        [HttpGet("dropdown")]
        public async Task<ActionResult<Result<List<CourierProviderDropdownDto>>>> GetDropdown()
        {
            return await _mediator.Send(new GetCourierProviderDropdownQuery());
        }

        [HttpGet]
        [Route("paged")]
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
        public async Task<ActionResult<Result<int>>> Create(CreateCourierProviderCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateCourierProviderCommand command)
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