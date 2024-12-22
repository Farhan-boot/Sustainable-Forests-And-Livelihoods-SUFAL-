using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class distributionTblUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributions_NurseryRaisedSeedlingInformations_Nurs~",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropIndex(
                name: "IX_NurseryDistributions_NurseryRaisedSeedlingId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "NurseryRaisedSeedlingId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.AddColumn<long>(
                name: "NurseryRaisedSeedlingId",
                table: "NurseryDistributionDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributionDetails_NurseryRaisedSeedlingId",
                table: "NurseryDistributionDetails",
                column: "NurseryRaisedSeedlingId");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributionDetails_NurseryRaisedSeedlingInformation~",
                table: "NurseryDistributionDetails",
                column: "NurseryRaisedSeedlingId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryRaisedSeedlingInformations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributionDetails_NurseryRaisedSeedlingInformation~",
                table: "NurseryDistributionDetails");

            migrationBuilder.DropIndex(
                name: "IX_NurseryDistributionDetails_NurseryRaisedSeedlingId",
                table: "NurseryDistributionDetails");

            migrationBuilder.DropColumn(
                name: "NurseryRaisedSeedlingId",
                table: "NurseryDistributionDetails");

            migrationBuilder.AddColumn<long>(
                name: "NurseryRaisedSeedlingId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_NurseryRaisedSeedlingId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "NurseryRaisedSeedlingId");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributions_NurseryRaisedSeedlingInformations_Nurs~",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "NurseryRaisedSeedlingId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryRaisedSeedlingInformations",
                principalColumn: "Id");
        }
    }
}
