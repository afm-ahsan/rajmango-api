using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminOrderPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 32, 38, 896, DateTimeKind.Unspecified).AddTicks(2310), "AQAAAAIAAYagAAAAEHq/tatJsYzB9jDiDXhtGiVRn/DWpcMvGVcVEFf/HYCQxO2mLbj7nBCUMNKRhrAK8g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 32, 38, 970, DateTimeKind.Unspecified).AddTicks(6783), "AQAAAAIAAYagAAAAEE8oj9pmjr2IyTaKic2WwTy/F67K2MrHHQzdKW2ceOpnqiL0tEnjl6LFu2HKLPgQRg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1207), "AQAAAAIAAYagAAAAEA7oOy8ZnM+fq3tWCfD4HUvEj4FBYRzbfb6gJaUQbYbz8StEXwRGWK3g52epzyOc5Q==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4550));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4336));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4341));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4436));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(4477));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Local).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Local).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Local).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Local).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "IsDeleted", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 68, new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744), 1, null, 0, "order.admin.create-for-customer", true, false, "order.admin", "order.admin.create-for-customer", null, 0 },
                    { 69, new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744), 1, null, 0, "order.admin.delete-permanent", true, false, "order.admin", "order.admin.delete-permanent", null, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 32, 38, 821, DateTimeKind.Unspecified).AddTicks(3925), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"order.admin.view\",\"order.admin.manage\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier.provider.view\",\"courier.provider.create\",\"courier.provider.update\",\"courier.provider.delete\",\"courier.station.view\",\"courier.station.create\",\"courier.station.update\",\"courier.station.delete\",\"courier.area.map.view\",\"courier.area.map.create\",\"courier.area.map.update\",\"courier.area.map.delete\",\"courier.rate.config.view\",\"courier.rate.config.create\",\"courier.rate.config.update\",\"courier.rate.config.delete\",\"order.admin.create-for-customer\",\"order.admin.delete-permanent\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 32, 38, 821, DateTimeKind.Unspecified).AddTicks(4177), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"order.admin.view\",\"order.admin.manage\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier.provider.view\",\"courier.provider.create\",\"courier.provider.update\",\"courier.provider.delete\",\"courier.station.view\",\"courier.station.create\",\"courier.station.update\",\"courier.station.delete\",\"courier.area.map.view\",\"courier.area.map.create\",\"courier.area.map.update\",\"courier.area.map.delete\",\"courier.rate.config.view\",\"courier.rate.config.create\",\"courier.rate.config.update\",\"courier.rate.config.delete\",\"order.admin.create-for-customer\",\"order.admin.delete-permanent\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 38, 821, DateTimeKind.Unspecified).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1607), new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1605) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1701), new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1707), new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1705) });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 68, 1 },
                    { 69, 1 },
                    { 68, 2 },
                    { 69, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 68, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 69, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 68, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 69, 2 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 27, 52, 780, DateTimeKind.Unspecified).AddTicks(430), "AQAAAAIAAYagAAAAELqEe6bdOI47pcDWOP6qkfW4tE0twENc17UtDf4S7uPMig5066h3W5IJVqwBbLJMTg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 27, 52, 879, DateTimeKind.Unspecified).AddTicks(5482), "AQAAAAIAAYagAAAAEBvlYbyNSFa68dslujdbV6hBnJ8zPDIM8Em9lYcjrOPZQxEnchDtRrSxBhqBozeYAg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(8143), "AQAAAAIAAYagAAAAEKIi+teD30FZQbTexbm8IdCJ4uOz26skcQP4IwdrTa/rnRvYy3NsCVY2pLn9t+o65g==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2568));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2313));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Unspecified).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Local).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Local).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Local).AddTicks(2114));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 983, DateTimeKind.Local).AddTicks(2122));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 27, 52, 682, DateTimeKind.Unspecified).AddTicks(4008), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"order.admin.view\",\"order.admin.manage\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier.provider.view\",\"courier.provider.create\",\"courier.provider.update\",\"courier.provider.delete\",\"courier.station.view\",\"courier.station.create\",\"courier.station.update\",\"courier.station.delete\",\"courier.area.map.view\",\"courier.area.map.create\",\"courier.area.map.update\",\"courier.area.map.delete\",\"courier.rate.config.view\",\"courier.rate.config.create\",\"courier.rate.config.update\",\"courier.rate.config.delete\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 27, 52, 682, DateTimeKind.Unspecified).AddTicks(4261), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"order.admin.view\",\"order.admin.manage\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier.provider.view\",\"courier.provider.create\",\"courier.provider.update\",\"courier.provider.delete\",\"courier.station.view\",\"courier.station.create\",\"courier.station.update\",\"courier.station.delete\",\"courier.area.map.view\",\"courier.area.map.create\",\"courier.area.map.update\",\"courier.area.map.delete\",\"courier.rate.config.view\",\"courier.rate.config.create\",\"courier.rate.config.update\",\"courier.rate.config.delete\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 27, 52, 682, DateTimeKind.Unspecified).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(8952), new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(8949) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(8966), new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(8973), new DateTime(2026, 7, 4, 10, 27, 52, 982, DateTimeKind.Unspecified).AddTicks(8971) });
        }
    }
}
