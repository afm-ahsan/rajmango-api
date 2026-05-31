using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Common;
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
            _passwordHasher = passwordHasher;
            _registrationLock = registrationLock;
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            using (await _registrationLock.AcquireAsync())
            {
                try
                {
                    var normalizedPhone = BangladeshPhoneNormalizer.Normalize(command.PhoneNumber)!;
                    var emailLower      = command.Email.Trim().ToLower();

                    // Uniqueness checks
                    var emailTaken = await _dataContext.Get<AppUser>()
                        .AnyAsync(u => u.Email.ToLower() == emailLower, cancellationToken);
                    if (emailTaken)
                        return await Result<int>.FailureAsync("Email address already exists.");

                    var phoneTaken = await _dataContext.Get<AppUser>()
                        .AnyAsync(u => u.PhoneNumber == normalizedPhone, cancellationToken);
                    if (phoneTaken)
                        return await Result<int>.FailureAsync("Phone number already exists.");

                    var userName     = await GenerateUniqueUserNameAsync(command.FirstName, command.LastName);
                    var passwordHash = _passwordHasher.HashPassword(null, command.Password);

                    var newUser = new AppUser
                    {
                        UserName             = userName,
                        FirstName            = command.FirstName,
                        LastName             = command.LastName,
                        Email                = command.Email.Trim(),
                        PhoneNumber          = normalizedPhone,
                        PasswordHash         = passwordHash,
                        IsActive             = true,
                        EmailConfirmed       = false,
                        PhoneNumberConfirmed = false,
                        CreatedAt            = Clock.Now(),
                    };

                    _dataContext.Get<AppUser>().Add(newUser);
                    await _dataContext.SaveChangesAsync(cancellationToken);

                    // Assign general role
                    _dataContext.Get<UserRole>().Add(new UserRole
                    {
                        UserId     = newUser.Id,
                        RoleId     = (int)UserType.General,
                        AssignedAt = Clock.Now(),
                        CreatedAt  = Clock.Now(),
                        CreatedBy  = newUser.Id,
                    });

                    // Auto-create linked Customer record
                    _dataContext.Get<Customer>().Add(new Customer
                    {
                        UserId       = newUser.Id,
                        FirstName    = command.FirstName,
                        LastName     = command.LastName,
                        PhoneNumber1 = normalizedPhone,
                        Email        = command.Email.Trim(),
                        CustomerType = CustomerType.Regular,
                        IsActive     = true,
                        CreatedBy    = newUser.Id,
                        CreatedAt    = Clock.Now(),
                    });

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(newUser.Id, "Account created successfully.");
                }
                catch (Exception ex)
                {
                    _errorHandler.Handle(ex);
                }
                return await Result<int>.FailureAsync("Registration failed. Please try again.");
            }
        }

        private async Task<string> GenerateUniqueUserNameAsync(string firstName, string lastName)
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
