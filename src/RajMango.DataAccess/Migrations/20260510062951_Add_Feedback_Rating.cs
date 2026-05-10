using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_Feedback_Rating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 29, 50, 618, DateTimeKind.Unspecified).AddTicks(7877), "AQAAAAIAAYagAAAAEGtORcqn/++CwNzaRbHwXRBw8oLgdk3TsI9O0bqSx25SbFpMxSoqAktlbpGJlLJ2yQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 29, 50, 715, DateTimeKind.Unspecified).AddTicks(576), "AQAAAAIAAYagAAAAEAVXLyDKVcR10SmXKhjUMjkUXCRPgJeczN814JPFNp5TciZ1Ea2FPSxT0hCIt+KWLQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Unspecified).AddTicks(1241), "AQAAAAIAAYagAAAAEPvBPyZS62sfjd8CPYWhaZkIxV5jxzewF2h7wFNOqsQjA/BphzBU4qcF49wrrxppNQ==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Local).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 29, 50, 544, DateTimeKind.Unspecified).AddTicks(8467));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 29, 50, 544, DateTimeKind.Unspecified).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 12, 29, 50, 544, DateTimeKind.Unspecified).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Unspecified).AddTicks(2023), new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Unspecified).AddTicks(2021) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Unspecified).AddTicks(2031), new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Unspecified).AddTicks(2030) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Unspecified).AddTicks(2037), new DateTime(2026, 5, 10, 12, 29, 50, 816, DateTimeKind.Unspecified).AddTicks(2035) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Feedbacks");

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
    }
}
