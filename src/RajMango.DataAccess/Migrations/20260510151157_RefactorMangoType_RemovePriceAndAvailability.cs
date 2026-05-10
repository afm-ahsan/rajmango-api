using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RefactorMangoType_RemovePriceAndAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "MangoTypes");

            migrationBuilder.DropColumn(
                name: "PricePerKg",
                table: "MangoTypes");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 21, 11, 55, 162, DateTimeKind.Unspecified).AddTicks(2166), "AQAAAAIAAYagAAAAEPwA9zQfeX90JTA43QENZZaH2Jpk79sY7UQkzp7TY4TU8Dxz7kGVQQiKpOWhZn/k0g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 21, 11, 55, 249, DateTimeKind.Unspecified).AddTicks(259), "AQAAAAIAAYagAAAAELc1OEXUQkIkq0ceKyNvtpUas4gyg/VhgBm51wI3ogggiT71xNM9frv1SLVNUMfNVQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Unspecified).AddTicks(3650), "AQAAAAIAAYagAAAAENsd8ewwLGDghoHt3iG2QQzpkSO0dTtLRAK/bCH/sPBW2oEO2eYn0ZP3VUrWRxmkTw==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 21, 11, 55, 85, DateTimeKind.Unspecified).AddTicks(6892));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 21, 11, 55, 85, DateTimeKind.Unspecified).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 21, 11, 55, 85, DateTimeKind.Unspecified).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Unspecified).AddTicks(4258), new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Unspecified).AddTicks(4256) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Unspecified).AddTicks(4303), new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Unspecified).AddTicks(4301) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Unspecified).AddTicks(4308), new DateTime(2026, 5, 10, 21, 11, 55, 324, DateTimeKind.Unspecified).AddTicks(4306) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "MangoTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerKg",
                table: "MangoTypes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

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
                columns: new[] { "CreatedAt", "IsAvailable", "PricePerKg" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(778), true, 130m });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsAvailable", "PricePerKg" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(787), true, 130m });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsAvailable", "PricePerKg" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(794), true, 140m });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsAvailable", "PricePerKg" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(802), true, 135m });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsAvailable", "PricePerKg" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(809), true, 115m });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsAvailable", "PricePerKg" },
                values: new object[] { new DateTime(2026, 5, 10, 13, 49, 45, 19, DateTimeKind.Local).AddTicks(815), true, 100m });

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
    }
}
