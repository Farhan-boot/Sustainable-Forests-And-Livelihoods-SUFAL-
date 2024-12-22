using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class LDFCountInAIG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "LDFCount",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "IndividualLDFInfoFormId",
                schema: "AIG",
                table: "AIGBasicInformations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_IndividualLDFInfoFormId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "IndividualLDFInfoFormId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AIGBasicInformations_IndividualLDFInfoForms_IndividualLDFIn~",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "IndividualLDFInfoFormId",
                principalSchema: "AIG",
                principalTable: "IndividualLDFInfoForms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIGBasicInformations_IndividualLDFInfoForms_IndividualLDFIn~",
                schema: "AIG",
                table: "AIGBasicInformations");

            migrationBuilder.DropIndex(
                name: "IX_AIGBasicInformations_IndividualLDFInfoFormId",
                schema: "AIG",
                table: "AIGBasicInformations");

            migrationBuilder.DropColumn(
                name: "LDFCount",
                schema: "AIG",
                table: "IndividualLDFInfoForms");

            migrationBuilder.DropColumn(
                name: "IndividualLDFInfoFormId",
                schema: "AIG",
                table: "AIGBasicInformations");

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
    }
}
