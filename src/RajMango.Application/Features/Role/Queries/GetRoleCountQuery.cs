using AutoMapper;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetRoleCountQuery : IRequest<Result<GetRoleCountDto>>
    {
        public GetRoleCountQuery() { }
    }

    public class GetRolesCountQueryHandler : IRequestHandler<GetRoleCountQuery, Result<GetRoleCountDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetRolesCountQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetRoleCountDto>> Handle(GetRoleCountQuery query, CancellationToken cancellationToken)
        {
            var totalCount = await _dataContext.Get<Role>().CountAsync();
            return await Result<GetRoleCountDto>.SuccessAsync(new GetRoleCountDto { TotalCount = totalCount});
        }
    }
}
