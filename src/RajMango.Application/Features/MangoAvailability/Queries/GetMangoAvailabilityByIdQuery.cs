using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetMangoAvailabilityByIdQuery(int Id) : IRequest<Result<MangoAvailabilityDto>>;

    public class GetMangoAvailabilityByIdQueryHandler : IRequestHandler<GetMangoAvailabilityByIdQuery, Result<MangoAvailabilityDto>>
    {
        private readonly IDataContext _dataContext;

        public GetMangoAvailabilityByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<MangoAvailabilityDto>> Handle(GetMangoAvailabilityByIdQuery query, CancellationToken cancellationToken)
        {
            var dto = await _dataContext.Get<MangoAvailability>()
                .Include(a => a.MangoType)
                .Where(a => a.Id == query.Id)
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
                .FirstOrDefaultAsync(cancellationToken);

            if (dto == null)
                return await Result<MangoAvailabilityDto>.FailureAsync($"Mango availability not found with Id {query.Id}.");

            return await Result<MangoAvailabilityDto>.SuccessAsync(dto);
        }
    }
}
