using AutoMapper;
using AutoMapper.QueryableExtensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetAllExpenseQuery : IRequest<Result<List<GetAllExpenseDto>>>;

    public class GetAllExpenseInfoQueryHandler : IRequestHandler<GetAllExpenseQuery, Result<List<GetAllExpenseDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAllExpenseInfoQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllExpenseDto>>> Handle(GetAllExpenseQuery query, CancellationToken cancellationToken)
        {
            var userList = await _dataContext.Get<Expense>()
                  .ProjectTo<GetAllExpenseDto>(_mapper.ConfigurationProvider)
                  .ToListAsync(cancellationToken);

            return await Result<List<GetAllExpenseDto>>.SuccessAsync(userList);
        }
    }
}
