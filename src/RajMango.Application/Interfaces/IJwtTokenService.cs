namespace RajMango.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(int userId, string userName, string email, string roleCode);
    }
}
