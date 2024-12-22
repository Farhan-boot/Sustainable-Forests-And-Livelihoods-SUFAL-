using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldIntoCipTeamMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DesignetionName",
                table: "CipTeamMember",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OtherCommitteeMemberId",
                table: "CipTeamMember",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CipTeamMember_OtherCommitteeMemberId",
                table: "CipTeamMember",
                column: "OtherCommitteeMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_CipTeamMember_OtherCommitteeMembers_OtherCommitteeMemberId",
                table: "CipTeamMember",
                column: "OtherCommitteeMemberId",
                principalSchema: "BEN",
                principalTable: "OtherCommitteeMembers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CipTeamMember_OtherCommitteeMembers_OtherCommitteeMemberId",
                table: "CipTeamMember");

            migrationBuilder.DropIndex(
                name: "IX_CipTeamMember_OtherCommitteeMemberId",
                table: "CipTeamMember");

            migrationBuilder.DropColumn(
                name: "DesignetionName",
                table: "CipTeamMember");

            migrationBuilder.DropColumn(
                name: "OtherCommitteeMemberId",
                table: "CipTeamMember");
        }
    }
}
