using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class SecondLDFStartRepaymentLDF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StartRepaymentLDFId",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartRepaymentLDFId",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");
        }
    }
}
