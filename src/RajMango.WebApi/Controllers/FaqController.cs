using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Faq;
using RajMango.Shared;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [ApiController]
    [Route("api/faq")]
    public class FaqController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FaqController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Public keyword search — used by the chatbot/FAQ widget.</summary>
        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<ActionResult<Result<List<FaqItemDto>>>> Search(
            [FromQuery] string keyword, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new SearchFaqQuery(keyword), cancellationToken);
        }

        /// <summary>Admin — full list including inactive items.</summary>
        [Authorize]
        [RequirePermission(Permissions.Faq.Manage)]
        [HttpGet]
        public async Task<ActionResult<Result<List<FaqItemDto>>>> GetAll(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAllFaqItemsQuery(), cancellationToken);
        }

        /// <summary>Admin — create or update a FAQ item (Id = 0 to create).</summary>
        [Authorize]
        [RequirePermission(Permissions.Faq.Manage)]
        [HttpPut]
        public async Task<ActionResult<Result<int>>> Upsert(
            [FromBody] UpsertFaqItemCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpsertFaqItemCommandValidator();
            var result = validator.Validate(command);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            return await _mediator.Send(command, cancellationToken);
        }

        /// <summary>Admin — delete a FAQ item.</summary>
        [Authorize]
        [RequirePermission(Permissions.Faq.Manage)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<int>>> Delete(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteFaqItemCommand(id), cancellationToken);
        }
    }
}
