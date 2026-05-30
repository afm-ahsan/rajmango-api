using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Seed_CourierRateConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 24, 12, 2, 32, 736, DateTimeKind.Unspecified).AddTicks(5379), "AQAAAAIAAYagAAAAEEeDwaoib2Ty9GEXEh9d6JKClnwSW1KhBLlGLQwfRNm5LYEPwxA+65SOU3NotX+JWQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 24, 12, 2, 32, 928, DateTimeKind.Unspecified).AddTicks(5482), "AQAAAAIAAYagAAAAEA1/wH8Nr9Py0dhmaIyCLzkZqgMs7BtlRTOsyD2PdB+oqFH5Vmaz82vNsDX9bg/YnQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(2712), "AQAAAAIAAYagAAAAEEu3HY6QfxBdZxk9OHCJVjszjDdUrwMmO25+h2FNMpRNpli+eJ/wSAMLl2uDY3aCHA==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5035));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4586));

            migrationBuilder.InsertData(
                table: "CourierRateConfigurations",
                columns: new[] { "Id", "CourierLocationType", "CourierProviderId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActive", "IsDeleted", "MinimumCharge", "RatePerKg", "Sequence", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 2, 1, 2, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 3, 1, 3, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 4, 1, 4, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 5, 1, 5, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 6, 1, 6, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 7, 1, 7, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 8, 1, 8, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 9, 2, 1, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 10, 2, 2, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 11, 2, 3, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 12, 2, 4, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 13, 2, 5, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 14, 2, 6, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 15, 2, 7, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 16, 2, 8, new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 }
                });

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Local).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Local).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Local).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 32, 541, DateTimeKind.Unspecified).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 32, 541, DateTimeKind.Unspecified).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 32, 541, DateTimeKind.Unspecified).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4618), new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4614) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4639), new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4636) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4650), new DateTime(2026, 5, 24, 12, 2, 33, 130, DateTimeKind.Unspecified).AddTicks(4647) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 24, 11, 57, 16, 155, DateTimeKind.Unspecified).AddTicks(3876), "AQAAAAIAAYagAAAAEFTbteUa7IOGJF3E+/iFnbSnJy/oZ122kRlSGSyJ7dGGsIZlYo7PTL8fjXicwJnHaQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 24, 11, 57, 16, 354, DateTimeKind.Unspecified).AddTicks(6205), "AQAAAAIAAYagAAAAEORvep+oPaAqbip7RxvSlDy8iZWpGPGjWRDa3oVZop8vlFAdG6qFA8l/FQgsPdIOcA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(8063), "AQAAAAIAAYagAAAAEHJSfRuE31U83o1obH65CykBTOhWCg1XYAZIYqjpsVPNJyMZU12woPVp7bIYBhiovA==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7510));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7523));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(6892));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(6901));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7277));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7333));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Unspecified).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6582));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6590));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 15, 937, DateTimeKind.Unspecified).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 15, 937, DateTimeKind.Unspecified).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 11, 57, 15, 937, DateTimeKind.Unspecified).AddTicks(4289));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9194), new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9214), new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9211) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9227), new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9223) });
        }
    }
}
