using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public class MyProfileDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public int? CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public record GetMyProfileQuery : IRequest<Result<MyProfileDto>>;

    public class GetMyProfileQueryHandler : IRequestHandler<GetMyProfileQuery, Result<MyProfileDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetMyProfileQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<MyProfileDto>> Handle(GetMyProfileQuery query, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var user = await _dataContext.Get<AppUser>()
                .Where(u => u.Id == userId)
                .Select(u => new { u.Id, u.UserName, u.FirstName, u.LastName, u.Email, u.PhoneNumber, u.ImagePath, u.EmailConfirmed, u.PhoneNumberConfirmed, u.CreatedAt })
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
                return await Result<MyProfileDto>.FailureAsync("User not found.");

            var userRole = await _dataContext.Get<UserRole>()
                .Where(r => r.UserId == userId)
                .Select(r => new { r.RoleId })
                .FirstOrDefaultAsync(cancellationToken);

            string roleName = null, roleCode = null;
            int? roleId = null;

            if (userRole != null)
            {
                var role = await _dataContext.Get<Role>()
                    .Where(r => r.Id == userRole.RoleId && r.IsActive)
                    .Select(r => new { r.Id, r.Name, r.Code })
                    .FirstOrDefaultAsync(cancellationToken);

                if (role != null)
                {
                    roleId   = role.Id;
                    roleName = role.Name;
                    roleCode = role.Code;
                }
            }

            var customer = await _dataContext.Get<Customer>()
                .Where(c => c.UserId == userId)
                .Select(c => new { c.Id })
                .FirstOrDefaultAsync(cancellationToken);

            var dto = new MyProfileDto
            {
                UserId               = user.Id,
                UserName             = user.UserName,
                FirstName            = user.FirstName,
                LastName             = user.LastName,
                FullName             = user.FirstName + " " + user.LastName,
                Email                = user.Email,
                PhoneNumber          = user.PhoneNumber,
                ImagePath            = user.ImagePath,
                EmailConfirmed       = user.EmailConfirmed,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                RoleId               = roleId,
                RoleName             = roleName,
                RoleCode             = roleCode,
                CustomerId           = customer?.Id,
                CreatedAt            = user.CreatedAt,
            };

            return await Result<MyProfileDto>.SuccessAsync(dto);
        }
    }
}
