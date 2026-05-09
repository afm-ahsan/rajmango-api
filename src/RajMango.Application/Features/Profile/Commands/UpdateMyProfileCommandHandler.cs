using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class UpdateMyProfileCommandHandler : IRequestHandler<UpdateMyProfileCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IErrorHandler _errorHandler;

        public UpdateMyProfileCommandHandler(IDataContext dataContext,
                                             ICurrentUserService currentUserService,
                                             IPasswordHasher<AppUser> passwordHasher,
                                             IErrorHandler errorHandler)
        {
            _dataContext         = dataContext;
            _currentUserService  = currentUserService;
            _passwordHasher      = passwordHasher;
            _errorHandler        = errorHandler;
        }

        public async Task<Result<int>> Handle(UpdateMyProfileCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _currentUserService.UserId;

                var user = await _dataContext.Get<AppUser>()
                    .FindAsync(new object[] { userId }, cancellationToken);

                if (user == null)
                    return await Result<int>.FailureAsync("User not found.");

                // Phone uniqueness check (skip if unchanged)
                if (user.PhoneNumber != command.PhoneNumber)
                {
                    var phoneTaken = await _dataContext.Get<AppUser>()
                        .AnyAsync(u => u.PhoneNumber == command.PhoneNumber && u.Id != userId, cancellationToken);
                    if (phoneTaken)
                        return await Result<int>.FailureAsync("This phone number is already associated with another account.");
                }

                // Password change
                if (!string.IsNullOrWhiteSpace(command.NewPassword))
                {
                    var verify = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, command.CurrentPassword);
                    if (verify == PasswordVerificationResult.Failed)
                        return await Result<int>.FailureAsync("Current password is incorrect.");

                    user.PasswordHash = _passwordHasher.HashPassword(user, command.NewPassword);
                }

                user.FirstName   = command.FirstName;
                user.LastName    = command.LastName;
                user.PhoneNumber = command.PhoneNumber;
                user.UpdatedAt   = Clock.Now();
                user.UpdatedBy   = userId;

                _dataContext.Get<AppUser>().Update(user);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(user.Id, "Profile updated successfully.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync("Profile update failed. Please try again.");
        }
    }
}
