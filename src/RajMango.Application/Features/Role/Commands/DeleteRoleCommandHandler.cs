using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Commands
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IPermissionService _permissionService;

        public DeleteRoleCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IPermissionService permissionService)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _permissionService = permissionService;
        }

        public async Task<Result<int>> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _dataContext.Get<Role>().FindAsync(command.Id);
                if (role != null)
                {
                    var affectedUserIds = await _dataContext.Get<UserRole>()
                        .Where(ur => ur.RoleId == command.Id)
                        .Select(ur => ur.UserId)
                        .ToListAsync(cancellationToken);

                    _dataContext.Get<Role>().Remove(role);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    foreach (var userId in affectedUserIds)
                        await _permissionService.InvalidateUserPermissionCacheAsync(userId, cancellationToken);

                    return await Result<int>.SuccessAsync(role.Id, "Role is Deleted");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }

            return await Result<int>.FailureAsync($"Role information not found with the Id - {command.Id}");
        }
    }
}
