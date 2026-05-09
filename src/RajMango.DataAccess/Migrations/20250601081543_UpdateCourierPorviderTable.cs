using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourierPorviderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "CourierProviders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "CourierProviders");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 30, 23, 11, 50, 486, DateTimeKind.Unspecified).AddTicks(5019), "AQAAAAIAAYagAAAAEBkquLD+V4r5vrbIxHL9Q3xA+B0P29OOvHndcvtADF41khUWumu+iuSMunYTIZT6NA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 30, 23, 11, 50, 587, DateTimeKind.Unspecified).AddTicks(7174), "AQAAAAIAAYagAAAAEAQYzYyNL1Bo9R9GKub01DYHX62KH3jmul9mfzejSnhgAslbd//EXNdXW6OGSB+mnw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Unspecified).AddTicks(8030), "AQAAAAIAAYagAAAAEHGTrA7Qh/7khzvf/dsAqrOIUKU7wKzL5XZSLvYKga0AzPH0zq1CvVDJWGETxJUYCA==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Local).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Local).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Local).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Local).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 23, 11, 50, 386, DateTimeKind.Unspecified).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 23, 11, 50, 386, DateTimeKind.Unspecified).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 23, 11, 50, 386, DateTimeKind.Unspecified).AddTicks(3318));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Unspecified).AddTicks(8891), new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Unspecified).AddTicks(8871) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Unspecified).AddTicks(8905), new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Unspecified).AddTicks(8902) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Unspecified).AddTicks(8912), new DateTime(2025, 5, 30, 23, 11, 50, 672, DateTimeKind.Unspecified).AddTicks(8910) });
        }
    }
}
