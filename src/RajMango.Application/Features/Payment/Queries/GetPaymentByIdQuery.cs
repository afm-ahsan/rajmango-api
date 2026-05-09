using AutoMapper;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetPaymentByIdQuery : IRequest<Result<GetPaymentByIdDto>>
    {
        public int Id { get; set; }

        public GetPaymentByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetPaymentInfoByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, Result<GetPaymentByIdDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetPaymentInfoByIdQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetPaymentByIdDto>> Handle(GetPaymentByIdQuery query, CancellationToken cancellationToken)
        {
            var table = await _dataContext.Get<Payment>().FirstOrDefaultAsync(u => u.Id == query.Id);
            var tableDto = _mapper.Map<GetPaymentByIdDto>(table);
            return await Result<GetPaymentByIdDto>.SuccessAsync(tableDto);
        }
    }
}
