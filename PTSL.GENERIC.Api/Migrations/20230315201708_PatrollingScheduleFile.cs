using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class PatrollingScheduleFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatrollingPlanningFile",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatrollingPlanningFile",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion");
        }
    }
}
