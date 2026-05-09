using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedFallbackAddressInOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FallbackAddress",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FallbackAddress",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 1, 14, 15, 42, 49, DateTimeKind.Unspecified).AddTicks(6592), "AQAAAAIAAYagAAAAEMDfKFXyPnWS1+uSKIpj6R0tcb8YZ0oX13v+zzAwNRodO01OitvzABdO+ylPHoqikw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 1, 14, 15, 42, 139, DateTimeKind.Unspecified).AddTicks(5935), "AQAAAAIAAYagAAAAEArWSHDpDOM87arR5TUDLKJoDNA//I2mycmSEAbPjtBrIqW5of4TGLd8+8XfsFNoYQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Unspecified).AddTicks(674), "AQAAAAIAAYagAAAAEJa8XAWkp2FtaZp8Bm9sTrzO3LubyuBP1LNdlv3uYIvBZi71QtAun94UxziXg13T1g==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Local).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 14, 15, 41, 971, DateTimeKind.Unspecified).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 14, 15, 41, 971, DateTimeKind.Unspecified).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 14, 15, 41, 971, DateTimeKind.Unspecified).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Unspecified).AddTicks(1270), new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Unspecified).AddTicks(1246) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Unspecified).AddTicks(1282), new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Unspecified).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Unspecified).AddTicks(1287), new DateTime(2025, 6, 1, 14, 15, 42, 230, DateTimeKind.Unspecified).AddTicks(1285) });
        }
    }
}
