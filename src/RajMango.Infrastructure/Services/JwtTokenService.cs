using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RajMango.Application.Interfaces;
using RajMango.Shared;

namespace RajMango.Infrastructure.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly AppSettings _settings;

        public JwtTokenService(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GenerateJwtToken(int userId, string userName, string email, string roleCode)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Security.Jwt.ClientSecret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email ?? string.Empty),
                new Claim(ClaimTypes.Name, userName ?? string.Empty),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            };

            if (!string.IsNullOrEmpty(roleCode))
                claims.Add(new Claim(ClaimTypes.Role, roleCode));

            var token = new JwtSecurityToken(
                issuer: _settings.Security.Jwt.Authority,
                audience: _settings.Security.Jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
