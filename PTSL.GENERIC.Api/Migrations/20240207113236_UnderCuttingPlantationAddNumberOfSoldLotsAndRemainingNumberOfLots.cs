using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class UnderCuttingPlantationAddNumberOfSoldLotsAndRemainingNumberOfLots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfSoldLots",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemainingNumberOfLots",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSoldLots",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropColumn(
                name: "RemainingNumberOfLots",
                schema: "SocialForestry",
                table: "CuttingPlantations");
        }
    }
}
