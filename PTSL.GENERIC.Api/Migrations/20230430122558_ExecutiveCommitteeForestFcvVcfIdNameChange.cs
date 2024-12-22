using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ExecutiveCommitteeForestFcvVcfIdNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestFcvVcfs_FcvId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.RenameColumn(
                name: "FcvId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "ForestFcvVcfId");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutiveCommittee_FcvId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "IX_ExecutiveCommittee_ForestFcvVcfId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestFcvVcfs_ForestFcvVcfId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestFcvVcfs_ForestFcvVcfId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.RenameColumn(
                name: "ForestFcvVcfId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "FcvId");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutiveCommittee_ForestFcvVcfId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "IX_ExecutiveCommittee_FcvId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestFcvVcfs_FcvId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id");
        }
    }
}
