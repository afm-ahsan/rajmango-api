using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Notifications.Queries
{
    public record GetUnreadNotificationCountQuery : IRequest<Result<int>>;

    internal class GetUnreadNotificationCountQueryHandler
        : IRequestHandler<GetUnreadNotificationCountQuery, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetUnreadNotificationCountQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(
            GetUnreadNotificationCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _dataContext.Get<Notification>()
                .CountAsync(n => n.UserId == _currentUserService.UserId && !n.IsRead, cancellationToken);

            return await Result<int>.SuccessAsync(count);
        }
    }
}
