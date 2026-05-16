using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCourierSeedDataAndGranularPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 29, 10, 593, DateTimeKind.Unspecified).AddTicks(3185), "AQAAAAIAAYagAAAAECfEaO6E0z/QEcvr4YhevkT1UEONIIkk023bjYVnSmu0xtjB1EjJdlWv50vvfQHX9A==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 29, 10, 681, DateTimeKind.Unspecified).AddTicks(5058), "AQAAAAIAAYagAAAAEHLjfF7tu1u0gj5kXgZa16VT6Tw3FNky7ui9eplAcTunJTZCya+sug4NJHcY+hyH7g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3080), "AQAAAAIAAYagAAAAEBu0Bsxggw3qfHXOAEi4Xk+wNe2pCE7n4bzE6tFN21zUBbCKtfXd0WMKY8j5Dnw2zw==" });

            // Idempotent: skip rows that already exist (handles re-runs on existing DBs)
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT CourierProviders ON;
INSERT INTO CourierProviders (Id, Name, SupportPhone, Sequence, IsActive, IsDeleted, CreatedAt, CreatedBy, DeletedBy, UpdatedBy)
SELECT v.Id, v.Name, v.SupportPhone, v.Sequence, v.IsActive, v.IsDeleted, v.CreatedAt, v.CreatedBy, v.DeletedBy, v.UpdatedBy
FROM (VALUES
  (1,'Ahmed Parcel Service','01710000001',1,1,0,'2026-01-01',1,0,0),
  (2,'Janani Courier Service','01710000002',2,1,0,'2026-01-01',1,0,0),
  (3,'Karatoa Courier Service','01710000003',3,1,0,'2026-01-01',1,0,0),
  (4,'SR Parcel Services Ltd.','01710000004',4,1,0,'2026-01-01',1,0,0),
  (5,'Shodagor Express Limited','01710000005',5,1,0,'2026-01-01',1,0,0),
  (6,'SB Courier Service','01710000006',6,1,0,'2026-01-01',1,0,0),
  (7,'SA Paribahan','01710000007',7,1,0,'2026-01-01',1,0,0),
  (8,'Sundarban Courier','01710000008',8,1,0,'2026-01-01',1,0,0)
) AS v(Id,Name,SupportPhone,Sequence,IsActive,IsDeleted,CreatedAt,CreatedBy,DeletedBy,UpdatedBy)
WHERE NOT EXISTS (SELECT 1 FROM CourierProviders WHERE Id = v.Id);
SET IDENTITY_INSERT CourierProviders OFF;
");

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Local).AddTicks(7080));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Local).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Local).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3835));

            migrationBuilder.Sql(@"
SET IDENTITY_INSERT Permissions ON;
INSERT INTO Permissions (Id, Name, Module, Description, IsActive, IsDeleted, CreatedAt, CreatedBy, DeletedBy, UpdatedBy)
SELECT v.Id, v.Name, v.Module, v.Description, 1, 0, '2026-01-01', 1, 0, 0
FROM (VALUES
  (50,'courier-provider.view','courier-provider','courier-provider.view'),
  (51,'courier-provider.create','courier-provider','courier-provider.create'),
  (52,'courier-provider.update','courier-provider','courier-provider.update'),
  (53,'courier-provider.delete','courier-provider','courier-provider.delete'),
  (54,'courier-station.view','courier-station','courier-station.view'),
  (55,'courier-station.create','courier-station','courier-station.create'),
  (56,'courier-station.update','courier-station','courier-station.update'),
  (57,'courier-station.delete','courier-station','courier-station.delete'),
  (58,'courier-area-map.view','courier-area-map','courier-area-map.view'),
  (59,'courier-area-map.create','courier-area-map','courier-area-map.create'),
  (60,'courier-area-map.update','courier-area-map','courier-area-map.update'),
  (61,'courier-area-map.delete','courier-area-map','courier-area-map.delete')
) AS v(Id,Name,Module,Description)
WHERE NOT EXISTS (SELECT 1 FROM Permissions WHERE Id = v.Id);
SET IDENTITY_INSERT Permissions OFF;
");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 29, 10, 511, DateTimeKind.Unspecified).AddTicks(7494), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier-provider.view\",\"courier-provider.create\",\"courier-provider.update\",\"courier-provider.delete\",\"courier-station.view\",\"courier-station.create\",\"courier-station.update\",\"courier-station.delete\",\"courier-area-map.view\",\"courier-area-map.create\",\"courier-area-map.update\",\"courier-area-map.delete\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 29, 10, 511, DateTimeKind.Unspecified).AddTicks(7752), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier-provider.view\",\"courier-provider.create\",\"courier-provider.update\",\"courier-provider.delete\",\"courier-station.view\",\"courier-station.create\",\"courier-station.update\",\"courier-station.delete\",\"courier-area-map.view\",\"courier-area-map.create\",\"courier-area-map.update\",\"courier-area-map.delete\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 10, 29, 10, 511, DateTimeKind.Unspecified).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3767), new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3764) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3783), new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3793), new DateTime(2026, 5, 16, 10, 29, 10, 773, DateTimeKind.Unspecified).AddTicks(3790) });

            migrationBuilder.Sql(@"
SET IDENTITY_INSERT CourierStations ON;
INSERT INTO CourierStations (Id, CourierProviderId, Name, AddressLine, City, Area, SupportPhone1, IsActive, IsDeleted, CreatedAt, CreatedBy, DeletedBy, UpdatedBy)
SELECT v.Id, v.ProviderId, v.Name, v.AddressLine, v.City, v.Area, v.Phone, v.IsActive, v.IsDeleted, v.CreatedAt, v.CreatedBy, v.DeletedBy, v.UpdatedBy
FROM (VALUES
  (1,1,'Ahmed - Dhanmondi Branch','Satmasjid Road','Dhaka','Dhanmondi','01720000001',1,0,'2026-01-01',1,0,0),
  (2,2,'Janani - Mirpur 10','Pallabi, Mirpur 10','Dhaka','Mirpur','01720000002',1,0,'2026-01-01',1,0,0),
  (3,3,'Karatoa - Banani','Banani Block C','Dhaka','Banani','01720000003',1,0,'2026-01-01',1,0,0),
  (4,4,'SR - Gulshan 2','Gulshan Circle 2','Dhaka','Gulshan 2','01720000004',1,0,'2026-01-01',1,0,0),
  (5,5,'Shodagor - Kawran Bazar','Near T&T Market','Dhaka','Kawran Bazar','01720000005',1,0,'2026-01-01',1,0,0),
  (6,6,'SB - Mohakhali','Opposite Bus Terminal','Dhaka','Mohakhali','01720000006',1,0,'2026-01-01',1,0,0),
  (7,7,'SA - Gulistan','Gulistan Underpass','Dhaka','Gulistan','01720000007',1,0,'2026-01-01',1,0,0),
  (8,8,'Sundarban - New Market','Gate 1','Dhaka','New Market','01720000008',1,0,'2026-01-01',1,0,0),
  (9,7,'SA - Malibagh','Malibagh Crossing','Dhaka','Malibagh','01720000009',1,0,'2026-01-01',1,0,0),
  (10,8,'Sundarban - Uttara','Sector 7','Dhaka','Uttara','01720000010',1,0,'2026-01-01',1,0,0),
  (11,6,'SB - Gazipur','Chowrasta','Gazipur','Gazipur','01720000011',1,0,'2026-01-01',1,0,0),
  (12,5,'Shodagor - Gulshan 1','Gulshan 1 Circle','Dhaka','Gulshan 1','01720000012',1,0,'2026-01-01',1,0,0)
) AS v(Id,ProviderId,Name,AddressLine,City,Area,Phone,IsActive,IsDeleted,CreatedAt,CreatedBy,DeletedBy,UpdatedBy)
WHERE NOT EXISTS (SELECT 1 FROM CourierStations WHERE Id = v.Id);
SET IDENTITY_INSERT CourierStations OFF;
");

            migrationBuilder.Sql(@"
INSERT INTO RolePermissions (PermissionId, RoleId)
SELECT v.PermissionId, v.RoleId
FROM (VALUES
  (50,1),(51,1),(52,1),(53,1),(54,1),(55,1),(56,1),(57,1),(58,1),(59,1),(60,1),(61,1),
  (50,2),(51,2),(52,2),(53,2),(54,2),(55,2),(56,2),(57,2),(58,2),(59,2),(60,2),(61,2)
) AS v(PermissionId, RoleId)
WHERE NOT EXISTS (
  SELECT 1 FROM RolePermissions rp WHERE rp.PermissionId = v.PermissionId AND rp.RoleId = v.RoleId
);
");

            migrationBuilder.Sql(@"
SET IDENTITY_INSERT CourierAreaMaps ON;
INSERT INTO CourierAreaMaps (Id, CourierStationId, Area, CreatedAt, CreatedBy, UpdatedBy)
SELECT v.Id, v.StationId, v.Area, v.CreatedAt, v.CreatedBy, v.UpdatedBy
FROM (VALUES
  (1,1,'Dhanmondi','2026-01-01',1,0),
  (2,2,'Mirpur','2026-01-01',1,0),
  (3,3,'Banani','2026-01-01',1,0),
  (4,4,'Gulshan 2','2026-01-01',1,0),
  (5,5,'Kawran Bazar','2026-01-01',1,0),
  (6,6,'Mohakhali','2026-01-01',1,0),
  (7,7,'Gulistan','2026-01-01',1,0),
  (8,8,'New Market','2026-01-01',1,0),
  (9,9,'Malibagh','2026-01-01',1,0),
  (10,10,'Uttara','2026-01-01',1,0),
  (11,11,'Gazipur','2026-01-01',1,0),
  (12,12,'Gulshan 1','2026-01-01',1,0)
) AS v(Id,StationId,Area,CreatedAt,CreatedBy,UpdatedBy)
WHERE NOT EXISTS (SELECT 1 FROM CourierAreaMaps WHERE Id = v.Id);
SET IDENTITY_INSERT CourierAreaMaps OFF;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CourierAreaMaps",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 50, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 51, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 52, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 53, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 54, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 55, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 56, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 57, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 58, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 59, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 60, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 61, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 50, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 51, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 52, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 53, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 54, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 55, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 56, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 57, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 58, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 59, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 60, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 61, 2 });

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CourierStations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CourierProviders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 782, DateTimeKind.Unspecified).AddTicks(6962), "AQAAAAIAAYagAAAAEDFweH4cfqgkC8an/tycmQN5HYIQH402b0fZStaryS/bpNgOH2Un0X24Esj/iMKBrw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 861, DateTimeKind.Unspecified).AddTicks(815), "AQAAAAIAAYagAAAAEJkhaCoeRl9VBGsB61keEWli3NuxGtwTGghcQhF/B3LcUbwgI0sWEafgkI3fD+YxTA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2122), "AQAAAAIAAYagAAAAELRRRNm+FmocOgPPTHXOv15dT23Ti1qiav7uI6E/m+0GyJLDzeeXuJ7po8PpA98IkA==" });

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6495));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "MangoTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 704, DateTimeKind.Unspecified).AddTicks(7958), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PermissionJson" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 704, DateTimeKind.Unspecified).AddTicks(7992), "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\"]" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 13, 22, 34, 6, 704, DateTimeKind.Unspecified).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2977), new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2974) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2992), new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2989) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedAt", "CreatedAt" },
                values: new object[] { new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(3001), new DateTime(2026, 5, 13, 22, 34, 6, 965, DateTimeKind.Unspecified).AddTicks(2998) });
        }
    }
}
