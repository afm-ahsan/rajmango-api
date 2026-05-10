using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSweetnessLevelToMangoType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SweetnessLevel",
                table: "MangoTypes",
                type: "int",
                nullable: false,
                defaultValue: 2); // SweetnessLevel.Medium — safe fallback for pre-existing rows

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 435, DateTimeKind.Unspecified).AddTicks(3635), "AQAAAAIAAYagAAAAEKQ3KDpikEgt+NitCzN5IqIw9Q+yBVHu4GcCn/c8ryq95lWYgdBe/I+onDjf2XttHQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 521, DateTimeKind.Unspecified).AddTicks(2272), "AQAAAAIAAYagAAAAECdRF+YMfShNyzX+evZUg1XYlQ8xb2sTxmUZqlqRxQzSWvYfjIr28lKcCa9nv17IQQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8568), "AQAAAAIAAYagAAAAECNWF35dOKUsL4XwAO/1cV4EIIP5Rr0UXuS60+v7ns8Q/NEx/raquwn9KFDsEBlxHg==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "SweetnessLevel" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9065), 4 });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "SweetnessLevel" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9070), 4 });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "SweetnessLevel" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9074), 3 });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "SweetnessLevel" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9078), 3 });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "SweetnessLevel" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9081), 2 });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "SweetnessLevel" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9085), 2 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 22, 37, 12, 351, DateTimeKind.Unspecified).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 22, 37, 12, 351, DateTimeKind.Unspecified).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 22, 37, 12, 351, DateTimeKind.Unspecified).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8976), new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8951) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8993), new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8992) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(9000), new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8998) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SweetnessLevel",
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
    }
}
