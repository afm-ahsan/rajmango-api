using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NormalizePhoneNumbers_AddUniqueIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Assign distinct interim phones to seed users who all share '01700000000',
            //         so they can each be normalized to a unique number.
            migrationBuilder.Sql("""
                UPDATE AppUsers SET PhoneNumber = '01700000001' WHERE Id = 1 AND PhoneNumber = '01700000000';
                UPDATE AppUsers SET PhoneNumber = '01700000002' WHERE Id = 2 AND PhoneNumber = '01700000000';
                UPDATE AppUsers SET PhoneNumber = '01700000003' WHERE Id = 3 AND PhoneNumber = '01700000000';
                """);

            // Step 2: Normalize 01XXXXXXXXX → +8801XXXXXXXXX for AppUsers
            migrationBuilder.Sql(
                "UPDATE AppUsers SET PhoneNumber = '+88' + PhoneNumber WHERE PhoneNumber LIKE '01[3-9]%' AND LEN(PhoneNumber) = 11;");

            // Step 3: Normalize 8801XXXXXXXXX → +8801XXXXXXXXX for AppUsers
            migrationBuilder.Sql(
                "UPDATE AppUsers SET PhoneNumber = '+' + PhoneNumber WHERE PhoneNumber LIKE '8801%' AND LEN(PhoneNumber) = 13;");

            // Step 4: Normalize Customers.PhoneNumber1 (mirrored from AppUser on registration)
            migrationBuilder.Sql(
                "UPDATE Customers SET PhoneNumber1 = '+88' + PhoneNumber1 WHERE PhoneNumber1 LIKE '01[3-9]%' AND LEN(PhoneNumber1) = 11;");
            migrationBuilder.Sql(
                "UPDATE Customers SET PhoneNumber1 = '+' + PhoneNumber1 WHERE PhoneNumber1 LIKE '8801%' AND LEN(PhoneNumber1) = 13;");

            // Step 5: Sync HasData seed phone values so EF model tracking is consistent
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PhoneNumber" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 48, 869, DateTimeKind.Unspecified).AddTicks(3830), "AQAAAAIAAYagAAAAEDE/v9e0mVuBEu6lrnlF/4j9+zEAOk/hYcYGWjbtkXcT3g+m/IXMuAehq/e7fg22EQ==", "+8801700000001" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PhoneNumber" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 49, 40, DateTimeKind.Unspecified).AddTicks(5328), "AQAAAAIAAYagAAAAEB6l+JawdWyWIZi8NF2uC+Amnzxl76IrPFjNoP+XYX/UEgvngFA9xQ5EritkrN91tw==", "+8801700000002" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "PhoneNumber" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(2766), "AQAAAAIAAYagAAAAEGX8doiEh5x2yHLQxzr7uK867tcQNM+m1lYJz6fmjiV1CufysvzQUCMP+DltPde92A==", "+8801700000003" });

            // Step 6: Widen PhoneNumber column so deduplication suffix fits.
            //         Normalized BD numbers are 14 chars; nvarchar(30) gives comfortable margin.
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AppUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            // Step 7: Deduplicate any remaining phone conflicts by appending _DUP_{Id} to
            //         non-canonical rows (keeps the earliest-registered account's phone intact).
            //         Admin should review and correct flagged rows after migration.
            migrationBuilder.Sql("""
                WITH RankedByPhone AS (
                    SELECT Id,
                           ROW_NUMBER() OVER (PARTITION BY PhoneNumber ORDER BY Id ASC) AS rn
                    FROM AppUsers
                )
                UPDATE AppUsers
                SET PhoneNumber = AppUsers.PhoneNumber + '_DUP_' + CAST(AppUsers.Id AS NVARCHAR(10))
                FROM AppUsers
                INNER JOIN RankedByPhone r ON AppUsers.Id = r.Id
                WHERE r.rn > 1;
                """);

            // Step 8: Deduplicate emails (case-insensitive) the same way
            migrationBuilder.Sql("""
                WITH RankedByEmail AS (
                    SELECT Id,
                           ROW_NUMBER() OVER (PARTITION BY LOWER(Email) ORDER BY Id ASC) AS rn
                    FROM AppUsers
                )
                UPDATE AppUsers
                SET Email = AppUsers.Email + '_DUP_' + CAST(AppUsers.Id AS NVARCHAR(10))
                FROM AppUsers
                INNER JOIN RankedByEmail r ON AppUsers.Id = r.Id
                WHERE r.rn > 1;
                """);

            // Step 9: Add unique indexes on AppUsers
            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Email",
                table: "AppUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_PhoneNumber",
                table: "AppUsers",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUsers_PhoneNumber",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_Email",
                table: "AppUsers");

            // Restore seed user phone values (de-normalize is not fully reversible for real user data)
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PhoneNumber" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 48, 869, DateTimeKind.Unspecified).AddTicks(3830), "AQAAAAIAAYagAAAAEDE/v9e0mVuBEu6lrnlF/4j9+zEAOk/hYcYGWjbtkXcT3g+m/IXMuAehq/e7fg22EQ==", "01700000000" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PhoneNumber" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 49, 40, DateTimeKind.Unspecified).AddTicks(5328), "AQAAAAIAAYagAAAAEB6l+JawdWyWIZi8NF2uC+Amnzxl76IrPFjNoP+XYX/UEgvngFA9xQ5EritkrN91tw==", "01700000000" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "PhoneNumber" },
                values: new object[] { new DateTime(2026, 5, 18, 19, 52, 49, 211, DateTimeKind.Unspecified).AddTicks(2766), "AQAAAAIAAYagAAAAEGX8doiEh5x2yHLQxzr7uK867tcQNM+m1lYJz6fmjiV1CufysvzQUCMP+DltPde92A==", "01700000000" });
        }
    }
}
