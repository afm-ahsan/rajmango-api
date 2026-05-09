using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
    {
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IRegistrationLock _registrationLock;
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public CreateUserCommandHandler(IPasswordHasher<AppUser> passwordHasher,
                                        IRegistrationLock registrationLock,
                                        IErrorHandler errorHandler,
                                        IDataContext dataContext)
        {
            _registrationLock = registrationLock;
            _passwordHasher = passwordHasher;
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            using (await _registrationLock.AcquireAsync())
            {
                try
                {
                    var userName = await GenerateUniqueUserNameAsync(command.FirstName, command.LastName);
                    var passwordHash = _passwordHasher.HashPassword(new AppUser(), command.Password);
                    var newUser = new AppUser
                    {
                        UserName = userName,
                        FirstName = command.FirstName,
                        LastName = command.LastName,
                        Email = command.Email,
                        PhoneNumber = command.PhoneNumber,
                        IsActive = true,
                        EmailConfirmed = false,
                        PhoneNumberConfirmed = false,
                        PasswordHash = _passwordHasher.HashPassword(null, command.Password),
                    };

                    _dataContext.Get<AppUser>().Add(newUser);
                    await _dataContext.SaveChangesAsync(cancellationToken);

                    if (command.RoleId != null && command.RoleId > 0)
                    {
                        var roleUser = new UserRole
                        {
                            UserId = newUser.Id,
                            RoleId = command.RoleId.Value,
                        };

                        _dataContext.Get<UserRole>().Add(roleUser);
                        await _dataContext.SaveChangesAsync(cancellationToken);
                    }

                    return await Result<int>.SuccessAsync(newUser.Id, "App User Created Successfully.");
                }
                catch (Exception ex)
                {
                    _errorHandler.Handle(ex);
                }
                return await Result<int>.FailureAsync($"App User Creation Failed.");
            }
        }

        /**
         * Generates a unique username using:
         * First char of first name + first char of last name (both uppercased) + 4-digit random number
         */
        public async Task<string> GenerateUniqueUserNameAsync(string firstName, string lastName)
        {
            string username;

            do
            {
                username = UserNameGenerator.GenerateUsername(firstName, lastName);
            }
            while (await _dataContext.Get<AppUser>().AnyAsync(u => u.UserName == username));

            return username;
        }
    }
}
