using AutoMapper;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetExpenseTypeByIdQuery : IRequest<Result<GetExpenseTypeByIdDto>>
    {
        public int Id { get; set; }

        public GetExpenseTypeByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetExpenseTypeInfoByIdQueryHandler : IRequestHandler<GetExpenseTypeByIdQuery, Result<GetExpenseTypeByIdDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetExpenseTypeInfoByIdQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetExpenseTypeByIdDto>> Handle(GetExpenseTypeByIdQuery query, CancellationToken cancellationToken)
        {
            var table = await _dataContext.Get<ExpenseType>().FirstOrDefaultAsync(u => u.Id == query.Id);
            var tableDto = _mapper.Map<GetExpenseTypeByIdDto>(table);
            return await Result<GetExpenseTypeByIdDto>.SuccessAsync(tableDto);
        }
    }
}
