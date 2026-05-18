using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    /// <summary>
    /// Returns mango types that are currently marked Available.
    /// Used by the order placement page and the seasonal availability calendar.
    /// </summary>
    public record GetActiveMangoAvailabilityQuery : IRequest<Result<List<MangoAvailabilityDto>>>;

    public class GetActiveMangoAvailabilityQueryHandler : IRequestHandler<GetActiveMangoAvailabilityQuery, Result<List<MangoAvailabilityDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetActiveMangoAvailabilityQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<MangoAvailabilityDto>>> Handle(GetActiveMangoAvailabilityQuery query, CancellationToken cancellationToken)
        {
            var today = Clock.Now().Date;

            var list = await _dataContext.Get<MangoAvailability>()
                .Include(a => a.MangoType)
                .Where(a => a.Status == MangoAvailabilityStatus.Available)
                         //&& a.StartDate.Date <= today
                         //&& a.EndDate.Date >= today)
                .OrderBy(a => a.StartDate)
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
