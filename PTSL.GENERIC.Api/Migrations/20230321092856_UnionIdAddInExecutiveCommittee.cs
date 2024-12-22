using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class UnionIdAddInExecutiveCommittee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BadLoanType",
                schema: "AIG",
                table: "AIGBasicInformations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_UnionId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "UnionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_Union_UnionId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_Union_UnionId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_UnionId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "BadLoanType",
                schema: "AIG",
                table: "AIGBasicInformations");
        }
    }
}
