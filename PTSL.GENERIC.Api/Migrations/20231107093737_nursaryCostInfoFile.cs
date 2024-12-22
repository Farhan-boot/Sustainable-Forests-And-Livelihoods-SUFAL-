using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class nursaryCostInfoFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseryCostInformationFile_NurseryCostInformations_NurseryC~",
                table: "NurseryCostInformationFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NurseryCostInformationFile",
                table: "NurseryCostInformationFile");

            migrationBuilder.RenameTable(
                name: "NurseryCostInformationFile",
                newName: "NurseryCostInformationFiles",
                newSchema: "SocialForestry");

            migrationBuilder.RenameIndex(
                name: "IX_NurseryCostInformationFile_NurseryCostInformationId",
                schema: "SocialForestry",
                table: "NurseryCostInformationFiles",
                newName: "IX_NurseryCostInformationFiles_NurseryCostInformationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NurseryCostInformationFiles",
                schema: "SocialForestry",
                table: "NurseryCostInformationFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryCostInformationFiles_NurseryCostInformations_Nursery~",
                schema: "SocialForestry",
                table: "NurseryCostInformationFiles",
                column: "NurseryCostInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryCostInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseryCostInformationFiles_NurseryCostInformations_Nursery~",
                schema: "SocialForestry",
                table: "NurseryCostInformationFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NurseryCostInformationFiles",
                schema: "SocialForestry",
                table: "NurseryCostInformationFiles");

            migrationBuilder.RenameTable(
                name: "NurseryCostInformationFiles",
                schema: "SocialForestry",
                newName: "NurseryCostInformationFile");

            migrationBuilder.RenameIndex(
                name: "IX_NurseryCostInformationFiles_NurseryCostInformationId",
                table: "NurseryCostInformationFile",
                newName: "IX_NurseryCostInformationFile_NurseryCostInformationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NurseryCostInformationFile",
                table: "NurseryCostInformationFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryCostInformationFile_NurseryCostInformations_NurseryC~",
                table: "NurseryCostInformationFile",
                column: "NurseryCostInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryCostInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
