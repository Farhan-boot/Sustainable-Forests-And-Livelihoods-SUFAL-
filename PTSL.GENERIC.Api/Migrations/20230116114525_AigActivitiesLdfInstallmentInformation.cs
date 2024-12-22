using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class AigActivitiesLdfInstallmentInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AIG");

            migrationBuilder.CreateTable(
                name: "AigActivitiesLdfInstallmentInformation",
                schema: "AIG",
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
                    ForestFcvVcfId = table.Column<long>(nullable: true),
                    CivilDivisionId = table.Column<long>(nullable: true),
                    CivilDistrictId = table.Column<long>(nullable: true),
                    CivilUpazillaId = table.Column<long>(nullable: true),
                    NgoId = table.Column<long>(nullable: true),
                    BeneficiaryId = table.Column<long>(nullable: true),
                    TradeId = table.Column<long>(nullable: true),
                    IsRecievedTrainingInThisTrade = table.Column<bool>(nullable: true),
                    IsTakenAnyLoan = table.Column<bool>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AigActivitiesLdfInstallmentInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_Surveys_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_District_CivilDistri~",
                        column: x => x.CivilDistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_Division_CivilDivisi~",
                        column: x => x.CivilDivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_Upazilla_CivilUpazil~",
                        column: x => x.CivilUpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_ForestBeats_ForestBe~",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_ForestCircles_Forest~",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_ForestDivisions_Fore~",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_ForestFcvVcfs_Forest~",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_ForestRanges_ForestR~",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_Trade_TradeId",
                        column: x => x.TradeId,
                        principalSchema: "BEN",
                        principalTable: "Trade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_BeneficiaryId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "BeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_CivilDistrictId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "CivilDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_CivilDivisionId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "CivilDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_CivilUpazillaId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "CivilUpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_ForestBeatId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_ForestCircleId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_ForestDivisionId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_ForestFcvVcfId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_ForestRangeId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_NgoId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_TradeId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "TradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AigActivitiesLdfInstallmentInformation",
                schema: "AIG");
        }
    }
}
