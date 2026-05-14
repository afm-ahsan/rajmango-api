using AutoMapper;
using AutoMapper.QueryableExtensions;
using RajMango.Application.Common;
using RajMango.Application.DTOs;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Queries
{
    public record GetRoleWithPaginationQuery : IRequest<PaginatedResult<GetRoleWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetRoleWithPaginationQuery() { }

        public GetRoleWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetRoleInfoWithPaginationQueryHandler : IRequestHandler<GetRoleWithPaginationQuery, PaginatedResult<GetRoleWithPaginationDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetRoleInfoWithPaginationQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetRoleWithPaginationDto>> Handle(GetRoleWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var paginatedRoles =  await _dataContext.Get<Role>()
                   .OrderBy(x => x.Name)
                   .ProjectTo<GetRoleWithPaginationDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);

            foreach (var role in paginatedRoles.Data)
                role.Permissions = PermissionMigrationHelper.DeserializeToFlatPermissions(role.PermissionJson);
            return paginatedRoles;
        }
    }
}
