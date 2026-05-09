using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_Customer_UserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Customers",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AppUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AppUsers_UserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 491, DateTimeKind.Unspecified).AddTicks(7464), "AQAAAAIAAYagAAAAEDbwVbDgYMCSLGuzSA9GBxK8RQr7jDv1stoX3M7OxS+iIvV/5bu/3r0iY1EEzxKtWg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 564, DateTimeKind.Unspecified).AddTicks(9005), "AQAAAAIAAYagAAAAENjYyS3JrOT3dpA46IDfzfDiXqNWhPl1TBaQGb29mP6NegoTzwJv5ngtmI38Lpjreg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(7489), "AQAAAAIAAYagAAAAEKeCPMU3N++v7+ozskvwqzgSv/6tMKAPT1HxKLB3bld7XYTunoktTV+hkHH+q6J8SQ==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 417, DateTimeKind.Unspecified).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 417, DateTimeKind.Unspecified).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 417, DateTimeKind.Unspecified).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8222), new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8220) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8232), new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8237), new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8236) });
        }
    }
}
