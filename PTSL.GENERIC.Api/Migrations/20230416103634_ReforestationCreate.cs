using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ReforestationCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reforestation ",
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
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: true),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: true),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: true),
                    FcvId = table.Column<long>(type: "bigint", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: true),
                    NgoId = table.Column<long>(type: "bigint", nullable: true),
                    StripTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectNameAndBudgetId = table.Column<long>(type: "bigint", nullable: true),
                    TypeOfPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    PlantationArea = table.Column<string>(type: "text", nullable: true),
                    PlantationYear = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PlantationLocation = table.Column<string>(type: "text", nullable: true),
                    PlantationEstablishmentCostNurseryTk = table.Column<decimal>(type: "numeric", nullable: true),
                    PlantationEstablishmentCostPlantationTk = table.Column<decimal>(type: "numeric", nullable: true),
                    PlantationEstablishmentCostTotalTk = table.Column<decimal>(type: "numeric", nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationMale = table.Column<long>(type: "bigint", nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationFemale = table.Column<long>(type: "bigint", nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationTotal = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberNurseryMale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberNurseryFemale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberNurseryTotal = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberPlantationMale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberPlantationFemale = table.Column<long>(type: "bigint", nullable: true),
                    LaborInvolvedNumberPlantationTotal = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfBeneficiariesMale = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfBeneficiariesFemale = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfBeneficiariesTotal = table.Column<long>(type: "bigint", nullable: true),
                    IsAccountMaintainedByTffSubCommitee = table.Column<bool>(type: "boolean", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    YearOfFelling = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RotationInYear = table.Column<long>(type: "bigint", nullable: true),
                    RotationNoId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reforestation ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reforestation _District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _NewRaisedPlantation_NewRaisedPlantationId",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "NewRaisedPlantation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _ProjectNameAndBudget_ProjectNameAndBudgetId",
                        column: x => x.ProjectNameAndBudgetId,
                        principalSchema: "Plantation",
                        principalTable: "ProjectNameAndBudget",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _RotationNumber_RotationNoId",
                        column: x => x.RotationNoId,
                        principalSchema: "Plantation",
                        principalTable: "RotationNumber",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _StripType_StripTypeId",
                        column: x => x.StripTypeId,
                        principalSchema: "Plantation",
                        principalTable: "StripType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _TypeOfPlantation_TypeOfPlantationId",
                        column: x => x.TypeOfPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "TypeOfPlantation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reforestation _Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _DistrictId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _DivisionId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _ForestBeatId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _ForestCircleId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _ForestDivisionId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _ForestRangeId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _NewRaisedPlantationId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _NgoId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _ProjectNameAndBudgetId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "ProjectNameAndBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _RotationNoId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "RotationNoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _StripTypeId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "StripTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _TypeOfPlantationId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "TypeOfPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation _UpazillaId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "UpazillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reforestation ",
                schema: "Plantation");
        }
    }
}
