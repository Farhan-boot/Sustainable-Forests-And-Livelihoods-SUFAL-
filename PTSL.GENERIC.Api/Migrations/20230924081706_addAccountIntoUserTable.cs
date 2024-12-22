using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class addAccountIntoUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountsId",
                schema: "System",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountsId",
                schema: "System",
                table: "User",
                column: "AccountsId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Accounts_AccountsId",
                schema: "System",
                table: "User",
                column: "AccountsId",
                principalSchema: "AccountManagement",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Accounts_AccountsId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AccountsId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccountsId",
                schema: "System",
                table: "User");
        }
    }
}
