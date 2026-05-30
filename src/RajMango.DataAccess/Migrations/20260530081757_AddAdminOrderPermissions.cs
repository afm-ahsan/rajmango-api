using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                values: new object[] { new DateTime(2026, 5, 30, 14, 17, 53, 779, DateTimeKind.Unspecified).AddTicks(3892), "AQAAAAIAAYagAAAAENLCeI8AFGUcz2atQaLeNJlkgwyq+9/o8id7AnmryGjQL2wYJ2OI8CBsbBtAb7Wlgw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 30, 14, 17, 53, 913, DateTimeKind.Unspecified).AddTicks(5389), "AQAAAAIAAYagAAAAEK4csdc7iJeOGyST1isRnIGyLACvK1s/T4cxRtJY1BIhrSPpYwsPb0tP06l17LAUOg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(888), "AQAAAAIAAYagAAAAEBR4nhua4lle1c9DXO2bNaj5WgfcratwKlntbASA3YGT3sA0wZe3u6nKWhqRfF8AfA==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(500));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(9809));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(9849));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(9877));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(268));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(315));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(333));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 67, DateTimeKind.Unspecified).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Local).AddTicks(9617));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Local).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Local).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Local).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 53, 663, DateTimeKind.Unspecified).AddTicks(891));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 53, 663, DateTimeKind.Unspecified).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 14, 17, 53, 663, DateTimeKind.Unspecified).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(1746), new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(1739) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(1765), new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(1762) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(1777), new DateTime(2026, 5, 30, 14, 17, 54, 66, DateTimeKind.Unspecified).AddTicks(1773) });

            // Add admin order permissions (idempotent)
            migrationBuilder.Sql(@"
INSERT INTO Permissions (Name, Module, Description, IsActive, IsDeleted, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt, DeletedBy)
SELECT 'order.admin.view', 'order.admin', 'order.admin.view', 1, 0, '2026-05-30', 1, NULL, 0, NULL, 0
WHERE NOT EXISTS (SELECT 1 FROM Permissions WHERE Name = 'order.admin.view');

INSERT INTO Permissions (Name, Module, Description, IsActive, IsDeleted, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt, DeletedBy)
SELECT 'order.admin.manage', 'order.admin', 'order.admin.manage', 1, 0, '2026-05-30', 1, NULL, 0, NULL, 0
WHERE NOT EXISTS (SELECT 1 FROM Permissions WHERE Name = 'order.admin.manage');

INSERT INTO RolePermissions (RoleId, PermissionId)
SELECT 1, p.Id FROM Permissions p WHERE p.Name = 'order.admin.view'
  AND NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = 1 AND PermissionId = p.Id);

INSERT INTO RolePermissions (RoleId, PermissionId)
SELECT 1, p.Id FROM Permissions p WHERE p.Name = 'order.admin.manage'
  AND NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = 1 AND PermissionId = p.Id);

INSERT INTO RolePermissions (RoleId, PermissionId)
SELECT 2, p.Id FROM Permissions p WHERE p.Name = 'order.admin.view'
  AND NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = 2 AND PermissionId = p.Id);

INSERT INTO RolePermissions (RoleId, PermissionId)
SELECT 2, p.Id FROM Permissions p WHERE p.Name = 'order.admin.manage'
  AND NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = 2 AND PermissionId = p.Id);
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 12, 2, 33, 131, DateTimeKind.Unspecified).AddTicks(5077));

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

            // Remove admin order permissions on rollback
            migrationBuilder.Sql(@"
DELETE rp FROM RolePermissions rp
INNER JOIN Permissions p ON rp.PermissionId = p.Id
WHERE p.Name IN ('order.admin.view', 'order.admin.manage');

DELETE FROM Permissions WHERE Name IN ('order.admin.view', 'order.admin.manage');
");
        }
    }
}
