using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.UserPermission.Commands
{
    public class GrantUserPermissionCommand : IRequest<Result<int>>
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
    }

    internal class GrantUserPermissionCommandHandler : IRequestHandler<GrantUserPermissionCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly IErrorHandler _errorHandler;
        private readonly IPermissionService _permissionService;

        public GrantUserPermissionCommandHandler(IDataContext dataContext, IErrorHandler errorHandler, IPermissionService permissionService)
        {
            _dataContext = dataContext;
            _errorHandler = errorHandler;
            _permissionService = permissionService;
        }

        public async Task<Result<int>> Handle(GrantUserPermissionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userExists = await _dataContext.Get<AppUser>().AnyAsync(u => u.Id == command.UserId, cancellationToken);
                if (!userExists)
                    return await Result<int>.FailureAsync($"User not found with Id {command.UserId}");

                var permissionExists = await _dataContext.Get<Permission>().AnyAsync(p => p.Id == command.PermissionId, cancellationToken);
                if (!permissionExists)
                    return await Result<int>.FailureAsync($"Permission not found with Id {command.PermissionId}");

                var existing = await _dataContext.Get<Domain.Entities.UserPermission>()
                    .FirstOrDefaultAsync(up => up.UserId == command.UserId && up.PermissionId == command.PermissionId, cancellationToken);

                if (existing != null)
                {
                    if (existing.IsGranted)
                        return await Result<int>.SuccessAsync(command.UserId, "Permission is already granted.");

                    existing.IsGranted = true;
                    _dataContext.Get<Domain.Entities.UserPermission>().Update(existing);
                }
                else
                {
                    _dataContext.Get<Domain.Entities.UserPermission>().Add(new Domain.Entities.UserPermission
                    {
                        UserId = command.UserId,
                        PermissionId = command.PermissionId,
                        IsGranted = true,
                    });
                }

                await _dataContext.SaveChangesAsync(cancellationToken);
                await _permissionService.InvalidateUserPermissionCacheAsync(command.UserId, cancellationToken);

                return await Result<int>.SuccessAsync(command.UserId, "Permission granted successfully.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync("Failed to grant permission.");
        }
    }
}
