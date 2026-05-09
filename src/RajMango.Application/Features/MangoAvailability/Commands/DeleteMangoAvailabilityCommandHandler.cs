using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class DeleteMangoAvailabilityCommandHandler : IRequestHandler<DeleteMangoAvailabilityCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public DeleteMangoAvailabilityCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(DeleteMangoAvailabilityCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var availability = await _dataContext.Get<MangoAvailability>().FindAsync(new object[] { command.Id }, cancellationToken);
                if (availability == null)
                    return await Result<int>.FailureAsync($"Mango availability not found with Id {command.Id}.");

                _dataContext.Get<MangoAvailability>().Remove(availability);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(availability.Id, "Mango availability record deleted.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Mango availability deletion failed for Id {command.Id}.");
        }
    }
}
