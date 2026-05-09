using AutoMapper;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetExpenseCountQuery : IRequest<Result<GetExpenseCountDto>>
    {
        public GetExpenseCountQuery() { }
    }

    public class GetExpensesCountQueryHandler : IRequestHandler<GetExpenseCountQuery, Result<GetExpenseCountDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetExpensesCountQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetExpenseCountDto>> Handle(GetExpenseCountQuery query, CancellationToken cancellationToken)
        {
            var totalCount = await _dataContext.Get<Expense>().CountAsync();
            return await Result<GetExpenseCountDto>.SuccessAsync(new GetExpenseCountDto { TotalCount = totalCount});
        }
    }
}
