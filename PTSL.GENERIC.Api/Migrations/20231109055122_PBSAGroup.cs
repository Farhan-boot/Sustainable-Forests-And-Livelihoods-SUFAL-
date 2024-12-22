using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class PBSAGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreementUploadFileUrl",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "CheckIfPBSAIsSigned",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.AddColumn<string>(
                name: "AgreementUploadFileUrl",
                schema: "SocialForestry",
                table: "PlantationSocialForestryBeneficiaryMaps",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "CheckIfPBSAIsSigned",
                schema: "SocialForestry",
                table: "PlantationSocialForestryBeneficiaryMaps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PBSAGroupId",
                schema: "SocialForestry",
                table: "PlantationSocialForestryBeneficiaryMaps",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreementUploadFileUrl",
                schema: "SocialForestry",
                table: "PlantationSocialForestryBeneficiaryMaps");

            migrationBuilder.DropColumn(
                name: "CheckIfPBSAIsSigned",
                schema: "SocialForestry",
                table: "PlantationSocialForestryBeneficiaryMaps");

            migrationBuilder.DropColumn(
                name: "PBSAGroupId",
                schema: "SocialForestry",
                table: "PlantationSocialForestryBeneficiaryMaps");

            migrationBuilder.AddColumn<string>(
                name: "AgreementUploadFileUrl",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "CheckIfPBSAIsSigned",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
