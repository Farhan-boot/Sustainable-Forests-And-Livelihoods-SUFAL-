using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ReforestationAndCuttingPlantation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaborInformations_NewRaisedPlantations_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "LaborInformations");

            migrationBuilder.DropColumn(
                name: "ScientificName",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropColumn(
                name: "SpeciesName",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.AddColumn<long>(
                name: "NurseryInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "NurseryRaisedSeedlingInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "LaborInformations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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
                    TotalTreeMarked = table.Column<int>(type: "integer", nullable: false),
                    MarkingCost = table.Column<double>(type: "double precision", nullable: false),
                    StandingTreeMarkingListUrl = table.Column<string>(type: "text", nullable: false),
                    MarkedTimber = table.Column<int>(type: "integer", nullable: false),
                    MarkedTimberUnitId = table.Column<long>(type: "bigint", nullable: false),
                    MarkedPole = table.Column<int>(type: "integer", nullable: false),
                    MarkedPoleUnitId = table.Column<long>(type: "bigint", nullable: false),
                    MarkedFuelWood = table.Column<int>(type: "integer", nullable: false),
                    MarkedFuelWoodUnitId = table.Column<long>(type: "bigint", nullable: false),
                    FinancialYearId = table.Column<long>(type: "bigint", nullable: false),
                    RotationNo = table.Column<int>(type: "integer", nullable: false),
                    TotalNumberOfLots = table.Column<int>(type: "integer", nullable: false),
                    ProducedTimber = table.Column<int>(type: "integer", nullable: false),
                    ProducedTimberUnitId = table.Column<long>(type: "bigint", nullable: false),
                    ProducedPole = table.Column<int>(type: "integer", nullable: false),
                    ProducedPoleUnitId = table.Column<long>(type: "bigint", nullable: false),
                    ProducedFuelWood = table.Column<int>(type: "integer", nullable: false),
                    ProducedFuelWoodUnitId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingPlantations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuttingPlantations_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalSchema: "GS",
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuttingPlantations_NewRaisedPlantations_NewRaisedPlantation~",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuttingPlantations_PlantationUnits_MarkedFuelWoodUnitId",
                        column: x => x.MarkedFuelWoodUnitId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuttingPlantations_PlantationUnits_MarkedPoleUnitId",
                        column: x => x.MarkedPoleUnitId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuttingPlantations_PlantationUnits_MarkedTimberUnitId",
                        column: x => x.MarkedTimberUnitId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuttingPlantations_PlantationUnits_ProducedFuelWoodUnitId",
                        column: x => x.ProducedFuelWoodUnitId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuttingPlantations_PlantationUnits_ProducedPoleUnitId",
                        column: x => x.ProducedPoleUnitId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuttingPlantations_PlantationUnits_ProducedTimberUnitId",
                        column: x => x.ProducedTimberUnitId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replantations",
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
                    FinancialYearId = table.Column<long>(type: "bigint", nullable: false),
                    RotationYears = table.Column<int>(type: "integer", nullable: false),
                    PlantationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    PlantationArea = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_Replantations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replantations_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalSchema: "GS",
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Replantations_NewRaisedPlantations_NewRaisedPlantationId",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Replantations_PlantationTypes_PlantationTypeId",
                        column: x => x.PlantationTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LotWiseSellingInformations",
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
                    LotNumber = table.Column<string>(type: "text", nullable: false),
                    CuttingOrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TenderNotificationInformation = table.Column<string>(type: "text", nullable: false),
                    ContractorName = table.Column<string>(type: "text", nullable: false),
                    ContractorMobileNumber = table.Column<string>(type: "text", nullable: false),
                    ContractorNID = table.Column<string>(type: "text", nullable: false),
                    ContractorAddress = table.Column<string>(type: "text", nullable: true),
                    LotWiseTimber = table.Column<int>(type: "integer", nullable: false),
                    LotWiseTimberUnitId = table.Column<long>(type: "bigint", nullable: false),
                    LotWisePole = table.Column<int>(type: "integer", nullable: false),
                    LotWisePoleUnitId = table.Column<long>(type: "bigint", nullable: false),
                    LotWiseFuelWood = table.Column<int>(type: "integer", nullable: false),
                    LotWiseFuelWoodUnitId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotWiseSellingInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotWiseSellingInformations_CuttingPlantations_CuttingPlanta~",
                        column: x => x.CuttingPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "CuttingPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotWiseSellingInformations_PlantationUnits_LotWiseFuelWoodU~",
                        column: x => x.LotWiseFuelWoodUnitId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotWiseSellingInformations_PlantationUnits_LotWisePoleUnitId",
                        column: x => x.LotWisePoleUnitId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotWiseSellingInformations_PlantationUnits_LotWiseTimberUni~",
                        column: x => x.LotWiseTimberUnitId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplantationCostInfos",
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
                    ReplantationId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_ReplantationCostInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplantationCostInfos_CostTypes_CostTypeId",
                        column: x => x.CostTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "CostTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplantationCostInfos_Replantations_ReplantationId",
                        column: x => x.ReplantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "Replantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplantationInspectionMaps",
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
                    ReplantationId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionDetailsId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplantationInspectionMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplantationInspectionMaps_InspectionDetailss_InspectionDet~",
                        column: x => x.InspectionDetailsId,
                        principalSchema: "SocialForestry",
                        principalTable: "InspectionDetailss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplantationInspectionMaps_Replantations_ReplantationId",
                        column: x => x.ReplantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "Replantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplantationLaborInfos",
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
                    ReplantationId = table.Column<long>(type: "bigint", nullable: false),
                    LaborCostTypeId = table.Column<long>(type: "bigint", nullable: false),
                    LaborCostDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalMale = table.Column<int>(type: "integer", nullable: false),
                    TotalFemale = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    Attachment = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplantationLaborInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplantationLaborInfos_LaborCostTypes_LaborCostTypeId",
                        column: x => x.LaborCostTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "LaborCostTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplantationLaborInfos_Replantations_ReplantationId",
                        column: x => x.ReplantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "Replantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplantationNurseryInfos",
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
                    ReplantationId = table.Column<long>(type: "bigint", nullable: false),
                    NurseryInformationId = table.Column<long>(type: "bigint", nullable: false),
                    NurseryRaisedSeedlingInformationId = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfSeedlingPlanted = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplantationNurseryInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplantationNurseryInfos_NurseryInformations_NurseryInforma~",
                        column: x => x.NurseryInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplantationNurseryInfos_NurseryRaisedSeedlingInformations_~",
                        column: x => x.NurseryRaisedSeedlingInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryRaisedSeedlingInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReplantationNurseryInfos_Replantations_ReplantationId",
                        column: x => x.ReplantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "Replantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplantationSocialForestryBeneficiaryMaps",
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
                    ReplantationId = table.Column<long>(type: "bigint", nullable: false),
                    PBSAGroupId = table.Column<string>(type: "text", nullable: false),
                    CheckIfPBSAIsSigned = table.Column<bool>(type: "boolean", nullable: false),
                    AgreementUploadFileUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplantationSocialForestryBeneficiaryMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplantationSocialForestryBeneficiaryMaps_Replantations_Rep~",
                        column: x => x.ReplantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "Replantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplantationSocialForestryBeneficiaryMaps_SocialForestryBen~",
                        column: x => x.SocialForestryBeneficiaryId,
                        principalSchema: "SocialForestry",
                        principalTable: "SocialForestryBeneficiarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantationPlants_NurseryInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants",
                column: "NurseryInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantationPlants_NurseryRaisedSeedlingInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants",
                column: "NurseryRaisedSeedlingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingPlantations_FinancialYearId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingPlantations_MarkedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "MarkedFuelWoodUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingPlantations_MarkedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "MarkedPoleUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingPlantations_MarkedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "MarkedTimberUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingPlantations_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingPlantations_ProducedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "ProducedFuelWoodUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingPlantations_ProducedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "ProducedPoleUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingPlantations_ProducedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "ProducedTimberUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LotWiseSellingInformations_CuttingPlantationId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                column: "CuttingPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_LotWiseSellingInformations_LotWiseFuelWoodUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                column: "LotWiseFuelWoodUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LotWiseSellingInformations_LotWisePoleUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                column: "LotWisePoleUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LotWiseSellingInformations_LotWiseTimberUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                column: "LotWiseTimberUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplantationCostInfos_CostTypeId",
                schema: "SocialForestry",
                table: "ReplantationCostInfos",
                column: "CostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplantationCostInfos_ReplantationId",
                schema: "SocialForestry",
                table: "ReplantationCostInfos",
                column: "ReplantationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplantationInspectionMaps_InspectionDetailsId",
                schema: "SocialForestry",
                table: "ReplantationInspectionMaps",
                column: "InspectionDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplantationInspectionMaps_ReplantationId",
                schema: "SocialForestry",
                table: "ReplantationInspectionMaps",
                column: "ReplantationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplantationLaborInfos_LaborCostTypeId",
                schema: "SocialForestry",
                table: "ReplantationLaborInfos",
                column: "LaborCostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplantationLaborInfos_ReplantationId",
                schema: "SocialForestry",
                table: "ReplantationLaborInfos",
                column: "ReplantationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplantationNurseryInfos_NurseryInformationId",
                schema: "SocialForestry",
                table: "ReplantationNurseryInfos",
                column: "NurseryInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplantationNurseryInfos_NurseryRaisedSeedlingInformationId",
                schema: "SocialForestry",
                table: "ReplantationNurseryInfos",
                column: "NurseryRaisedSeedlingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplantationNurseryInfos_ReplantationId",
                schema: "SocialForestry",
                table: "ReplantationNurseryInfos",
                column: "ReplantationId");

            migrationBuilder.CreateIndex(
                name: "IX_Replantations_FinancialYearId",
                schema: "SocialForestry",
                table: "Replantations",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Replantations_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "Replantations",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_Replantations_PlantationTypeId",
                schema: "SocialForestry",
                table: "Replantations",
                column: "PlantationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplantationSocialForestryBeneficiaryMaps_ReplantationId",
                schema: "SocialForestry",
                table: "ReplantationSocialForestryBeneficiaryMaps",
                column: "ReplantationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplantationSocialForestryBeneficiaryMaps_SocialForestryBen~",
                schema: "SocialForestry",
                table: "ReplantationSocialForestryBeneficiaryMaps",
                column: "SocialForestryBeneficiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaborInformations_NewRaisedPlantations_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "LaborInformations",
                column: "NewRaisedPlantationId",
                principalSchema: "SocialForestry",
                principalTable: "NewRaisedPlantations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantationPlants_NurseryInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants",
                column: "NurseryInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantationPlants_NurseryRaisedSeedlingInformations_NurseryR~",
                schema: "SocialForestry",
                table: "PlantationPlants",
                column: "NurseryRaisedSeedlingInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryRaisedSeedlingInformations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaborInformations_NewRaisedPlantations_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "LaborInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantationPlants_NurseryInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantationPlants_NurseryRaisedSeedlingInformations_NurseryR~",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropTable(
                name: "LotWiseSellingInformations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "ReplantationCostInfos",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "ReplantationInspectionMaps",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "ReplantationLaborInfos",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "ReplantationNurseryInfos",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "ReplantationSocialForestryBeneficiaryMaps",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "CuttingPlantations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "Replantations",
                schema: "SocialForestry");

            migrationBuilder.DropIndex(
                name: "IX_PlantationPlants_NurseryInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropIndex(
                name: "IX_PlantationPlants_NurseryRaisedSeedlingInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropColumn(
                name: "NurseryInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropColumn(
                name: "NurseryRaisedSeedlingInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.AddColumn<string>(
                name: "ScientificName",
                schema: "SocialForestry",
                table: "PlantationPlants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpeciesName",
                schema: "SocialForestry",
                table: "PlantationPlants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "LaborInformations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_LaborInformations_NewRaisedPlantations_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "LaborInformations",
                column: "NewRaisedPlantationId",
                principalSchema: "SocialForestry",
                principalTable: "NewRaisedPlantations",
                principalColumn: "Id");
        }
    }
}
