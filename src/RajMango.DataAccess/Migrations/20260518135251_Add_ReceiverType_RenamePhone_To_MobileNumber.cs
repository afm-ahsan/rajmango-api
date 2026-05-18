using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_ReceiverType_RenamePhone_To_MobileNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceiverPhone",
                table: "Orders",
                newName: "ReceiverMobileNumber");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverType",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 48, 869, DateTimeKind.Unspecified).AddTicks(3830), "AQAAAAIAAYagAAAAEDE/v9e0mVuBEu6lrnlF/4j9+zEAOk/hYcYGWjbtkXcT3g+m/IXMuAehq/e7fg22EQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 49, 40, DateTimeKind.Unspecified).AddTicks(5328), "AQAAAAIAAYagAAAAEB6l+JawdWyWIZi8NF2uC+Amnzxl76IrPFjNoP+XYX/UEgvngFA9xQ5EritkrN91tw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(2766), "AQAAAAIAAYagAAAAEGX8doiEh5x2yHLQxzr7uK867tcQNM+m1lYJz6fmjiV1CufysvzQUCMP+DltPde92A==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7242));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 48, 710, DateTimeKind.Unspecified).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 48, 710, DateTimeKind.Unspecified).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 19, 52, 48, 710, DateTimeKind.Unspecified).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3510), new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3507) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3528), new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3525) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3539), new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(3536) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverType",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ReceiverMobileNumber",
                table: "Orders",
                newName: "ReceiverPhone");

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
    }
}
