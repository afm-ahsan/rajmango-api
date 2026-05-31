namespace RajMango.Shared
{
    /// <summary>
    /// Single source of truth for all permission strings.
    /// Convention: module.resource.action  (e.g. "order.create")
    /// </summary>
    public static class Permissions
    {
        public static class Users
        {
            public const string View   = "user.view";
            public const string Create = "user.create";
            public const string Update = "user.update";
            public const string Delete = "user.delete";
        }

        public static class Roles
        {
            public const string View   = "role.view";
            public const string Create = "role.create";
            public const string Update = "role.update";
            public const string Delete = "role.delete";
        }

        public static class Orders
        {
            public const string View        = "order.view";
            public const string Create      = "order.create";
            public const string Update      = "order.update";
            public const string Delete      = "order.delete";
            public const string AdminView   = "order.admin.view";
            public const string AdminManage = "order.admin.manage";
        }

        public static class Payments
        {
            public const string View   = "payment.view";
            public const string Create = "payment.create";
            public const string Update = "payment.update";
            public const string Delete = "payment.delete";
        }

        public static class Expenses
        {
            public const string View   = "expense.view";
            public const string Create = "expense.create";
            public const string Update = "expense.update";
            public const string Delete = "expense.delete";
        }

        public static class ExpenseTypes
        {
            public const string View   = "expense.type.view";
            public const string Create = "expense.type.create";
            public const string Update = "expense.type.update";
            public const string Delete = "expense.type.delete";
        }

        public static class Couriers
        {
            public const string View   = "courier.view";
            public const string Create = "courier.create";
            public const string Update = "courier.update";
            public const string Delete = "courier.delete";
        }

        public static class CourierProviders
        {
            public const string View   = "courier.provider.view";
            public const string Create = "courier.provider.create";
            public const string Update = "courier.provider.update";
            public const string Delete = "courier.provider.delete";
        }

        public static class CourierStations
        {
            public const string View   = "courier.station.view";
            public const string Create = "courier.station.create";
            public const string Update = "courier.station.update";
            public const string Delete = "courier.station.delete";
        }

        public static class CourierAreaMaps
        {
            public const string View   = "courier.area.map.view";
            public const string Create = "courier.area.map.create";
            public const string Update = "courier.area.map.update";
            public const string Delete = "courier.area.map.delete";
        }

        public static class Customers
        {
            public const string View   = "customer.view";
            public const string Create = "customer.create";
            public const string Update = "customer.update";
            public const string Delete = "customer.delete";
        }

        public static class MangoTypes
        {
            public const string View   = "mango.type.view";
            public const string Manage = "mango.type.manage";
        }

        public static class MangoAvailability
        {
            public const string View   = "mango.availability.view";
            public const string Manage = "mango.availability.manage";
        }

        public static class Reports
        {
            public const string View = "report.view";
        }

        public static class Dashboard
        {
            public const string AdminView    = "dashboard.admin.view";
            public const string CustomerView = "dashboard.customer.view";
        }

        public static class Complaints
        {
            public const string Submit      = "complaint.submit";
            public const string AdminView   = "complaint.admin.view";
            public const string AdminManage = "complaint.admin.manage";
        }

        public static class Faq
        {
            public const string Manage = "faq.manage";
        }

        public static class Policies
        {
            public const string View   = "policy.view";
            public const string Manage = "policy.manage";
        }

        public static class CourierRateConfigurations
        {
            public const string View   = "courier.rate.config.view";
            public const string Create = "courier.rate.config.create";
            public const string Update = "courier.rate.config.update";
            public const string Delete = "courier.rate.config.delete";
        }

        public static class Feedback
        {
            public const string AdminView = "feedback.admin.view";
        }

        public static class UserPermissions
        {
            public const string View   = "user.permission.view";
            public const string Grant  = "user.permission.grant";
            public const string Revoke = "user.permission.revoke";
        }

        /// <summary>All permissions — used for seed data generation.</summary>
        public static IReadOnlyList<string> All => new[]
        {
            Users.View, Users.Create, Users.Update, Users.Delete,
            Roles.View, Roles.Create, Roles.Update, Roles.Delete,
            Orders.View, Orders.Create, Orders.Update, Orders.Delete, Orders.AdminView, Orders.AdminManage,
            Payments.View, Payments.Create, Payments.Update, Payments.Delete,
            Expenses.View, Expenses.Create, Expenses.Update, Expenses.Delete,
            ExpenseTypes.View, ExpenseTypes.Create, ExpenseTypes.Update, ExpenseTypes.Delete,
            Couriers.View, Couriers.Create, Couriers.Update, Couriers.Delete,
            Customers.View, Customers.Create, Customers.Update, Customers.Delete,
            MangoTypes.View, MangoTypes.Manage,
            MangoAvailability.View, MangoAvailability.Manage,
            Reports.View,
            Dashboard.AdminView, Dashboard.CustomerView,
            Complaints.Submit, Complaints.AdminView, Complaints.AdminManage,
            Faq.Manage,
            Policies.View, Policies.Manage,
            Feedback.AdminView,
            UserPermissions.View, UserPermissions.Grant, UserPermissions.Revoke,
            CourierProviders.View, CourierProviders.Create, CourierProviders.Update, CourierProviders.Delete,
            CourierStations.View, CourierStations.Create, CourierStations.Update, CourierStations.Delete,
            CourierAreaMaps.View, CourierAreaMaps.Create, CourierAreaMaps.Update, CourierAreaMaps.Delete,
            CourierRateConfigurations.View, CourierRateConfigurations.Create, CourierRateConfigurations.Update, CourierRateConfigurations.Delete,
        };

        /// <summary>Permissions granted to the Admin role.</summary>
        public static IReadOnlyList<string> AdminPermissions => All;

        /// <summary>Permissions granted to the General (customer) role.</summary>
        public static IReadOnlyList<string> GeneralPermissions => new[]
        {
            Orders.View, Orders.Create, Orders.Update, Orders.Delete,
            MangoTypes.View, MangoAvailability.View,
            Dashboard.CustomerView,
            Complaints.Submit,
            Policies.View,
        };
    }
}
