using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetOrderCountQuery : IRequest<Result<int>>
    {
        public GetOrderCountQuery() { }
    }

    public class GetOrderCountQueryHandler : IRequestHandler<GetOrderCountQuery, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetOrderCountQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(GetOrderCountQuery query, CancellationToken cancellationToken)
        {
            var totalRecord = await _dataContext.Get<Order>().CountAsync();
            return await Result<int>.SuccessAsync(totalRecord);
        }
    }
}
