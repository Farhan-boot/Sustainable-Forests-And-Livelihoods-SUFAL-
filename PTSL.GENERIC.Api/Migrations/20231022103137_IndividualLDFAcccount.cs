using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class IndividualLDFAcccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_AccountId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualLDFInfoForms_Accounts_AccountId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "AccountId",
                principalSchema: "AccountManagement",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualLDFInfoForms_Accounts_AccountId",
                schema: "AIG",
                table: "IndividualLDFInfoForms");

            migrationBuilder.DropIndex(
                name: "IX_IndividualLDFInfoForms_AccountId",
                schema: "AIG",
                table: "IndividualLDFInfoForms");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "AIG",
                table: "IndividualLDFInfoForms");
        }
    }
}
