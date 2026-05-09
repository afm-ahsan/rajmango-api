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
            var users = await _dataContext.Get<AppUser>()
                                          .ToListAsync(cancellationToken);

            var userDtos = new List<AppUserDto>();
            foreach (var user in users)
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

            return await Result<List<AppUserDto>>.SuccessAsync(userDtos);
        }
    }
}
