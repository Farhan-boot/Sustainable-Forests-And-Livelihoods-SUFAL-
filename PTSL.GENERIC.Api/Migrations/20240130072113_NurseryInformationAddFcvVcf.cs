using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NurseryInformationAddFcvVcf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ForestFcvVcfId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_ForestFcvVcfId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "ForestFcvVcfId");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryInformations_ForestFcvVcfs_ForestFcvVcfId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseryInformations_ForestFcvVcfs_ForestFcvVcfId",
                schema: "SocialForestry",
                table: "NurseryInformations");

            migrationBuilder.DropIndex(
                name: "IX_NurseryInformations_ForestFcvVcfId",
                schema: "SocialForestry",
                table: "NurseryInformations");

            migrationBuilder.DropColumn(
                name: "ForestFcvVcfId",
                schema: "SocialForestry",
                table: "NurseryInformations");
        }
    }
}
