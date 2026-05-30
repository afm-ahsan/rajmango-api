using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Courier.RateConfig;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Courier.RateConfig.Queries
{
    public record GetCourierRateConfigByIdQuery(int Id) : IRequest<Result<CourierRateConfigurationDto>>;

    public class GetCourierRateConfigByIdQueryHandler
        : IRequestHandler<GetCourierRateConfigByIdQuery, Result<CourierRateConfigurationDto>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierRateConfigByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<CourierRateConfigurationDto>> Handle(
            GetCourierRateConfigByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _dataContext.Get<CourierRateConfiguration>()
                .Include(r => r.CourierProvider)
                .FirstOrDefaultAsync(r => r.Id == query.Id, cancellationToken);

            if (entity == null)
                return await Result<CourierRateConfigurationDto>.FailureAsync(
                    $"Courier rate configuration not found with Id {query.Id}.");

            return await Result<CourierRateConfigurationDto>.SuccessAsync(MapToDto(entity));
        }

        private static CourierRateConfigurationDto MapToDto(CourierRateConfiguration r) => new()
        {
            Id                  = r.Id,
            CourierProviderId   = r.CourierProviderId,
            CourierProviderName = r.CourierProvider?.Name,
            CourierLocationType = r.CourierLocationType,
            RatePerKg           = r.RatePerKg,
            MinimumCharge       = r.MinimumCharge,
            IsActive            = r.IsActive,
            Sequence            = r.Sequence,
        };
    }
}
