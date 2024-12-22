using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserRoles_UserRolesId",
                schema: "System",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UserRolesId",
                schema: "System",
                table: "User",
                newName: "UserRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserRolesId",
                schema: "System",
                table: "User",
                newName: "IX_User_UserRoleId");

            migrationBuilder.AddColumn<string>(
                name: "AccessList",
                schema: "System",
                table: "UserRoles",
                type: "varchar(900)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AccessListType",
                schema: "System",
                table: "Accesslist",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserRoles_UserRoleId",
                schema: "System",
                table: "User",
                column: "UserRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserRoles_UserRoleId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccessList",
                schema: "System",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "AccessListType",
                schema: "System",
                table: "Accesslist");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                schema: "System",
                table: "User",
                newName: "UserRolesId");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserRoleId",
                schema: "System",
                table: "User",
                newName: "IX_User_UserRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserRoles_UserRolesId",
                schema: "System",
                table: "User",
                column: "UserRolesId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");
        }
    }
}
