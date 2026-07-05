using RajMango.Application.DTOs;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetAuthUserQuery : IRequest<Result<GetAuthUserDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public GetAuthUserQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    public class GetGetAuthUserQueryHandler : IRequestHandler<GetAuthUserQuery, Result<GetAuthUserDto>>
    {
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IDataContext _dataContext;
        private readonly IJwtTokenService _jwtTokenService;

        public GetGetAuthUserQueryHandler(
            IPasswordHasher<AppUser> passwordHasher,
            IDataContext dataContext,
            IJwtTokenService jwtTokenService)
        {
            _passwordHasher = passwordHasher;
            _dataContext = dataContext;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<Result<GetAuthUserDto>> Handle(GetAuthUserQuery query, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Get<AppUser>().FirstOrDefaultAsync(u => u.Email == query.Email, cancellationToken);

            if (user == null)
                return await Result<GetAuthUserDto>.FailureAsync("Invalid username.");

            var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, query.Password);
            if (verifyPassword == PasswordVerificationResult.Failed)
                return await Result<GetAuthUserDto>.FailureAsync("Invalid password.");

            // Fetch role before token generation so the role claim is embedded in the JWT
            string roleCode = null;
            int? roleId = null;
            List<string> permissions = null;

            var userRole = await _dataContext.Get<UserRole>().FirstOrDefaultAsync(p => p.UserId == user.Id, cancellationToken);
            if (userRole != null)
            {
                var role = await _dataContext.Get<Role>().FirstOrDefaultAsync(p => p.Id == userRole.RoleId && p.IsActive, cancellationToken);
                if (role != null)
                {
                    roleCode = role.Code;
                    roleId = role.Id;

                    // Read permissions from the normalised RolePermission → Permission join.
                    // This is the ground truth: every permission assigned to this role via
                    // HasData seed and subsequent migrations is correctly represented here.
                    // It replaces the previous Role.PermissionJson approach which was fragile
                    // (depended on PermissionJson format staying in sync with the flat-string
                    // convention and PermissionMigrationHelper.FeatureActionMap being complete).
                    permissions = await _dataContext.Get<RolePermission>()
                        .Where(rp => rp.RoleId == role.Id)
                        .Select(rp => rp.Permission.Name)
                        .ToListAsync(cancellationToken);
                }
            }

            var jwtAuth = await CreateAccessTokenAsync(user, roleCode, cancellationToken);

            return await Result<GetAuthUserDto>.SuccessAsync(new GetAuthUserDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ImagePath = user.ImagePath,
                PhoneNumber = user.PhoneNumber,
                AuthToken = jwtAuth.AuthToken,
                JwtAuth = jwtAuth,
                RoleId = roleId,
                RoleCode = roleCode,
                Permissions = permissions ?? new List<string>(),
            });
        }

        private async Task<JwtAuthDto> CreateAccessTokenAsync(AppUser user, string roleCode, CancellationToken cancellationToken)
        {
            var token = _jwtTokenService.GenerateJwtToken(user.Id, user.UserName, user.Email, roleCode);
            var expiry = Clock.Now().AddHours(24);

            var jwtAuth = new JwtAuth
            {
                UserId = user.Id,
                AuthToken = token,
                RefreshToken = Guid.NewGuid().ToString("N"),
                ExpiresIn = expiry,
                IpAddress = "127.0.0.1",
                DeviceInfo = "Web",
            };
            _dataContext.Get<JwtAuth>().Add(jwtAuth);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return new JwtAuthDto
            {
                AuthToken = token,
                RefreshToken = jwtAuth.RefreshToken,
                ExpiresIn = expiry,
            };
        }
    }
}
