using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NurseryDistribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcernedOfficialMap_ConcernedOfficials_ConcernedOfficialId",
                table: "ConcernedOfficialMap");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcernedOfficialMap_NewRaisedPlantations_NewRaisedPlantati~",
                table: "ConcernedOfficialMap");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcernedOfficialMap_NurseryInformations_NursaryInformation~",
                table: "ConcernedOfficialMap");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailsMap_NewRaisedPlantations_NewRaisedPlantati~",
                table: "InspectionDetailsMap");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailsMap_NurseryInformations_NurseryInformation~",
                table: "InspectionDetailsMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionDetailsMap",
                table: "InspectionDetailsMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConcernedOfficialMap",
                table: "ConcernedOfficialMap");

            migrationBuilder.RenameTable(
                name: "InspectionDetailsMap",
                newName: "InspectionDetailsMaps",
                newSchema: "SocialForestry");

            migrationBuilder.RenameTable(
                name: "ConcernedOfficialMap",
                newName: "ConcernedOfficialMaps",
                newSchema: "SocialForestry");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionDetailsMap_NurseryInformationId",
                schema: "SocialForestry",
                table: "InspectionDetailsMaps",
                newName: "IX_InspectionDetailsMaps_NurseryInformationId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionDetailsMap_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "InspectionDetailsMaps",
                newName: "IX_InspectionDetailsMaps_NewRaisedPlantationId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionDetailsMap_InspectionDetailsId",
                schema: "SocialForestry",
                table: "InspectionDetailsMaps",
                newName: "IX_InspectionDetailsMaps_InspectionDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_ConcernedOfficialMap_NursaryInformationId",
                schema: "SocialForestry",
                table: "ConcernedOfficialMaps",
                newName: "IX_ConcernedOfficialMaps_NursaryInformationId");

            migrationBuilder.RenameIndex(
                name: "IX_ConcernedOfficialMap_NewRaisedPlantationId",
                schema: "SocialForestry",
                table: "ConcernedOfficialMaps",
                newName: "IX_ConcernedOfficialMaps_NewRaisedPlantationId");

            migrationBuilder.RenameIndex(
                name: "IX_ConcernedOfficialMap_ConcernedOfficialId",
                schema: "SocialForestry",
                table: "ConcernedOfficialMaps",
                newName: "IX_ConcernedOfficialMaps_ConcernedOfficialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionDetailsMaps",
                schema: "SocialForestry",
                table: "InspectionDetailsMaps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConcernedOfficialMaps",
                schema: "SocialForestry",
                table: "ConcernedOfficialMaps",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "NurseryDistributions",
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
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    NurseryId = table.Column<long>(type: "bigint", nullable: false),
                    NurseryInformationId = table.Column<long>(type: "bigint", nullable: true),
                    NurseryRaisedSeedlingId = table.Column<long>(type: "bigint", nullable: true),
                    SpeciesName = table.Column<string>(type: "text", nullable: true),
                    NumberofSeedlingTobeDistributed = table.Column<long>(type: "bigint", nullable: true),
                    DistributedTo = table.Column<string>(type: "text", nullable: false),
                    BeneficiaryNid = table.Column<string>(type: "text", nullable: false),
                    MobileNo = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseryDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseryDistributions_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryDistributions_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryDistributions_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryDistributions_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryDistributions_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryDistributions_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryDistributions_NurseryInformations_NurseryInformation~",
                        column: x => x.NurseryInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NurseryDistributions_NurseryRaisedSeedlingInformations_Nurs~",
                        column: x => x.NurseryRaisedSeedlingId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryRaisedSeedlingInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NurseryDistributions_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NurseryDistributions_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_DistrictId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_DivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_ForestBeatId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_ForestCircleId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_ForestDivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_ForestRangeId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_NurseryInformationId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "NurseryInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_NurseryRaisedSeedlingId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "NurseryRaisedSeedlingId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_UnionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_UpazillaId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "UpazillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcernedOfficialMaps_ConcernedOfficials_ConcernedOfficialId",
                schema: "SocialForestry",
                table: "ConcernedOfficialMaps",
                column: "ConcernedOfficialId",
                principalSchema: "SocialForestry",
                principalTable: "ConcernedOfficials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcernedOfficialMaps_NewRaisedPlantations_NewRaisedPlantat~",
                schema: "SocialForestry",
                table: "ConcernedOfficialMaps",
                column: "NewRaisedPlantationId",
                principalSchema: "SocialForestry",
                principalTable: "NewRaisedPlantations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcernedOfficialMaps_NurseryInformations_NursaryInformatio~",
                schema: "SocialForestry",
                table: "ConcernedOfficialMaps",
                column: "NursaryInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryInformations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailsMaps_InspectionDetailss_InspectionDetailsId",
                schema: "SocialForestry",
                table: "InspectionDetailsMaps",
                column: "InspectionDetailsId",
                principalSchema: "SocialForestry",
                principalTable: "InspectionDetailss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailsMaps_NewRaisedPlantations_NewRaisedPlantat~",
                schema: "SocialForestry",
                table: "InspectionDetailsMaps",
                column: "NewRaisedPlantationId",
                principalSchema: "SocialForestry",
                principalTable: "NewRaisedPlantations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailsMaps_NurseryInformations_NurseryInformatio~",
                schema: "SocialForestry",
                table: "InspectionDetailsMaps",
                column: "NurseryInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryInformations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcernedOfficialMaps_ConcernedOfficials_ConcernedOfficialId",
                schema: "SocialForestry",
                table: "ConcernedOfficialMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcernedOfficialMaps_NewRaisedPlantations_NewRaisedPlantat~",
                schema: "SocialForestry",
                table: "ConcernedOfficialMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcernedOfficialMaps_NurseryInformations_NursaryInformatio~",
                schema: "SocialForestry",
                table: "ConcernedOfficialMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailsMaps_InspectionDetailss_InspectionDetailsId",
                schema: "SocialForestry",
                table: "InspectionDetailsMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailsMaps_NewRaisedPlantations_NewRaisedPlantat~",
                schema: "SocialForestry",
                table: "InspectionDetailsMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailsMaps_NurseryInformations_NurseryInformatio~",
                schema: "SocialForestry",
                table: "InspectionDetailsMaps");

            migrationBuilder.DropTable(
                name: "NurseryDistributions",
                schema: "SocialForestry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionDetailsMaps",
                schema: "SocialForestry",
                table: "InspectionDetailsMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConcernedOfficialMaps",
                schema: "SocialForestry",
                table: "ConcernedOfficialMaps");

            migrationBuilder.RenameTable(
                name: "InspectionDetailsMaps",
                schema: "SocialForestry",
                newName: "InspectionDetailsMap");

            migrationBuilder.RenameTable(
                name: "ConcernedOfficialMaps",
                schema: "SocialForestry",
                newName: "ConcernedOfficialMap");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionDetailsMaps_NurseryInformationId",
                table: "InspectionDetailsMap",
                newName: "IX_InspectionDetailsMap_NurseryInformationId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionDetailsMaps_NewRaisedPlantationId",
                table: "InspectionDetailsMap",
                newName: "IX_InspectionDetailsMap_NewRaisedPlantationId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionDetailsMaps_InspectionDetailsId",
                table: "InspectionDetailsMap",
                newName: "IX_InspectionDetailsMap_InspectionDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_ConcernedOfficialMaps_NursaryInformationId",
                table: "ConcernedOfficialMap",
                newName: "IX_ConcernedOfficialMap_NursaryInformationId");

            migrationBuilder.RenameIndex(
                name: "IX_ConcernedOfficialMaps_NewRaisedPlantationId",
                table: "ConcernedOfficialMap",
                newName: "IX_ConcernedOfficialMap_NewRaisedPlantationId");

            migrationBuilder.RenameIndex(
                name: "IX_ConcernedOfficialMaps_ConcernedOfficialId",
                table: "ConcernedOfficialMap",
                newName: "IX_ConcernedOfficialMap_ConcernedOfficialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionDetailsMap",
                table: "InspectionDetailsMap",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConcernedOfficialMap",
                table: "ConcernedOfficialMap",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcernedOfficialMap_ConcernedOfficials_ConcernedOfficialId",
                table: "ConcernedOfficialMap",
                column: "ConcernedOfficialId",
                principalSchema: "SocialForestry",
                principalTable: "ConcernedOfficials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcernedOfficialMap_NewRaisedPlantations_NewRaisedPlantati~",
                table: "ConcernedOfficialMap",
                column: "NewRaisedPlantationId",
                principalSchema: "SocialForestry",
                principalTable: "NewRaisedPlantations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcernedOfficialMap_NurseryInformations_NursaryInformation~",
                table: "ConcernedOfficialMap",
                column: "NursaryInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryInformations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap",
                column: "InspectionDetailsId",
                principalSchema: "SocialForestry",
                principalTable: "InspectionDetailss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailsMap_NewRaisedPlantations_NewRaisedPlantati~",
                table: "InspectionDetailsMap",
                column: "NewRaisedPlantationId",
                principalSchema: "SocialForestry",
                principalTable: "NewRaisedPlantations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailsMap_NurseryInformations_NurseryInformation~",
                table: "InspectionDetailsMap",
                column: "NurseryInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryInformations",
                principalColumn: "Id");
        }
    }
}
