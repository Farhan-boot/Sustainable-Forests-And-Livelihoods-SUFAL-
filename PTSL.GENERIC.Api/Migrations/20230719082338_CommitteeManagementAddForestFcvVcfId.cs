using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CommitteeManagementAddForestFcvVcfId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ForestFcvVcfId",
                schema: "BEN",
                table: "CommitteeManagement",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_ForestFcvVcfId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "ForestFcvVcfId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeManagement_ForestFcvVcfs_ForestFcvVcfId",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.DropIndex(
                name: "IX_CommitteeManagement_ForestFcvVcfId",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.DropColumn(
                name: "ForestFcvVcfId",
                schema: "BEN",
                table: "CommitteeManagement");
        }
    }
}
