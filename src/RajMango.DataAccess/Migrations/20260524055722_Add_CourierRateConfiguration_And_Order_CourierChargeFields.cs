using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_CourierRateConfiguration_And_Order_CourierChargeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CourierCharge",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CourierChargeNote",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CourierChargeOverrideAmount",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourierLocationType",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourierProviderId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CourierRatePerKg",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsCourierChargeOverridden",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductTotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CourierRateConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierProviderId = table.Column<int>(type: "int", nullable: false),
                    CourierLocationType = table.Column<int>(type: "int", nullable: false),
                    RatePerKg = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MinimumCharge = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierRateConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierRateConfigurations_CourierProviders_CourierProviderId",
                        column: x => x.CourierProviderId,
                        principalTable: "CourierProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { new DateTime(2026, 5, 24, 11, 57, 16, 155, DateTimeKind.Unspecified).AddTicks(3876), "sysadmin@rajmango.com", "AQAAAAIAAYagAAAAEFTbteUa7IOGJF3E+/iFnbSnJy/oZ122kRlSGSyJ7dGGsIZlYo7PTL8fjXicwJnHaQ==", "+8801717441690", "SA1722" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { new DateTime(2026, 5, 24, 11, 57, 16, 354, DateTimeKind.Unspecified).AddTicks(6205), "AQAAAAIAAYagAAAAEORvep+oPaAqbip7RxvSlDy8iZWpGPGjWRDa3oVZop8vlFAdG6qFA8l/FQgsPdIOcA==", "+8801323993377", "AU1982" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(8063), "sr@rajmango.com", "Self", "Register", "AQAAAAIAAYagAAAAEHJSfRuE31U83o1obH65CykBTOhWCg1XYAZIYqjpsVPNJyMZU12woPVp7bIYBhiovA==", "+8801323993388", "SR3300" });

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
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "325-350g", new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6570) });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "400-425g", new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6582) });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "375-400g", new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "250-300g", new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6597) });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "250-275g", new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6603) });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "850-950g", new DateTime(2026, 5, 24, 11, 57, 16, 550, DateTimeKind.Local).AddTicks(6620) });

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

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "IsDeleted", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 62, new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626), 1, null, 0, "courier-rate-config.view", true, false, "courier-rate-config", "courier-rate-config.view", null, 0 },
                    { 63, new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626), 1, null, 0, "courier-rate-config.create", true, false, "courier-rate-config", "courier-rate-config.create", null, 0 },
                    { 64, new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626), 1, null, 0, "courier-rate-config.update", true, false, "courier-rate-config", "courier-rate-config.update", null, 0 },
                    { 65, new DateTime(2026, 5, 24, 11, 57, 16, 549, DateTimeKind.Unspecified).AddTicks(9626), 1, null, 0, "courier-rate-config.delete", true, false, "courier-rate-config", "courier-rate-config.delete", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 11, 3 },
                    { 12, 3 },
                    { 44, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 24, 11, 57, 15, 937, DateTimeKind.Unspecified).AddTicks(3160), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier-provider.view\",\"courier-provider.create\",\"courier-provider.update\",\"courier-provider.delete\",\"courier-station.view\",\"courier-station.create\",\"courier-station.update\",\"courier-station.delete\",\"courier-area-map.view\",\"courier-area-map.create\",\"courier-area-map.update\",\"courier-area-map.delete\",\"courier-rate-config.view\",\"courier-rate-config.create\",\"courier-rate-config.update\",\"courier-rate-config.delete\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 24, 11, 57, 15, 937, DateTimeKind.Unspecified).AddTicks(4140), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier-provider.view\",\"courier-provider.create\",\"courier-provider.update\",\"courier-provider.delete\",\"courier-station.view\",\"courier-station.create\",\"courier-station.update\",\"courier-station.delete\",\"courier-area-map.view\",\"courier-area-map.create\",\"courier-area-map.update\",\"courier-area-map.delete\",\"courier-rate-config.view\",\"courier-rate-config.create\",\"courier-rate-config.update\",\"courier-rate-config.delete\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "CreatedAt", "Name", "PermissionJson" },
                values: new object[] { "self_register", new DateTime(2026, 5, 24, 11, 57, 15, 937, DateTimeKind.Unspecified).AddTicks(4289), "Self Register", "[\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"mango.type.view\",\"mango.availability.view\",\"dashboard.customer.view\",\"complaint.submit\",\"policy.view\"]" });

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

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 62, 1 },
                    { 63, 1 },
                    { 64, 1 },
                    { 65, 1 },
                    { 62, 2 },
                    { 63, 2 },
                    { 64, 2 },
                    { 65, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CourierProviderId",
                table: "Orders",
                column: "CourierProviderId");

            migrationBuilder.CreateIndex(
                name: "UX_CourierRateConfigurations_Provider_LocationType_Active",
                table: "CourierRateConfigurations",
                columns: new[] { "CourierProviderId", "CourierLocationType" },
                unique: true,
                filter: "[IsActive] = 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CourierProviders_CourierProviderId",
                table: "Orders",
                column: "CourierProviderId",
                principalTable: "CourierProviders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CourierProviders_CourierProviderId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CourierRateConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CourierProviderId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 62, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 63, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 64, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 65, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 62, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 63, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 64, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 65, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 44, 3 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DropColumn(
                name: "CourierCharge",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CourierChargeNote",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CourierChargeOverrideAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CourierLocationType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CourierProviderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CourierRatePerKg",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsCourierChargeOverridden",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductTotalAmount",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 48, 869, DateTimeKind.Unspecified).AddTicks(3830), "systemadmin@rajmango.com", "AQAAAAIAAYagAAAAEDE/v9e0mVuBEu6lrnlF/4j9+zEAOk/hYcYGWjbtkXcT3g+m/IXMuAehq/e7fg22EQ==", "+8801700000001", "SA1000" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 49, 40, DateTimeKind.Unspecified).AddTicks(5328), "AQAAAAIAAYagAAAAEB6l+JawdWyWIZi8NF2uC+Amnzxl76IrPFjNoP+XYX/UEgvngFA9xQ5EritkrN91tw==", "+8801700000002", "AU2000" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(2766), "general@rajmango.com", "General", "User", "AQAAAAIAAYagAAAAEGX8doiEh5x2yHLQxzr7uK867tcQNM+m1lYJz6fmjiV1CufysvzQUCMP+DltPde92A==", "+8801700000003", "GU3000" });

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
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "250-350g", new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7086) });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "300-400g", new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7093) });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "300-500g", new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7099) });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "200-300g", new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7105) });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "250-350g", new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7111) });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AverageWeight", "CreatedAt" },
                values: new object[] { "500-700g", new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Local).AddTicks(7117) });

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
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 48, 710, DateTimeKind.Unspecified).AddTicks(7437), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier-provider.view\",\"courier-provider.create\",\"courier-provider.update\",\"courier-provider.delete\",\"courier-station.view\",\"courier-station.create\",\"courier-station.update\",\"courier-station.delete\",\"courier-area-map.view\",\"courier-area-map.create\",\"courier-area-map.update\",\"courier-area-map.delete\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 48, 710, DateTimeKind.Unspecified).AddTicks(7630), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier-provider.view\",\"courier-provider.create\",\"courier-provider.update\",\"courier-provider.delete\",\"courier-station.view\",\"courier-station.create\",\"courier-station.update\",\"courier-station.delete\",\"courier-area-map.view\",\"courier-area-map.create\",\"courier-area-map.update\",\"courier-area-map.delete\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "CreatedAt", "Name", "PermissionJson" },
                values: new object[] { "general", new DateTime(2026, 5, 18, 19, 52, 48, 710, DateTimeKind.Unspecified).AddTicks(7688), "General", "[\"order.view\",\"order.create\",\"mango.type.view\",\"mango.availability.view\",\"dashboard.customer.view\",\"complaint.submit\"]" });

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
    }
}
