using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFeedbackAdminViewPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 8, 36, 519, DateTimeKind.Unspecified).AddTicks(5556), "AQAAAAIAAYagAAAAEA2AlPao56qGlKvtlr4hG5K2RtTU2ApytNd0O+z5H01IcNI2GefJYOVx97EPPudjWw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 8, 36, 597, DateTimeKind.Unspecified).AddTicks(3087), "AQAAAAIAAYagAAAAEIBQPGw4Elc6Z1+iOvGJW3EFcc1FwBLovPtzVhM5W9jsm4v9RpIjptJJbE2umdYtGQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(8780), "AQAAAAIAAYagAAAAEJ7TvEqz71FNMQZZf0dujvrO41uRuMnbfG1FsKWSl8vdk+9h0oBq6L3UOGB9EzsCCA==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 677, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 677, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 677, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 677, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 677, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 677, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "IsDeleted", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 46, new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508), 1, null, 0, "feedback.admin.view", true, false, "feedback.admin", "feedback.admin.view", null, 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 440, DateTimeKind.Unspecified).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 440, DateTimeKind.Unspecified).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 440, DateTimeKind.Unspecified).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9461), new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9459) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9472), new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9470) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9478), new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9476) });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 46, 1 },
                    { 46, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 46, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 46, 2 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46);

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

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 364, DateTimeKind.Unspecified).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 57, DateTimeKind.Unspecified).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 57, DateTimeKind.Unspecified).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 4, 36, 57, DateTimeKind.Unspecified).AddTicks(558));

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
        }
    }
}
