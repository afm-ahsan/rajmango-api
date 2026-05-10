using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_FaqItems_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaqItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqItems", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 44, 862, DateTimeKind.Unspecified).AddTicks(2433), "AQAAAAIAAYagAAAAEP0yZOG/ApgT/6PgFQzPUgp9PkBMtGDspYiVzeMrOuOkR3mKe/OFy9q+oV1ztczKrg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 44, 939, DateTimeKind.Unspecified).AddTicks(92), "AQAAAAIAAYagAAAAEGSwp2VYh9PMa3sCaTIbibr6l4pJYHQ8xvNjeF/nqfHwwqaZWWSOpphTXzq/Tr29xg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 45, 18, DateTimeKind.Unspecified).AddTicks(9532), "AQAAAAIAAYagAAAAEA4mkNt5G9GPldA5yWUO0Oeu+zYN2U+6yynJTZ2J8gvC1rPNB4F6jhEDfhcgak36Pw==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(802));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(809));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 13, 49, 44, 786, DateTimeKind.Unspecified).AddTicks(8455));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 13, 49, 44, 786, DateTimeKind.Unspecified).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 13, 49, 44, 786, DateTimeKind.Unspecified).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Unspecified).AddTicks(568), new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Unspecified).AddTicks(564) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Unspecified).AddTicks(583), new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Unspecified).AddTicks(580) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Unspecified).AddTicks(594), new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Unspecified).AddTicks(590) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaqItems");

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
    }
}
