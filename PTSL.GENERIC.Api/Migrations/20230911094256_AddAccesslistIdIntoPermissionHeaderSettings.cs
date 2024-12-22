using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAccesslistIdIntoPermissionHeaderSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionHeaderSettings_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "AccesslistId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionHeaderSettings_Accesslist_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "AccesslistId",
                principalSchema: "System",
                principalTable: "Accesslist",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionHeaderSettings_Accesslist_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings");

            migrationBuilder.DropIndex(
                name: "IX_PermissionHeaderSettings_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings");

            migrationBuilder.DropColumn(
                name: "AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings");
        }
    }
}
