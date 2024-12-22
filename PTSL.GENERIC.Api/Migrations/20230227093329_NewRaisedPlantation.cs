using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class NewRaisedPlantation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    ForestCircleId = table.Column<long>(nullable: true),
                    ForestDivisionId = table.Column<long>(nullable: true),
                    ForestRangeId = table.Column<long>(nullable: true),
                    ForestBeatId = table.Column<long>(nullable: true),
                    FcvId = table.Column<long>(nullable: true),
                    DivisionId = table.Column<long>(nullable: true),
                    DistrictId = table.Column<long>(nullable: true),
                    UpazillaId = table.Column<long>(nullable: true),
                    NgoId = table.Column<long>(nullable: true),
                    ProjectNameAndBudgetId = table.Column<long>(nullable: true),
                    TypeOfPlantationId = table.Column<long>(nullable: true),
                    PlantationArea = table.Column<string>(nullable: true),
                    PlantationYear = table.Column<DateTime>(nullable: true),
                    PlantationLocation = table.Column<string>(nullable: true),
                    PlantationEstablishmentCostNurseryTk = table.Column<decimal>(nullable: true),
                    PlantationEstablishmentCostPlantationTk = table.Column<decimal>(nullable: true),
                    PlantationEstablishmentCostTotalTk = table.Column<decimal>(nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationMale = table.Column<long>(nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationFemale = table.Column<long>(nullable: true),
                    ManpowerlabourEngagedRaisingNurseryPlantationTotal = table.Column<long>(nullable: true),
                    LaborInvolvedNumberNurseryMale = table.Column<long>(nullable: true),
                    LaborInvolvedNumberNurseryFemale = table.Column<long>(nullable: true),
                    LaborInvolvedNumberNurseryTotal = table.Column<long>(nullable: true),
                    LaborInvolvedNumberPlantationMale = table.Column<long>(nullable: true),
                    LaborInvolvedNumberPlantationFemale = table.Column<long>(nullable: true),
                    LaborInvolvedNumberPlantationTotal = table.Column<long>(nullable: true),
                    NumberOfBeneficiariesMale = table.Column<long>(nullable: true),
                    NumberOfBeneficiariesFemale = table.Column<long>(nullable: true),
                    NumberOfBeneficiariesTotal = table.Column<long>(nullable: true),
                    SubCommitteeMaintainPlantationEstablishmentAccount = table.Column<bool>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRaisedPlantation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_ProjectNameAndBudget_ProjectNameAndBudg~",
                        column: x => x.ProjectNameAndBudgetId,
                        principalSchema: "Plantation",
                        principalTable: "ProjectNameAndBudget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_TypeOfPlantation_TypeOfPlantationId",
                        column: x => x.TypeOfPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "TypeOfPlantation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewRaisedPlantation_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_NewRaisedPlantation_TypeOfPlantationId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "TypeOfPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_UpazillaId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "UpazillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewRaisedPlantation",
                schema: "Plantation");
        }
    }
}
