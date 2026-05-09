using AutoMapper;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetCustomerByIdQuery : IRequest<Result<GetCustomerByIdDto>>
    {
        public int Id { get; set; }

        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCustomerInfoByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<GetCustomerByIdDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCustomerInfoByIdQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetCustomerByIdDto>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            var table = await _dataContext.Get<Customer>().FirstOrDefaultAsync(u => u.Id == query.Id);
            var tableDto = _mapper.Map<GetCustomerByIdDto>(table);
            return await Result<GetCustomerByIdDto>.SuccessAsync(tableDto);
        }
    }
}
