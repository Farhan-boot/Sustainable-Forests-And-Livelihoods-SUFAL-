using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class configManyToManyNurseryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcernedOfficials_NewRaisedPlantations_NewRaisedPlantation~",
                schema: "SocialForestry",
                table: "ConcernedOfficials");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailss_NewRaisedPlantations_NewRaisedPlantation~",
                schema: "SocialForestry",
                table: "InspectionDetailss");

            migrationBuilder.DropIndex(
                name: "IX_ConcernedOfficials_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "ConcernedOfficials");

            migrationBuilder.DropColumn(
                name: "NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "ConcernedOfficials");

            migrationBuilder.AddColumn<string>(
                name: "NursaryImageFilePath",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NursaryJournalFilePath",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NursaryLayoutFilePath",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "InspectionDetailsId",
                table: "InspectionDetailsMap",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDetailsMap_InspectionDetailsId",
                table: "InspectionDetailsMap",
                column: "InspectionDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap",
                column: "InspectionDetailsId",
                principalSchema: "SocialForestry",
                principalTable: "InspectionDetailss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailss_NewRaisedPlantations_NewRaisedPlantation~",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                column: "NewRaisedPlantationId",
                principalSchema: "SocialForestry",
                principalTable: "NewRaisedPlantations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailss_NewRaisedPlantations_NewRaisedPlantation~",
                schema: "SocialForestry",
                table: "InspectionDetailss");

            migrationBuilder.DropIndex(
                name: "IX_InspectionDetailsMap_InspectionDetailsId",
                table: "InspectionDetailsMap");

            migrationBuilder.DropColumn(
                name: "NursaryImageFilePath",
                schema: "SocialForestry",
                table: "NurseryInformations");

            migrationBuilder.DropColumn(
                name: "NursaryJournalFilePath",
                schema: "SocialForestry",
                table: "NurseryInformations");

            migrationBuilder.DropColumn(
                name: "NursaryLayoutFilePath",
                schema: "SocialForestry",
                table: "NurseryInformations");

            migrationBuilder.DropColumn(
                name: "InspectionDetailsId",
                table: "InspectionDetailsMap");

            migrationBuilder.AlterColumn<long>(
                name: "NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "ConcernedOfficials",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ConcernedOfficials_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "ConcernedOfficials",
                column: "NewRaisedPlantationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcernedOfficials_NewRaisedPlantations_NewRaisedPlantation~",
                schema: "SocialForestry",
                table: "ConcernedOfficials",
                column: "NewRaisedPlantationId",
                principalSchema: "SocialForestry",
                principalTable: "NewRaisedPlantations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailss_NewRaisedPlantations_NewRaisedPlantation~",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                column: "NewRaisedPlantationId",
                principalSchema: "SocialForestry",
                principalTable: "NewRaisedPlantations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
