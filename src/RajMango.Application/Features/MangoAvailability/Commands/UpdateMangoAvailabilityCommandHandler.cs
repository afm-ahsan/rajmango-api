using MediatR;
using RajMango.Application.Common;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class UpdateMangoAvailabilityCommandHandler : IRequestHandler<UpdateMangoAvailabilityCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly ICacheService _cache;

        public UpdateMangoAvailabilityCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, ICacheService cache)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _cache = cache;
        }

        public async Task<Result<int>> Handle(UpdateMangoAvailabilityCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var availability = await _dataContext.Get<MangoAvailability>().FindAsync(new object[] { command.Id }, cancellationToken);
                if (availability == null)
                    return await Result<int>.FailureAsync($"Mango availability not found with Id {command.Id}.");

                if (command.EndDate <= command.StartDate)
                    return await Result<int>.FailureAsync("End date must be after start date.");

                availability.SeasonYear = command.SeasonYear;
                availability.StartDate  = command.StartDate;
                availability.EndDate    = command.EndDate;
                availability.PricePerKg = command.PricePerKg;
                availability.Status     = command.Status;
                availability.Notes      = command.Notes;
                availability.UpdatedBy  = command.UpdatedBy;
                availability.UpdatedAt  = Clock.Now();

                _dataContext.Get<MangoAvailability>().Update(availability);
                await _dataContext.SaveChangesAsync(cancellationToken);

                await _cache.RemoveAsync(CacheKeys.CatalogAll, cancellationToken);
                return await Result<int>.SuccessAsync(availability.Id, "Mango availability updated.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Mango availability update failed for Id {command.Id}.");
        }
    }
}
