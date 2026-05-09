using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class DeleteUserAddressCommandHandler : IRequestHandler<DeleteUserAddressCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public DeleteUserAddressCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(DeleteUserAddressCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _currentUserService.UserId;

                var address = await _dataContext.Get<UserAddress>()
                    .FirstOrDefaultAsync(a => a.Id == command.Id && a.UserId == userId, cancellationToken);

                if (address == null)
                    return await Result<int>.FailureAsync($"Address not found with Id {command.Id}.");

                _dataContext.Get<UserAddress>().Remove(address);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(address.Id, "Address deleted.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Address deletion failed for Id {command.Id}.");
        }
    }
}
