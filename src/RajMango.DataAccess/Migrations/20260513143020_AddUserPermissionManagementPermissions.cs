using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserPermissionManagementPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "IsDeleted", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 47, new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958), 1, null, 0, "user.permission.view", true, false, "user.permission", "user.permission.view", null, 0 },
                    { 48, new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958), 1, null, 0, "user.permission.grant", true, false, "user.permission", "user.permission.grant", null, 0 },
                    { 49, new DateTime(2026, 5, 13, 20, 30, 19, 250, DateTimeKind.Unspecified).AddTicks(2958), 1, null, 0, "user.permission.revoke", true, false, "user.permission", "user.permission.revoke", null, 0 }
                });

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

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 47, 1 },
                    { 48, 1 },
                    { 49, 1 },
                    { 47, 2 },
                    { 48, 2 },
                    { 49, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 47, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 48, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 49, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 47, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 48, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 49, 2 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49);

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

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 20, 8, 36, 676, DateTimeKind.Unspecified).AddTicks(9508));

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
        }
    }
}
