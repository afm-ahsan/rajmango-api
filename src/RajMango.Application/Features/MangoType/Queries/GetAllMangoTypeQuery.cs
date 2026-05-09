using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetAllMangoTypeQuery : IRequest<Result<List<GetAllMangoTypeDto>>>;

    public class GetAllCategoryInfoQueryHandler : IRequestHandler<GetAllMangoTypeQuery, Result<List<GetAllMangoTypeDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetAllCategoryInfoQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<GetAllMangoTypeDto>>> Handle(GetAllMangoTypeQuery query, CancellationToken cancellationToken)
        {
            var list = await _dataContext.Get<MangoType>()
                .OrderBy(m => m.Sequence).ThenBy(m => m.Name)
                .Select(m => new GetAllMangoTypeDto
                {
                    Id            = m.Id,
                    Name          = m.Name,
                    Description   = m.Description,
                    ImagePath     = m.ImagePath,
                    Region        = m.Region,
                    AverageWeight = m.AverageWeight,
                    MangoGrade    = m.MangoGrade,
                    PricePerKg    = m.PricePerKg,
                    Sequence      = m.Sequence,
                    IsAvailable   = m.IsAvailable,
                    CreatedAt     = m.CreatedAt,
                    CreatedBy     = m.CreatedBy,
                    UpdatedAt     = m.UpdatedAt,
                    UpdatedBy     = m.UpdatedBy,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllMangoTypeDto>>.SuccessAsync(list);
        }
    }
}
