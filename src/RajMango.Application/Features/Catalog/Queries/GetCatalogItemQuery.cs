using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using RajMango.Shared.Utils;

namespace RajMango.Application.Features.Queries
{
    public class CatalogItemDetailDto : CatalogItemDto
    {
        public int? SeasonYear { get; set; }
        public int? AvailabilityId { get; set; }
    }

    public record GetCatalogItemQuery(int MangoTypeId) : IRequest<Result<CatalogItemDetailDto>>;

    public class GetCatalogItemQueryHandler : IRequestHandler<GetCatalogItemQuery, Result<CatalogItemDetailDto>>
    {
        private readonly IDataContext _dataContext;

        public GetCatalogItemQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<CatalogItemDetailDto>> Handle(GetCatalogItemQuery query, CancellationToken cancellationToken)
        {
            var today = Clock.Now().Date;

            var mangoType = await _dataContext.Get<MangoType>()
                .Where(m => m.Id == query.MangoTypeId)
                .Select(m => new
                {
                    m.Id, m.Name, m.Description, m.ImagePath,
                    m.Region, m.AverageWeight, m.MangoGrade, m.SweetnessLevel, m.Sequence,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (mangoType == null)
                return await Result<CatalogItemDetailDto>.FailureAsync($"Mango type not found with Id {query.MangoTypeId}.");

            var avail = await _dataContext.Get<MangoAvailability>()
                .Where(a => a.MangoTypeId == query.MangoTypeId
                         && a.Status == MangoAvailabilityStatus.Available
                         && a.StartDate.Date <= today
                         && a.EndDate.Date >= today)
                .Select(a => new
                {
                    a.Id, a.PricePerKg, a.StartDate, a.EndDate, a.Notes, a.SeasonYear,
                })
                .FirstOrDefaultAsync(cancellationToken);

            var pricePerKg = avail?.PricePerKg;

            var crateOptions = new List<CrateOptionDto>
            {
                new() {
                    CrateType     = CrateType.Crate10Kg,
                    Label         = "10 kg Crate",
                    WeightKg      = DomainUtils.GetCrateWeight(CrateType.Crate10Kg),
                    PricePerCrate = pricePerKg.HasValue ? pricePerKg.Value * DomainUtils.GetCrateWeight(CrateType.Crate10Kg) : null,
                },
                new() {
                    CrateType     = CrateType.Crate20Kg,
                    Label         = "20 kg Crate",
                    WeightKg      = DomainUtils.GetCrateWeight(CrateType.Crate20Kg),
                    PricePerCrate = pricePerKg.HasValue ? pricePerKg.Value * DomainUtils.GetCrateWeight(CrateType.Crate20Kg) : null,
                },
            };

            var dto = new CatalogItemDetailDto
            {
                MangoTypeId          = mangoType.Id,
                Name                 = mangoType.Name,
                Description          = mangoType.Description,
                ImagePath            = mangoType.ImagePath,
                Region               = mangoType.Region,
                AverageWeight        = mangoType.AverageWeight,
                MangoGrade           = mangoType.MangoGrade,
                SweetnessLevel       = mangoType.SweetnessLevel,
                Sequence             = mangoType.Sequence,
                IsCurrentlyAvailable = avail != null,
                PricePerKg           = pricePerKg,
                AvailableFrom        = avail?.StartDate,
                AvailableUntil       = avail?.EndDate,
                SeasonNotes          = avail?.Notes,
                SeasonYear           = avail?.SeasonYear,
                AvailabilityId       = avail?.Id,
                CrateOptions         = crateOptions,
            };

            return await Result<CatalogItemDetailDto>.SuccessAsync(dto);
        }
    }
}
