namespace RajMango.Infrastructure.Authorization
{
    public static class PermissionCacheKeys
    {
        /// <summary>Cache key for a user's effective permission list.</summary>
        public static string UserPermissions(int userId) => $"user-permissions:0:{userId}";
    }
}
