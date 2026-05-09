using RajMango.Application.DTOs;

namespace RajMango.Application.Features.Queries
{
    public class GetAuthUserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        //public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AuthToken { get; set; }

        public JwtAuthDto JwtAuth { get; set; }
        public List<AuthUserRole> Roles { get; set; }

        public int? RoleId { get; set; }

        public string PermissionJson { get; set; }
        public List<PermissionModel> Permissions { get; set; }
    }

    public class AuthUserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
