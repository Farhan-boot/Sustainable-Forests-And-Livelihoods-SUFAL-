using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class FirstLDFGraceMonth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GraceMonth",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GraceMonth",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs");
        }
    }
}
