using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IPermissionService _permissionService;

        public DeleteUserCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IPermissionService permissionService)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _permissionService = permissionService;
        }

        public async Task<Result<int>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dataContext.Get<AppUser>().FindAsync(command.Id);
                if (user != null)
                {
                    var role = await _dataContext.Get<UserRole>().FirstOrDefaultAsync(p => p.UserId == command.Id);
                    if (role != null)
                    {
                        _dataContext.Get<UserRole>().Remove(role);
                    }

                    _dataContext.Get<AppUser>().Remove(user);

                    await _permissionService.InvalidateUserPermissionCacheAsync(user.Id, cancellationToken);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(user.Id, "User Deleted Successfully.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }

            return await Result<int>.FailureAsync($"User information not found with the Id - {command.Id}");
        }
    }
}
