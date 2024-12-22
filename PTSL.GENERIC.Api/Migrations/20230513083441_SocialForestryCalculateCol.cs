using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class SocialForestryCalculateCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaborEngagedTotal",
                schema: "SocialForestry",
                table: "Reforestations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaborEngagedTotalFemale",
                schema: "SocialForestry",
                table: "Reforestations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaborEngagedTotalMale",
                schema: "SocialForestry",
                table: "Reforestations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaborInvolvedNurseryTotal",
                schema: "SocialForestry",
                table: "Reforestations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaborInvolvedPlantationTotal",
                schema: "SocialForestry",
                table: "Reforestations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PlantationEstablishmentCostPlantationTotal",
                schema: "SocialForestry",
                table: "Reforestations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "RotationInYears",
                schema: "SocialForestry",
                table: "Reforestations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaborEngagedTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaborEngagedTotalFemale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaborEngagedTotalMale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaborInvolvedNurseryTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaborInvolvedPlantationTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PlantationEstablishmentCostPlantationTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TotalBeneficiaries",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ResourceQtyTotal",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SaleValueTotal",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaborEngagedTotal",
                schema: "SocialForestry",
                table: "Reforestations");

            migrationBuilder.DropColumn(
                name: "LaborEngagedTotalFemale",
                schema: "SocialForestry",
                table: "Reforestations");

            migrationBuilder.DropColumn(
                name: "LaborEngagedTotalMale",
                schema: "SocialForestry",
                table: "Reforestations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedNurseryTotal",
                schema: "SocialForestry",
                table: "Reforestations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedPlantationTotal",
                schema: "SocialForestry",
                table: "Reforestations");

            migrationBuilder.DropColumn(
                name: "PlantationEstablishmentCostPlantationTotal",
                schema: "SocialForestry",
                table: "Reforestations");

            migrationBuilder.DropColumn(
                name: "RotationInYears",
                schema: "SocialForestry",
                table: "Reforestations");

            migrationBuilder.DropColumn(
                name: "LaborEngagedTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborEngagedTotalFemale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborEngagedTotalMale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedNurseryTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedPlantationTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PlantationEstablishmentCostPlantationTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "TotalBeneficiaries",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "ResourceQtyTotal",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropColumn(
                name: "SaleValueTotal",
                schema: "SocialForestry",
                table: "CuttingPlantations");
        }
    }
}
