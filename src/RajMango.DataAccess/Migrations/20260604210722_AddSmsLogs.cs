using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSmsLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmsLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TriggerEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    HttpStatusCode = table.Column<int>(type: "int", nullable: true),
                    ProviderResponse = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsLogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 7, 21, 605, DateTimeKind.Unspecified).AddTicks(7418), "AQAAAAIAAYagAAAAEF3E8cqQ4E/JXJeA+vj0f6GCr3tNEuLhrsIU492HJ9yMcy91T2HDKm7s339S5YdZ2w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 7, 21, 681, DateTimeKind.Unspecified).AddTicks(691), "AQAAAAIAAYagAAAAEPqMOiQ2epB6cgUvIHtFP7FOKlQXD4kDz2XpkFaE/CMS+5cE0iwsGqa8Jj+kJ/q4Ug==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3138), "AQAAAAIAAYagAAAAEEuW7k0mgVIoCYRyRYy5nv00e5IIso5n8KvRxu/XmyTCnhlA/owPQYEEnLkQEKDf0A==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7588));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7591));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7620));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7359));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(7526));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Local).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 523, DateTimeKind.Unspecified).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 523, DateTimeKind.Unspecified).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 7, 21, 523, DateTimeKind.Unspecified).AddTicks(8097));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3611), new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3609) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3658), new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3656) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3663), new DateTime(2026, 6, 5, 3, 7, 21, 769, DateTimeKind.Unspecified).AddTicks(3661) });

            migrationBuilder.CreateIndex(
                name: "IX_SmsLogs_CreatedAt",
                table: "SmsLogs",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_SmsLogs_OrderNumber",
                table: "SmsLogs",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SmsLogs_UserId_Status",
                table: "SmsLogs",
                columns: new[] { "UserId", "Status" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmsLogs");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 5, 12, 305, DateTimeKind.Unspecified).AddTicks(2918), "AQAAAAIAAYagAAAAECINl4PkB0fC1qxc3knpptEAarw5GEhfCj5zHdMGMomau0V4329ex2RRL3DlHUwB3g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 5, 12, 380, DateTimeKind.Unspecified).AddTicks(1847), "AQAAAAIAAYagAAAAEKQ+RxjW6oDbzMN85SEE/nuELfzA3hm3wrDO8k77G6+m27Ez+oQ+da9rviw5S2MT0w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(5396), "AQAAAAIAAYagAAAAEGSdL7zcBxRsMExebZsHRsB0x6ZFqSPZ6phG35Xf7H+uoq/MQ/9XG6RJbu0zhIMO4A==" });

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9715));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9735));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9739));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9758));

            migrationBuilder.UpdateData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9531));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierRateConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9618));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9623));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9639));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Local).AddTicks(9305));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Local).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Local).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 225, DateTimeKind.Unspecified).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 225, DateTimeKind.Unspecified).AddTicks(1298));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 3, 5, 12, 225, DateTimeKind.Unspecified).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(5874), new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(5872) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(5930), new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(5928) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6015), new DateTime(2026, 6, 5, 3, 5, 12, 469, DateTimeKind.Unspecified).AddTicks(6014) });
        }
    }
}
