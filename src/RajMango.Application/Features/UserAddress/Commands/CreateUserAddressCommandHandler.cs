using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class CreateUserAddressCommandHandler : IRequestHandler<CreateUserAddressCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserAddressLock _userAddressLock;

        public CreateUserAddressCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, ICurrentUserService currentUserService, IUserAddressLock userAddressLock)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _userAddressLock = userAddressLock;
        }

        public async Task<Result<int>> Handle(CreateUserAddressCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _currentUserService.UserId;

                using (await _userAddressLock.AcquireAsync())
                {
                    // Only one primary address per user
                    if (command.IsPrimary)
                    {
                        var existing = await _dataContext.Get<UserAddress>()
                            .Where(a => a.UserId == userId && a.IsPrimary)
                            .ToListAsync(cancellationToken);

                        foreach (var addr in existing)
                            addr.IsPrimary = false;
                    }

                    var address = new UserAddress
                    {
                        UserId      = userId,
                        AddressLine = command.AddressLine,
                        City        = command.City,
                        Area        = command.Area,
                        PostalCode  = command.PostalCode,
                        AddressType = command.AddressType,
                        IsPrimary   = command.IsPrimary,
                    };

                    _dataContext.Get<UserAddress>().Add(address);
                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(address.Id, "Address created.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync("Address creation failed.");
        }
    }
}
