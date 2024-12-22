using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccountInAIG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                schema: "AIG",
                table: "AIGBasicInformations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_AccountId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AIGBasicInformations_Accounts_AccountId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "AccountId",
                principalSchema: "AccountManagement",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIGBasicInformations_Accounts_AccountId",
                schema: "AIG",
                table: "AIGBasicInformations");

            migrationBuilder.DropIndex(
                name: "IX_AIGBasicInformations_AccountId",
                schema: "AIG",
                table: "AIGBasicInformations");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "AIG",
                table: "AIGBasicInformations");
        }
    }
}
