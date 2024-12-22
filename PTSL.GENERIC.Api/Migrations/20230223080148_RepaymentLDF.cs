using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class RepaymentLDF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepaymentAmount",
                schema: "AIG",
                table: "RepaymentLDFs");

            migrationBuilder.AddColumn<long>(
                name: "AIGBasicInformationId",
                schema: "AIG",
                table: "RepaymentLDFs",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "FirstSixtyPercentRepaymentAmount",
                schema: "AIG",
                table: "RepaymentLDFs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SecondFortyPercentRepaymentAmount",
                schema: "AIG",
                table: "RepaymentLDFs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentLDFs_AIGBasicInformationId",
                schema: "AIG",
                table: "RepaymentLDFs",
                column: "AIGBasicInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepaymentLDFs_AIGBasicInformations_AIGBasicInformationId",
                schema: "AIG",
                table: "RepaymentLDFs",
                column: "AIGBasicInformationId",
                principalSchema: "AIG",
                principalTable: "AIGBasicInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepaymentLDFs_AIGBasicInformations_AIGBasicInformationId",
                schema: "AIG",
                table: "RepaymentLDFs");

            migrationBuilder.DropIndex(
                name: "IX_RepaymentLDFs_AIGBasicInformationId",
                schema: "AIG",
                table: "RepaymentLDFs");

            migrationBuilder.DropColumn(
                name: "AIGBasicInformationId",
                schema: "AIG",
                table: "RepaymentLDFs");

            migrationBuilder.DropColumn(
                name: "FirstSixtyPercentRepaymentAmount",
                schema: "AIG",
                table: "RepaymentLDFs");

            migrationBuilder.DropColumn(
                name: "SecondFortyPercentRepaymentAmount",
                schema: "AIG",
                table: "RepaymentLDFs");

            migrationBuilder.AddColumn<double>(
                name: "RepaymentAmount",
                schema: "AIG",
                table: "RepaymentLDFs",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
