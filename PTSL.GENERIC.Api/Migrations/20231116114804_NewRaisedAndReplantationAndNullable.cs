using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NewRaisedAndReplantationAndNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NID",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                schema: "SocialForestry",
                table: "Replantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PlantationJournalUploadUrl",
                schema: "SocialForestry",
                table: "Replantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PlantationArea",
                schema: "SocialForestry",
                table: "Replantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "MonitoringReportUrl",
                schema: "SocialForestry",
                table: "Replantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "AdvisoryCommitteeFormedFile",
                schema: "SocialForestry",
                table: "Replantations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FundManagementSubCommitteeFormedFile",
                schema: "SocialForestry",
                table: "Replantations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialForestryManagementCommitteeFormedFile",
                schema: "SocialForestry",
                table: "Replantations",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgreementUploadFileUrl",
                schema: "SocialForestry",
                table: "PlantationSocialForestryBeneficiaryMaps",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "AdvisoryCommitteeFormedFile",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FundManagementSubCommitteeFormedFile",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialForestryManagementCommitteeFormedFile",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvisoryCommitteeFormedFile",
                schema: "SocialForestry",
                table: "Replantations");

            migrationBuilder.DropColumn(
                name: "FundManagementSubCommitteeFormedFile",
                schema: "SocialForestry",
                table: "Replantations");

            migrationBuilder.DropColumn(
                name: "SocialForestryManagementCommitteeFormedFile",
                schema: "SocialForestry",
                table: "Replantations");

            migrationBuilder.DropColumn(
                name: "AdvisoryCommitteeFormedFile",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "FundManagementSubCommitteeFormedFile",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "SocialForestryManagementCommitteeFormedFile",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.AlterColumn<string>(
                name: "NID",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                schema: "SocialForestry",
                table: "Replantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlantationJournalUploadUrl",
                schema: "SocialForestry",
                table: "Replantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlantationArea",
                schema: "SocialForestry",
                table: "Replantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MonitoringReportUrl",
                schema: "SocialForestry",
                table: "Replantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgreementUploadFileUrl",
                schema: "SocialForestry",
                table: "PlantationSocialForestryBeneficiaryMaps",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
