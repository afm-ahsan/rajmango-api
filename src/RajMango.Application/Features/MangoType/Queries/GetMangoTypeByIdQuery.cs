using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetMangoTypeByIdQuery : IRequest<Result<GetMangoTypeByIdDto>>
    {
        public int Id { get; set; }

        public GetMangoTypeByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCategoryInfoByIdQueryHandler : IRequestHandler<GetMangoTypeByIdQuery, Result<GetMangoTypeByIdDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCategoryInfoByIdQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetMangoTypeByIdDto>> Handle(GetMangoTypeByIdQuery query, CancellationToken cancellationToken)
        {
            var mangoType = await _dataContext.Get<MangoType>().FirstOrDefaultAsync(u => u.Id == query.Id);
            var mangoTypeDto = _mapper.Map<GetMangoTypeByIdDto>(mangoType);
            return await Result<GetMangoTypeByIdDto>.SuccessAsync(mangoTypeDto);
        }
    }
}
