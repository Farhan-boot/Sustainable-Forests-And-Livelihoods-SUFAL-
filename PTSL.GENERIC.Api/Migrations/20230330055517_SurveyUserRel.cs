using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class SurveyUserRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_SurveyId",
                schema: "System",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_SurveyId",
                schema: "System",
                table: "User",
                column: "SurveyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_SurveyId",
                schema: "System",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_SurveyId",
                schema: "System",
                table: "User",
                column: "SurveyId");
        }
    }
}
