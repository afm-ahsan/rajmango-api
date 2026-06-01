using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Notifications.Queries
{
    public record GetPagedNotificationsQuery : IRequest<PaginatedResult<NotificationDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public bool? IsRead { get; set; }
    }

    internal class GetPagedNotificationsQueryHandler
        : IRequestHandler<GetPagedNotificationsQuery, PaginatedResult<NotificationDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetPagedNotificationsQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<PaginatedResult<NotificationDto>> Handle(
            GetPagedNotificationsQuery request, CancellationToken cancellationToken)
        {
            var query = _dataContext.Get<Notification>()
                .Where(n => n.UserId == _currentUserService.UserId);

            if (request.IsRead.HasValue)
                query = query.Where(n => n.IsRead == request.IsRead.Value);

            int pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            int pageSize   = request.PageSize   <= 0 ? 20 : request.PageSize;

            int totalCount = await query.CountAsync(cancellationToken);

            var data = await query
                .OrderByDescending(n => n.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
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

            return PaginatedResult<NotificationDto>.Create(data, totalCount, pageNumber, pageSize);
        }
    }
}
