using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreatePermissionSettingsForRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRowSettings_PermissionHeaderSettings_PermissionHe~",
                table: "PermissionRowSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRowSettings_UserRoles_UserRoleId",
                table: "PermissionRowSettings");

            migrationBuilder.RenameTable(
                name: "PermissionRowSettings",
                newName: "PermissionRowSettings",
                newSchema: "PermissionSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRowSettings_PermissionHeaderSettings_PermissionHe~",
                schema: "PermissionSettings",
                table: "PermissionRowSettings",
                column: "PermissionHeaderSettingsId",
                principalSchema: "PermissionSettings",
                principalTable: "PermissionHeaderSettings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRowSettings_UserRoles_UserRoleId",
                schema: "PermissionSettings",
                table: "PermissionRowSettings",
                column: "UserRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRowSettings_PermissionHeaderSettings_PermissionHe~",
                schema: "PermissionSettings",
                table: "PermissionRowSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRowSettings_UserRoles_UserRoleId",
                schema: "PermissionSettings",
                table: "PermissionRowSettings");

            migrationBuilder.RenameTable(
                name: "PermissionRowSettings",
                schema: "PermissionSettings",
                newName: "PermissionRowSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRowSettings_PermissionHeaderSettings_PermissionHe~",
                table: "PermissionRowSettings",
                column: "PermissionHeaderSettingsId",
                principalSchema: "PermissionSettings",
                principalTable: "PermissionHeaderSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRowSettings_UserRoles_UserRoleId",
                table: "PermissionRowSettings",
                column: "UserRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
