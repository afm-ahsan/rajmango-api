namespace RajMango.Application.Interfaces
{
    public interface IPermissionService
    {
        Task<IReadOnlyList<string>> GetUserPermissionsAsync(int userId, CancellationToken ct = default);
        Task<bool> HasPermissionAsync(int userId, string permission, CancellationToken ct = default);
        Task InvalidateUserPermissionCacheAsync(int userId, CancellationToken ct = default);
    }
}
