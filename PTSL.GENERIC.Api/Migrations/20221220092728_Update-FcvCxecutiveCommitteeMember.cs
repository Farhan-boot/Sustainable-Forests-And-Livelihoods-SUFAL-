using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class UpdateFcvCxecutiveCommitteeMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_FcvCxecutiveCommitteeMember_FcvCxecutive~",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_FcvCxecutiveCommitteeMember_Ngos_NgoId",
                schema: "BEN",
                table: "FcvCxecutiveCommitteeMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FcvCxecutiveCommitteeMember",
                schema: "BEN",
                table: "FcvCxecutiveCommitteeMember");

            migrationBuilder.RenameTable(
                name: "FcvCxecutiveCommitteeMember",
                schema: "BEN",
                newName: "FcvExecutiveCommitteeMember",
                newSchema: "BEN");

            migrationBuilder.RenameIndex(
                name: "IX_FcvCxecutiveCommitteeMember_NgoId",
                schema: "BEN",
                table: "FcvExecutiveCommitteeMember",
                newName: "IX_FcvExecutiveCommitteeMember_NgoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FcvExecutiveCommitteeMember",
                schema: "BEN",
                table: "FcvExecutiveCommitteeMember",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_FcvExecutiveCommitteeMember_FcvCxecutive~",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvCxecutiveCommitteeMembersId",
                principalSchema: "BEN",
                principalTable: "FcvExecutiveCommitteeMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FcvExecutiveCommitteeMember_Ngos_NgoId",
                schema: "BEN",
                table: "FcvExecutiveCommitteeMember",
                column: "NgoId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_FcvExecutiveCommitteeMember_FcvCxecutive~",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_FcvExecutiveCommitteeMember_Ngos_NgoId",
                schema: "BEN",
                table: "FcvExecutiveCommitteeMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FcvExecutiveCommitteeMember",
                schema: "BEN",
                table: "FcvExecutiveCommitteeMember");

            migrationBuilder.RenameTable(
                name: "FcvExecutiveCommitteeMember",
                schema: "BEN",
                newName: "FcvCxecutiveCommitteeMember",
                newSchema: "BEN");

            migrationBuilder.RenameIndex(
                name: "IX_FcvExecutiveCommitteeMember_NgoId",
                schema: "BEN",
                table: "FcvCxecutiveCommitteeMember",
                newName: "IX_FcvCxecutiveCommitteeMember_NgoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FcvCxecutiveCommitteeMember",
                schema: "BEN",
                table: "FcvCxecutiveCommitteeMember",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_FcvCxecutiveCommitteeMember_FcvCxecutive~",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvCxecutiveCommitteeMembersId",
                principalSchema: "BEN",
                principalTable: "FcvCxecutiveCommitteeMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FcvCxecutiveCommitteeMember_Ngos_NgoId",
                schema: "BEN",
                table: "FcvCxecutiveCommitteeMember",
                column: "NgoId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
