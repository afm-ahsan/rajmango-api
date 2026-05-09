using AutoMapper;
using AutoMapper.QueryableExtensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetAllCustomerQuery : IRequest<Result<List<GetAllCustomerDto>>>;

    public class GetAllCustomerInfoQueryHandler : IRequestHandler<GetAllCustomerQuery, Result<List<GetAllCustomerDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAllCustomerInfoQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllCustomerDto>>> Handle(GetAllCustomerQuery query, CancellationToken cancellationToken)
        {
            var userList = await _dataContext.Get<Customer>()
                  .ProjectTo<GetAllCustomerDto>(_mapper.ConfigurationProvider)
                  .ToListAsync(cancellationToken);

            return await Result<List<GetAllCustomerDto>>.SuccessAsync(userList);
        }
    }
}
