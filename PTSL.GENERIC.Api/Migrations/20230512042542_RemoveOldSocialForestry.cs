using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOldSocialForestry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDeposit",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "Reforestation",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "ReforestationType",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "RevenueOrDistributedAmount",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "TypeOfPlantationRevenues",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "RevenueDistribution",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "RevenueFeelingOrCutting",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "FeelingOrCutting",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "NewRaisedPlantation",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "RotationNumber",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "ProjectNameAndBudget",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "StripType",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "TypeOfPlantation",
                schema: "Plantation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Plantation");

            migrationBuilder.CreateTable(
                name: "ProjectNameAndBudget",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNameAndBudget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReforestationType",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReforestationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RotationNumber",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotationNumber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfPlantation",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    PlantationAreaName = table.Column<string>(type: "varchar(500)", nullable: true),
                    PlantationName = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPlantation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripType",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TypeOfPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripType_TypeOfPlantation_TypeOfPlantationId",
                        column: x => x.TypeOfPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "TypeOfPlantation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TypeOfPlantationRevenues",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TypeOfPlantationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    RevenueDistributionTypeEnum = table.Column<int>(type: "integer", nullable: false),
                    RevenuePercentage = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPlantationRevenues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeOfPlantationRevenues_TypeOfPlantation_TypeOfPlantationId",
                        column: x => x.TypeOfPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "TypeOfPlantation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewRaisedPlantation",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: true),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: true),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: true),
                    NgoId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectNameAndBudgetId = table.Column<long>(type: "bigint", nullable: true),
                    StripTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TypeOfPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    FcvId = table.Column<long>(type: "bigint", nullable: true),
                    IsFundManagementSubCommiteeFormed = table.Column<bool>(type: "boolean", nullable: true),
                    IsSocialForestryCommiteeFormed = table.Column<bool>(type: "boolean", nullable: true),
                    LaborInvolvedNumberNurseryFemale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberNurseryMale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberNurseryTotal = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberPlantationFemale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberPlantationMale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberPlantationTotal = table.Column<long>(type: "bigint", nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationFemale = table.Column<long>(type: "bigint", nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationMale = table.Column<long>(type: "bigint", nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationTotal = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfBeneficiariesFemale = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfBeneficiariesMale = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfBeneficiariesTotal = table.Column<long>(type: "bigint", nullable: true),
                    PlantationArea = table.Column<string>(type: "text", nullable: true),
                    PlantationAreaNumber = table.Column<decimal>(type: "numeric", nullable: true),
                    PlantationEstablishmentCostNurseryTk = table.Column<decimal>(type: "numeric", nullable: true),
                    PlantationEstablishmentCostPlantationTk = table.Column<decimal>(type: "numeric", nullable: true),
                    PlantationEstablishmentCostTotalTk = table.Column<decimal>(type: "numeric", nullable: true),
                    PlantationLocation = table.Column<string>(type: "text", nullable: true),
                    PlantationYear = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    RotationInYear = table.Column<long>(type: "bigint", nullable: true),
                    SubCommitteeMaintainPlantationEstablishmentAccount = table.Column<bool>(type: "boolean", nullable: true),
                    YearOfFelling = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRaisedPlantation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_ProjectNameAndBudget_ProjectNameAndBudg~",
                        column: x => x.ProjectNameAndBudgetId,
                        principalSchema: "Plantation",
                        principalTable: "ProjectNameAndBudget",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_StripType_StripTypeId",
                        column: x => x.StripTypeId,
                        principalSchema: "Plantation",
                        principalTable: "StripType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_TypeOfPlantation_TypeOfPlantationId",
                        column: x => x.TypeOfPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "TypeOfPlantation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeelingOrCutting",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: true),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: true),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: true),
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    NgoId = table.Column<long>(type: "bigint", nullable: true),
                    RotationNoId = table.Column<long>(type: "bigint", nullable: true),
                    StripTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TypeOfPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    FcvId = table.Column<long>(type: "bigint", nullable: true),
                    FellingInformationYearOfFelling = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    PlantationArea = table.Column<string>(type: "text", nullable: true),
                    PlantationLocation = table.Column<string>(type: "text", nullable: true),
                    PlantationYear = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    ResourceQtyFuelWood = table.Column<decimal>(type: "numeric", nullable: true),
                    ResourceQtyPole = table.Column<decimal>(type: "numeric", nullable: true),
                    ResourceQtyTimbar = table.Column<decimal>(type: "numeric", nullable: true),
                    ResourceQtyTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    SaleValueFuelWood = table.Column<decimal>(type: "numeric", nullable: true),
                    SaleValuePole = table.Column<decimal>(type: "numeric", nullable: true),
                    SaleValueTimbar = table.Column<decimal>(type: "numeric", nullable: true),
                    SaleValueTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    YearOfFelling = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeelingOrCutting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_NewRaisedPlantation_NewRaisedPlantationId",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "NewRaisedPlantation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_RotationNumber_RotationNoId",
                        column: x => x.RotationNoId,
                        principalSchema: "Plantation",
                        principalTable: "RotationNumber",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_StripType_StripTypeId",
                        column: x => x.StripTypeId,
                        principalSchema: "Plantation",
                        principalTable: "StripType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_TypeOfPlantation_TypeOfPlantationId",
                        column: x => x.TypeOfPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "TypeOfPlantation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reforestation",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: true),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: true),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: true),
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    NgoId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectNameAndBudgetId = table.Column<long>(type: "bigint", nullable: true),
                    RotationNoId = table.Column<long>(type: "bigint", nullable: true),
                    StripTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TypeOfPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    FcvId = table.Column<long>(type: "bigint", nullable: true),
                    IsAccountMaintainedByTffSubCommitee = table.Column<bool>(type: "boolean", nullable: true),
                    LaborInvolvedNumberNurseryFemale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberNurseryMale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberNurseryTotal = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberPlantationFemale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberPlantationMale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberPlantationTotal = table.Column<long>(type: "bigint", nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationFemale = table.Column<long>(type: "bigint", nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationMale = table.Column<long>(type: "bigint", nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationTotal = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfBeneficiariesFemale = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfBeneficiariesMale = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfBeneficiariesTotal = table.Column<long>(type: "bigint", nullable: true),
                    PlantationArea = table.Column<string>(type: "text", nullable: true),
                    PlantationEstablishmentCostNurseryTk = table.Column<decimal>(type: "numeric", nullable: true),
                    PlantationEstablishmentCostPlantationTk = table.Column<decimal>(type: "numeric", nullable: true),
                    PlantationEstablishmentCostTotalTk = table.Column<decimal>(type: "numeric", nullable: true),
                    PlantationLocation = table.Column<string>(type: "text", nullable: true),
                    PlantationYear = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    RotationInYear = table.Column<long>(type: "bigint", nullable: true),
                    YearOfFelling = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reforestation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reforestation_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_NewRaisedPlantation_NewRaisedPlantationId",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "NewRaisedPlantation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_ProjectNameAndBudget_ProjectNameAndBudgetId",
                        column: x => x.ProjectNameAndBudgetId,
                        principalSchema: "Plantation",
                        principalTable: "ProjectNameAndBudget",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_RotationNumber_RotationNoId",
                        column: x => x.RotationNoId,
                        principalSchema: "Plantation",
                        principalTable: "RotationNumber",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_StripType_StripTypeId",
                        column: x => x.StripTypeId,
                        principalSchema: "Plantation",
                        principalTable: "StripType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_TypeOfPlantation_TypeOfPlantationId",
                        column: x => x.TypeOfPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "TypeOfPlantation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RevenueFeelingOrCutting",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    FeelingOrCuttingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    OutstandingSaleValue = table.Column<decimal>(type: "numeric", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    RevenueReceived = table.Column<decimal>(type: "numeric", nullable: false),
                    RevenueReceivedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueFeelingOrCutting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueFeelingOrCutting_FeelingOrCutting_FeelingOrCuttingId",
                        column: x => x.FeelingOrCuttingId,
                        principalSchema: "Plantation",
                        principalTable: "FeelingOrCutting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevenueDistribution",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RevenueFeelingOrCuttingId = table.Column<long>(type: "bigint", nullable: false),
                    AmountInHand = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    GovernmentRevenue = table.Column<double>(type: "double precision", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    NumberOrFemale = table.Column<int>(type: "integer", nullable: false),
                    NumberOrMale = table.Column<int>(type: "integer", nullable: false),
                    OutStandingAmount = table.Column<double>(type: "double precision", nullable: false),
                    RevenueCollected = table.Column<double>(type: "double precision", nullable: false),
                    RevenueDistributionTypeEnum = table.Column<int>(type: "integer", nullable: false),
                    ShareInPercentage = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueDistribution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueDistribution_RevenueFeelingOrCutting_RevenueFeelingO~",
                        column: x => x.RevenueFeelingOrCuttingId,
                        principalSchema: "Plantation",
                        principalTable: "RevenueFeelingOrCutting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankDeposit",
                schema: "Plantation",
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
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    DepositAmount = table.Column<double>(type: "double precision", nullable: false),
                    DepositDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDeposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDeposit_RevenueDistribution_RevenueDistributionId",
                        column: x => x.RevenueDistributionId,
                        principalSchema: "Plantation",
                        principalTable: "RevenueDistribution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevenueOrDistributedAmount",
                schema: "Plantation",
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
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateOccurred = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueOrDistributedAmount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueOrDistributedAmount_RevenueDistribution_RevenueDistr~",
                        column: x => x.RevenueDistributionId,
                        principalSchema: "Plantation",
                        principalTable: "RevenueDistribution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankDeposit_RevenueDistributionId",
                schema: "Plantation",
                table: "BankDeposit",
                column: "RevenueDistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_DistrictId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_DivisionId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_ForestBeatId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_ForestCircleId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_ForestDivisionId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_ForestRangeId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_NewRaisedPlantationId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_NgoId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_RotationNoId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "RotationNoId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_StripTypeId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "StripTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_TypeOfPlantationId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "TypeOfPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_UnionId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_UpazillaId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_DistrictId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_DivisionId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_ForestBeatId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_ForestCircleId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_ForestDivisionId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_ForestRangeId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_NgoId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_ProjectNameAndBudgetId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "ProjectNameAndBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_StripTypeId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "StripTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_TypeOfPlantationId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "TypeOfPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_UnionId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_UpazillaId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_DistrictId",
                schema: "Plantation",
                table: "Reforestation",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_DivisionId",
                schema: "Plantation",
                table: "Reforestation",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_ForestBeatId",
                schema: "Plantation",
                table: "Reforestation",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_ForestCircleId",
                schema: "Plantation",
                table: "Reforestation",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_ForestDivisionId",
                schema: "Plantation",
                table: "Reforestation",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_ForestRangeId",
                schema: "Plantation",
                table: "Reforestation",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_NewRaisedPlantationId",
                schema: "Plantation",
                table: "Reforestation",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_NgoId",
                schema: "Plantation",
                table: "Reforestation",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_ProjectNameAndBudgetId",
                schema: "Plantation",
                table: "Reforestation",
                column: "ProjectNameAndBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_RotationNoId",
                schema: "Plantation",
                table: "Reforestation",
                column: "RotationNoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_StripTypeId",
                schema: "Plantation",
                table: "Reforestation",
                column: "StripTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_TypeOfPlantationId",
                schema: "Plantation",
                table: "Reforestation",
                column: "TypeOfPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_UnionId",
                schema: "Plantation",
                table: "Reforestation",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_UpazillaId",
                schema: "Plantation",
                table: "Reforestation",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueDistribution_RevenueFeelingOrCuttingId",
                schema: "Plantation",
                table: "RevenueDistribution",
                column: "RevenueFeelingOrCuttingId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueFeelingOrCutting_FeelingOrCuttingId",
                schema: "Plantation",
                table: "RevenueFeelingOrCutting",
                column: "FeelingOrCuttingId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueOrDistributedAmount_RevenueDistributionId",
                schema: "Plantation",
                table: "RevenueOrDistributedAmount",
                column: "RevenueDistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_StripType_TypeOfPlantationId",
                schema: "Plantation",
                table: "StripType",
                column: "TypeOfPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfPlantationRevenues_TypeOfPlantationId",
                schema: "Plantation",
                table: "TypeOfPlantationRevenues",
                column: "TypeOfPlantationId");
        }
    }
}
