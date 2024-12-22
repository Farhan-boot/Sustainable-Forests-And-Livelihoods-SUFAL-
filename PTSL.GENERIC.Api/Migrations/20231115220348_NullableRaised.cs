using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NullableRaised : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_LandOwningAgencys_LandOwningAgencyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_PlantationTopographys_PlantationTopogr~",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_ZoneOrAreas_ZoneOrAreaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.AlterColumn<long>(
                name: "ZoneOrAreaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "SoilType",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "SanctionNo",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "PlantationTopographyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "PlantationJournalUploadUrl",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PlantationArea",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NaturalTreeSpecies",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "MonitoringReportUrl",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LocationWithCoordinate",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "LandOwningAgencyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "ClimateOfPlantationSite",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_LandOwningAgencys_LandOwningAgencyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "LandOwningAgencyId",
                principalSchema: "SocialForestry",
                principalTable: "LandOwningAgencys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_PlantationTopographys_PlantationTopogr~",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationTopographyId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationTopographys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_ZoneOrAreas_ZoneOrAreaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ZoneOrAreaId",
                principalSchema: "SocialForestry",
                principalTable: "ZoneOrAreas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_LandOwningAgencys_LandOwningAgencyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_PlantationTopographys_PlantationTopogr~",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_ZoneOrAreas_ZoneOrAreaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.AlterColumn<long>(
                name: "ZoneOrAreaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoilType",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SanctionNo",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PlantationTopographyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlantationJournalUploadUrl",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlantationArea",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NaturalTreeSpecies",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MonitoringReportUrl",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocationWithCoordinate",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LandOwningAgencyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClimateOfPlantationSite",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_LandOwningAgencys_LandOwningAgencyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "LandOwningAgencyId",
                principalSchema: "SocialForestry",
                principalTable: "LandOwningAgencys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_PlantationTopographys_PlantationTopogr~",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationTopographyId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationTopographys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_ZoneOrAreas_ZoneOrAreaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ZoneOrAreaId",
                principalSchema: "SocialForestry",
                principalTable: "ZoneOrAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
