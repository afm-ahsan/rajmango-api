using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;
        private readonly AppSettings _appSettings;

        public AuthController(IMediator mediator, ILogger<AuthController> logger, IOptions<AppSettings> appSettings)
        {
            _mediator = mediator;
            _logger = logger;
            _appSettings = appSettings.Value;
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

        [HttpGet("config")]
        public IActionResult GetConfig()
        {
            var ts = _appSettings?.CloudflareTurnstile;
            var enabled = ts?.Enabled ?? false;
            return Ok(new
            {
                enabled,
                siteKey = enabled ? (ts!.SiteKey ?? string.Empty) : string.Empty,
            });
        }

        [HttpPost("registration")]
        public async Task<ActionResult<Result<int>>> Register(RegisterUserCommand command)
        {
            var validator = new RegisterUserCommandValidator();
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