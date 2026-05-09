using AutoMapper;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetExpenseByIdQuery : IRequest<Result<GetExpenseByIdDto>>
    {
        public int Id { get; set; }

        public GetExpenseByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetExpenseInfoByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, Result<GetExpenseByIdDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetExpenseInfoByIdQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetExpenseByIdDto>> Handle(GetExpenseByIdQuery query, CancellationToken cancellationToken)
        {
            var table = await _dataContext.Get<Expense>().FirstOrDefaultAsync(u => u.Id == query.Id);
            var tableDto = _mapper.Map<GetExpenseByIdDto>(table);
            return await Result<GetExpenseByIdDto>.SuccessAsync(tableDto);
        }
    }
}
