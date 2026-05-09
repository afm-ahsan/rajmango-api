using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public class MangoAvailabilityDto
    {
        public int Id { get; set; }
        public int MangoTypeId { get; set; }
        public string MangoTypeName { get; set; }
        public int SeasonYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PricePerKg { get; set; }
        public MangoAvailabilityStatus Status { get; set; }
        public string Notes { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public record GetAllMangoAvailabilityQuery : IRequest<Result<List<MangoAvailabilityDto>>>;

    public class GetAllMangoAvailabilityQueryHandler : IRequestHandler<GetAllMangoAvailabilityQuery, Result<List<MangoAvailabilityDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetAllMangoAvailabilityQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<MangoAvailabilityDto>>> Handle(GetAllMangoAvailabilityQuery query, CancellationToken cancellationToken)
        {
            var list = await _dataContext.Get<MangoAvailability>()
                .Include(a => a.MangoType)
                .OrderByDescending(a => a.SeasonYear)
                .ThenBy(a => a.StartDate)
                .Select(a => new MangoAvailabilityDto
                {
                    Id            = a.Id,
                    MangoTypeId   = a.MangoTypeId,
                    MangoTypeName = a.MangoType.Name,
                    SeasonYear    = a.SeasonYear,
                    StartDate     = a.StartDate,
                    EndDate       = a.EndDate,
                    PricePerKg    = a.PricePerKg,
                    Status        = a.Status,
                    Notes         = a.Notes,
                    CreatedBy     = a.CreatedBy,
                    CreatedAt     = a.CreatedAt,
                    UpdatedBy     = a.UpdatedBy,
                    UpdatedAt     = a.UpdatedAt,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<MangoAvailabilityDto>>.SuccessAsync(list);
        }
    }
}
