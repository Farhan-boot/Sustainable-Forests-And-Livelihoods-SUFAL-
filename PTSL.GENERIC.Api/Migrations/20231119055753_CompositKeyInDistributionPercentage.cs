using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CompositKeyInDistributionPercentage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DistributionPercentages",
                schema: "SocialForestry",
                table: "DistributionPercentages");

            migrationBuilder.DropIndex(
                name: "IX_DistributionPercentages_DistributionFundTypeId",
                schema: "SocialForestry",
                table: "DistributionPercentages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DistributionPercentages",
                schema: "SocialForestry",
                table: "DistributionPercentages",
                columns: new[] { "DistributionFundTypeId", "PlantationTypeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DistributionPercentages",
                schema: "SocialForestry",
                table: "DistributionPercentages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DistributionPercentages",
                schema: "SocialForestry",
                table: "DistributionPercentages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DistributionPercentages_DistributionFundTypeId",
                schema: "SocialForestry",
                table: "DistributionPercentages",
                column: "DistributionFundTypeId");
        }
    }
}
