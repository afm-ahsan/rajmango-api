using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public UpdateUserAddressCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(UpdateUserAddressCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _currentUserService.UserId;

                var address = await _dataContext.Get<UserAddress>()
                    .FirstOrDefaultAsync(a => a.Id == command.Id && a.UserId == userId, cancellationToken);

                if (address == null)
                    return await Result<int>.FailureAsync($"Address not found with Id {command.Id}.");

                // Only one primary address per user
                if (command.IsPrimary && !address.IsPrimary)
                {
                    var others = await _dataContext.Get<UserAddress>()
                        .Where(a => a.UserId == userId && a.IsPrimary && a.Id != command.Id)
                        .ToListAsync(cancellationToken);

                    foreach (var other in others)
                        other.IsPrimary = false;
                }

                address.AddressLine = command.AddressLine;
                address.City        = command.City;
                address.Area        = command.Area;
                address.PostalCode  = command.PostalCode;
                address.AddressType = command.AddressType;
                address.IsPrimary   = command.IsPrimary;

                _dataContext.Get<UserAddress>().Update(address);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(address.Id, "Address updated.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Address update failed for Id {command.Id}.");
        }
    }
}
