using AutoMapper;
using AutoMapper.QueryableExtensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetAllPaymentQuery : IRequest<Result<List<GetAllPaymentDto>>>;

    public class GetAllPaymentInfoQueryHandler : IRequestHandler<GetAllPaymentQuery, Result<List<GetAllPaymentDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAllPaymentInfoQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllPaymentDto>>> Handle(GetAllPaymentQuery query, CancellationToken cancellationToken)
        {
            var userList = await _dataContext.Get<Payment>()
                  .ProjectTo<GetAllPaymentDto>(_mapper.ConfigurationProvider)
                  .ToListAsync(cancellationToken);

            return await Result<List<GetAllPaymentDto>>.SuccessAsync(userList);
        }
    }
}
