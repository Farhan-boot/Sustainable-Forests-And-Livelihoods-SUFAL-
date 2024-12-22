using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NewRaisedPlantationCleanUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_Plantations_PlantationId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropTable(
                name: "Plantations",
                schema: "SocialForestry");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_PlantationId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.AlterColumn<string>(
                name: "PlantationId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "ClimateOfPlantationSite",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "CurrentRotationNo",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "DistrictId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ForestBeatId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ForestCircleId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ForestDivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ForestRangeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LandOwningAgencyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "LocationWithCoordinate",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MoujaAndJLNumber",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NaturalTreeSpecies",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PlantationTopographyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PlantationTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "PlotNo",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanctionNo",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SheetNo",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoilType",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpazillaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ZoneOrAreaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "CreatedFinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_DistrictId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_DivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_ForestBeatId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_ForestCircleId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_ForestDivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_ForestRangeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_LandOwningAgencyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "LandOwningAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_PlantationTopographyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationTopographyId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_PlantationTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_UnionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_UpazillaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_ZoneOrAreaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ZoneOrAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CostInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations",
                column: "NurseryInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostInformations_NurseryInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations",
                column: "NurseryInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryInformations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_District_DistrictId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_Division_DivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_FinancialYears_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "CreatedFinancialYearId",
                principalSchema: "GS",
                principalTable: "FinancialYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_ForestBeats_ForestBeatId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_ForestCircles_ForestCircleId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_ForestDivisions_ForestDivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_ForestRanges_ForestRangeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_NewRaisedPlantations_PlantationTypes_PlantationTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationTypeId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_Union_UnionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_Upazilla_UpazillaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostInformations_NurseryInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_District_DistrictId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_Division_DivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_FinancialYears_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_ForestBeats_ForestBeatId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_ForestCircles_ForestCircleId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_ForestDivisions_ForestDivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_ForestRanges_ForestRangeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_LandOwningAgencys_LandOwningAgencyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_PlantationTopographys_PlantationTopogr~",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_PlantationTypes_PlantationTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_Union_UnionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_Upazilla_UpazillaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_ZoneOrAreas_ZoneOrAreaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_DistrictId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_DivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_ForestBeatId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_ForestCircleId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_ForestDivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_ForestRangeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_LandOwningAgencyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_PlantationTopographyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_PlantationTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_UnionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_UpazillaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_ZoneOrAreaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_CostInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations");

            migrationBuilder.DropColumn(
                name: "ClimateOfPlantationSite",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "CurrentRotationNo",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "ForestBeatId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "ForestCircleId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "ForestDivisionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "ForestRangeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LandOwningAgencyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "LocationWithCoordinate",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "MoujaAndJLNumber",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "NaturalTreeSpecies",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PlantationTopographyId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PlantationTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PlotNo",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "SanctionNo",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "SheetNo",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "SoilType",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "UpazillaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "ZoneOrAreaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations");

            migrationBuilder.AlterColumn<long>(
                name: "PlantationId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Plantations",
                schema: "SocialForestry",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedFinancialYearId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: false),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: false),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: false),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: false),
                    LandOwningAgencyId = table.Column<long>(type: "bigint", nullable: false),
                    PlantationTopographyId = table.Column<long>(type: "bigint", nullable: false),
                    PlantationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    PlantationUnitId = table.Column<long>(type: "bigint", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: false),
                    ZoneOrAreaId = table.Column<long>(type: "bigint", nullable: false),
                    ClimateOfPlantationSite = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CurrentRotationNo = table.Column<int>(type: "integer", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    LocationWithCoordinate = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    MoujaAndJLNumber = table.Column<string>(type: "text", nullable: true),
                    NaturalTreeSpecies = table.Column<string>(type: "text", nullable: false),
                    PlantationArea = table.Column<string>(type: "text", nullable: false),
                    PlantationId = table.Column<string>(type: "text", nullable: false),
                    PlotNo = table.Column<string>(type: "text", nullable: true),
                    ProjectTypeId = table.Column<long>(type: "bigint", nullable: true),
                    SanctionNo = table.Column<string>(type: "text", nullable: false),
                    SheetNo = table.Column<string>(type: "text", nullable: true),
                    SocialForestryNgoId = table.Column<long>(type: "bigint", nullable: true),
                    SoilType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plantations_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_FinancialYears_CreatedFinancialYearId",
                        column: x => x.CreatedFinancialYearId,
                        principalSchema: "GS",
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_LandOwningAgencys_LandOwningAgencyId",
                        column: x => x.LandOwningAgencyId,
                        principalSchema: "SocialForestry",
                        principalTable: "LandOwningAgencys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_PlantationTopographys_PlantationTopographyId",
                        column: x => x.PlantationTopographyId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationTopographys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_PlantationTypes_PlantationTypeId",
                        column: x => x.PlantationTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_PlantationUnits_PlantationUnitId",
                        column: x => x.PlantationUnitId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_ProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "ProjectTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plantations_SocialForestryNgos_SocialForestryNgoId",
                        column: x => x.SocialForestryNgoId,
                        principalSchema: "SocialForestry",
                        principalTable: "SocialForestryNgos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plantations_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plantations_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_ZoneOrAreas_ZoneOrAreaId",
                        column: x => x.ZoneOrAreaId,
                        principalSchema: "SocialForestry",
                        principalTable: "ZoneOrAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_PlantationId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "CreatedFinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_DistrictId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_DivisionId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_ForestBeatId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_ForestCircleId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_ForestDivisionId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_ForestRangeId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_LandOwningAgencyId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "LandOwningAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_PlantationTopographyId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "PlantationTopographyId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_PlantationTypeId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "PlantationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_PlantationUnitId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "PlantationUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_ProjectTypeId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_SocialForestryNgoId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "SocialForestryNgoId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_UnionId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_UpazillaId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_ZoneOrAreaId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "ZoneOrAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_Plantations_PlantationId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationId",
                principalSchema: "SocialForestry",
                principalTable: "Plantations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
