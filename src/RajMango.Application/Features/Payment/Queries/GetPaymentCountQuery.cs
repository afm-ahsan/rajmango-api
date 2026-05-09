using AutoMapper;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetPaymentCountQuery : IRequest<Result<GetPaymentCountDto>>
    {
        public GetPaymentCountQuery() { }
    }

    public class GetPaymentsCountQueryHandler : IRequestHandler<GetPaymentCountQuery, Result<GetPaymentCountDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetPaymentsCountQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetPaymentCountDto>> Handle(GetPaymentCountQuery query, CancellationToken cancellationToken)
        {
            var totalCount = await _dataContext.Get<Payment>().CountAsync();
            return await Result<GetPaymentCountDto>.SuccessAsync(new GetPaymentCountDto { TotalCount = totalCount});
        }
    }
}
