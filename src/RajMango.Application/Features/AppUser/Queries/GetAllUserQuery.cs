using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetAllUserQuery : IRequest<Result<List<AppUserDto>>>;

    public class GetAllUserInfoQueryHandler : IRequestHandler<GetAllUserQuery, Result<List<AppUserDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetAllUserInfoQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<AppUserDto>>> Handle(GetAllUserQuery query, CancellationToken cancellationToken)
        {
            var userDtos = await (
                from user in _dataContext.Get<AppUser>()
                join userRole in _dataContext.Get<UserRole>() on user.Id equals userRole.UserId into userRoles
                from userRole in userRoles.DefaultIfEmpty()
                join role in _dataContext.Get<Role>() on userRole.RoleId equals role.Id into roles
                from role in roles.DefaultIfEmpty()
                select new AppUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    EmailConfirmed = user.EmailConfirmed,
                    ImagePath = user.ImagePath ?? "/assets/media/avatars/300-1.jpg",
                    IsActive = user.IsActive,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                    RoleId = userRole == null ? 0 : userRole.RoleId,
                    RoleName = role == null ? null : role.Name,
                }
            ).ToListAsync(cancellationToken);

            return await Result<List<AppUserDto>>.SuccessAsync(userDtos);
        }
    }
}
