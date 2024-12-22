using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class FinancialYearInNewraised : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailss_NewRaisedPlantations_NewRaisedPlantation~",
                schema: "SocialForestry",
                table: "InspectionDetailss");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_FinancialYears_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_InspectionDetailss_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "InspectionDetailss");

            migrationBuilder.DropColumn(
                name: "CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "InspectionDetailss");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "CreatedFinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDetailss_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                column: "NewRaisedPlantationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailss_NewRaisedPlantations_NewRaisedPlantation~",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                column: "NewRaisedPlantationId",
                principalSchema: "SocialForestry",
                principalTable: "NewRaisedPlantations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_FinancialYears_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "CreatedFinancialYearId",
                principalSchema: "GS",
                principalTable: "FinancialYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
