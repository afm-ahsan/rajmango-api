using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using RajMango.Shared.Utils;

namespace RajMango.Application.Features.Queries
{
    public class CatalogItemDto
    {
        public int MangoTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Region { get; set; }
        public string AverageWeight { get; set; }
        public MangoGrade MangoGrade { get; set; }
        public int Sequence { get; set; }
        public bool IsCurrentlyAvailable { get; set; }
        public decimal? PricePerKg { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableUntil { get; set; }
        public string SeasonNotes { get; set; }
        public List<CrateOptionDto> CrateOptions { get; set; } = new();
    }

    public class CrateOptionDto
    {
        public CrateType CrateType { get; set; }
        public string Label { get; set; }
        public int WeightKg { get; set; }
        public decimal? PricePerCrate { get; set; }
    }

    public record GetCatalogQuery : IRequest<Result<List<CatalogItemDto>>>;

    public class GetCatalogQueryHandler : IRequestHandler<GetCatalogQuery, Result<List<CatalogItemDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetCatalogQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<CatalogItemDto>>> Handle(GetCatalogQuery query, CancellationToken cancellationToken)
        {
            var today = Clock.Now().Date;

            var mangoTypes = await _dataContext.Get<MangoType>()
                .OrderBy(m => m.Sequence).ThenBy(m => m.Name)
                .Select(m => new
                {
                    m.Id, m.Name, m.Description, m.ImagePath,
                    m.Region, m.AverageWeight, m.MangoGrade, m.Sequence,
                })
                .ToListAsync(cancellationToken);

            // Load today's active availabilities keyed by MangoTypeId
            var availabilities = await _dataContext.Get<MangoAvailability>()
                .Where(a => a.Status == MangoAvailabilityStatus.Available
                         && a.StartDate.Date <= today
                         && a.EndDate.Date >= today)
                .Select(a => new
                {
                    a.MangoTypeId, a.PricePerKg,
                    a.StartDate, a.EndDate, a.Notes,
                })
                .ToListAsync(cancellationToken);

            var availabilityByMangoType = availabilities.ToDictionary(a => a.MangoTypeId);

            var catalog = mangoTypes.Select(m =>
            {
                availabilityByMangoType.TryGetValue(m.Id, out var avail);
                var pricePerKg = avail?.PricePerKg;

                var crateOptions = new List<CrateOptionDto>
                {
                    new() {
                        CrateType    = CrateType.Crate10Kg,
                        Label        = "10 kg Crate",
                        WeightKg     = DomainUtils.GetCrateWeight(CrateType.Crate10Kg),
                        PricePerCrate = pricePerKg.HasValue ? pricePerKg.Value * DomainUtils.GetCrateWeight(CrateType.Crate10Kg) : null,
                    },
                    new() {
                        CrateType    = CrateType.Crate20Kg,
                        Label        = "20 kg Crate",
                        WeightKg     = DomainUtils.GetCrateWeight(CrateType.Crate20Kg),
                        PricePerCrate = pricePerKg.HasValue ? pricePerKg.Value * DomainUtils.GetCrateWeight(CrateType.Crate20Kg) : null,
                    },
                };

                return new CatalogItemDto
                {
                    MangoTypeId          = m.Id,
                    Name                 = m.Name,
                    Description          = m.Description,
                    ImagePath            = m.ImagePath,
                    Region               = m.Region,
                    AverageWeight        = m.AverageWeight,
                    MangoGrade           = m.MangoGrade,
                    Sequence             = m.Sequence,
                    IsCurrentlyAvailable = avail != null,
                    PricePerKg           = pricePerKg,
                    AvailableFrom        = avail?.StartDate,
                    AvailableUntil       = avail?.EndDate,
                    SeasonNotes          = avail?.Notes,
                    CrateOptions         = crateOptions,
                };
            }).ToList();

            return await Result<List<CatalogItemDto>>.SuccessAsync(catalog);
        }
    }
}
