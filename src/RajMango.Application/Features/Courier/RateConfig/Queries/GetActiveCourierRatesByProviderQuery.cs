using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Courier.RateConfig;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Courier.RateConfig.Queries
{
    public record GetActiveCourierRatesByProviderQuery(int CourierProviderId)
        : IRequest<Result<List<CourierRateConfigurationDto>>>;

    public class GetActiveCourierRatesByProviderQueryHandler
        : IRequestHandler<GetActiveCourierRatesByProviderQuery, Result<List<CourierRateConfigurationDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetActiveCourierRatesByProviderQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<CourierRateConfigurationDto>>> Handle(
            GetActiveCourierRatesByProviderQuery query, CancellationToken cancellationToken)
        {
            var rates = await _dataContext.Get<CourierRateConfiguration>()
                .Include(r => r.CourierProvider)
                .Where(r => r.CourierProviderId == query.CourierProviderId && r.IsActive)
                .OrderBy(r => r.Sequence)
                .Select(r => new CourierRateConfigurationDto
                {
                    Id                  = r.Id,
                    CourierProviderId   = r.CourierProviderId,
                    CourierProviderName = r.CourierProvider.Name,
                    LocationType        = (int)r.CourierLocationType,
                    RatePerKg           = r.RatePerKg,
                    MinimumCharge       = r.MinimumCharge,
                    IsActive            = r.IsActive,
                    Sequence            = r.Sequence,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<CourierRateConfigurationDto>>.SuccessAsync(rates);
        }
    }
}
