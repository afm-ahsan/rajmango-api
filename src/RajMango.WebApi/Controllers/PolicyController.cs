using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Policy;
using RajMango.Shared;
using RajMango.Shared.Enums;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [ApiController]
    [Route("api/policy")]
    public class PolicyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PolicyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Get all active policies (public).</summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Result<List<PolicyDto>>>> GetAll()
        {
            return await _mediator.Send(new GetAllPoliciesQuery());
        }

        /// <summary>Get a specific policy by type (public).</summary>
        [HttpGet("{policyType}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<PolicyDto>>> GetByType(PolicyType policyType)
        {
            return await _mediator.Send(new GetPolicyByTypeQuery(policyType));
        }

        /// <summary>Create or update a policy (admin only).</summary>
        [HttpPut]
        [Authorize]
        [RequirePermission(Permissions.Policies.Manage)]
        public async Task<ActionResult<Result<int>>> Upsert([FromBody] UpsertPolicyCommand command)
        {
            var validator = new UpsertPolicyCommandValidator();
            var result = validator.Validate(command);

            if (!result.IsValid)
                return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToList());

            return await _mediator.Send(command);
        }
    }
}
