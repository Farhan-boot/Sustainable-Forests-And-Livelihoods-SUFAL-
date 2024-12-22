using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class PatrollingScheduleInformetionCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Patrolling");

            migrationBuilder.RenameTable(
                name: "PatrollingScheduleInformetion",
                newName: "PatrollingScheduleInformetion",
                newSchema: "Patrolling");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PatrollingScheduleInformetion",
                schema: "Patrolling",
                newName: "PatrollingScheduleInformetion");
        }
    }
}
