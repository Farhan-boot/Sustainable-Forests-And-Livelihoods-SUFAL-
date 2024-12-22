using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class addUnionIntoPatrollingScheduleInformetion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingScheduleInformetion_UnionId",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion",
                column: "UnionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatrollingScheduleInformetion_Union_UnionId",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatrollingScheduleInformetion_Union_UnionId",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion");

            migrationBuilder.DropIndex(
                name: "IX_PatrollingScheduleInformetion_UnionId",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion");
        }
    }
}
