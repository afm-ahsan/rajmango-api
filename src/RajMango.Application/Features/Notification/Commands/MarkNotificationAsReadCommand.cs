using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Notifications.Commands
{
    public record MarkNotificationAsReadCommand(int Id) : IRequest<Result<int>>;

    internal class MarkNotificationAsReadCommandHandler
        : IRequestHandler<MarkNotificationAsReadCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public MarkNotificationAsReadCommandHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(MarkNotificationAsReadCommand command, CancellationToken cancellationToken)
        {
            var notification = await _dataContext.Get<Notification>()
                .FirstOrDefaultAsync(n => n.Id == command.Id && n.UserId == _currentUserService.UserId, cancellationToken);

            if (notification == null)
                return await Result<int>.FailureAsync("Notification not found.");

            if (notification.IsRead)
                return await Result<int>.SuccessAsync(notification.Id);

            notification.IsRead = true;
            notification.ReadAt = Clock.Now();

            _dataContext.Get<Notification>().Update(notification);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return await Result<int>.SuccessAsync(notification.Id);
        }
    }
}
