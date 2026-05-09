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
            var userQuery = _dataContext.Get<AppUser>()
                                         .AsQueryable();
            userQuery = GetSortableQuery(userQuery, query.Filter, query.SortBy, query.SortOrder == "asc");

            var users = await userQuery.ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);

            var userDtos = new List<AppUserDto>();
            foreach (var user in users.Data)
            {
                var orderDto = new AppUserDto
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    IsActive = user.IsActive,
                    EmailConfirmed = user.EmailConfirmed,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                };

                userDtos.Add(orderDto);
            }

            var roleList = await _dataContext.Get<UserRole>().ToListAsync(cancellationToken);
            foreach (var userDto in userDtos)
            {
                var role = roleList.FirstOrDefault(p => p.UserId == userDto.Id);
                if (role != null)
                {
                    userDto.RoleId = role.RoleId;
                }
            }

            return new PaginatedResult<AppUserDto>(succeeded: true, data: userDtos, pageNumber: query.PageNumber, pageSize: query.PageSize);
        }

        public IQueryable<AppUser> GetSortableQuery(IQueryable<AppUser> query, string filter, string sortBy, bool ascending)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(s => s.FirstName.Contains(filter));
            }

            switch (sortBy)
            {
                case "userName":
                    query = ascending ? query.OrderBy(e => e.UserName) : query.OrderByDescending(e => e.UserName);
                    break;
                case "firstName":
                    query = ascending ? query.OrderBy(e => e.FirstName) : query.OrderByDescending(e => e.FirstName);
                    break;
                case "lastName":
                    query = ascending ? query.OrderBy(e => e.LastName) : query.OrderByDescending(e => e.LastName);
                    break;
                case "email":
                    query = ascending ? query.OrderBy(e => e.Email) : query.OrderByDescending(e => e.Email);
                    break;
                case "phoneNumber":
                    query = ascending ? query.OrderBy(e => e.PhoneNumber) : query.OrderByDescending(e => e.PhoneNumber);
                    break;
                case "isActive":
                    query = ascending ? query.OrderBy(e => e.IsActive) : query.OrderByDescending(e => e.IsActive);
                    break;
            }

            return query;
        }
    }
}
