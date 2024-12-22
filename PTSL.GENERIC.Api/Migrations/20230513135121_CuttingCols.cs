using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CuttingCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalBeneficiaries",
                schema: "SocialForestry",
                table: "Reforestations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RotationInYears",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearOfReforestation",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalBeneficiaries",
                schema: "SocialForestry",
                table: "Reforestations");

            migrationBuilder.DropColumn(
                name: "RotationInYears",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropColumn(
                name: "YearOfReforestation",
                schema: "SocialForestry",
                table: "CuttingPlantations");
        }
    }
}
