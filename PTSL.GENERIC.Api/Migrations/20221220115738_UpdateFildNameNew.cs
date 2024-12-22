using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class UpdateFildNameNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_Ngos_FcvCxecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_FcvExecutiveCommitteeMember_FcvCxecutive~",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_FcvCxecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_FcvCxecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "FcvCxecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "FcvCxecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.AddColumn<long>(
                name: "FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FcvExecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvExecutiveCommitteeMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_FcvExecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvExecutiveCommitteeMembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_Ngos_FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvExecutiveCommitteeMemberId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_FcvExecutiveCommitteeMember_FcvExecutive~",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvExecutiveCommitteeMembersId",
                principalSchema: "BEN",
                principalTable: "FcvExecutiveCommitteeMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_Ngos_FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_FcvExecutiveCommitteeMember_FcvExecutive~",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_FcvExecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "FcvExecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.AddColumn<long>(
                name: "FcvCxecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FcvCxecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_FcvCxecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvCxecutiveCommitteeMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_FcvCxecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvCxecutiveCommitteeMembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_Ngos_FcvCxecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvCxecutiveCommitteeMemberId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_FcvExecutiveCommitteeMember_FcvCxecutive~",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvCxecutiveCommitteeMembersId",
                principalSchema: "BEN",
                principalTable: "FcvExecutiveCommitteeMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
