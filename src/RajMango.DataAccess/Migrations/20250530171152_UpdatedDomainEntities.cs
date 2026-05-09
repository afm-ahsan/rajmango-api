using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDomainEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourierStations_CourierProviders_ProviderId",
                table: "CourierStations");

            migrationBuilder.DropColumn(
                name: "StationName",
                table: "CourierStations");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customers",
                newName: "PhoneNumber1");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "CourierStations",
                newName: "CourierProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_CourierStations_ProviderId",
                table: "CourierStations",
                newName: "IX_CourierStations_CourierProviderId");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Customers",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupportPhone1",
                table: "CourierStations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "CourierStations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "CourierStations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "CourierStations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CourierStations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "CourierAreaMaps",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CourierStations_CourierProviders_CourierProviderId",
                table: "CourierStations",
                column: "CourierProviderId",
                principalTable: "CourierProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourierStations_CourierProviders_CourierProviderId",
                table: "CourierStations");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CourierStations");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber1",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "Customers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "CourierProviderId",
                table: "CourierStations",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_CourierStations_CourierProviderId",
                table: "CourierStations",
                newName: "IX_CourierStations_ProviderId");

            migrationBuilder.AlterColumn<string>(
                name: "SupportPhone1",
                table: "CourierStations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "CourierStations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "CourierStations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "CourierStations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "StationName",
                table: "CourierStations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "CourierAreaMaps",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 30, 12, 48, 26, 989, DateTimeKind.Unspecified).AddTicks(8059), "AQAAAAIAAYagAAAAEOl0J6a01/4TMf/BUFKT5aQMsxADLWL343aVBOY24wvhKAjES76KKOLC5uUkxELRcQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 30, 12, 48, 27, 63, DateTimeKind.Unspecified).AddTicks(8196), "AQAAAAIAAYagAAAAEA9qqL3NnVaPQfmG73Yf/W0WPhGz23M445BIk2q18b0WCE4YHOp+qiOPv8g4H1vxRw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Unspecified).AddTicks(3843), "AQAAAAIAAYagAAAAEDQJ8+4cKJyyIdmsyuKGLpSAey9wGnlJOHilOJ7oZwfVx8ksq9GL8+Atauk8f0pZQA==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Local).AddTicks(4683));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Local).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Local).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Local).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 12, 48, 26, 917, DateTimeKind.Unspecified).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 12, 48, 26, 917, DateTimeKind.Unspecified).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 12, 48, 26, 917, DateTimeKind.Unspecified).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Unspecified).AddTicks(4529), new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Unspecified).AddTicks(4527) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Unspecified).AddTicks(4605), new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Unspecified).AddTicks(4603) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Unspecified).AddTicks(4611), new DateTime(2025, 5, 30, 12, 48, 27, 150, DateTimeKind.Unspecified).AddTicks(4609) });

            migrationBuilder.AddForeignKey(
                name: "FK_CourierStations_CourierProviders_ProviderId",
                table: "CourierStations",
                column: "ProviderId",
                principalTable: "CourierProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
