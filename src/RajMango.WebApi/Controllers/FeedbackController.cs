using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Feedback.Commands;
using RajMango.Application.Features.Feedback.Queries;
using RajMango.Shared;
using FluentValidation;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/feedback")]
    public class FeedbackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeedbackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Submit feedback for a delivered order (customer).</summary>
        [HttpPost]
        public async Task<ActionResult<Result<int>>> Submit([FromBody] SubmitFeedbackCommand command)
        {
            var validator = new SubmitFeedbackCommandValidator();
            var result = validator.Validate(command);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            return await _mediator.Send(command);
        }

        /// <summary>Get feedback for a specific order (own order for customer, any order for admin).</summary>
        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<Result<FeedbackDto>>> GetByOrder(int orderId)
        {
            return await _mediator.Send(new GetFeedbackByOrderIdQuery(orderId));
        }

        /// <summary>Get all feedback (admin only).</summary>
        [HttpGet]
        [RequirePermission(Permissions.Feedback.AdminView)]
        public async Task<ActionResult<Result<List<FeedbackDto>>>> GetAll()
        {
            return await _mediator.Send(new GetAllFeedbackQuery());
        }

        /// <summary>Attach an uploaded image path to a feedback (max 3 images).</summary>
        [HttpPost("images")]
        public async Task<ActionResult<Result<int>>> AddImage([FromBody] AddFeedbackImageCommand command)
        {
            var validation = new AddFeedbackImageCommandValidator().Validate(command);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            return await _mediator.Send(command);
        }
    }
}
