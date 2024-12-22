using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CommitteeManagementAddForestFcvVcfIdUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeManagement_ForestFcvVcfs_ForestFcvVcfId",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeManagement_ForestFcvVcfs_ForestFcvVcfId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeManagement_ForestFcvVcfs_ForestFcvVcfId",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeManagement_ForestFcvVcfs_ForestFcvVcfId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
