using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class AIGCalculationChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SecurityChargePercentage",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ServiceChargePercentage",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SecurityChargePercentage",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ServiceChargePercentage",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecurityChargePercentage",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "ServiceChargePercentage",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "SecurityChargePercentage",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "ServiceChargePercentage",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs");
        }
    }
}
