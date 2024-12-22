using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class SocialForestry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SocialForestry");

            migrationBuilder.CreateTable(
                name: "CostTypes",
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameBn = table.Column<string>(type: "text", nullable: false),
                    LabelName = table.Column<string>(type: "text", nullable: false),
                    LabelNameBn = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaborCostTypes",
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameBn = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborCostTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandOwningAgencys",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandOwningAgencys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantationCauseOfDamages",
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameBn = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationCauseOfDamages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantationTopographys",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationTopographys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantationTypes",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantationUnits",
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameBn = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialForestryBeneficiarys",
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
                    BeneficiaryName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    NID = table.Column<string>(type: "text", nullable: false),
                    MobileNumber = table.Column<string>(type: "text", nullable: false),
                    EthnicityId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialForestryBeneficiarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialForestryBeneficiarys_Ethnicitys_EthnicityId",
                        column: x => x.EthnicityId,
                        principalSchema: "BEN",
                        principalTable: "Ethnicitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialForestryDesignations",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialForestryDesignations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialForestryNgos",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialForestryNgos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZoneOrAreas",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneOrAreas", x => x.Id);
                });

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
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: false),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: false),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: false),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: false),
                    ZoneOrAreaId = table.Column<long>(type: "bigint", nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    LandOwningAgencyId = table.Column<long>(type: "bigint", nullable: false),
                    SocialForestryNgoId = table.Column<long>(type: "bigint", nullable: false),
                    PlantationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CurrentRotationNo = table.Column<int>(type: "integer", nullable: false),
                    PlantationId = table.Column<string>(type: "text", nullable: false),
                    PlantationArea = table.Column<string>(type: "text", nullable: false),
                    PlantationUnitId = table.Column<long>(type: "bigint", nullable: false),
                    LocationWithCoordinate = table.Column<string>(type: "text", nullable: false),
                    MoujaAndJLNumber = table.Column<string>(type: "text", nullable: false),
                    SheetNo = table.Column<string>(type: "text", nullable: false),
                    PlotNo = table.Column<string>(type: "text", nullable: false),
                    ProjectTypeId = table.Column<long>(type: "bigint", nullable: false),
                    FinancialYearId = table.Column<long>(type: "bigint", nullable: false),
                    RotationInYear = table.Column<int>(type: "integer", nullable: false),
                    ExpectedCuttingYear = table.Column<int>(type: "integer", nullable: false),
                    SanctionNo = table.Column<string>(type: "text", nullable: false),
                    SoilType = table.Column<string>(type: "text", nullable: false),
                    NaturalTreeSpecies = table.Column<string>(type: "text", nullable: false),
                    PlantationTopographyId = table.Column<long>(type: "bigint", nullable: false),
                    ClimateOfPlantationSite = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
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
                        name: "FK_Plantations_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantations_SocialForestryNgos_SocialForestryNgoId",
                        column: x => x.SocialForestryNgoId,
                        principalSchema: "SocialForestry",
                        principalTable: "SocialForestryNgos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "NewRaisedPlantations",
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
                    PlantationId = table.Column<long>(type: "bigint", nullable: false),
                    RotationNo = table.Column<int>(type: "integer", nullable: false),
                    CheckIfPBSAIsSigned = table.Column<bool>(type: "boolean", nullable: false),
                    AgreementUploadFileUrl = table.Column<string>(type: "text", nullable: false),
                    SocialForestryManagementCommitteeFormed = table.Column<bool>(type: "boolean", nullable: false),
                    FundManagementSubCommitteeFormed = table.Column<bool>(type: "boolean", nullable: false),
                    AdvisoryCommitteeFormed = table.Column<bool>(type: "boolean", nullable: false),
                    PlantationJournalUploadUrl = table.Column<string>(type: "text", nullable: false),
                    MonitoringReportUrl = table.Column<string>(type: "text", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRaisedPlantations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_Plantations_PlantationId",
                        column: x => x.PlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "Plantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcernedOfficials",
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
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: false),
                    OfficialName = table.Column<string>(type: "text", nullable: false),
                    DesignationId = table.Column<long>(type: "bigint", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    MobileNo = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernedOfficials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcernedOfficials_NewRaisedPlantations_NewRaisedPlantation~",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcernedOfficials_SocialForestryDesignations_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "SocialForestry",
                        principalTable: "SocialForestryDesignations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostInformations",
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
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: false),
                    CostTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CostDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CostAmount = table.Column<double>(type: "double precision", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostInformations_CostTypes_CostTypeId",
                        column: x => x.CostTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "CostTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostInformations_NewRaisedPlantations_NewRaisedPlantationId",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionDetailss",
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
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: false),
                    OfficialName = table.Column<string>(type: "text", nullable: false),
                    SocialForestryDesignationId = table.Column<long>(type: "bigint", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: false),
                    InspectionFile = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionDetailss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionDetailss_NewRaisedPlantations_NewRaisedPlantation~",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionDetailss_SocialForestryDesignations_SocialForestr~",
                        column: x => x.SocialForestryDesignationId,
                        principalSchema: "SocialForestry",
                        principalTable: "SocialForestryDesignations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaborInformations",
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
                    LaborCostTypeId = table.Column<long>(type: "bigint", nullable: false),
                    LaborCostDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalMale = table.Column<int>(type: "integer", nullable: false),
                    TotalFemale = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaborInformations_LaborCostTypes_LaborCostTypeId",
                        column: x => x.LaborCostTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "LaborCostTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaborInformations_NewRaisedPlantations_NewRaisedPlantationId",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlantationDamageInformations",
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
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfOccurrence = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PlantationCauseOfDamageId = table.Column<long>(type: "bigint", nullable: false),
                    DamageDescription = table.Column<string>(type: "text", nullable: true),
                    InspectedByAuthority = table.Column<bool>(type: "boolean", nullable: false),
                    DamageUrl = table.Column<string>(type: "text", nullable: true),
                    InspectionReportUrl = table.Column<string>(type: "text", nullable: true),
                    ActionTaken = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationDamageInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantationDamageInformations_NewRaisedPlantations_NewRaised~",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantationDamageInformations_PlantationCauseOfDamages_Plant~",
                        column: x => x.PlantationCauseOfDamageId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationCauseOfDamages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantationFiles",
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
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantationFiles_NewRaisedPlantations_NewRaisedPlantationId",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantationPlants",
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
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: false),
                    SpeciesName = table.Column<string>(type: "text", nullable: false),
                    NumberOfSeedlingPlanted = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationPlants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantationPlants_NewRaisedPlantations_NewRaisedPlantationId",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantationSocialForestryBeneficiaryMaps",
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
                    SocialForestryBeneficiaryId = table.Column<long>(type: "bigint", nullable: false),
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationSocialForestryBeneficiaryMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantationSocialForestryBeneficiaryMaps_NewRaisedPlantation~",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantationSocialForestryBeneficiaryMaps_SocialForestryBenef~",
                        column: x => x.SocialForestryBeneficiaryId,
                        principalSchema: "SocialForestry",
                        principalTable: "SocialForestryBeneficiarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostInformationFiles",
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
                    CostInformationId = table.Column<long>(type: "bigint", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostInformationFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostInformationFiles_CostInformations_CostInformationId",
                        column: x => x.CostInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "CostInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaborInformationFiles",
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
                    LaborInformationId = table.Column<long>(type: "bigint", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborInformationFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaborInformationFiles_LaborInformations_LaborInformationId",
                        column: x => x.LaborInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "LaborInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcernedOfficials_DesignationId",
                schema: "SocialForestry",
                table: "ConcernedOfficials",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcernedOfficials_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "ConcernedOfficials",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_CostInformationFiles_CostInformationId",
                schema: "SocialForestry",
                table: "CostInformationFiles",
                column: "CostInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CostInformations_CostTypeId",
                schema: "SocialForestry",
                table: "CostInformations",
                column: "CostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostInformations_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "CostInformations",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDetailss_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDetailss_SocialForestryDesignationId",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                column: "SocialForestryDesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborInformationFiles_LaborInformationId",
                schema: "SocialForestry",
                table: "LaborInformationFiles",
                column: "LaborInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborInformations_LaborCostTypeId",
                schema: "SocialForestry",
                table: "LaborInformations",
                column: "LaborCostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborInformations_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "LaborInformations",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_PlantationId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantationDamageInformations_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "PlantationDamageInformations",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantationDamageInformations_PlantationCauseOfDamageId",
                schema: "SocialForestry",
                table: "PlantationDamageInformations",
                column: "PlantationCauseOfDamageId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantationFiles_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "PlantationFiles",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantationPlants_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "PlantationPlants",
                column: "NewRaisedPlantationId");

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
                name: "IX_Plantations_FinancialYearId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "FinancialYearId");

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

            migrationBuilder.CreateIndex(
                name: "IX_PlantationSocialForestryBeneficiaryMaps_NewRaisedPlantation~",
                schema: "SocialForestry",
                table: "PlantationSocialForestryBeneficiaryMaps",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantationSocialForestryBeneficiaryMaps_SocialForestryBenef~",
                schema: "SocialForestry",
                table: "PlantationSocialForestryBeneficiaryMaps",
                column: "SocialForestryBeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryBeneficiarys_EthnicityId",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys",
                column: "EthnicityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcernedOfficials",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "CostInformationFiles",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "InspectionDetailss",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "LaborInformationFiles",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "PlantationDamageInformations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "PlantationFiles",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "PlantationPlants",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "PlantationSocialForestryBeneficiaryMaps",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "CostInformations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "SocialForestryDesignations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "LaborInformations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "PlantationCauseOfDamages",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "SocialForestryBeneficiarys",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "CostTypes",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "LaborCostTypes",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "NewRaisedPlantations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "Plantations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "LandOwningAgencys",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "PlantationTopographys",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "PlantationTypes",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "PlantationUnits",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "ProjectTypes",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "SocialForestryNgos",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "ZoneOrAreas",
                schema: "SocialForestry");
        }
    }
}
