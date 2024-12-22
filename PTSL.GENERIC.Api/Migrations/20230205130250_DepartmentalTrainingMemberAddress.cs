using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class DepartmentalTrainingMemberAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberAddress",
                schema: "Capacity",
                table: "DepartmentalTrainingMembers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberAddress",
                schema: "Capacity",
                table: "DepartmentalTrainingMembers");
        }
    }
}
