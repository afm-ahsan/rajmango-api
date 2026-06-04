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
        public string Filter { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        public GetRoleWithPaginationQuery() { }
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
            var q = _dataContext.Get<Role>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                var f = query.Filter.Trim().ToLower();
                q = q.Where(r => r.Name.ToLower().Contains(f) ||
                                 (r.Description != null && r.Description.ToLower().Contains(f)));
            }

            bool asc = string.IsNullOrEmpty(query.SortOrder) || query.SortOrder.ToLower() != "desc";
            q = (query.SortBy?.ToLower()) switch
            {
                "description" => asc ? q.OrderBy(r => r.Description) : q.OrderByDescending(r => r.Description),
                _             => asc ? q.OrderBy(r => r.Name)        : q.OrderByDescending(r => r.Name),
            };

            var paginatedRoles = await q
                .ProjectTo<GetRoleWithPaginationDto>(_mapper.ConfigurationProvider)
                .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);

            foreach (var role in paginatedRoles.Data)
                role.Permissions = PermissionMigrationHelper.DeserializeToFlatPermissions(role.PermissionJson);
            return paginatedRoles;
        }
    }
}
