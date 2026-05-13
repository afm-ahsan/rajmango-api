using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.UserPermission.Queries
{
    public record GetUserDirectPermissionsQuery(int UserId) : IRequest<Result<List<UserPermissionDto>>>;

    public class UserPermissionDto
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string Module { get; set; }
        public bool IsGranted { get; set; }
    }

    internal class GetUserDirectPermissionsQueryHandler : IRequestHandler<GetUserDirectPermissionsQuery, Result<List<UserPermissionDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly IErrorHandler _errorHandler;

        public GetUserDirectPermissionsQueryHandler(IDataContext dataContext, IErrorHandler errorHandler)
        {
            _dataContext = dataContext;
            _errorHandler = errorHandler;
        }

        public async Task<Result<List<UserPermissionDto>>> Handle(GetUserDirectPermissionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userExists = await _dataContext.Get<AppUser>().AnyAsync(u => u.Id == request.UserId, cancellationToken);
                if (!userExists)
                    return await Result<List<UserPermissionDto>>.FailureAsync($"User not found with Id {request.UserId}");

                var items = await _dataContext.Get<Domain.Entities.UserPermission>()
                    .Where(up => up.UserId == request.UserId)
                    .Select(up => new UserPermissionDto
                    {
                        PermissionId = up.PermissionId,
                        PermissionName = up.Permission.Name,
                        Module = up.Permission.Module,
                        IsGranted = up.IsGranted,
                    })
                    .OrderBy(x => x.Module).ThenBy(x => x.PermissionName)
                    .ToListAsync(cancellationToken);

                return await Result<List<UserPermissionDto>>.SuccessAsync(items);
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<List<UserPermissionDto>>.FailureAsync("Failed to retrieve user permissions.");
        }
    }
}
