using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Notifications.Commands;
using RajMango.Application.Features.Notifications.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Returns the latest 5 notifications for the logged-in user.</summary>
        [HttpGet("latest")]
        public async Task<ActionResult<Result<List<NotificationDto>>>> GetLatest()
        {
            return await _mediator.Send(new GetLatestNotificationsQuery());
        }

        /// <summary>Paginated notification list for the logged-in user. Filter by IsRead.</summary>
        [HttpGet("paged")]
        public async Task<ActionResult<PaginatedResult<NotificationDto>>> GetPaged([FromQuery] GetPagedNotificationsQuery query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>Returns the count of unread notifications for the logged-in user.</summary>
        [HttpGet("unread-count")]
        public async Task<ActionResult<Result<int>>> GetUnreadCount()
        {
            return await _mediator.Send(new GetUnreadNotificationCountQuery());
        }

        /// <summary>Marks a single notification as read. Only the owner can mark their own notifications.</summary>
        [HttpPost("{id}/mark-as-read")]
        public async Task<ActionResult<Result<int>>> MarkAsRead(int id)
        {
            return await _mediator.Send(new MarkNotificationAsReadCommand(id));
        }

        /// <summary>Marks all unread notifications as read for the logged-in user.</summary>
        [HttpPost("mark-all-as-read")]
        public async Task<ActionResult<Result<int>>> MarkAllAsRead()
        {
            return await _mediator.Send(new MarkAllNotificationsAsReadCommand());
        }
    }
}
