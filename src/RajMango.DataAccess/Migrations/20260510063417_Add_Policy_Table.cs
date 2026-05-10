using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_Policy_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 34, 16, 316, DateTimeKind.Unspecified).AddTicks(4503), "AQAAAAIAAYagAAAAEPdJ0GRbQ/hjSLXgap+9q5AycO8s1VnULVUPMEy2cu4ziaoxKzVy4Qh/iQ/7X0O/yQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 34, 16, 388, DateTimeKind.Unspecified).AddTicks(1088), "AQAAAAIAAYagAAAAEAror/VJKHASjarhV30qpoQ3sRr6Ao0vKH6bxPO5IBUmV97IC6oQ83JjiXSIFbqHYQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Unspecified).AddTicks(7731), "AQAAAAIAAYagAAAAEKw2V5lv/7T1iT4HlIY5vILFsaCZDc7MvvOoblZqOnU2SacAbtEj9oo3XIjC9NPerw==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Local).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Local).AddTicks(8444));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Local).AddTicks(8477));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 34, 16, 244, DateTimeKind.Unspecified).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 34, 16, 244, DateTimeKind.Unspecified).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 34, 16, 244, DateTimeKind.Unspecified).AddTicks(2347));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Unspecified).AddTicks(8338), new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Unspecified).AddTicks(8324) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Unspecified).AddTicks(8353), new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Unspecified).AddTicks(8351) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Unspecified).AddTicks(8360), new DateTime(2026, 5, 10, 12, 34, 16, 460, DateTimeKind.Unspecified).AddTicks(8358) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 32, 46, 122, DateTimeKind.Unspecified).AddTicks(3907), "AQAAAAIAAYagAAAAEFVvz1v51np8G+QDSTBAg5xGjWOgmFNHD3RKxhDbUse/vEi8w6325AWyKrG0glTneQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 32, 46, 198, DateTimeKind.Unspecified).AddTicks(8949), "AQAAAAIAAYagAAAAEMymqpY0oG+Tsxfyw2LU7mEFmOBbprJ2B5ZBGQ75fOx7WJzlU21QTIe5qeyT8lJsZQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Unspecified).AddTicks(957), "AQAAAAIAAYagAAAAEFlM0OfSMh1dmw/aGXjXhp8JNJLVSiFftLmgoF4HYPRxSrC4WLB6XjVHZbHJHYEQzA==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Local).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Local).AddTicks(1699));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Local).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 32, 46, 38, DateTimeKind.Unspecified).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 32, 46, 38, DateTimeKind.Unspecified).AddTicks(3930));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 32, 46, 38, DateTimeKind.Unspecified).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Unspecified).AddTicks(1592), new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Unspecified).AddTicks(1577) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Unspecified).AddTicks(1608), new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Unspecified).AddTicks(1606) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Unspecified).AddTicks(1614), new DateTime(2026, 5, 10, 12, 32, 46, 279, DateTimeKind.Unspecified).AddTicks(1612) });
        }
    }
}
