using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemovePmsGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_PmsGroup_PmsGroupID",
                schema: "System",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserGroup_GroupID",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PmsGroupID",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PmsGroupID",
                schema: "System",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "GroupID",
                schema: "System",
                table: "User",
                newName: "UserGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_User_GroupID",
                schema: "System",
                table: "User",
                newName: "IX_User_UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserGroup_UserGroupId",
                schema: "System",
                table: "User",
                column: "UserGroupId",
                principalSchema: "System",
                principalTable: "UserGroup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserGroup_UserGroupId",
                schema: "System",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UserGroupId",
                schema: "System",
                table: "User",
                newName: "GroupID");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserGroupId",
                schema: "System",
                table: "User",
                newName: "IX_User_GroupID");

            migrationBuilder.AddColumn<long>(
                name: "PmsGroupID",
                schema: "System",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_User_PmsGroupID",
                schema: "System",
                table: "User",
                column: "PmsGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_PmsGroup_PmsGroupID",
                schema: "System",
                table: "User",
                column: "PmsGroupID",
                principalSchema: "System",
                principalTable: "PmsGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserGroup_GroupID",
                schema: "System",
                table: "User",
                column: "GroupID",
                principalSchema: "System",
                principalTable: "UserGroup",
                principalColumn: "Id");
        }
    }
}
