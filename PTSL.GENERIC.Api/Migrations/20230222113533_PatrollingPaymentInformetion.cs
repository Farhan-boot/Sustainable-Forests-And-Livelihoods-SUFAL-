using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class PatrollingPaymentInformetion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PatrollingPaymentInformetion",
                newName: "PatrollingPaymentInformetion",
                newSchema: "Patrolling");

            migrationBuilder.AddColumn<long>(
                name: "OtherPatrollingMemberId",
                schema: "Patrolling",
                table: "PatrollingPaymentInformetion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingPaymentInformetion_OtherPatrollingMemberId",
                schema: "Patrolling",
                table: "PatrollingPaymentInformetion",
                column: "OtherPatrollingMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatrollingPaymentInformetion_OtherPatrollingMember_OtherPat~",
                schema: "Patrolling",
                table: "PatrollingPaymentInformetion",
                column: "OtherPatrollingMemberId",
                principalSchema: "Patrolling",
                principalTable: "OtherPatrollingMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatrollingPaymentInformetion_OtherPatrollingMember_OtherPat~",
                schema: "Patrolling",
                table: "PatrollingPaymentInformetion");

            migrationBuilder.DropIndex(
                name: "IX_PatrollingPaymentInformetion_OtherPatrollingMemberId",
                schema: "Patrolling",
                table: "PatrollingPaymentInformetion");

            migrationBuilder.DropColumn(
                name: "OtherPatrollingMemberId",
                schema: "Patrolling",
                table: "PatrollingPaymentInformetion");

            migrationBuilder.RenameTable(
                name: "PatrollingPaymentInformetion",
                schema: "Patrolling",
                newName: "PatrollingPaymentInformetion");
        }
    }
}
