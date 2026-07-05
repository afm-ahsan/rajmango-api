using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Common;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<int>>
    {
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IPermissionService _permissionService;
        private readonly ICurrentUserService _currentUserService;

        private const string SystemAdminRoleCode = "system_admin";

        public UpdateUserCommandHandler(IPasswordHasher<AppUser> passwordHasher,
                                        IErrorHandler errorHandler,
                                        IDataContext dataContext,
                                        IPermissionService permissionService,
                                        ICurrentUserService currentUserService)
        {
            _passwordHasher = passwordHasher;
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _permissionService = permissionService;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dataContext.Get<AppUser>().FindAsync(command.Id);
                if (user != null)
                {
                    // Check if target user is a System Admin
                    var targetUserRole = await _dataContext.Get<UserRole>()
                        .Include(ur => ur.Role)
                        .FirstOrDefaultAsync(ur => ur.UserId == user.Id, cancellationToken);
                    bool targetIsSystemAdmin = targetUserRole?.Role?.Code == SystemAdminRoleCode;

                    if (targetIsSystemAdmin && !_currentUserService.IsSuperAdmin)
                        return await Result<int>.FailureAsync(
                            "Only a System Admin can edit another System Admin user.");

                    user.FirstName = command.FirstName;
                    user.LastName = command.LastName;
                    user.Email = command.Email.Trim();
                    user.PhoneNumber = BangladeshPhoneNormalizer.Normalize(command.PhoneNumber) ?? command.PhoneNumber;
                    user.IsActive = command.IsActive;

                    if (!string.IsNullOrWhiteSpace(command.Password))
                    {
                        var passwordHash = _passwordHasher.HashPassword(user, command.Password);
                        user.PasswordHash = passwordHash;
                    }

                    if (command.ImagePath != null)
                        user.ImagePath = string.IsNullOrEmpty(command.ImagePath) ? null : command.ImagePath;
                    
                    _dataContext.Get<AppUser>().Update(user);

                    var role = await _dataContext.Get<UserRole>().FirstOrDefaultAsync(p => p.UserId == command.Id);
                    if (role == null || role.RoleId != command.RoleId)
                    {
                        if (role != null)
                        {
                            _dataContext.Get<UserRole>().Remove(role);
                        }
                        var roleUser = new UserRole
                        {
                            UserId = command.Id,
                            RoleId = command.RoleId.Value,
                        };
                        _dataContext.Get<UserRole>().Add(roleUser);
                    }

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    await _permissionService.InvalidateUserPermissionCacheAsync(command.Id, cancellationToken);

                    return await Result<int>.SuccessAsync(user.Id, "User Information Updated Successfully.");
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
