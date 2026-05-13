using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Newtonsoft.Json;

namespace RajMango.Application.Features.Commands
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IPermissionService _permissionService;

        public UpdateRoleCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IMapper mapper, IPermissionService permissionService)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
            _permissionService = permissionService;
        }

        public async Task<Result<int>> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _dataContext.Get<Role>().FindAsync(command.Id);
                if (role != null)
                {
                    var affectedUserIds = await _dataContext.Get<UserRole>()
                        .Where(ur => ur.RoleId == command.Id)
                        .Select(ur => ur.UserId)
                        .ToListAsync(cancellationToken);

                    role.Name = command.Name;
                    role.Description = command.Description;
                    role.IsActive = command.IsActive;
                    role.PermissionJson = JsonConvert.SerializeObject(command.Permissions);
                    role.UpdatedAt = Clock.Now();

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    foreach (var userId in affectedUserIds)
                        await _permissionService.InvalidateUserPermissionCacheAsync(userId, cancellationToken);

                    return await Result<int>.SuccessAsync(role.Id, "Role is Updated.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Role information not found with the Id - {command.Id}");
        }
    }
}
