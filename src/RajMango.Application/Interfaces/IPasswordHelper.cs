using RajMango.Domain.Entities;

namespace RajMango.Application.Interfaces
{
    public interface IPasswordHelper
    {
        string HashPassword(AppUser user, string password);
        bool VerifyPassword(AppUser user, string hashedPassword, string password);
    }
}
