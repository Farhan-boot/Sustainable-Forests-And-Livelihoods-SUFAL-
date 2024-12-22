using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class DepartmentalTrainingTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalFemale",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalMale",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalMembers",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalFemale",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropColumn(
                name: "TotalMale",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropColumn(
                name: "TotalMembers",
                schema: "Capacity",
                table: "DepartmentalTrainings");
        }
    }
}
