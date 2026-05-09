using AutoMapper;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace RajMango.Application.Features.Queries
{
    public record GetAuthUserQuery : IRequest<Result<GetAuthUserDto>>
    {
        //public string UserName { get; set; }
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
        private readonly IMapper _mapper;

        public GetGetAuthUserQueryHandler(IPasswordHasher<AppUser> passwordHasher, IDataContext dataContext, IMapper mapper)
        {
            _passwordHasher = passwordHasher;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<GetAuthUserDto>> Handle(GetAuthUserQuery query, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Get<AppUser>().FirstOrDefaultAsync(u => u.Email == query.Email);

            if (user == null)
            {
                return await Result<GetAuthUserDto>.FailureAsync($"Invalid username.");
            }

            //var hashedPassword = _passwordHasher.HashPassword(user, query.Password);
            //var hashedPassword1 = _passwordHasher.HashPassword(user, "S@dmin321!");
            //var hashedPassword2 = _passwordHasher.HashPassword(user, "@dmin321!");

            var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, query.Password);
            if (verifyPassword == PasswordVerificationResult.Failed)
            {
                return await Result<GetAuthUserDto>.FailureAsync($"Invalid password.");
            }

            var jwtAuth = await CreateAccessToken(user.Id, cancellationToken);

            var authUserDto = new GetAuthUserDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ImagePath = "/assets/media/avatars/300-1.jpg",
                PhoneNumber = user.PhoneNumber,
                AuthToken = jwtAuth.AuthToken,
                JwtAuth = jwtAuth
            };


            var userRole = _dataContext.Get<UserRole>().FirstOrDefault(p => p.UserId == user.Id);
            if (userRole != null)
            {
                var role = await _dataContext.Get<Role>().FirstOrDefaultAsync(p => p.Id == userRole.RoleId && p.IsActive);
                if (role != null)
                {
                    authUserDto.RoleId = role.Id;
                    if (!string.IsNullOrEmpty(role.PermissionJson))
                    {
                        authUserDto.PermissionJson = role.PermissionJson;
                        authUserDto.Permissions = JsonConvert.DeserializeObject<List<PermissionModel>>(role.PermissionJson);
                    }
                }
            }
            return await Result<GetAuthUserDto>.SuccessAsync(authUserDto);
        }

        private async Task<JwtAuthDto> CreateAccessToken(int userId, CancellationToken cancellationToken)
        {
            var jwtAuth = new JwtAuth
            {
                UserId = userId,
                AuthToken = CreateToken(),
                RefreshToken = CreateToken(),
                ExpiresIn = DateTime.Now.AddHours(24),
                IpAddress = "127.0.0.1",
                DeviceInfo = "Seeded device",
            };
            _dataContext.Get<JwtAuth>().Add(jwtAuth);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return new JwtAuthDto
            {
                AuthToken = jwtAuth.AuthToken,
                RefreshToken = jwtAuth.RefreshToken,
                ExpiresIn = jwtAuth.ExpiresIn
            };
        }

        private string CreateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.Now.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            return token;
            //string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}
