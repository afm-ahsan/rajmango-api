using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentFailureReason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RefundedAmount",
                table: "Payments",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2)
                .Annotation("Relational:ColumnOrder", 21)
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<string>(
                name: "RawExecuteResponse",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 19)
                .OldAnnotation("Relational:ColumnOrder", 18);

            migrationBuilder.AlterColumn<string>(
                name: "RawCreateResponse",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 18)
                .OldAnnotation("Relational:ColumnOrder", 17);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaidAt",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 20)
                .OldAnnotation("Relational:ColumnOrder", 19);

            migrationBuilder.AddColumn<string>(
                name: "FailureReason",
                table: "Payments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 6, 21, 28, 33, 10, DateTimeKind.Unspecified).AddTicks(7081), "AQAAAAIAAYagAAAAEM16eUO5RWwcr/ga36YZqLjQFsTqm+kdKpsdtsIRVDZaetVrYfaNMO2fezIdA2CVPw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 6, 21, 28, 33, 121, DateTimeKind.Unspecified).AddTicks(1724), "AQAAAAIAAYagAAAAECgVw7zg5kTElFR8Sw9LwS2uaiXzVteRAHWOgRTt76XT1McU/BKM7dzth2h1Dkpr3Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(7665), "AQAAAAIAAYagAAAAEKmahrrVbGJlUokHCzBUeIBYJVDNDjzt7KrhwNzNFCHGez/O2CYJK7eIy0fs32oW/A==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4192));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4399));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4414));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Unspecified).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Local).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Local).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Local).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Local).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 224, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 32, 908, DateTimeKind.Unspecified).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 32, 908, DateTimeKind.Unspecified).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 21, 28, 32, 908, DateTimeKind.Unspecified).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8885), new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8881) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8903), new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8900) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8913), new DateTime(2026, 7, 6, 21, 28, 33, 223, DateTimeKind.Unspecified).AddTicks(8910) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailureReason",
                table: "Payments");

            migrationBuilder.AlterColumn<decimal>(
                name: "RefundedAmount",
                table: "Payments",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2)
                .Annotation("Relational:ColumnOrder", 20)
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<string>(
                name: "RawExecuteResponse",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 18)
                .OldAnnotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<string>(
                name: "RawCreateResponse",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 17)
                .OldAnnotation("Relational:ColumnOrder", 18);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaidAt",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 19)
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 6, 20, 47, 41, 956, DateTimeKind.Unspecified).AddTicks(6989), "AQAAAAIAAYagAAAAEGEtDEXyKxDDC1wj0FavyMiQwb8uo+z6yg1jcjUBTghgyNCahPoZMKudPCD5D2dLUw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 6, 20, 47, 42, 67, DateTimeKind.Unspecified).AddTicks(3402), "AQAAAAIAAYagAAAAEE+fAtzk+PBSDaJpSNiv8zjJ22VPemwORpAH5+FBERGu0aMDw/YcZBwr5sabcM143g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(4165), "AQAAAAIAAYagAAAAEDkLBZcLCMRq/R/2dVpSLb8hvryXy/xp3gsnwxqF5UriRaslYs4nB5R50/1cWP4ZMQ==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2040));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1587));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1604));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1634));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1830));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Unspecified).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Local).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Local).AddTicks(1237));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Local).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 177, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 41, 826, DateTimeKind.Unspecified).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 41, 826, DateTimeKind.Unspecified).AddTicks(1943));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 6, 20, 47, 41, 826, DateTimeKind.Unspecified).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(4979), new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5037), new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5034) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5047), new DateTime(2026, 7, 6, 20, 47, 42, 176, DateTimeKind.Unspecified).AddTicks(5045) });
        }
    }
}
