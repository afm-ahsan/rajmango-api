using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetMangoTypeByIdQuery(int Id) : IRequest<Result<GetMangoTypeByIdDto>>;

    public class GetCategoryInfoByIdQueryHandler : IRequestHandler<GetMangoTypeByIdQuery, Result<GetMangoTypeByIdDto>>
    {
        private readonly IDataContext _dataContext;

        public GetCategoryInfoByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<GetMangoTypeByIdDto>> Handle(GetMangoTypeByIdQuery query, CancellationToken cancellationToken)
        {
            var dto = await _dataContext.Get<MangoType>()
                .Where(m => m.Id == query.Id)
                .Select(m => new GetMangoTypeByIdDto
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
                .FirstOrDefaultAsync(cancellationToken);

            if (dto == null)
                return await Result<GetMangoTypeByIdDto>.FailureAsync($"Mango type not found with Id {query.Id}.");

            return await Result<GetMangoTypeByIdDto>.SuccessAsync(dto);
        }
    }
}
