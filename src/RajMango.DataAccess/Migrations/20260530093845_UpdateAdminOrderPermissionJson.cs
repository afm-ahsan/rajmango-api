using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdminOrderPermissionJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 30, 15, 38, 41, 713, DateTimeKind.Unspecified).AddTicks(1002), "AQAAAAIAAYagAAAAEBDBvt8Du8cu6XoDtjqfxrwLtmv9FULxosdldv3JdXc3g6zyQErcfCCl/JESgBXwiA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 30, 15, 38, 41, 855, DateTimeKind.Unspecified).AddTicks(1116), "AQAAAAIAAYagAAAAENJJzM2D9E/4e1j44t+qPWbkBR5NzPJeyh4yhA1XnyrR4RFyZAx0tdwsKTEiYjlcyw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(539), "AQAAAAIAAYagAAAAEESCIHFOb8GHFnT6c6Gv8eJVbx27S7eiXYL1N4znKE6omT8vOgw4Cy5i8Vcn0/xOfA==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(169));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(215));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9942));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 12, DateTimeKind.Unspecified).AddTicks(58));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Local).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 30, 15, 38, 41, 581, DateTimeKind.Unspecified).AddTicks(617), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier-provider.view\",\"courier-provider.create\",\"courier-provider.update\",\"courier-provider.delete\",\"courier-station.view\",\"courier-station.create\",\"courier-station.update\",\"courier-station.delete\",\"courier-area-map.view\",\"courier-area-map.create\",\"courier-area-map.update\",\"courier-area-map.delete\",\"courier-rate-config.view\",\"courier-rate-config.create\",\"courier-rate-config.update\",\"courier-rate-config.delete\",\"order.admin.view\",\"order.admin.manage\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 30, 15, 38, 41, 581, DateTimeKind.Unspecified).AddTicks(1043), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier-provider.view\",\"courier-provider.create\",\"courier-provider.update\",\"courier-provider.delete\",\"courier-station.view\",\"courier-station.create\",\"courier-station.update\",\"courier-station.delete\",\"courier-area-map.view\",\"courier-area-map.create\",\"courier-area-map.update\",\"courier-area-map.delete\",\"courier-rate-config.view\",\"courier-rate-config.create\",\"courier-rate-config.update\",\"courier-rate-config.delete\",\"order.admin.view\",\"order.admin.manage\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 30, 15, 38, 41, 581, DateTimeKind.Unspecified).AddTicks(1132));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2222), new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2248), new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2243) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2262), new DateTime(2026, 5, 30, 15, 38, 42, 11, DateTimeKind.Unspecified).AddTicks(2258) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 30, 14, 17, 53, 663, DateTimeKind.Unspecified).AddTicks(891), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier-provider.view\",\"courier-provider.create\",\"courier-provider.update\",\"courier-provider.delete\",\"courier-station.view\",\"courier-station.create\",\"courier-station.update\",\"courier-station.delete\",\"courier-area-map.view\",\"courier-area-map.create\",\"courier-area-map.update\",\"courier-area-map.delete\",\"courier-rate-config.view\",\"courier-rate-config.create\",\"courier-rate-config.update\",\"courier-rate-config.delete\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 30, 14, 17, 53, 663, DateTimeKind.Unspecified).AddTicks(1172), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier-provider.view\",\"courier-provider.create\",\"courier-provider.update\",\"courier-provider.delete\",\"courier-station.view\",\"courier-station.create\",\"courier-station.update\",\"courier-station.delete\",\"courier-area-map.view\",\"courier-area-map.create\",\"courier-area-map.update\",\"courier-area-map.delete\",\"courier-rate-config.view\",\"courier-rate-config.create\",\"courier-rate-config.update\",\"courier-rate-config.delete\"]" });

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
        }
    }
}
