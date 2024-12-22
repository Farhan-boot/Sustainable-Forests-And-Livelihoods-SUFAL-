using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class RepaymentMonthOfInstallment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repayment_RepaymentMonthOfInstallment_RepaymentMonthOfInsta~",
                schema: "AIG",
                table: "Repayment");

            migrationBuilder.DropIndex(
                name: "IX_Repayment_RepaymentMonthOfInstallmentId",
                schema: "AIG",
                table: "Repayment");

            migrationBuilder.DropColumn(
                name: "RepaymentMonthOfInstallmentId",
                schema: "AIG",
                table: "Repayment");

            migrationBuilder.AddColumn<long>(
                name: "RepaymentId",
                table: "RepaymentMonthOfInstallment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentMonthOfInstallment_RepaymentId",
                table: "RepaymentMonthOfInstallment",
                column: "RepaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepaymentMonthOfInstallment_Repayment_RepaymentId",
                table: "RepaymentMonthOfInstallment",
                column: "RepaymentId",
                principalSchema: "AIG",
                principalTable: "Repayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepaymentMonthOfInstallment_Repayment_RepaymentId",
                table: "RepaymentMonthOfInstallment");

            migrationBuilder.DropIndex(
                name: "IX_RepaymentMonthOfInstallment_RepaymentId",
                table: "RepaymentMonthOfInstallment");

            migrationBuilder.DropColumn(
                name: "RepaymentId",
                table: "RepaymentMonthOfInstallment");

            migrationBuilder.AddColumn<long>(
                name: "RepaymentMonthOfInstallmentId",
                schema: "AIG",
                table: "Repayment",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repayment_RepaymentMonthOfInstallmentId",
                schema: "AIG",
                table: "Repayment",
                column: "RepaymentMonthOfInstallmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repayment_RepaymentMonthOfInstallment_RepaymentMonthOfInsta~",
                schema: "AIG",
                table: "Repayment",
                column: "RepaymentMonthOfInstallmentId",
                principalTable: "RepaymentMonthOfInstallment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
