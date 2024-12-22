using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class OtherCommitteMemeberExecutiveCommitteOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.AddColumn<long>(
                name: "OtherCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_OtherCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "OtherCommitteeMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_OtherCommitteeMembers_OtherCommitteeMemb~",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "OtherCommitteeMemberId",
                principalSchema: "BEN",
                principalTable: "OtherCommitteeMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_OtherCommitteeMembers_OtherCommitteeMemb~",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_OtherCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "OtherCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.AddColumn<long>(
                name: "OtherMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "bigint",
                nullable: true);
        }
    }
}
