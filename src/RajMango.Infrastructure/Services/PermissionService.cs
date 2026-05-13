using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Infrastructure.Authorization;

namespace RajMango.Infrastructure.Services
{
    public class PermissionService : IPermissionService
    {
        private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(30);

        private readonly IDataContext _dataContext;
        private readonly ICacheService _cacheService;
        private readonly ILogger<PermissionService> _logger;

        public PermissionService(
            IDataContext dataContext,
            ICacheService cacheService,
            ILogger<PermissionService> logger)
        {
            _dataContext = dataContext;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<IReadOnlyList<string>> GetUserPermissionsAsync(int userId, CancellationToken ct = default)
        {
            var cacheKey = PermissionCacheKeys.UserPermissions(userId);

            var cached = await _cacheService.GetAsync<List<string>>(cacheKey, ct);
            if (cached is not null)
                return cached;

            var permissions = await LoadPermissionsFromDbAsync(userId, ct);
            await _cacheService.SetAsync(cacheKey, permissions.ToList(), CacheTtl, ct);

            return permissions;
        }

        public async Task<bool> HasPermissionAsync(int userId, string permission, CancellationToken ct = default)
        {
            var permissions = await GetUserPermissionsAsync(userId, ct);
            return permissions.Contains(permission, StringComparer.OrdinalIgnoreCase);
        }

        public async Task InvalidateUserPermissionCacheAsync(int userId, CancellationToken ct = default)
        {
            await _cacheService.RemoveAsync(PermissionCacheKeys.UserPermissions(userId), ct);
            _logger.LogInformation("Permission cache invalidated for user {UserId}", userId);
        }

        private async Task<IReadOnlyList<string>> LoadPermissionsFromDbAsync(int userId, CancellationToken ct)
        {
            var roleIds = await _dataContext.Get<UserRole>()
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.RoleId)
                .ToListAsync(ct);

            var rolePermissionNames = await _dataContext.Get<RolePermission>()
                .Where(rp => roleIds.Contains(rp.RoleId) && rp.Permission.IsActive)
                .Select(rp => rp.Permission.Name)
                .Distinct()
                .ToListAsync(ct);

            var userOverrides = await _dataContext.Get<UserPermission>()
                .Where(up => up.UserId == userId && up.Permission.IsActive)
                .Select(up => new { up.Permission.Name, up.IsGranted })
                .ToListAsync(ct);

            var permissions = new HashSet<string>(rolePermissionNames, StringComparer.OrdinalIgnoreCase);

            foreach (var ov in userOverrides)
            {
                if (ov.IsGranted)
                    permissions.Add(ov.Name);
                else
                    permissions.Remove(ov.Name);
            }

            _logger.LogDebug("Loaded {Count} permissions for user {UserId} from database", permissions.Count, userId);
            return permissions.ToList();
        }
    }
}
