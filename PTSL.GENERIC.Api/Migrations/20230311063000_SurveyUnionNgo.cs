using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class SurveyUnionNgo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NgoId",
                schema: "BEN",
                table: "Surveys",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PermanentUnionNewId",
                schema: "BEN",
                table: "Surveys",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PresentUnionNewId",
                schema: "BEN",
                table: "Surveys",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_NgoId",
                schema: "BEN",
                table: "Surveys",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PermanentUnionNewId",
                schema: "BEN",
                table: "Surveys",
                column: "PermanentUnionNewId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PresentUnionNewId",
                schema: "BEN",
                table: "Surveys",
                column: "PresentUnionNewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Ngos_NgoId",
                schema: "BEN",
                table: "Surveys",
                column: "NgoId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Union_PermanentUnionNewId",
                schema: "BEN",
                table: "Surveys",
                column: "PermanentUnionNewId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Union_PresentUnionNewId",
                schema: "BEN",
                table: "Surveys",
                column: "PresentUnionNewId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Ngos_NgoId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Union_PermanentUnionNewId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Union_PresentUnionNewId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_NgoId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_PermanentUnionNewId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_PresentUnionNewId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "NgoId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "PermanentUnionNewId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "PresentUnionNewId",
                schema: "BEN",
                table: "Surveys");
        }
    }
}
