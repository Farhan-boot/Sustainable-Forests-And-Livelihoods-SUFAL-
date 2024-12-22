using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class DepartmentalTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FinancialYearId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_FinancialYearId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "FinancialYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_FinancialYears_FinancialYearId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "FinancialYearId",
                principalSchema: "GS",
                principalTable: "FinancialYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_FinancialYears_FinancialYearId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentalTrainings_FinancialYearId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                schema: "Capacity",
                table: "DepartmentalTrainings");
        }
    }
}
