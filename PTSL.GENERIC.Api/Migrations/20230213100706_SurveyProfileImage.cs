using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class SurveyProfileImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryDocumentURL",
                schema: "BEN",
                table: "Surveys",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryProfileURL",
                schema: "BEN",
                table: "Surveys",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiaryDocumentURL",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "BeneficiaryProfileURL",
                schema: "BEN",
                table: "Surveys");
        }
    }
}
