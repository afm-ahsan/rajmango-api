using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user-address")]
    public class UserAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<UserAddressDto>>>> Get()
        {
            return await _mediator.Send(new GetUserAddressesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<UserAddressDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetUserAddressByIdQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create([FromBody] CreateUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Update(int id, [FromBody] UpdateUserAddressCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteUserAddressCommand { Id = id });
        }
    }
}
