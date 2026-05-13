using RajMango.Application.DTOs;
using System.Text.Json;

namespace RajMango.DataAccess.Extensions
{
    /// <summary>
    /// Builds the PermissionModel JSON stored in Role.PermissionJson for the legacy
    /// area/feature/action model consumed by the Angular frontend.
    /// IDs are stable — never renumber them; only add new ones at the end.
    /// </summary>
    internal static class RajMangoPermissionData
    {
        // ── Feature IDs (stable, never renumber) ──────────────────────────────
        // Dashboard:           1 = Admin Dashboard, 2 = Customer Dashboard
        // Mango Management:    3 = Mango Types,     4 = Mango Availability
        // Order Management:    5 = Orders
        // Customer Management: 6 = Customers
        // Courier Management:  7 = Couriers
        // Payment Management:  8 = Payments
        // Expense Management:  9 = Expenses,        10 = Expense Types
        // Feedback/Complaints: 11 = Feedback,       12 = Complaints
        // Reports:             13 = Reports
        // Administration:      14 = Users,          15 = Roles,  16 = User Permissions
        // Configuration:       17 = FAQ,            18 = Policies

        private static readonly List<ActionModel> ViewOnly =
            new() { new() { Id = 1, Action = "View", HasAccess = true } };

        private static readonly List<ActionModel> ViewCreate =
            new() { new() { Id = 1, Action = "View", HasAccess = true }, new() { Id = 2, Action = "Create", HasAccess = true } };

        private static readonly List<ActionModel> Crud =
            new()
            {
                new() { Id = 1, Action = "View", HasAccess = true },
                new() { Id = 2, Action = "Create", HasAccess = true },
                new() { Id = 3, Action = "Update", HasAccess = true },
                new() { Id = 4, Action = "Delete", HasAccess = true },
            };

        private static readonly List<ActionModel> ViewManage =
            new() { new() { Id = 1, Action = "View", HasAccess = true }, new() { Id = 2, Action = "Manage", HasAccess = true } };

        private static readonly List<ActionModel> ManageOnly =
            new() { new() { Id = 1, Action = "Manage", HasAccess = true } };

        private static readonly List<ActionModel> ViewAndManage =
            new() { new() { Id = 1, Action = "View", HasAccess = true }, new() { Id = 2, Action = "Manage", HasAccess = true } };

        public static string AdminPermissionJson() =>
            Serialize(new List<PermissionModel>
            {
                new()
                {
                    Area = "Dashboard",
                    FeatureModels = new()
                    {
                        new() { Id = 1, Title = "Admin Dashboard",    HasAccess = true, ActionModels = ViewOnly },
                        new() { Id = 2, Title = "Customer Dashboard", HasAccess = true, ActionModels = ViewOnly },
                    }
                },
                new()
                {
                    Area = "Mango Management",
                    FeatureModels = new()
                    {
                        new() { Id = 3,  Title = "Mango Types",       HasAccess = true, ActionModels = ViewManage },
                        new() { Id = 4,  Title = "Mango Availability", HasAccess = true, ActionModels = ViewManage },
                    }
                },
                new()
                {
                    Area = "Order Management",
                    FeatureModels = new()
                    {
                        new() { Id = 5,  Title = "Orders",            HasAccess = true, ActionModels = Crud },
                    }
                },
                new()
                {
                    Area = "Customer Management",
                    FeatureModels = new()
                    {
                        new() { Id = 6,  Title = "Customers",         HasAccess = true, ActionModels = Crud },
                    }
                },
                new()
                {
                    Area = "Courier Management",
                    FeatureModels = new()
                    {
                        new() { Id = 7,  Title = "Couriers",          HasAccess = true, ActionModels = Crud },
                    }
                },
                new()
                {
                    Area = "Payment Management",
                    FeatureModels = new()
                    {
                        new() { Id = 8,  Title = "Payments",          HasAccess = true, ActionModels = Crud },
                    }
                },
                new()
                {
                    Area = "Expense Management",
                    FeatureModels = new()
                    {
                        new() { Id = 9,  Title = "Expenses",          HasAccess = true, ActionModels = Crud },
                        new() { Id = 10, Title = "Expense Types",     HasAccess = true, ActionModels = Crud },
                    }
                },
                new()
                {
                    Area = "Feedback & Complaints",
                    FeatureModels = new()
                    {
                        new() { Id = 11, Title = "Feedback",   HasAccess = true, ActionModels = new() { new() { Id = 1, Action = "Admin View", HasAccess = true } } },
                        new() { Id = 12, Title = "Complaints", HasAccess = true, ActionModels = new()
                        {
                            new() { Id = 1, Action = "Submit",       HasAccess = true },
                            new() { Id = 2, Action = "Admin View",   HasAccess = true },
                            new() { Id = 3, Action = "Admin Manage", HasAccess = true },
                        }},
                    }
                },
                new()
                {
                    Area = "Reports",
                    FeatureModels = new()
                    {
                        new() { Id = 13, Title = "Reports", HasAccess = true, ActionModels = ViewOnly },
                    }
                },
                new()
                {
                    Area = "Administration",
                    FeatureModels = new()
                    {
                        new() { Id = 14, Title = "Users",             HasAccess = true, ActionModels = Crud },
                        new() { Id = 15, Title = "Roles",             HasAccess = true, ActionModels = Crud },
                        new() { Id = 16, Title = "User Permissions",  HasAccess = true, ActionModels = new()
                        {
                            new() { Id = 1, Action = "View",   HasAccess = true },
                            new() { Id = 2, Action = "Grant",  HasAccess = true },
                            new() { Id = 3, Action = "Revoke", HasAccess = true },
                        }},
                    }
                },
                new()
                {
                    Area = "Configuration",
                    FeatureModels = new()
                    {
                        new() { Id = 17, Title = "FAQ",      HasAccess = true, ActionModels = ManageOnly },
                        new() { Id = 18, Title = "Policies", HasAccess = true, ActionModels = ViewAndManage },
                    }
                },
            });

        public static string GeneralPermissionJson() =>
            Serialize(new List<PermissionModel>
            {
                new()
                {
                    Area = "Dashboard",
                    FeatureModels = new()
                    {
                        new() { Id = 2, Title = "Customer Dashboard", HasAccess = true, ActionModels = ViewOnly },
                    }
                },
                new()
                {
                    Area = "Mango Management",
                    FeatureModels = new()
                    {
                        new() { Id = 3, Title = "Mango Types",        HasAccess = true, ActionModels = ViewOnly },
                        new() { Id = 4, Title = "Mango Availability",  HasAccess = true, ActionModels = ViewOnly },
                    }
                },
                new()
                {
                    Area = "Order Management",
                    FeatureModels = new()
                    {
                        new() { Id = 5, Title = "Orders", HasAccess = true, ActionModels = ViewCreate },
                    }
                },
                new()
                {
                    Area = "Feedback & Complaints",
                    FeatureModels = new()
                    {
                        new() { Id = 12, Title = "Complaints", HasAccess = true, ActionModels = new()
                        {
                            new() { Id = 1, Action = "Submit", HasAccess = true },
                        }},
                    }
                },
            });

        private static string Serialize(List<PermissionModel> model) =>
            JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = false });
    }
}
