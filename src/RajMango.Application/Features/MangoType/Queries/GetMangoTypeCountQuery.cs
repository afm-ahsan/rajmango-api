using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetMangoTypeCountQuery : IRequest<Result<GetMangoTypeCountDto>>
    {
        public GetMangoTypeCountQuery() { }
    }

    public class GetCategoriesCountQueryHandler : IRequestHandler<GetMangoTypeCountQuery, Result<GetMangoTypeCountDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCategoriesCountQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetMangoTypeCountDto>> Handle(GetMangoTypeCountQuery query, CancellationToken cancellationToken)
        {
            var totalCount = await _dataContext.Get<MangoType>().CountAsync();
            return await Result<GetMangoTypeCountDto>.SuccessAsync(new GetMangoTypeCountDto { TotalCount = totalCount});
        }
    }
}
