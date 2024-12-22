using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccountDepositRelationFKFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposits_FinancialYears_AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposits_SourceOfFunds_AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposits_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposits_SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "SourceOfFundId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposits_FinancialYears_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "FinancialYearId",
                principalSchema: "GS",
                principalTable: "FinancialYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposits_SourceOfFunds_SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "SourceOfFundId",
                principalSchema: "AccountManagement",
                principalTable: "SourceOfFunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposits_FinancialYears_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposits_SourceOfFunds_SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposits_FinancialYears_AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "AccountId",
                principalSchema: "GS",
                principalTable: "FinancialYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposits_SourceOfFunds_AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "AccountId",
                principalSchema: "AccountManagement",
                principalTable: "SourceOfFunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
