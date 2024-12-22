using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class SurveyApprovedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BeneficiaryApprovedById",
                schema: "BEN",
                table: "Surveys",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_BeneficiaryApprovedById",
                schema: "BEN",
                table: "Surveys",
                column: "BeneficiaryApprovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_User_BeneficiaryApprovedById",
                schema: "BEN",
                table: "Surveys",
                column: "BeneficiaryApprovedById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_User_BeneficiaryApprovedById",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_BeneficiaryApprovedById",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "BeneficiaryApprovedById",
                schema: "BEN",
                table: "Surveys");
        }
    }
}
