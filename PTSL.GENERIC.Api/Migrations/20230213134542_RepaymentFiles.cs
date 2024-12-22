using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class RepaymentFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repayment_RepaymentFiles_RepaymentFilesId",
                schema: "AIG",
                table: "Repayment");

            migrationBuilder.DropIndex(
                name: "IX_Repayment_RepaymentFilesId",
                schema: "AIG",
                table: "Repayment");

            migrationBuilder.AddColumn<long>(
                name: "RepaymentFilesId",
                table: "RepaymentFiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentFiles_RepaymentId",
                table: "RepaymentFiles",
                column: "RepaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepaymentFiles_Repayment_RepaymentId",
                table: "RepaymentFiles",
                column: "RepaymentId",
                principalSchema: "AIG",
                principalTable: "Repayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepaymentFiles_Repayment_RepaymentId",
                table: "RepaymentFiles");

            migrationBuilder.DropIndex(
                name: "IX_RepaymentFiles_RepaymentId",
                table: "RepaymentFiles");

            migrationBuilder.DropColumn(
                name: "RepaymentFilesId",
                table: "RepaymentFiles");

            migrationBuilder.CreateIndex(
                name: "IX_Repayment_RepaymentFilesId",
                schema: "AIG",
                table: "Repayment",
                column: "RepaymentFilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repayment_RepaymentFiles_RepaymentFilesId",
                schema: "AIG",
                table: "Repayment",
                column: "RepaymentFilesId",
                principalTable: "RepaymentFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
