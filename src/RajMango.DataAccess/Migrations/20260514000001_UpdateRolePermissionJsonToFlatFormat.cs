using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    public partial class UpdateRolePermissionJsonToFlatFormat : Migration
    {
        private const string FlatAdminPermissionJson =
            "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\"," +
            "\"role.view\",\"role.create\",\"role.update\",\"role.delete\"," +
            "\"order.view\",\"order.create\",\"order.update\",\"order.delete\"," +
            "\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\"," +
            "\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\"," +
            "\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\"," +
            "\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\"," +
            "\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\"," +
            "\"mango.type.view\",\"mango.type.manage\"," +
            "\"mango.availability.view\",\"mango.availability.manage\"," +
            "\"report.view\"," +
            "\"dashboard.admin.view\",\"dashboard.customer.view\"," +
            "\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\"," +
            "\"faq.manage\"," +
            "\"policy.view\",\"policy.manage\"," +
            "\"feedback.admin.view\"," +
            "\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\"]";

        private const string FlatGeneralPermissionJson =
            "[\"order.view\",\"order.create\"," +
            "\"mango.type.view\",\"mango.availability.view\"," +
            "\"dashboard.customer.view\"," +
            "\"complaint.submit\"]";

        // Old hierarchical JSON for Down() rollback
        private const string OldAdminPermissionJson = "[{\"Area\":\"Dashboard\",\"FeatureModels\":[{\"Id\":1,\"Title\":\"Admin Dashboard\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true}]},{\"Id\":2,\"Title\":\"Customer Dashboard\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true}]}]},{\"Area\":\"Mango Management\",\"FeatureModels\":[{\"Id\":3,\"Title\":\"Mango Types\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Manage\",\"HasAccess\":true}]},{\"Id\":4,\"Title\":\"Mango Availability\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Manage\",\"HasAccess\":true}]}]},{\"Area\":\"Order Management\",\"FeatureModels\":[{\"Id\":5,\"Title\":\"Orders\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Create\",\"HasAccess\":true},{\"Id\":3,\"Action\":\"Update\",\"HasAccess\":true},{\"Id\":4,\"Action\":\"Delete\",\"HasAccess\":true}]}]},{\"Area\":\"Customer Management\",\"FeatureModels\":[{\"Id\":6,\"Title\":\"Customers\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Create\",\"HasAccess\":true},{\"Id\":3,\"Action\":\"Update\",\"HasAccess\":true},{\"Id\":4,\"Action\":\"Delete\",\"HasAccess\":true}]}]},{\"Area\":\"Courier Management\",\"FeatureModels\":[{\"Id\":7,\"Title\":\"Couriers\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Create\",\"HasAccess\":true},{\"Id\":3,\"Action\":\"Update\",\"HasAccess\":true},{\"Id\":4,\"Action\":\"Delete\",\"HasAccess\":true}]}]},{\"Area\":\"Payment Management\",\"FeatureModels\":[{\"Id\":8,\"Title\":\"Payments\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Create\",\"HasAccess\":true},{\"Id\":3,\"Action\":\"Update\",\"HasAccess\":true},{\"Id\":4,\"Action\":\"Delete\",\"HasAccess\":true}]}]},{\"Area\":\"Expense Management\",\"FeatureModels\":[{\"Id\":9,\"Title\":\"Expenses\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Create\",\"HasAccess\":true},{\"Id\":3,\"Action\":\"Update\",\"HasAccess\":true},{\"Id\":4,\"Action\":\"Delete\",\"HasAccess\":true}]},{\"Id\":10,\"Title\":\"Expense Types\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Create\",\"HasAccess\":true},{\"Id\":3,\"Action\":\"Update\",\"HasAccess\":true},{\"Id\":4,\"Action\":\"Delete\",\"HasAccess\":true}]}]},{\"Area\":\"Feedback & Complaints\",\"FeatureModels\":[{\"Id\":11,\"Title\":\"Feedback\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"Admin View\",\"HasAccess\":true}]},{\"Id\":12,\"Title\":\"Complaints\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"Submit\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Admin View\",\"HasAccess\":true},{\"Id\":3,\"Action\":\"Admin Manage\",\"HasAccess\":true}]}]},{\"Area\":\"Reports\",\"FeatureModels\":[{\"Id\":13,\"Title\":\"Reports\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true}]}]},{\"Area\":\"Administration\",\"FeatureModels\":[{\"Id\":14,\"Title\":\"Users\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Create\",\"HasAccess\":true},{\"Id\":3,\"Action\":\"Update\",\"HasAccess\":true},{\"Id\":4,\"Action\":\"Delete\",\"HasAccess\":true}]},{\"Id\":15,\"Title\":\"Roles\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Create\",\"HasAccess\":true},{\"Id\":3,\"Action\":\"Update\",\"HasAccess\":true},{\"Id\":4,\"Action\":\"Delete\",\"HasAccess\":true}]},{\"Id\":16,\"Title\":\"User Permissions\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Grant\",\"HasAccess\":true},{\"Id\":3,\"Action\":\"Revoke\",\"HasAccess\":true}]}]},{\"Area\":\"Configuration\",\"FeatureModels\":[{\"Id\":17,\"Title\":\"FAQ\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"Manage\",\"HasAccess\":true}]},{\"Id\":18,\"Title\":\"Policies\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Manage\",\"HasAccess\":true}]}]}]";

        private const string OldGeneralPermissionJson = "[{\"Area\":\"Dashboard\",\"FeatureModels\":[{\"Id\":2,\"Title\":\"Customer Dashboard\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true}]}]},{\"Area\":\"Mango Management\",\"FeatureModels\":[{\"Id\":3,\"Title\":\"Mango Types\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true}]},{\"Id\":4,\"Title\":\"Mango Availability\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true}]}]},{\"Area\":\"Order Management\",\"FeatureModels\":[{\"Id\":5,\"Title\":\"Orders\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"View\",\"HasAccess\":true},{\"Id\":2,\"Action\":\"Create\",\"HasAccess\":true}]}]},{\"Area\":\"Feedback & Complaints\",\"FeatureModels\":[{\"Id\":12,\"Title\":\"Complaints\",\"HasAccess\":true,\"ActionModels\":[{\"Id\":1,\"Action\":\"Submit\",\"HasAccess\":true}]}]}]";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"UPDATE [Roles] SET [PermissionJson] = '{FlatAdminPermissionJson}' WHERE [Id] = 1");
            migrationBuilder.Sql($"UPDATE [Roles] SET [PermissionJson] = '{FlatAdminPermissionJson}' WHERE [Id] = 2");
            migrationBuilder.Sql($"UPDATE [Roles] SET [PermissionJson] = '{FlatGeneralPermissionJson}' WHERE [Id] = 3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"UPDATE [Roles] SET [PermissionJson] = '{OldAdminPermissionJson}' WHERE [Id] = 1");
            migrationBuilder.Sql($"UPDATE [Roles] SET [PermissionJson] = '{OldAdminPermissionJson}' WHERE [Id] = 2");
            migrationBuilder.Sql($"UPDATE [Roles] SET [PermissionJson] = '{OldGeneralPermissionJson}' WHERE [Id] = 3");
        }
    }
}
