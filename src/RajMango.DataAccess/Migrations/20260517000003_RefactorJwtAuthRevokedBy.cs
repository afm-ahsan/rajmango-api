using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RefactorJwtAuthRevokedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RevokedBy",
                table: "JwtAuth",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            // Clear int 0 defaults (meaning "not revoked") now that the column allows NULL
            migrationBuilder.Sql("UPDATE JwtAuth SET RevokedBy = NULL WHERE RevokedBy = 0");

            migrationBuilder.CreateIndex(
                name: "IX_JwtAuth_RevokedBy",
                table: "JwtAuth",
                column: "RevokedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_JwtAuth_AppUsers_RevokedBy",
                table: "JwtAuth",
                column: "RevokedBy",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JwtAuth_AppUsers_RevokedBy",
                table: "JwtAuth");

            migrationBuilder.DropIndex(
                name: "IX_JwtAuth_RevokedBy",
                table: "JwtAuth");

            migrationBuilder.AlterColumn<int>(
                name: "RevokedBy",
                table: "JwtAuth",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
