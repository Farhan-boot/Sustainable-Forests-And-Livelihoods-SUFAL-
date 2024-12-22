using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class SurveyDocuments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyDocument_Surveys_SurveyId",
                table: "SurveyDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyDocument",
                table: "SurveyDocument");

            migrationBuilder.RenameTable(
                name: "SurveyDocument",
                newName: "SurveyDocuments",
                newSchema: "BEN");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyDocument_SurveyId",
                schema: "BEN",
                table: "SurveyDocuments",
                newName: "IX_SurveyDocuments_SurveyId");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNameURL",
                schema: "BEN",
                table: "SurveyDocuments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentName",
                schema: "BEN",
                table: "SurveyDocuments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyDocuments",
                schema: "BEN",
                table: "SurveyDocuments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyDocuments_Surveys_SurveyId",
                schema: "BEN",
                table: "SurveyDocuments",
                column: "SurveyId",
                principalSchema: "BEN",
                principalTable: "Surveys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyDocuments_Surveys_SurveyId",
                schema: "BEN",
                table: "SurveyDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyDocuments",
                schema: "BEN",
                table: "SurveyDocuments");

            migrationBuilder.RenameTable(
                name: "SurveyDocuments",
                schema: "BEN",
                newName: "SurveyDocument");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyDocuments_SurveyId",
                table: "SurveyDocument",
                newName: "IX_SurveyDocument_SurveyId");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNameURL",
                table: "SurveyDocument",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentName",
                table: "SurveyDocument",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyDocument",
                table: "SurveyDocument",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyDocument_Surveys_SurveyId",
                table: "SurveyDocument",
                column: "SurveyId",
                principalSchema: "BEN",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
