using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class RepaymentLock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                schema: "AIG",
                table: "RepaymentLDFs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                schema: "AIG",
                table: "RepaymentLDFs");
        }
    }
}
