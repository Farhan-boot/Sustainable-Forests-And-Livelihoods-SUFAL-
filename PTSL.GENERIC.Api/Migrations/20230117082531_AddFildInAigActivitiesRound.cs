using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class AddFildInAigActivitiesRound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RepaymentInterestPercentage",
                schema: "AIG",
                table: "AigActivitiesRound",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepaymentInterestPercentage",
                schema: "AIG",
                table: "AigActivitiesRound");
        }
    }
}
