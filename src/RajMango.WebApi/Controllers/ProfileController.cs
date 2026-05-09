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
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<MyProfileDto>>> Get()
        {
            return await _mediator.Send(new GetMyProfileQuery());
        }

        [HttpPut]
        public async Task<ActionResult<Result<int>>> Update([FromBody] UpdateMyProfileCommand command)
        {
            var validator = new UpdateMyProfileCommandValidator();
            var result = validator.Validate(command);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            return await _mediator.Send(command);
        }
    }
}
