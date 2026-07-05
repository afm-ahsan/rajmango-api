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
        private readonly ICurrentUserService _currentUserService;

        public CalculateOrderPreviewQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<OrderPreviewDto>> Handle(CalculateOrderPreviewQuery query, CancellationToken cancellationToken)
        {
            if (query.OrderDetails == null || !query.OrderDetails.Any())
                return await Result<OrderPreviewDto>.FailureAsync("Order details are required.");

            var mangoTypeIds = query.OrderDetails.Select(d => d.MangoTypeId).Distinct().ToList();

            bool isAdmin = _currentUserService.IsAdmin || _currentUserService.IsSuperAdmin;

            // Admins can order any mango type regardless of availability status.
            // Customers are restricted to status == Available only.
            var availQuery = _dataContext.Get<MangoAvailability>().AsNoTracking()
                .Where(a => mangoTypeIds.Contains(a.MangoTypeId));

            if (!isAdmin)
                availQuery = availQuery.Where(a => a.Status == MangoAvailabilityStatus.Available);

            var availabilities = await availQuery.ToListAsync(cancellationToken);

            // Build price map: for admins prefer Available price, fall back to any configured price.
            Dictionary<int, decimal> priceMap;
            if (isAdmin)
            {
                priceMap = availabilities
                    .GroupBy(a => a.MangoTypeId)
                    .ToDictionary(
                        g => g.Key,
                        g => g.OrderByDescending(a => a.Status == MangoAvailabilityStatus.Available ? 1 : 0)
                               .ThenByDescending(a => a.StartDate)
                               .First().PricePerKg);
            }
            else
            {
                priceMap = availabilities.ToDictionary(a => a.MangoTypeId, a => a.PricePerKg);
            }

            var missingTypeIds = mangoTypeIds.Where(id => !priceMap.ContainsKey(id)).ToList();
            if (missingTypeIds.Any())
            {
                var errorMsg = isAdmin
                    ? "One or more mango types have no configured price. Please set up an availability record first."
                    : "One or more mango types are not currently available.";
                return await Result<OrderPreviewDto>.FailureAsync(errorMsg);
            }

            decimal courierCharge = 0m;
            string courierProviderName = null;
            decimal? ratePerKg = null;
            CourierLocationType? resolvedLocationType = null;
            decimal? resolvedMinimumCharge = null;
            decimal? resolvedChargeCalculated = null;
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
                        resolvedLocationType = locationType;
                        resolvedMinimumCharge = courierRate.MinimumCharge;
                        resolvedChargeCalculated = totalWeightKg * courierRate.RatePerKg;
                        courierResolved = true;
                    }
                }
            }

            var summary = OrderCalculator.CalculateTotals(query.OrderDetails, priceMap, courierCharge);

            return await Result<OrderPreviewDto>.SuccessAsync(new OrderPreviewDto
            {
                ProductTotalAmount    = summary.ProductTotalAmount,
                TotalWeightKg         = summary.TotalQuantity,
                CourierCharge         = courierResolved ? courierCharge : (decimal?)null,
                TotalAmount           = summary.TotalAmount,
                CourierProviderName   = courierProviderName,
                CourierRatePerKg      = ratePerKg,
                CourierLocationType   = resolvedLocationType,
                MinimumCharge         = resolvedMinimumCharge,
                CourierChargeCalculated = resolvedChargeCalculated,
            });
        }
    }
}
