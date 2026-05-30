using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Courier.RateConfig.Commands
{
    internal class CreateCourierRateConfigCommandHandler : IRequestHandler<CreateCourierRateConfigCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public CreateCourierRateConfigCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext  = dataContext;
        }

        public async Task<Result<int>> Handle(CreateCourierRateConfigCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var providerExists = await _dataContext.Get<CourierProvider>()
                    .AnyAsync(p => p.Id == command.CourierProviderId, cancellationToken);

                if (!providerExists)
                    return await Result<int>.FailureAsync($"Courier provider with Id {command.CourierProviderId} not found.");

                if (command.IsActive)
                {
                    var conflict = await _dataContext.Get<CourierRateConfiguration>()
                        .AnyAsync(r => r.CourierProviderId    == command.CourierProviderId
                                    && r.CourierLocationType  == command.CourierLocationType
                                    && r.IsActive,
                                  cancellationToken);

                    if (conflict)
                        return await Result<int>.FailureAsync(
                            $"An active rate for {command.CourierLocationType} already exists for this provider. Deactivate it first.");
                }

                var entity = new CourierRateConfiguration
                {
                    CourierProviderId   = command.CourierProviderId,
                    CourierLocationType = command.CourierLocationType,
                    RatePerKg           = command.RatePerKg,
                    MinimumCharge       = command.MinimumCharge,
                    IsActive            = command.IsActive,
                    Sequence            = command.Sequence,
                };

                _dataContext.Get<CourierRateConfiguration>().Add(entity);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(entity.Id, "Courier rate configuration created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync("Courier rate configuration creation failed.");
        }
    }
}
