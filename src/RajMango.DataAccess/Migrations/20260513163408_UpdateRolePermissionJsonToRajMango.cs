using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRolePermissionJsonToRajMango : Migration
    {
        private const string AdminPermissionJson = @"[{""Area"":""Dashboard"",""FeatureModels"":[{""Id"":1,""Title"":""Admin Dashboard"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true}]},{""Id"":2,""Title"":""Customer Dashboard"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true}]}]},{""Area"":""Mango Management"",""FeatureModels"":[{""Id"":3,""Title"":""Mango Types"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Manage"",""HasAccess"":true}]},{""Id"":4,""Title"":""Mango Availability"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Manage"",""HasAccess"":true}]}]},{""Area"":""Order Management"",""FeatureModels"":[{""Id"":5,""Title"":""Orders"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Create"",""HasAccess"":true},{""Id"":3,""Action"":""Update"",""HasAccess"":true},{""Id"":4,""Action"":""Delete"",""HasAccess"":true}]}]},{""Area"":""Customer Management"",""FeatureModels"":[{""Id"":6,""Title"":""Customers"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Create"",""HasAccess"":true},{""Id"":3,""Action"":""Update"",""HasAccess"":true},{""Id"":4,""Action"":""Delete"",""HasAccess"":true}]}]},{""Area"":""Courier Management"",""FeatureModels"":[{""Id"":7,""Title"":""Couriers"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Create"",""HasAccess"":true},{""Id"":3,""Action"":""Update"",""HasAccess"":true},{""Id"":4,""Action"":""Delete"",""HasAccess"":true}]}]},{""Area"":""Payment Management"",""FeatureModels"":[{""Id"":8,""Title"":""Payments"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Create"",""HasAccess"":true},{""Id"":3,""Action"":""Update"",""HasAccess"":true},{""Id"":4,""Action"":""Delete"",""HasAccess"":true}]}]},{""Area"":""Expense Management"",""FeatureModels"":[{""Id"":9,""Title"":""Expenses"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Create"",""HasAccess"":true},{""Id"":3,""Action"":""Update"",""HasAccess"":true},{""Id"":4,""Action"":""Delete"",""HasAccess"":true}]},{""Id"":10,""Title"":""Expense Types"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Create"",""HasAccess"":true},{""Id"":3,""Action"":""Update"",""HasAccess"":true},{""Id"":4,""Action"":""Delete"",""HasAccess"":true}]}]},{""Area"":""Feedback & Complaints"",""FeatureModels"":[{""Id"":11,""Title"":""Feedback"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""Admin View"",""HasAccess"":true}]},{""Id"":12,""Title"":""Complaints"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""Submit"",""HasAccess"":true},{""Id"":2,""Action"":""Admin View"",""HasAccess"":true},{""Id"":3,""Action"":""Admin Manage"",""HasAccess"":true}]}]},{""Area"":""Reports"",""FeatureModels"":[{""Id"":13,""Title"":""Reports"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true}]}]},{""Area"":""Administration"",""FeatureModels"":[{""Id"":14,""Title"":""Users"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Create"",""HasAccess"":true},{""Id"":3,""Action"":""Update"",""HasAccess"":true},{""Id"":4,""Action"":""Delete"",""HasAccess"":true}]},{""Id"":15,""Title"":""Roles"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Create"",""HasAccess"":true},{""Id"":3,""Action"":""Update"",""HasAccess"":true},{""Id"":4,""Action"":""Delete"",""HasAccess"":true}]},{""Id"":16,""Title"":""User Permissions"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Grant"",""HasAccess"":true},{""Id"":3,""Action"":""Revoke"",""HasAccess"":true}]}]},{""Area"":""Configuration"",""FeatureModels"":[{""Id"":17,""Title"":""FAQ"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""Manage"",""HasAccess"":true}]},{""Id"":18,""Title"":""Policies"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Manage"",""HasAccess"":true}]}]}]";

        private const string GeneralPermissionJson = @"[{""Area"":""Dashboard"",""FeatureModels"":[{""Id"":2,""Title"":""Customer Dashboard"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true}]}]},{""Area"":""Mango Management"",""FeatureModels"":[{""Id"":3,""Title"":""Mango Types"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true}]},{""Id"":4,""Title"":""Mango Availability"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true}]}]},{""Area"":""Order Management"",""FeatureModels"":[{""Id"":5,""Title"":""Orders"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""View"",""HasAccess"":true},{""Id"":2,""Action"":""Create"",""HasAccess"":true}]}]},{""Area"":""Feedback & Complaints"",""FeatureModels"":[{""Id"":12,""Title"":""Complaints"",""HasAccess"":true,""ActionModels"":[{""Id"":1,""Action"":""Submit"",""HasAccess"":true}]}]}]";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"UPDATE [Roles] SET [PermissionJson] = '{AdminPermissionJson}' WHERE [Id] = 1");
            migrationBuilder.Sql($"UPDATE [Roles] SET [PermissionJson] = '{AdminPermissionJson}' WHERE [Id] = 2");
            migrationBuilder.Sql($"UPDATE [Roles] SET [PermissionJson] = '{GeneralPermissionJson}' WHERE [Id] = 3");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 782, DateTimeKind.Unspecified).AddTicks(6962), "AQAAAAIAAYagAAAAEDFweH4cfqgkC8an/tycmQN5HYIQH402b0fZStaryS/bpNgOH2Un0X24Esj/iMKBrw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 861, DateTimeKind.Unspecified).AddTicks(815), "AQAAAAIAAYagAAAAEJkhaCoeRl9VBGsB61keEWli3NuxGtwTGghcQhF/B3LcUbwgI0sWEafgkI3fD+YxTA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2122), "AQAAAAIAAYagAAAAELRRRNm+FmocOgPPTHXOv15dT23Ti1qiav7uI6E/m+0GyJLDzeeXuJ7po8PpA98IkA==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6495));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 704, DateTimeKind.Unspecified).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 704, DateTimeKind.Unspecified).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 704, DateTimeKind.Unspecified).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2977), new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2974) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2992), new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2989) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3001), new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2998) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 30, 19, 45, DateTimeKind.Unspecified).AddTicks(5428), "AQAAAAIAAYagAAAAEC4CNeHOsBx0nRa+QvkNTmQjPhToGq3Tu5QZ4n+P73Mv2Aao6lqJUXvxkuEs+BERkg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 30, 19, 150, DateTimeKind.Unspecified).AddTicks(5684), "AQAAAAIAAYagAAAAECTOFLbY9dzuxl+zyk4t1a7HO+xX+5NIem2OHJC8E/KY8H9ZXrXuw3djf2VzGGufMQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(1782), "AQAAAAIAAYagAAAAEG2SngG9PsrnoYp3I3P99O0oeSc4c5KeKhP8Jg7MbxP3E9cRZJwg1zgjt3dVNbk5oA==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Local).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Local).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Local).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 18, 904, DateTimeKind.Unspecified).AddTicks(1239));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 18, 904, DateTimeKind.Unspecified).AddTicks(1324));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 30, 18, 904, DateTimeKind.Unspecified).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2854), new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2873), new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2869) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2884), new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2881) });
        }
    }
}
