using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_Order_ReceiverFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryNote",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverPhone",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 28, 19, 940, DateTimeKind.Unspecified).AddTicks(1730), "AQAAAAIAAYagAAAAEPOjpdlqoN3bh2sy1rKoIipyXGlp141KB3P+4yfau/lYDqekMqnPNExepsqZCzL8vA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 28, 20, 19, DateTimeKind.Unspecified).AddTicks(4800), "AQAAAAIAAYagAAAAEIZ0oLVXkYoIgXem1FlNXj1JSjhelwdP1FDVWGlEv0uXcwWpP/I1b8XLkEuy5oT3qQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Unspecified).AddTicks(2036), "AQAAAAIAAYagAAAAEHZeT7X7IyMhT8jx/mOTv1dgC4DcdTDjm3cSYXFy5VO3l2EQn9l39Fl2ZgEqHnEQHA==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Local).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Local).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Local).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Local).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 28, 19, 868, DateTimeKind.Unspecified).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 28, 19, 868, DateTimeKind.Unspecified).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 28, 19, 868, DateTimeKind.Unspecified).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Unspecified).AddTicks(2565), new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Unspecified).AddTicks(2543) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Unspecified).AddTicks(2576), new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Unspecified).AddTicks(2574) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Unspecified).AddTicks(2581), new DateTime(2026, 5, 10, 12, 28, 20, 99, DateTimeKind.Unspecified).AddTicks(2579) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryNote",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverPhone",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 20, 39, 54, 533, DateTimeKind.Unspecified).AddTicks(729), "AQAAAAIAAYagAAAAEGfHN6ZXqHuQ+U6tSe8HgGTPLYzMWqiVFaxlTYxUzX1AgxkWYijd5sv66BudVqRebQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 20, 39, 54, 665, DateTimeKind.Unspecified).AddTicks(5805), "AQAAAAIAAYagAAAAEOGT2RHB4G/9fbQl7a+mgfGMfOwo5fzCdbvntsXrh3ePJc/Ll53bVZNZNt8mFIGwnw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 20, 39, 54, 776, DateTimeKind.Unspecified).AddTicks(8987), "AQAAAAIAAYagAAAAEJ6WouC/z7h5Rt+AHQYoo+ZxOys4K/2gxGX7Wu08gpMO6MEEyn/TSGB0M3Ly3g542Q==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Local).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 20, 39, 54, 421, DateTimeKind.Unspecified).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 20, 39, 54, 421, DateTimeKind.Unspecified).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 20, 39, 54, 421, DateTimeKind.Unspecified).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Unspecified).AddTicks(69), new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Unspecified).AddTicks(67) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Unspecified).AddTicks(82), new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Unspecified).AddTicks(81) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Unspecified).AddTicks(88), new DateTime(2026, 5, 9, 20, 39, 54, 777, DateTimeKind.Unspecified).AddTicks(87) });
        }
    }
}
