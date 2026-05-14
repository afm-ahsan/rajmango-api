using AutoMapper;
using AutoMapper.QueryableExtensions;
using RajMango.Application.Common;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetAllRoleQuery : IRequest<Result<List<GetAllRoleDto>>>;

    public class GetAllRoleInfoQueryHandler : IRequestHandler<GetAllRoleQuery, Result<List<GetAllRoleDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAllRoleInfoQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllRoleDto>>> Handle(GetAllRoleQuery query, CancellationToken cancellationToken)
        {
            var roles = await _dataContext.Get<Role>()
                  .ProjectTo<GetAllRoleDto>(_mapper.ConfigurationProvider)
                  .ToListAsync(cancellationToken);
            
            foreach (var role in roles)
                role.Permissions = PermissionMigrationHelper.DeserializeToFlatPermissions(role.PermissionJson);

            return await Result<List<GetAllRoleDto>>.SuccessAsync(roles);
        }
    }
}
