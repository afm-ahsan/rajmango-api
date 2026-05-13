using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.UserPermission.Commands
{
    public class DeleteUserPermissionOverrideCommand : IRequest<Result<int>>
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
    }

    internal class DeleteUserPermissionOverrideCommandHandler : IRequestHandler<DeleteUserPermissionOverrideCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly IErrorHandler _errorHandler;
        private readonly IPermissionService _permissionService;

        public DeleteUserPermissionOverrideCommandHandler(IDataContext dataContext, IErrorHandler errorHandler, IPermissionService permissionService)
        {
            _dataContext = dataContext;
            _errorHandler = errorHandler;
            _permissionService = permissionService;
        }

        public async Task<Result<int>> Handle(DeleteUserPermissionOverrideCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var existing = await _dataContext.Get<Domain.Entities.UserPermission>()
                    .FirstOrDefaultAsync(up => up.UserId == command.UserId && up.PermissionId == command.PermissionId, cancellationToken);

                if (existing == null)
                    return await Result<int>.FailureAsync("No override found for this user and permission.");

                _dataContext.Get<Domain.Entities.UserPermission>().Remove(existing);

                await _dataContext.SaveChangesAsync(cancellationToken);
                await _permissionService.InvalidateUserPermissionCacheAsync(command.UserId, cancellationToken);

                return await Result<int>.SuccessAsync(command.UserId, "Permission override removed. Role-based permissions are now in effect.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync("Failed to remove permission override.");
        }
    }
}
