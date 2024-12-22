using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class MeetingFinancialYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FinancialYearId",
                schema: "Meeting",
                table: "Meetings",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_FinancialYearId",
                schema: "Meeting",
                table: "Meetings",
                column: "FinancialYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_FinancialYears_FinancialYearId",
                schema: "Meeting",
                table: "Meetings",
                column: "FinancialYearId",
                principalSchema: "GS",
                principalTable: "FinancialYears",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_FinancialYears_FinancialYearId",
                schema: "Meeting",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_FinancialYearId",
                schema: "Meeting",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                schema: "Meeting",
                table: "Meetings");
        }
    }
}
