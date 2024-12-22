using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CipSurveyOnetoOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CipId",
                schema: "BEN",
                table: "Surveys",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_CipId",
                schema: "BEN",
                table: "Surveys",
                column: "CipId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Cips_CipId",
                schema: "BEN",
                table: "Surveys",
                column: "CipId",
                principalSchema: "BEN",
                principalTable: "Cips",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Cips_CipId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_CipId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "CipId",
                schema: "BEN",
                table: "Surveys");
        }
    }
}
