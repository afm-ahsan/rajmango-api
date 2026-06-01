using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Notifications.Commands
{
    public record MarkAllNotificationsAsReadCommand : IRequest<Result<int>>;

    internal class MarkAllNotificationsAsReadCommandHandler
        : IRequestHandler<MarkAllNotificationsAsReadCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public MarkAllNotificationsAsReadCommandHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(MarkAllNotificationsAsReadCommand command, CancellationToken cancellationToken)
        {
            var now = Clock.Now();

            var unread = await _dataContext.Get<Notification>()
                .Where(n => n.UserId == _currentUserService.UserId && !n.IsRead)
                .ToListAsync(cancellationToken);

            if (!unread.Any())
                return await Result<int>.SuccessAsync(0);

            foreach (var n in unread)
            {
                n.IsRead = true;
                n.ReadAt = now;
            }

            await _dataContext.SaveChangesAsync(cancellationToken);

            return await Result<int>.SuccessAsync(unread.Count, $"{unread.Count} notification(s) marked as read.");
        }
    }
}
