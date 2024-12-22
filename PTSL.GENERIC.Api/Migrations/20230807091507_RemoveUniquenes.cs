using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniquenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRolePermissionMap_UserRoleId_PermissionName",
                schema: "System",
                table: "UserRolePermissionMap");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolePermissionMap_UserRoleId",
                schema: "System",
                table: "UserRolePermissionMap",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRolePermissionMap_UserRoleId",
                schema: "System",
                table: "UserRolePermissionMap");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolePermissionMap_UserRoleId_PermissionName",
                schema: "System",
                table: "UserRolePermissionMap",
                columns: new[] { "UserRoleId", "PermissionName" },
                unique: true);
        }
    }
}
