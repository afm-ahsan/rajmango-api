using AutoMapper;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetCustomersCountQuery : IRequest<Result<GetCustomerCountDto>>
    {
        public GetCustomersCountQuery() { }
    }

    public class GetCustomersCountQueryHandler : IRequestHandler<GetCustomersCountQuery, Result<GetCustomerCountDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCustomersCountQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetCustomerCountDto>> Handle(GetCustomersCountQuery query, CancellationToken cancellationToken)
        {
            var totalCount = await _dataContext.Get<Customer>().CountAsync();
            return await Result<GetCustomerCountDto>.SuccessAsync(new GetCustomerCountDto { TotalCount = totalCount});
        }
    }
}
