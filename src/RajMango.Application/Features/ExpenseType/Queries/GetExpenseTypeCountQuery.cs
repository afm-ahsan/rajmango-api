using AutoMapper;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetExpenseTypeCountQuery : IRequest<Result<GetExpenseTypeCountDto>>
    {
        public GetExpenseTypeCountQuery() { }
    }

    public class GetExpenseTypesCountQueryHandler : IRequestHandler<GetExpenseTypeCountQuery, Result<GetExpenseTypeCountDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetExpenseTypesCountQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetExpenseTypeCountDto>> Handle(GetExpenseTypeCountQuery query, CancellationToken cancellationToken)
        {
            var totalCount = await _dataContext.Get<ExpenseType>().CountAsync();
            return await Result<GetExpenseTypeCountDto>.SuccessAsync(new GetExpenseTypeCountDto { TotalCount = totalCount});
        }
    }
}
