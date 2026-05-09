using AutoMapper;
using AutoMapper.QueryableExtensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetAllExpenseTypeQuery : IRequest<Result<List<GetAllExpenseTypeDto>>>;

    public class GetAllExpenseTypeInfoQueryHandler : IRequestHandler<GetAllExpenseTypeQuery, Result<List<GetAllExpenseTypeDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAllExpenseTypeInfoQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllExpenseTypeDto>>> Handle(GetAllExpenseTypeQuery query, CancellationToken cancellationToken)
        {
            var userList = await _dataContext.Get<ExpenseType>()
                  .ProjectTo<GetAllExpenseTypeDto>(_mapper.ConfigurationProvider)
                  .ToListAsync(cancellationToken);

            return await Result<List<GetAllExpenseTypeDto>>.SuccessAsync(userList);
        }
    }
}
