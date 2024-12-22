using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class OtherCommitteeMemberUnion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtherCommitteeMembers_UnionId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "UnionId");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherCommitteeMembers_Union_UnionId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherCommitteeMembers_Union_UnionId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropIndex(
                name: "IX_OtherCommitteeMembers_UnionId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "BEN",
                table: "OtherCommitteeMembers");
        }
    }
}
