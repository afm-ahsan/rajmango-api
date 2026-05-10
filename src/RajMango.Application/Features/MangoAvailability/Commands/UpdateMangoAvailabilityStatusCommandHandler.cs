using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Common;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    internal class UpdateMangoAvailabilityStatusCommandHandler : IRequestHandler<UpdateMangoAvailabilityStatusCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly ICacheService _cache;
        private readonly IRealtimeService _realtime;

        public UpdateMangoAvailabilityStatusCommandHandler(
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

        public async Task<Result<int>> Handle(UpdateMangoAvailabilityStatusCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var availability = await _dataContext.Get<MangoAvailability>()
                    .Include(a => a.MangoType)
                    .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

                if (availability == null)
                    return await Result<int>.FailureAsync($"Mango availability not found with Id {command.Id}.");

                availability.Status    = command.NewStatus;
                availability.UpdatedBy = command.UpdatedBy;
                availability.UpdatedAt = Clock.Now();

                // Keep MangoType.IsAvailable in sync so the order placement check stays accurate.
                availability.MangoType.IsAvailable = command.NewStatus == MangoAvailabilityStatus.Available;

                _dataContext.Get<MangoAvailability>().Update(availability);
                _dataContext.Get<MangoType>().Update(availability.MangoType);
                await _dataContext.SaveChangesAsync(cancellationToken);

                await _cache.RemoveAsync(CacheKeys.CatalogAll, cancellationToken);
                await _realtime.SendToAllAsync(RealtimeEvents.CatalogUpdated,
                    new { MangoTypeId = availability.MangoTypeId, Status = command.NewStatus.ToString() },
                    cancellationToken);

                return await Result<int>.SuccessAsync(availability.Id, $"Mango availability status updated to {command.NewStatus}.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Mango availability status update failed for Id {command.Id}.");
        }
    }
}
