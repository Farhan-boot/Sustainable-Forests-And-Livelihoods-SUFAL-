using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class RepaymentMonthOfInstallmentsNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RepaymentMonthOfInstallment",
                newName: "RepaymentMonthOfInstallment",
                newSchema: "AIG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RepaymentMonthOfInstallment",
                schema: "AIG",
                newName: "RepaymentMonthOfInstallment");
        }
    }
}
