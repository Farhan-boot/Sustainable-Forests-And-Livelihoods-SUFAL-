using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CommitteeManagementIdAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeManagementMember_CommitteeDesignation_SubCommittee~",
                schema: "BEN",
                table: "CommitteeManagementMember");

            migrationBuilder.DropColumn(
                name: "ExecutiveDesignationId",
                schema: "BEN",
                table: "CommitteeManagementMember");

            migrationBuilder.RenameColumn(
                name: "SubCommitteeDesignationId",
                schema: "BEN",
                table: "CommitteeManagementMember",
                newName: "CommitteeDesignationId");

            migrationBuilder.RenameIndex(
                name: "IX_CommitteeManagementMember_SubCommitteeDesignationId",
                schema: "BEN",
                table: "CommitteeManagementMember",
                newName: "IX_CommitteeManagementMember_CommitteeDesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeManagementMember_CommitteeDesignation_CommitteeDes~",
                schema: "BEN",
                table: "CommitteeManagementMember",
                column: "CommitteeDesignationId",
                principalSchema: "GS",
                principalTable: "CommitteeDesignation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeManagementMember_CommitteeDesignation_CommitteeDes~",
                schema: "BEN",
                table: "CommitteeManagementMember");

            migrationBuilder.RenameColumn(
                name: "CommitteeDesignationId",
                schema: "BEN",
                table: "CommitteeManagementMember",
                newName: "SubCommitteeDesignationId");

            migrationBuilder.RenameIndex(
                name: "IX_CommitteeManagementMember_CommitteeDesignationId",
                schema: "BEN",
                table: "CommitteeManagementMember",
                newName: "IX_CommitteeManagementMember_SubCommitteeDesignationId");

            migrationBuilder.AddColumn<int>(
                name: "ExecutiveDesignationId",
                schema: "BEN",
                table: "CommitteeManagementMember",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeManagementMember_CommitteeDesignation_SubCommittee~",
                schema: "BEN",
                table: "CommitteeManagementMember",
                column: "SubCommitteeDesignationId",
                principalSchema: "GS",
                principalTable: "CommitteeDesignation",
                principalColumn: "Id");
        }
    }
}
