using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class SocialForestryDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SocialForestry");

            migrationBuilder.CreateTable(
                name: "PlantationProjects",
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
                    table.PrimaryKey("PK_PlantationProjects", x => x.Id);
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
                    TypeName = table.Column<string>(type: "text", nullable: true),
                    PlantationAreaTypeEnum = table.Column<int>(type: "integer", nullable: false),
                    HasStripType = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantationTypeRevenuePercentages",
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
                    PlantationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    RevenueDistributionTypeEnum = table.Column<int>(type: "integer", nullable: false),
                    RevenuePercentage = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationTypeRevenuePercentages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantationTypeRevenuePercentages_PlantationTypes_Plantation~",
                        column: x => x.PlantationTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StripTypes",
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
                    PlantationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripTypes_PlantationTypes_PlantationTypeId",
                        column: x => x.PlantationTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationTypes",
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
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: false),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: false),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: false),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: false),
                    ForestFcvVcfId = table.Column<long>(type: "bigint", nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    NgoId = table.Column<long>(type: "bigint", nullable: false),
                    PlantationProjectId = table.Column<long>(type: "bigint", nullable: false),
                    PlantationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    StripTypeId = table.Column<long>(type: "bigint", nullable: true),
                    YearOfPlantation = table.Column<int>(type: "integer", nullable: false),
                    ExpectedYearOfCutting = table.Column<int>(type: "integer", nullable: false),
                    PlantationLocation = table.Column<string>(type: "text", nullable: true),
                    PlantationArea = table.Column<double>(type: "double precision", nullable: false),
                    PlantationEstablishmentCostNurseryTk = table.Column<double>(type: "double precision", nullable: false),
                    PlantationEstablishmentCostPlantationTk = table.Column<double>(type: "double precision", nullable: false),
                    LaborInvolvedNurseryMale = table.Column<int>(type: "integer", nullable: false),
                    LaborInvolvedNurseryFemale = table.Column<int>(type: "integer", nullable: false),
                    LaborInvolvedPlantationMale = table.Column<int>(type: "integer", nullable: false),
                    LaborInvolvedPlantationFemale = table.Column<int>(type: "integer", nullable: false),
                    MaleBeneficiaries = table.Column<int>(type: "integer", nullable: false),
                    FemaleBeneficiaries = table.Column<int>(type: "integer", nullable: false),
                    IsSocialForestryCommitteeFormed = table.Column<bool>(type: "boolean", nullable: false),
                    IsFundManagementSubCommitteeFormed = table.Column<bool>(type: "boolean", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRaisedPlantations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_PlantationProjects_PlantationProjectId",
                        column: x => x.PlantationProjectId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_PlantationTypes_PlantationTypeId",
                        column: x => x.PlantationTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantations_StripTypes_StripTypeId",
                        column: x => x.StripTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "StripTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CuttingPlantations",
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
                    YearOfCutting = table.Column<int>(type: "integer", nullable: false),
                    ResourceQtyTimber = table.Column<double>(type: "double precision", nullable: false),
                    ResourceQtyPole = table.Column<double>(type: "double precision", nullable: false),
                    ResourceQtyFuelWood = table.Column<double>(type: "double precision", nullable: false),
                    SaleValueTimber = table.Column<double>(type: "double precision", nullable: false),
                    SaleValuePole = table.Column<double>(type: "double precision", nullable: false),
                    SaleValueFuelWood = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingPlantations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuttingPlantations_NewRaisedPlantations_NewRaisedPlantation~",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewRaisedPlantationUnionMaps",
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
                    UnionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRaisedPlantationUnionMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantationUnionMaps_NewRaisedPlantations_NewRaised~",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantationUnionMaps_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewRaisedPlantationUpazillaMaps",
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
                    UpazillaId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRaisedPlantationUpazillaMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantationUpazillaMaps_NewRaisedPlantations_NewRai~",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantationUpazillaMaps_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reforestations",
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
                    YearOfReforestation = table.Column<int>(type: "integer", nullable: false),
                    ExpectedYearOfCutting = table.Column<int>(type: "integer", nullable: false),
                    ReforestLocation = table.Column<string>(type: "text", nullable: true),
                    ReforestationArea = table.Column<double>(type: "double precision", nullable: false),
                    PlantationEstablishmentCostNurseryTk = table.Column<double>(type: "double precision", nullable: false),
                    PlantationEstablishmentCostPlantationTk = table.Column<double>(type: "double precision", nullable: false),
                    LaborInvolvedNurseryMale = table.Column<int>(type: "integer", nullable: false),
                    LaborInvolvedNurseryFemale = table.Column<int>(type: "integer", nullable: false),
                    LaborInvolvedPlantationMale = table.Column<int>(type: "integer", nullable: false),
                    LaborInvolvedPlantationFemale = table.Column<int>(type: "integer", nullable: false),
                    MaleBeneficiaries = table.Column<int>(type: "integer", nullable: false),
                    FemaleBeneficiaries = table.Column<int>(type: "integer", nullable: false),
                    IsAccountMaintainedBySubCommittee = table.Column<bool>(type: "boolean", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reforestations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reforestations_NewRaisedPlantations_NewRaisedPlantationId",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revenues",
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
                    CuttingPlantationId = table.Column<long>(type: "bigint", nullable: false),
                    RevenueReceivedAmount = table.Column<double>(type: "double precision", nullable: false),
                    RevenueReceivedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OutstandingSaleValue = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revenues_CuttingPlantations_CuttingPlantationId",
                        column: x => x.CuttingPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "CuttingPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevenueDistributions",
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
                    RevenueId = table.Column<long>(type: "bigint", nullable: false),
                    RevenueDistributionTypeEnum = table.Column<int>(type: "integer", nullable: false),
                    ShareInPercentage = table.Column<double>(type: "double precision", nullable: false),
                    GovernmentRevenue = table.Column<double>(type: "double precision", nullable: false),
                    RevenueCollected = table.Column<double>(type: "double precision", nullable: false),
                    OutStandingAmount = table.Column<double>(type: "double precision", nullable: false),
                    NumberOrMale = table.Column<int>(type: "integer", nullable: true),
                    NumberOrFemale = table.Column<int>(type: "integer", nullable: true),
                    AmountInHand = table.Column<double>(type: "double precision", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueDistributions_Revenues_RevenueId",
                        column: x => x.RevenueId,
                        principalSchema: "SocialForestry",
                        principalTable: "Revenues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankDeposits",
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
                    RevenueDistributionId = table.Column<long>(type: "bigint", nullable: false),
                    DepositAmount = table.Column<double>(type: "double precision", nullable: false),
                    DepositDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDeposits_RevenueDistributions_RevenueDistributionId",
                        column: x => x.RevenueDistributionId,
                        principalSchema: "SocialForestry",
                        principalTable: "RevenueDistributions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistributedOrRevenueDepositAmounts",
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
                    RevenueDistributionId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    DateOccurred = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributedOrRevenueDepositAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistributedOrRevenueDepositAmounts_RevenueDistributions_Rev~",
                        column: x => x.RevenueDistributionId,
                        principalSchema: "SocialForestry",
                        principalTable: "RevenueDistributions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankDeposits_RevenueDistributionId",
                schema: "SocialForestry",
                table: "BankDeposits",
                column: "RevenueDistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingPlantations_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedOrRevenueDepositAmounts_RevenueDistributionId",
                schema: "SocialForestry",
                table: "DistributedOrRevenueDepositAmounts",
                column: "RevenueDistributionId");

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
                name: "IX_NewRaisedPlantations_ForestFcvVcfId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_ForestRangeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_NgoId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_PlantationProjectId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_PlantationTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_StripTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "StripTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantationUnionMaps_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "NewRaisedPlantationUnionMaps",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantationUnionMaps_UnionId",
                schema: "SocialForestry",
                table: "NewRaisedPlantationUnionMaps",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantationUpazillaMaps_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "NewRaisedPlantationUpazillaMaps",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantationUpazillaMaps_UpazillaId",
                schema: "SocialForestry",
                table: "NewRaisedPlantationUpazillaMaps",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantationTypeRevenuePercentages_PlantationTypeId",
                schema: "SocialForestry",
                table: "PlantationTypeRevenuePercentages",
                column: "PlantationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestations_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "Reforestations",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueDistributions_RevenueId",
                schema: "SocialForestry",
                table: "RevenueDistributions",
                column: "RevenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_CuttingPlantationId",
                schema: "SocialForestry",
                table: "Revenues",
                column: "CuttingPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_StripTypes_PlantationTypeId",
                schema: "SocialForestry",
                table: "StripTypes",
                column: "PlantationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDeposits",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "DistributedOrRevenueDepositAmounts",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "NewRaisedPlantationUnionMaps",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "NewRaisedPlantationUpazillaMaps",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "PlantationTypeRevenuePercentages",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "Reforestations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "RevenueDistributions",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "Revenues",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "CuttingPlantations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "NewRaisedPlantations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "PlantationProjects",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "StripTypes",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "PlantationTypes",
                schema: "SocialForestry");
        }
    }
}
