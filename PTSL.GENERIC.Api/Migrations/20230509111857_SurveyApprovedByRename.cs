using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class SurveyApprovedByRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_User_BeneficiaryApprovedById",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.RenameColumn(
                name: "BeneficiaryApprovedById",
                schema: "BEN",
                table: "Surveys",
                newName: "BeneficiaryApproveStatusById");

            migrationBuilder.RenameIndex(
                name: "IX_Surveys_BeneficiaryApprovedById",
                schema: "BEN",
                table: "Surveys",
                newName: "IX_Surveys_BeneficiaryApproveStatusById");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_User_BeneficiaryApproveStatusById",
                schema: "BEN",
                table: "Surveys",
                column: "BeneficiaryApproveStatusById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_User_BeneficiaryApproveStatusById",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.RenameColumn(
                name: "BeneficiaryApproveStatusById",
                schema: "BEN",
                table: "Surveys",
                newName: "BeneficiaryApprovedById");

            migrationBuilder.RenameIndex(
                name: "IX_Surveys_BeneficiaryApproveStatusById",
                schema: "BEN",
                table: "Surveys",
                newName: "IX_Surveys_BeneficiaryApprovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_User_BeneficiaryApprovedById",
                schema: "BEN",
                table: "Surveys",
                column: "BeneficiaryApprovedById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
