using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Courier.RateConfig.Commands
{
    internal class UpdateCourierRateConfigCommandHandler : IRequestHandler<UpdateCourierRateConfigCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public UpdateCourierRateConfigCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext  = dataContext;
        }

        public async Task<Result<int>> Handle(UpdateCourierRateConfigCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _dataContext.Get<CourierRateConfiguration>()
                    .FindAsync(new object[] { command.Id }, cancellationToken);

                if (entity == null)
                    return await Result<int>.FailureAsync($"Courier rate configuration not found with Id {command.Id}.");

                if (command.IsActive)
                {
                    var conflict = await _dataContext.Get<CourierRateConfiguration>()
                        .AnyAsync(r => r.Id                  != command.Id
                                    && r.CourierProviderId    == command.CourierProviderId
                                    && r.CourierLocationType  == command.CourierLocationType
                                    && r.IsActive,
                                  cancellationToken);

                    if (conflict)
                        return await Result<int>.FailureAsync(
                            $"Another active rate for {command.CourierLocationType} already exists for this provider.");
                }

                entity.CourierProviderId   = command.CourierProviderId;
                entity.CourierLocationType = command.CourierLocationType;
                entity.RatePerKg           = command.RatePerKg;
                entity.MinimumCharge       = command.MinimumCharge;
                entity.IsActive            = command.IsActive;
                entity.Sequence            = command.Sequence;

                _dataContext.Get<CourierRateConfiguration>().Update(entity);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(entity.Id, "Courier rate configuration updated.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Courier rate configuration update failed for Id {command.Id}.");
        }
    }
}
