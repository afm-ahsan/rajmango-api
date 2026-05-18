using RajMango.Shared;
using System.Text.Json;

namespace RajMango.DataAccess.Extensions
{
    internal static class RajMangoPermissionData
    {
        public static string AdminPermissionJson() =>
            JsonSerializer.Serialize(Permissions.AdminPermissions);

        public static string SelfRegisterPermissionJson() =>
            JsonSerializer.Serialize(Permissions.GeneralPermissions);
    }
}
