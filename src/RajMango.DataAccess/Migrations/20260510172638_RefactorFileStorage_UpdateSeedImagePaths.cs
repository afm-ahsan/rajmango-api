using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RefactorFileStorage_UpdateSeedImagePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 351, DateTimeKind.Unspecified).AddTicks(1880), "AQAAAAIAAYagAAAAEGAnzVpoe8YSJFF6pA4RAVlsyLmoGzpgHrO/QVGUiXK8ygzq5sJi5BPLp9BEv53gsg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 428, DateTimeKind.Unspecified).AddTicks(2928), "AQAAAAIAAYagAAAAEKes+tgzlAA9GOmoxEccf73urcZ1GFOvvvho5JhdvAVUpYvvzbZxGdosFkhXaEFNQQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(3141), "AQAAAAIAAYagAAAAECazp3a74hyf9hcVl0KYJizOl87IIiFV2pzB3nzqrlspI1ZRI8FhryItlWr5W72ZtQ==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4138), "/uploads/mango-types/2026/05/mango-type-1-gopalbhog.jpg" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4142), "/uploads/mango-types/2026/05/mango-type-2-himsagor.jpg" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4176), "/uploads/mango-types/2026/05/mango-type-3-langra.jpg" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4180), "/uploads/mango-types/2026/05/mango-type-4-amrupali.jpg" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4183), "/uploads/mango-types/2026/05/mango-type-5-brindabon.jpg" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Local).AddTicks(4186), "/uploads/mango-types/2026/05/mango-type-6-fazli.jpg" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 279, DateTimeKind.Unspecified).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 279, DateTimeKind.Unspecified).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 23, 26, 37, 279, DateTimeKind.Unspecified).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4033), new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4031) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4042), new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4041) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4048), new DateTime(2026, 5, 10, 23, 26, 37, 504, DateTimeKind.Unspecified).AddTicks(4046) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 435, DateTimeKind.Unspecified).AddTicks(3635), "AQAAAAIAAYagAAAAEKQ3KDpikEgt+NitCzN5IqIw9Q+yBVHu4GcCn/c8ryq95lWYgdBe/I+onDjf2XttHQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 521, DateTimeKind.Unspecified).AddTicks(2272), "AQAAAAIAAYagAAAAECdRF+YMfShNyzX+evZUg1XYlQ8xb2sTxmUZqlqRxQzSWvYfjIr28lKcCa9nv17IQQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8568), "AQAAAAIAAYagAAAAECNWF35dOKUsL4XwAO/1cV4EIIP5Rr0UXuS60+v7ns8Q/NEx/raquwn9KFDsEBlxHg==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9065), "images/mango/gopalbhog.jpg" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9070), "images/mango/himsagor.jpg" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9074), "images/mango/langra.jpg" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9078), "images/mango/amrupali.jpg" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9081), "images/mango/brindabon.jpg" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ImagePath" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Local).AddTicks(9085), "images/mango/fazli.jpg" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 22, 37, 12, 351, DateTimeKind.Unspecified).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 22, 37, 12, 351, DateTimeKind.Unspecified).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 10, 22, 37, 12, 351, DateTimeKind.Unspecified).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8976), new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8951) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8993), new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8992) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(9000), new DateTime(2026, 5, 10, 22, 37, 12, 603, DateTimeKind.Unspecified).AddTicks(8998) });
        }
    }
}
