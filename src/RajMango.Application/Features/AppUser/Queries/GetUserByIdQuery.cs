using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetUserByIdQuery : IRequest<Result<AppUserDto>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetUserInfoByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<AppUserDto>>
    {
        private readonly IDataContext _dataContext;

        public GetUserInfoByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<AppUserDto>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Get<AppUser>().FirstOrDefaultAsync(u => u.Id == query.Id);
            if (user == null)
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

                var role = await _dataContext.Get<UserRole>().FirstOrDefaultAsync(p => p.UserId == query.Id);
                if (role != null)
                {
                    orderDto.RoleId = role.RoleId;
                }
                return await Result<AppUserDto>.SuccessAsync(orderDto);
            }
            return await Result<AppUserDto>.SuccessAsync(new AppUserDto());
        }
    }
}
