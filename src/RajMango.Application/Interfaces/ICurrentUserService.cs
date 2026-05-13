namespace RajMango.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string UserName { get; }
        bool IsAuthenticated { get; }
        bool IsAdmin { get; }
        bool IsSuperAdmin { get; }
    }
}
