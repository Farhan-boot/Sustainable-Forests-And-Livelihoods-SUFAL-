using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class FirstLdfAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepaymentMonthEnumId",
                schema: "AIG",
                table: "RepaymentLDFs");

            migrationBuilder.AddColumn<double>(
                name: "LDFAmount",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LDFAmount",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs");

            migrationBuilder.AddColumn<int>(
                name: "RepaymentMonthEnumId",
                schema: "AIG",
                table: "RepaymentLDFs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
