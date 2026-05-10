using MediatR;
using RajMango.Application.Common;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class CreateMangoAvailabilityCommandHandler : IRequestHandler<CreateMangoAvailabilityCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly ICacheService _cache;
        private readonly IRealtimeService _realtime;

        public CreateMangoAvailabilityCommandHandler(
            IErrorHandler errorHandler,
            IDataContext dataContext,
            ICacheService cache,
            IRealtimeService realtime)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _cache = cache;
            _realtime = realtime;
        }

        public async Task<Result<int>> Handle(CreateMangoAvailabilityCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var mangoType = await _dataContext.Get<MangoType>().FindAsync(new object[] { command.MangoTypeId }, cancellationToken);
                if (mangoType == null)
                    return await Result<int>.FailureAsync($"Mango type not found with Id {command.MangoTypeId}.");

                if (command.EndDate <= command.StartDate)
                    return await Result<int>.FailureAsync("End date must be after start date.");

                var availability = new MangoAvailability
                {
                    MangoTypeId = command.MangoTypeId,
                    SeasonYear  = command.SeasonYear,
                    StartDate   = command.StartDate,
                    EndDate     = command.EndDate,
                    PricePerKg  = command.PricePerKg,
                    Status      = command.Status,
                    Notes       = command.Notes,
                    CreatedBy   = command.CreatedBy,
                    CreatedAt   = Clock.Now(),
                };

                _dataContext.Get<MangoAvailability>().Add(availability);
                await _dataContext.SaveChangesAsync(cancellationToken);

                await _cache.RemoveAsync(CacheKeys.CatalogAll, cancellationToken);
                await _realtime.SendToAllAsync(RealtimeEvents.CatalogUpdated,
                    new { MangoTypeId = command.MangoTypeId }, cancellationToken);

                return await Result<int>.SuccessAsync(availability.Id, "Mango availability record created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync("Mango availability creation failed.");
        }
    }
}
