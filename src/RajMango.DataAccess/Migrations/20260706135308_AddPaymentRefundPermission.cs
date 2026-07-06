using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentRefundPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 6, 19, 53, 6, 277, DateTimeKind.Unspecified).AddTicks(2564), "AQAAAAIAAYagAAAAEOFhKWbjpBHE9RMGU+Wv1ICJ1KrH2DtMshhXiKqCNXQmcUCddKR2mVgJHXYu7IIssw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 6, 19, 53, 6, 361, DateTimeKind.Unspecified).AddTicks(1313), "AQAAAAIAAYagAAAAEGjyMqvgE4Cd9hRxJPs0KdzY0aEGDVSjYbhzFwdtIyJkdivB0bamWCm2PJ+kz/jfWA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(836), "AQAAAAIAAYagAAAAELSRB2da2+Yl3FZAzfKynqfeLSGZU2cr7AfR/HOhkAjoKMN6kbdNpU4mtsIDOJCRUg==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4418));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4452));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4121));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4125));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4143));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4308));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(4341));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Local).AddTicks(4031));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "IsDeleted", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 70, new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1586), 1, null, 0, "payment.admin.refund", true, false, "payment.admin", "payment.admin.refund", null, 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 7, 6, 19, 53, 6, 180, DateTimeKind.Unspecified).AddTicks(3257), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"order.admin.view\",\"order.admin.manage\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier.provider.view\",\"courier.provider.create\",\"courier.provider.update\",\"courier.provider.delete\",\"courier.station.view\",\"courier.station.create\",\"courier.station.update\",\"courier.station.delete\",\"courier.area.map.view\",\"courier.area.map.create\",\"courier.area.map.update\",\"courier.area.map.delete\",\"courier.rate.config.view\",\"courier.rate.config.create\",\"courier.rate.config.update\",\"courier.rate.config.delete\",\"order.admin.create-for-customer\",\"order.admin.delete-permanent\",\"payment.admin.refund\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 7, 6, 19, 53, 6, 180, DateTimeKind.Unspecified).AddTicks(3577), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"order.admin.view\",\"order.admin.manage\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier.provider.view\",\"courier.provider.create\",\"courier.provider.update\",\"courier.provider.delete\",\"courier.station.view\",\"courier.station.create\",\"courier.station.update\",\"courier.station.delete\",\"courier.area.map.view\",\"courier.area.map.create\",\"courier.area.map.update\",\"courier.area.map.delete\",\"courier.rate.config.view\",\"courier.rate.config.create\",\"courier.rate.config.update\",\"courier.rate.config.delete\",\"order.admin.create-for-customer\",\"order.admin.delete-permanent\",\"payment.admin.refund\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 19, 53, 6, 180, DateTimeKind.Unspecified).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1538), new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1536) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1549), new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1548) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1555), new DateTime(2026, 7, 6, 19, 53, 6, 450, DateTimeKind.Unspecified).AddTicks(1554) });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 70, 1 },
                    { 70, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 70, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 70, 2 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70);

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

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 10, 32, 39, 46, DateTimeKind.Unspecified).AddTicks(1744));

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
        }
    }
}
