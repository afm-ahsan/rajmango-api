using MediatR;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Result<GetAuthUserDto>>> Login(GetAuthUserQuery command)
        {
            _logger.LogInformation("POST /login endpoint was called at {Time}", DateTime.UtcNow);
            return await _mediator.Send(command);
        }

        [HttpPost("me")]
        public async Task<ActionResult<Result<bool>>> ValidToken(GetValidTokenQuery command)
        {
            _logger.LogInformation("POST /validate token endpoint was called at {Time}", DateTime.UtcNow);
            return await _mediator.Send(command);
        }

        [HttpPost("registration")]
        public async Task<ActionResult<Result<int>>> Register(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}