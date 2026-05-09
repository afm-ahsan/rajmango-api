using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Increase_JwtAuth_AuthToken_Length : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AuthToken",
                table: "JwtAuth",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AuthToken",
                table: "JwtAuth",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 19, 6, 1, 196, DateTimeKind.Unspecified).AddTicks(5824), "AQAAAAIAAYagAAAAEBSZ3lBBDmvcL+q7U2lXOIgfpQNtrcpizeSA4C61qED81q/Na//3Mf/KDDqJB7In6w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 19, 6, 1, 268, DateTimeKind.Unspecified).AddTicks(662), "AQAAAAIAAYagAAAAEG324ndL3hIAB+GnO2Yy10Bubgs6DLFbL+Zzn/ETKGBuzZwIuCn26ZV3G9OW/KJ+vA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Unspecified).AddTicks(5565), "AQAAAAIAAYagAAAAEPGhoha8xroJUF3ZbP39W24Dap9UnaqqYZbUlw80rLjyD2wghBqWEY9wASNgruNG+A==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Local).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Local).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Local).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 19, 6, 1, 122, DateTimeKind.Unspecified).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 19, 6, 1, 122, DateTimeKind.Unspecified).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 19, 6, 1, 122, DateTimeKind.Unspecified).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Unspecified).AddTicks(6197), new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Unspecified).AddTicks(6195) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Unspecified).AddTicks(6207), new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Unspecified).AddTicks(6205) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Unspecified).AddTicks(6212), new DateTime(2026, 5, 9, 19, 6, 1, 346, DateTimeKind.Unspecified).AddTicks(6210) });
        }
    }
}
