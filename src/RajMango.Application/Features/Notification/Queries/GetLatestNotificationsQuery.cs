using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Notifications.Queries
{
    public record GetLatestNotificationsQuery : IRequest<Result<List<NotificationDto>>>;

    internal class GetLatestNotificationsQueryHandler
        : IRequestHandler<GetLatestNotificationsQuery, Result<List<NotificationDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetLatestNotificationsQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<List<NotificationDto>>> Handle(
            GetLatestNotificationsQuery request, CancellationToken cancellationToken)
        {
            var data = await _dataContext.Get<Notification>()
                .Where(n => n.UserId == _currentUserService.UserId)
                .OrderByDescending(n => n.CreatedAt)
                .Take(5)
                .Select(n => new NotificationDto
                {
                    Id               = n.Id,
                    OrderId          = n.OrderId,
                    OrderNumber      = n.OrderNumber,
                    Title            = n.Title,
                    Message          = n.Message,
                    NotificationType = n.NotificationType,
                    IsRead           = n.IsRead,
                    ReadAt           = n.ReadAt,
                    CreatedAt        = n.CreatedAt,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<NotificationDto>>.SuccessAsync(data);
        }
    }
}
