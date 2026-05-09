using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_MangoAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MangoAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangoTypeId = table.Column<int>(type: "int", nullable: false),
                    SeasonYear = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePerKg = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_MangoAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MangoAvailabilities_MangoTypes_MangoTypeId",
                        column: x => x.MangoTypeId,
                        principalTable: "MangoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 491, DateTimeKind.Unspecified).AddTicks(7464), "AQAAAAIAAYagAAAAEDbwVbDgYMCSLGuzSA9GBxK8RQr7jDv1stoX3M7OxS+iIvV/5bu/3r0iY1EEzxKtWg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 564, DateTimeKind.Unspecified).AddTicks(9005), "AQAAAAIAAYagAAAAENjYyS3JrOT3dpA46IDfzfDiXqNWhPl1TBaQGb29mP6NegoTzwJv5ngtmI38Lpjreg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(7489), "AQAAAAIAAYagAAAAEKeCPMU3N++v7+ozskvwqzgSv/6tMKAPT1HxKLB3bld7XYTunoktTV+hkHH+q6J8SQ==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Local).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 417, DateTimeKind.Unspecified).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 417, DateTimeKind.Unspecified).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 18, 3, 30, 417, DateTimeKind.Unspecified).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8222), new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8220) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8232), new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8237), new DateTime(2026, 5, 9, 18, 3, 30, 638, DateTimeKind.Unspecified).AddTicks(8236) });

            migrationBuilder.CreateIndex(
                name: "IX_MangoAvailabilities_MangoTypeId",
                table: "MangoAvailabilities",
                column: "MangoTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangoAvailabilities");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 10, 12, 27, 40, 115, DateTimeKind.Unspecified).AddTicks(547), "AQAAAAIAAYagAAAAEC5ZRqgQ8fwJ2n8LJNmEr9fQuN1YXRReO3OPUMCJ2ecMB7KSJ7YT5qGS3LnOgn296A==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 10, 12, 27, 40, 185, DateTimeKind.Unspecified).AddTicks(7410), "AQAAAAIAAYagAAAAEAzP1n4riCxILgL0psMslvZeLPlcP65GZ4ox/Z8joKxRTeCBIQHxFfayWIBETC34UA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 10, 12, 27, 40, 261, DateTimeKind.Unspecified).AddTicks(9874), "AQAAAAIAAYagAAAAENWNX40twg80S8iR2KdIW29DF5zKlgrOb15bKt2xgUQCh0keVjoUhQuU2K2tHggzQQ==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Local).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Local).AddTicks(840));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Local).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 10, 12, 27, 40, 42, DateTimeKind.Unspecified).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 10, 12, 27, 40, 42, DateTimeKind.Unspecified).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 10, 12, 27, 40, 42, DateTimeKind.Unspecified).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Unspecified).AddTicks(560), new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Unspecified).AddTicks(554) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Unspecified).AddTicks(594), new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Unspecified).AddTicks(584) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Unspecified).AddTicks(610), new DateTime(2025, 6, 10, 12, 27, 40, 262, DateTimeKind.Unspecified).AddTicks(607) });
        }
    }
}
