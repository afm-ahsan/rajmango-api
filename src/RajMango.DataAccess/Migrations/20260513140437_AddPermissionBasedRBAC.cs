using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionBasedRBAC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSystemRole",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Module = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    IsGranted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => new { x.UserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserPermissions_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 4, 36, 150, DateTimeKind.Unspecified).AddTicks(1288), "AQAAAAIAAYagAAAAEAZANHIKBVF4DPTBTGNKUCixXtoDf5oC7U+uIvfZZjVwVGcCbfMAmlgYTiHCPpnT2w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 4, 36, 254, DateTimeKind.Unspecified).AddTicks(4819), "AQAAAAIAAYagAAAAEC9qzaOKJpkXHy6MNCOOczbS37ZMqtIe+L4arZ0PrcX1aO2HmaMl1O3G1Ku4c/6pWw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(6778), "AQAAAAIAAYagAAAAEL73zdPOB+/3L92aLszVuuRdf7eO4okgnNNIJTFP861j+BMpqWWDi8NYe5B5+yRe8w==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Local).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Local).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "IsDeleted", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "user.view", true, false, "user", "user.view", null, 0 },
                    { 2, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "user.create", true, false, "user", "user.create", null, 0 },
                    { 3, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "user.update", true, false, "user", "user.update", null, 0 },
                    { 4, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "user.delete", true, false, "user", "user.delete", null, 0 },
                    { 5, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "role.view", true, false, "role", "role.view", null, 0 },
                    { 6, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "role.create", true, false, "role", "role.create", null, 0 },
                    { 7, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "role.update", true, false, "role", "role.update", null, 0 },
                    { 8, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "role.delete", true, false, "role", "role.delete", null, 0 },
                    { 9, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "order.view", true, false, "order", "order.view", null, 0 },
                    { 10, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "order.create", true, false, "order", "order.create", null, 0 },
                    { 11, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "order.update", true, false, "order", "order.update", null, 0 },
                    { 12, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "order.delete", true, false, "order", "order.delete", null, 0 },
                    { 13, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "payment.view", true, false, "payment", "payment.view", null, 0 },
                    { 14, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "payment.create", true, false, "payment", "payment.create", null, 0 },
                    { 15, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "payment.update", true, false, "payment", "payment.update", null, 0 },
                    { 16, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "payment.delete", true, false, "payment", "payment.delete", null, 0 },
                    { 17, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "expense.view", true, false, "expense", "expense.view", null, 0 },
                    { 18, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "expense.create", true, false, "expense", "expense.create", null, 0 },
                    { 19, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "expense.update", true, false, "expense", "expense.update", null, 0 },
                    { 20, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "expense.delete", true, false, "expense", "expense.delete", null, 0 },
                    { 21, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "expense.type.view", true, false, "expense.type", "expense.type.view", null, 0 },
                    { 22, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "expense.type.create", true, false, "expense.type", "expense.type.create", null, 0 },
                    { 23, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "expense.type.update", true, false, "expense.type", "expense.type.update", null, 0 },
                    { 24, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "expense.type.delete", true, false, "expense.type", "expense.type.delete", null, 0 },
                    { 25, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "courier.view", true, false, "courier", "courier.view", null, 0 },
                    { 26, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "courier.create", true, false, "courier", "courier.create", null, 0 },
                    { 27, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "courier.update", true, false, "courier", "courier.update", null, 0 },
                    { 28, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "courier.delete", true, false, "courier", "courier.delete", null, 0 },
                    { 29, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "customer.view", true, false, "customer", "customer.view", null, 0 },
                    { 30, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "customer.create", true, false, "customer", "customer.create", null, 0 },
                    { 31, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "customer.update", true, false, "customer", "customer.update", null, 0 },
                    { 32, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "customer.delete", true, false, "customer", "customer.delete", null, 0 },
                    { 33, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "mango.type.view", true, false, "mango.type", "mango.type.view", null, 0 },
                    { 34, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "mango.type.manage", true, false, "mango.type", "mango.type.manage", null, 0 },
                    { 35, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "mango.availability.view", true, false, "mango.availability", "mango.availability.view", null, 0 },
                    { 36, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "mango.availability.manage", true, false, "mango.availability", "mango.availability.manage", null, 0 },
                    { 37, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "report.view", true, false, "report", "report.view", null, 0 },
                    { 38, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "dashboard.admin.view", true, false, "dashboard.admin", "dashboard.admin.view", null, 0 },
                    { 39, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "dashboard.customer.view", true, false, "dashboard.customer", "dashboard.customer.view", null, 0 },
                    { 40, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "complaint.submit", true, false, "complaint", "complaint.submit", null, 0 },
                    { 41, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "complaint.admin.view", true, false, "complaint.admin", "complaint.admin.view", null, 0 },
                    { 42, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "complaint.admin.manage", true, false, "complaint.admin", "complaint.admin.manage", null, 0 },
                    { 43, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "faq.manage", true, false, "faq", "faq.manage", null, 0 },
                    { 44, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "policy.view", true, false, "policy", "policy.view", null, 0 },
                    { 45, new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355), 1, null, 0, "policy.manage", true, false, "policy", "policy.manage", null, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsSystemRole" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 4, 36, 57, DateTimeKind.Unspecified).AddTicks(471), true });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsSystemRole" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 4, 36, 57, DateTimeKind.Unspecified).AddTicks(524), true });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsSystemRole" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 4, 36, 57, DateTimeKind.Unspecified).AddTicks(558), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7226), new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7224) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7239), new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7237) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7245), new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7243) });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 23, 1 },
                    { 24, 1 },
                    { 25, 1 },
                    { 26, 1 },
                    { 27, 1 },
                    { 28, 1 },
                    { 29, 1 },
                    { 30, 1 },
                    { 31, 1 },
                    { 32, 1 },
                    { 33, 1 },
                    { 34, 1 },
                    { 35, 1 },
                    { 36, 1 },
                    { 37, 1 },
                    { 38, 1 },
                    { 39, 1 },
                    { 40, 1 },
                    { 41, 1 },
                    { 42, 1 },
                    { 43, 1 },
                    { 44, 1 },
                    { 45, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 2 },
                    { 12, 2 },
                    { 13, 2 },
                    { 14, 2 },
                    { 15, 2 },
                    { 16, 2 },
                    { 17, 2 },
                    { 18, 2 },
                    { 19, 2 },
                    { 20, 2 },
                    { 21, 2 },
                    { 22, 2 },
                    { 23, 2 },
                    { 24, 2 },
                    { 25, 2 },
                    { 26, 2 },
                    { 27, 2 },
                    { 28, 2 },
                    { 29, 2 },
                    { 30, 2 },
                    { 31, 2 },
                    { 32, 2 },
                    { 33, 2 },
                    { 34, 2 },
                    { 35, 2 },
                    { 36, 2 },
                    { 37, 2 },
                    { 38, 2 },
                    { 39, 2 },
                    { 40, 2 },
                    { 41, 2 },
                    { 42, 2 },
                    { 43, 2 },
                    { 44, 2 },
                    { 45, 2 },
                    { 9, 3 },
                    { 10, 3 },
                    { 33, 3 },
                    { 35, 3 },
                    { 39, 3 },
                    { 40, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Name",
                table: "Permissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_PermissionId",
                table: "UserPermissions",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropColumn(
                name: "IsSystemRole",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 351, DateTimeKind.Unspecified).AddTicks(1880), "AQAAAAIAAYagAAAAEGAnzVpoe8YSJFF6pA4RAVlsyLmoGzpgHrO/QVGUiXK8ygzq5sJi5BPLp9BEv53gsg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 428, DateTimeKind.Unspecified).AddTicks(2928), "AQAAAAIAAYagAAAAEKes+tgzlAA9GOmoxEccf73urcZ1GFOvvvho5JhdvAVUpYvvzbZxGdosFkhXaEFNQQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(3141), "AQAAAAIAAYagAAAAECazp3a74hyf9hcVl0KYJizOl87IIiFV2pzB3nzqrlspI1ZRI8FhryItlWr5W72ZtQ==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 279, DateTimeKind.Unspecified).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 279, DateTimeKind.Unspecified).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 279, DateTimeKind.Unspecified).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4033), new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4031) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4042), new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4041) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4048), new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4046) });
        }
    }
}
