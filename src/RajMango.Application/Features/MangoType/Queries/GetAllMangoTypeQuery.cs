using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;

        public GetAllCategoryInfoQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllMangoTypeDto>>> Handle(GetAllMangoTypeQuery query, CancellationToken cancellationToken)
        {
            var mangoTypeList = await _dataContext.Get<MangoType>()
                  .ProjectTo<GetAllMangoTypeDto>(_mapper.ConfigurationProvider)
                  .ToListAsync(cancellationToken);

            return await Result<List<GetAllMangoTypeDto>>.SuccessAsync(mangoTypeList);
        }
    }
}
