using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<int>>
    {
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IRegistrationLock _registrationLock;
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public RegisterUserCommandHandler(IPasswordHasher<AppUser> passwordHasher,
                                        IRegistrationLock registrationLock,
                                        IErrorHandler errorHandler,
                                        IDataContext dataContext)
        {
            _registrationLock = registrationLock;
            _passwordHasher = passwordHasher;
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            using (await _registrationLock.AcquireAsync())
            {
                try
                {
                    var userName = await GenerateUniqueUserNameAsync(command.FirstName, command.LastName);
                    var passwordHash = _passwordHasher.HashPassword(null, command.Password);
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

                    var userRole = new UserRole
                    {
                        UserId = newUser.Id,
                        RoleId = (int)UserType.General, //FOR TEST
                        AssignedAt = Clock.Now(),
                    };

                    _dataContext.Get<UserRole>().Add(userRole);
                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(newUser.Id, "User registered successfully.");
                }
                catch (Exception ex)
                {
                    _errorHandler.Handle(ex);
                }
                return await Result<int>.FailureAsync($"User registration failed.");
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
