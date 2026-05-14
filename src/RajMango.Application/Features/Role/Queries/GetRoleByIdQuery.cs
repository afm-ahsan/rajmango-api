using AutoMapper;
using RajMango.Application.Common;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetRoleByIdQuery : IRequest<Result<GetRoleByIdDto>>
    {
        public int Id { get; set; }

        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetRoleInfoByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Result<GetRoleByIdDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetRoleInfoByIdQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetRoleByIdDto>> Handle(GetRoleByIdQuery query, CancellationToken cancellationToken)
        {
            var role = await _dataContext.Get<Role>().FirstOrDefaultAsync(u => u.Id == query.Id);
            var roleDto = _mapper.Map<GetRoleByIdDto>(role);
            roleDto.Permissions = PermissionMigrationHelper.DeserializeToFlatPermissions(roleDto.PermissionJson);
            return await Result<GetRoleByIdDto>.SuccessAsync(roleDto);
        }
    }
}
