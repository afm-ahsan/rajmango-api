using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_OrderNumberCounter_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderNumberCounters",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNumberCounters", x => x.Date);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 18, 18, 9, 32, 339, DateTimeKind.Unspecified).AddTicks(7970), "AQAAAAIAAYagAAAAEKbOkRxb0E03MP/uV3WGIiW7sSMqhr85MC7fKHClw0VsN4UbG8BJTzg5z+2IrF/M1Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 18, 18, 9, 32, 452, DateTimeKind.Unspecified).AddTicks(5412), "AQAAAAIAAYagAAAAEN8O0XICwG6m7gaGox4fuUQ4F4sYvDXApfxU4KcMkPlzFoyo5tIcOk+iZ/XInqnazA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(482), "AQAAAAIAAYagAAAAEDUIPcOllgCaRx2mPvMkSRGRwAbfWrQTpCc00pzcULz6AvTEzl3jUMOXXGM40nUwUw==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6669));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6182));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6375));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6386));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Local).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Local).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 220, DateTimeKind.Unspecified).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 220, DateTimeKind.Unspecified).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 18, 9, 32, 220, DateTimeKind.Unspecified).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1416), new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1411) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1442), new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1438) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1457), new DateTime(2026, 5, 18, 18, 9, 32, 574, DateTimeKind.Unspecified).AddTicks(1452) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderNumberCounters");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 18, 11, 26, 22, 874, DateTimeKind.Unspecified).AddTicks(3474), "AQAAAAIAAYagAAAAEC7eIk769k5DBqR3/MRE7dCwKLYZNLqQSKZNZrITi/78q9ShjCQl5UiTR7Ttk/wgDw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 18, 11, 26, 23, 157, DateTimeKind.Unspecified).AddTicks(8998), "AQAAAAIAAYagAAAAEKFvNlYYnG/Q5i/dlVZCK/pWIRFXdHxu5GwtYUYU0tKU+OFuM1KWGfcWh9KITsUFPQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3098), "AQAAAAIAAYagAAAAEL5TSNOdT2Cn6s3Uj2SmmdeA45BYb0BWO3aLfClJYswH8AYvM0Qjr2HDw7aTYcyXTg==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1132));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(651));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(665));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(816));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(892));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(935));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Unspecified).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Local).AddTicks(389));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Local).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Local).AddTicks(434));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 414, DateTimeKind.Local).AddTicks(444));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 22, 615, DateTimeKind.Unspecified).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 22, 615, DateTimeKind.Unspecified).AddTicks(9840));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 11, 26, 22, 615, DateTimeKind.Unspecified).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3866), new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3898), new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3892) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3918), new DateTime(2026, 5, 18, 11, 26, 23, 413, DateTimeKind.Unspecified).AddTicks(3912) });
        }
    }
}
