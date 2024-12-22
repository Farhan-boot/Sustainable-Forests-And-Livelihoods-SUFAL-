using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NewRaisedPlantationMaleFemalePercentage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlantationEstablishmentCostPlantationTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "TotalMaleBeneficiaryPercentage");

            migrationBuilder.RenameColumn(
                name: "PlantationEstablishmentCostPlantationTk",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "TotalFemaleBeneficiaryPercentage");

            migrationBuilder.RenameColumn(
                name: "PlantationEstablishmentCostNurseryTk",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "PlantationNurseryCostTk");

            migrationBuilder.RenameColumn(
                name: "LaborInvolvedPlantationTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "PBSATotalBeneficiaries");

            migrationBuilder.RenameColumn(
                name: "LaborInvolvedPlantationMale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "PBSAMaleBeneficiaries");

            migrationBuilder.RenameColumn(
                name: "LaborInvolvedPlantationFemale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "PBSAFemaleBeneficiaries");

            migrationBuilder.RenameColumn(
                name: "IsSocialForestryCommitteeFormed",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "IsPBSASigned");

            migrationBuilder.AddColumn<double>(
                name: "LaborEngagedFemalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LaborEngagedMalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "LaborInvolvedEstablishmentFemale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "LaborInvolvedEstablishmentFemalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "LaborInvolvedEstablishmentMale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "LaborInvolvedEstablishmentMalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "LaborInvolvedEstablishmentTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaborInvolvedMaintenanceFemale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "LaborInvolvedMaintenanceFemalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "LaborInvolvedMaintenanceMale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "LaborInvolvedMaintenanceMalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "LaborInvolvedMaintenanceTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "LaborInvolvedNurseryFemalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LaborInvolvedNurseryMalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PBSAAgreementDocumentURL",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PBSAFemaleBeneficiaryPercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PBSAMaleBeneficiaryPercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PlantationCostTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PlantationEstablishmentCostTk",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PlantationMaintenanceCostTk",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaborEngagedFemalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborEngagedMalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedEstablishmentFemale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedEstablishmentFemalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedEstablishmentMale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedEstablishmentMalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedEstablishmentTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedMaintenanceFemale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedMaintenanceFemalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedMaintenanceMale",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedMaintenanceMalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedMaintenanceTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedNurseryFemalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LaborInvolvedNurseryMalePercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PBSAAgreementDocumentURL",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PBSAFemaleBeneficiaryPercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PBSAMaleBeneficiaryPercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PlantationCostTotal",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PlantationEstablishmentCostTk",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PlantationMaintenanceCostTk",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.RenameColumn(
                name: "TotalMaleBeneficiaryPercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "PlantationEstablishmentCostPlantationTotal");

            migrationBuilder.RenameColumn(
                name: "TotalFemaleBeneficiaryPercentage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "PlantationEstablishmentCostPlantationTk");

            migrationBuilder.RenameColumn(
                name: "PlantationNurseryCostTk",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "PlantationEstablishmentCostNurseryTk");

            migrationBuilder.RenameColumn(
                name: "PBSATotalBeneficiaries",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "LaborInvolvedPlantationTotal");

            migrationBuilder.RenameColumn(
                name: "PBSAMaleBeneficiaries",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "LaborInvolvedPlantationMale");

            migrationBuilder.RenameColumn(
                name: "PBSAFemaleBeneficiaries",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "LaborInvolvedPlantationFemale");

            migrationBuilder.RenameColumn(
                name: "IsPBSASigned",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                newName: "IsSocialForestryCommitteeFormed");
        }
    }
}
