using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetUserWithPaginationQuery : IRequest<PaginatedResult<AppUserDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string Filter { get; set; }
    }

    public class GetUserInfoWithPaginationQueryHandler : IRequestHandler<GetUserWithPaginationQuery, PaginatedResult<AppUserDto>>
    {
        private readonly IDataContext _dataContext;

        public GetUserInfoWithPaginationQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PaginatedResult<AppUserDto>> Handle(GetUserWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var userQuery = BuildQuery(query.Filter, query.SortBy, query.SortOrder == "asc");

            var paginated = await userQuery.ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);

            return PaginatedResult<AppUserDto>.Create(paginated.Data, paginated.TotalCount, query.PageNumber, query.PageSize);
        }

        private IQueryable<AppUserDto> BuildQuery(string filter, string sortBy, bool ascending)
        {
            var query =
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
                    RoleCode = role == null ? null : role.Code,
                };

            if (!string.IsNullOrEmpty(filter))
                query = query.Where(u => u.FirstName.Contains(filter) || u.LastName.Contains(filter) || u.Email.Contains(filter));

            query = sortBy switch
            {
                "userName" => ascending ? query.OrderBy(u => u.UserName) : query.OrderByDescending(u => u.UserName),
                "firstName" => ascending ? query.OrderBy(u => u.FirstName) : query.OrderByDescending(u => u.FirstName),
                "lastName" => ascending ? query.OrderBy(u => u.LastName) : query.OrderByDescending(u => u.LastName),
                "email" => ascending ? query.OrderBy(u => u.Email) : query.OrderByDescending(u => u.Email),
                "phoneNumber" => ascending ? query.OrderBy(u => u.PhoneNumber) : query.OrderByDescending(u => u.PhoneNumber),
                "isActive" => ascending ? query.OrderBy(u => u.IsActive) : query.OrderByDescending(u => u.IsActive),
                _ => query.OrderBy(u => u.Id),
            };

            return query;
        }
    }
}
