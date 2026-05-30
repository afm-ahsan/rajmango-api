using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using RajMango.Shared.Utils;

namespace RajMango.Application.Features.Queries
{
    public record CalculateOrderPreviewQuery : IRequest<Result<OrderPreviewDto>>
    {
        public int? CourierStationId { get; set; }
        public IEnumerable<OrderDetailInputDto> OrderDetails { get; set; }
    }

    internal class CalculateOrderPreviewQueryHandler : IRequestHandler<CalculateOrderPreviewQuery, Result<OrderPreviewDto>>
    {
        private readonly IDataContext _dataContext;

        public CalculateOrderPreviewQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<OrderPreviewDto>> Handle(CalculateOrderPreviewQuery query, CancellationToken cancellationToken)
        {
            if (query.OrderDetails == null || !query.OrderDetails.Any())
                return await Result<OrderPreviewDto>.FailureAsync("Order details are required.");

            var mangoTypeIds = query.OrderDetails.Select(d => d.MangoTypeId).Distinct().ToList();

            var availabilities = await _dataContext.Get<MangoAvailability>()
                .AsNoTracking()
                .Where(a => mangoTypeIds.Contains(a.MangoTypeId) && a.Status == MangoAvailabilityStatus.Available)
                .ToListAsync(cancellationToken);

            var priceMap = availabilities.ToDictionary(a => a.MangoTypeId, a => a.PricePerKg);

            var missingTypeIds = mangoTypeIds.Where(id => !priceMap.ContainsKey(id)).ToList();
            if (missingTypeIds.Any())
                return await Result<OrderPreviewDto>.FailureAsync("One or more mango types are not currently available.");

            decimal courierCharge = 0m;
            string courierProviderName = null;
            decimal? ratePerKg = null;
            bool courierResolved = false;

            if (query.CourierStationId.HasValue)
            {
                var station = await _dataContext.Get<CourierStation>()
                    .AsNoTracking()
                    .Include(s => s.CourierProvider)
                    .FirstOrDefaultAsync(s => s.Id == query.CourierStationId.Value, cancellationToken);

                if (station != null)
                {
                    var locationType = string.Equals(station.City, "Dhaka", StringComparison.OrdinalIgnoreCase)
                        ? CourierLocationType.InsideDhaka
                        : CourierLocationType.OutsideDhaka;

                    var courierRate = await _dataContext.Get<CourierRateConfiguration>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(
                            r => r.CourierProviderId == station.CourierProviderId
                              && r.CourierLocationType == locationType
                              && r.IsActive,
                            cancellationToken);

                    if (courierRate != null)
                    {
                        var totalWeightKg = query.OrderDetails.Sum(d => d.Quantity * DomainUtils.GetCrateWeight(d.CrateType));
                        ratePerKg = courierRate.RatePerKg;
                        courierCharge = OrderCalculator.CalculateCourierCharge(totalWeightKg, courierRate.RatePerKg, courierRate.MinimumCharge);
                        courierProviderName = station.CourierProvider?.Name;
                        courierResolved = true;
                    }
                }
            }

            var summary = OrderCalculator.CalculateTotals(query.OrderDetails, priceMap, courierCharge);

            return await Result<OrderPreviewDto>.SuccessAsync(new OrderPreviewDto
            {
                ProductTotalAmount = summary.ProductTotalAmount,
                TotalWeightKg      = summary.TotalQuantity,
                CourierCharge      = courierResolved ? courierCharge : (decimal?)null,
                TotalAmount        = summary.TotalAmount,
                CourierProviderName = courierProviderName,
                CourierRatePerKg   = ratePerKg,
            });
        }
    }
}
