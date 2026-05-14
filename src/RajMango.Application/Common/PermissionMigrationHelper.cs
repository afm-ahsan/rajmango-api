using Newtonsoft.Json;
using RajMango.Application.DTOs;

namespace RajMango.Application.Common
{
    /// <summary>
    /// Safely deserializes Role.PermissionJson from either the old hierarchical format
    /// (List of PermissionModel with Area/FeatureModels) or the new flat format
    /// (List of permission key strings like "user.view").
    /// </summary>
    internal static class PermissionMigrationHelper
    {
        // Feature ID + Action name → flat permission key (matches RajMangoPermissionData stable IDs)
        private static readonly Dictionary<(int featureId, string action), string> FeatureActionMap =
            new()
            {
                { (1, "View"),         "dashboard.admin.view" },
                { (2, "View"),         "dashboard.customer.view" },
                { (3, "View"),         "mango.type.view" },
                { (3, "Manage"),       "mango.type.manage" },
                { (4, "View"),         "mango.availability.view" },
                { (4, "Manage"),       "mango.availability.manage" },
                { (5, "View"),         "order.view" },
                { (5, "Create"),       "order.create" },
                { (5, "Update"),       "order.update" },
                { (5, "Delete"),       "order.delete" },
                { (6, "View"),         "customer.view" },
                { (6, "Create"),       "customer.create" },
                { (6, "Update"),       "customer.update" },
                { (6, "Delete"),       "customer.delete" },
                { (7, "View"),         "courier.view" },
                { (7, "Create"),       "courier.create" },
                { (7, "Update"),       "courier.update" },
                { (7, "Delete"),       "courier.delete" },
                { (8, "View"),         "payment.view" },
                { (8, "Create"),       "payment.create" },
                { (8, "Update"),       "payment.update" },
                { (8, "Delete"),       "payment.delete" },
                { (9, "View"),         "expense.view" },
                { (9, "Create"),       "expense.create" },
                { (9, "Update"),       "expense.update" },
                { (9, "Delete"),       "expense.delete" },
                { (10, "View"),        "expense.type.view" },
                { (10, "Create"),      "expense.type.create" },
                { (10, "Update"),      "expense.type.update" },
                { (10, "Delete"),      "expense.type.delete" },
                { (11, "Admin View"),  "feedback.admin.view" },
                { (12, "Submit"),      "complaint.submit" },
                { (12, "Admin View"),  "complaint.admin.view" },
                { (12, "Admin Manage"),"complaint.admin.manage" },
                { (13, "View"),        "report.view" },
                { (14, "View"),        "user.view" },
                { (14, "Create"),      "user.create" },
                { (14, "Update"),      "user.update" },
                { (14, "Delete"),      "user.delete" },
                { (15, "View"),        "role.view" },
                { (15, "Create"),      "role.create" },
                { (15, "Update"),      "role.update" },
                { (15, "Delete"),      "role.delete" },
                { (16, "View"),        "user.permission.view" },
                { (16, "Grant"),       "user.permission.grant" },
                { (16, "Revoke"),      "user.permission.revoke" },
                { (17, "Manage"),      "faq.manage" },
                { (18, "View"),        "policy.view" },
                { (18, "Manage"),      "policy.manage" },
            };

        public static List<string> DeserializeToFlatPermissions(string permissionJson)
        {
            if (string.IsNullOrWhiteSpace(permissionJson))
                return new List<string>();

            // Try new flat string-array format first
            try
            {
                var flat = JsonConvert.DeserializeObject<List<string>>(permissionJson);
                if (flat != null && flat.Count > 0)
                    return flat;
            }
            catch { }

            // Fall back to old hierarchical Area/Feature/Action format
            try
            {
                var hierarchical = JsonConvert.DeserializeObject<List<PermissionModel>>(permissionJson);
                if (hierarchical != null)
                    return ConvertHierarchicalToFlat(hierarchical);
            }
            catch { }

            return new List<string>();
        }

        private static List<string> ConvertHierarchicalToFlat(List<PermissionModel> areas)
        {
            var result = new List<string>();
            foreach (var area in areas)
            {
                if (area.FeatureModels == null) continue;
                foreach (var feature in area.FeatureModels)
                {
                    if (feature.ActionModels == null) continue;
                    foreach (var action in feature.ActionModels)
                    {
                        if (!action.HasAccess) continue;
                        if (FeatureActionMap.TryGetValue((feature.Id, action.Action), out var permKey))
                            result.Add(permKey);
                    }
                }
            }
            return result;
        }
    }
}
