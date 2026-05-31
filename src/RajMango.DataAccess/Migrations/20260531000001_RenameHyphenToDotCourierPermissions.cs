using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameHyphenToDotCourierPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Rename Permissions.Name / Module / Description for IDs 50-65
            // courier-provider.* → courier.provider.*
            migrationBuilder.Sql(@"
UPDATE Permissions SET Name = 'courier.provider.view',   Module = 'courier.provider', Description = 'courier.provider.view'   WHERE Id = 50;
UPDATE Permissions SET Name = 'courier.provider.create', Module = 'courier.provider', Description = 'courier.provider.create' WHERE Id = 51;
UPDATE Permissions SET Name = 'courier.provider.update', Module = 'courier.provider', Description = 'courier.provider.update' WHERE Id = 52;
UPDATE Permissions SET Name = 'courier.provider.delete', Module = 'courier.provider', Description = 'courier.provider.delete' WHERE Id = 53;
");

            // courier-station.* → courier.station.*
            migrationBuilder.Sql(@"
UPDATE Permissions SET Name = 'courier.station.view',   Module = 'courier.station', Description = 'courier.station.view'   WHERE Id = 54;
UPDATE Permissions SET Name = 'courier.station.create', Module = 'courier.station', Description = 'courier.station.create' WHERE Id = 55;
UPDATE Permissions SET Name = 'courier.station.update', Module = 'courier.station', Description = 'courier.station.update' WHERE Id = 56;
UPDATE Permissions SET Name = 'courier.station.delete', Module = 'courier.station', Description = 'courier.station.delete' WHERE Id = 57;
");

            // courier-area-map.* → courier.area.map.*
            migrationBuilder.Sql(@"
UPDATE Permissions SET Name = 'courier.area.map.view',   Module = 'courier.area.map', Description = 'courier.area.map.view'   WHERE Id = 58;
UPDATE Permissions SET Name = 'courier.area.map.create', Module = 'courier.area.map', Description = 'courier.area.map.create' WHERE Id = 59;
UPDATE Permissions SET Name = 'courier.area.map.update', Module = 'courier.area.map', Description = 'courier.area.map.update' WHERE Id = 60;
UPDATE Permissions SET Name = 'courier.area.map.delete', Module = 'courier.area.map', Description = 'courier.area.map.delete' WHERE Id = 61;
");

            // courier-rate-config.* → courier.rate.config.*
            migrationBuilder.Sql(@"
UPDATE Permissions SET Name = 'courier.rate.config.view',   Module = 'courier.rate.config', Description = 'courier.rate.config.view'   WHERE Id = 62;
UPDATE Permissions SET Name = 'courier.rate.config.create', Module = 'courier.rate.config', Description = 'courier.rate.config.create' WHERE Id = 63;
UPDATE Permissions SET Name = 'courier.rate.config.update', Module = 'courier.rate.config', Description = 'courier.rate.config.update' WHERE Id = 64;
UPDATE Permissions SET Name = 'courier.rate.config.delete', Module = 'courier.rate.config', Description = 'courier.rate.config.delete' WHERE Id = 65;
");

            // Update Roles.PermissionJson for SystemAdmin (Id=1) and Admin (Id=2)
            // Replace hyphen-separated courier keys with dot-separated equivalents
            migrationBuilder.Sql(@"
UPDATE Roles
SET PermissionJson = REPLACE(REPLACE(REPLACE(REPLACE(
    PermissionJson,
    'courier-provider.', 'courier.provider.'),
    'courier-station.', 'courier.station.'),
    'courier-area-map.', 'courier.area.map.'),
    'courier-rate-config.', 'courier.rate.config.')
WHERE Id IN (1, 2);
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert Roles.PermissionJson
            migrationBuilder.Sql(@"
UPDATE Roles
SET PermissionJson = REPLACE(REPLACE(REPLACE(REPLACE(
    PermissionJson,
    'courier.provider.', 'courier-provider.'),
    'courier.station.', 'courier-station.'),
    'courier.area.map.', 'courier-area-map.'),
    'courier.rate.config.', 'courier-rate-config.')
WHERE Id IN (1, 2);
");

            // Revert Permissions.Name for IDs 50-65
            migrationBuilder.Sql(@"
UPDATE Permissions SET Name = 'courier-provider.view',   Module = 'courier-provider', Description = 'courier-provider.view'   WHERE Id = 50;
UPDATE Permissions SET Name = 'courier-provider.create', Module = 'courier-provider', Description = 'courier-provider.create' WHERE Id = 51;
UPDATE Permissions SET Name = 'courier-provider.update', Module = 'courier-provider', Description = 'courier-provider.update' WHERE Id = 52;
UPDATE Permissions SET Name = 'courier-provider.delete', Module = 'courier-provider', Description = 'courier-provider.delete' WHERE Id = 53;
UPDATE Permissions SET Name = 'courier-station.view',   Module = 'courier-station', Description = 'courier-station.view'   WHERE Id = 54;
UPDATE Permissions SET Name = 'courier-station.create', Module = 'courier-station', Description = 'courier-station.create' WHERE Id = 55;
UPDATE Permissions SET Name = 'courier-station.update', Module = 'courier-station', Description = 'courier-station.update' WHERE Id = 56;
UPDATE Permissions SET Name = 'courier-station.delete', Module = 'courier-station', Description = 'courier-station.delete' WHERE Id = 57;
UPDATE Permissions SET Name = 'courier-area-map.view',   Module = 'courier-area-map', Description = 'courier-area-map.view'   WHERE Id = 58;
UPDATE Permissions SET Name = 'courier-area-map.create', Module = 'courier-area-map', Description = 'courier-area-map.create' WHERE Id = 59;
UPDATE Permissions SET Name = 'courier-area-map.update', Module = 'courier-area-map', Description = 'courier-area-map.update' WHERE Id = 60;
UPDATE Permissions SET Name = 'courier-area-map.delete', Module = 'courier-area-map', Description = 'courier-area-map.delete' WHERE Id = 61;
UPDATE Permissions SET Name = 'courier-rate-config.view',   Module = 'courier-rate-config', Description = 'courier-rate-config.view'   WHERE Id = 62;
UPDATE Permissions SET Name = 'courier-rate-config.create', Module = 'courier-rate-config', Description = 'courier-rate-config.create' WHERE Id = 63;
UPDATE Permissions SET Name = 'courier-rate-config.update', Module = 'courier-rate-config', Description = 'courier-rate-config.update' WHERE Id = 64;
UPDATE Permissions SET Name = 'courier-rate-config.delete', Module = 'courier-rate-config', Description = 'courier-rate-config.delete' WHERE Id = 65;
");
        }
    }
}
