using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class UserSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SurveyId",
                schema: "System",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_SurveyId",
                schema: "System",
                table: "User",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Surveys_SurveyId",
                schema: "System",
                table: "User",
                column: "SurveyId",
                principalSchema: "BEN",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Surveys_SurveyId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_SurveyId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                schema: "System",
                table: "User");
        }
    }
}
