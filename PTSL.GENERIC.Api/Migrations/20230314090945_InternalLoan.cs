using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class InternalLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "InternalLoan");

            migrationBuilder.CreateTable(
                name: "InternalLoanInformations",
                schema: "InternalLoan",
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
                    ForestCircleId = table.Column<long>(nullable: false),
                    ForestDivisionId = table.Column<long>(nullable: false),
                    ForestRangeId = table.Column<long>(nullable: false),
                    ForestBeatId = table.Column<long>(nullable: false),
                    ForestFcvVcfId = table.Column<long>(nullable: false),
                    DivisionId = table.Column<long>(nullable: false),
                    DistrictId = table.Column<long>(nullable: false),
                    UpazillaId = table.Column<long>(nullable: false),
                    UnionId = table.Column<long>(nullable: true),
                    NgoId = table.Column<long>(nullable: false),
                    SurveyId = table.Column<long>(nullable: false),
                    LDFCount = table.Column<int>(nullable: false),
                    TotalAllocatedLoanAmount = table.Column<double>(nullable: false),
                    MaximumRepaymentMonth = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ServiceChargePercentage = table.Column<double>(nullable: false),
                    SecurityChargePercentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalLoanInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalLoanInformations_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalLoanInformations_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalLoanInformations_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalLoanInformations_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalLoanInformations_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalLoanInformations_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalLoanInformations_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalLoanInformations_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalLoanInformations_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalLoanInformations_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalLoanInformations_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternalLoanInformations_DistrictId",
                schema: "InternalLoan",
                table: "InternalLoanInformations",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalLoanInformations_DivisionId",
                schema: "InternalLoan",
                table: "InternalLoanInformations",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalLoanInformations_ForestBeatId",
                schema: "InternalLoan",
                table: "InternalLoanInformations",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalLoanInformations_ForestCircleId",
                schema: "InternalLoan",
                table: "InternalLoanInformations",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalLoanInformations_ForestDivisionId",
                schema: "InternalLoan",
                table: "InternalLoanInformations",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalLoanInformations_ForestFcvVcfId",
                schema: "InternalLoan",
                table: "InternalLoanInformations",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalLoanInformations_ForestRangeId",
                schema: "InternalLoan",
                table: "InternalLoanInformations",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalLoanInformations_NgoId",
                schema: "InternalLoan",
                table: "InternalLoanInformations",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalLoanInformations_SurveyId",
                schema: "InternalLoan",
                table: "InternalLoanInformations",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalLoanInformations_UnionId",
                schema: "InternalLoan",
                table: "InternalLoanInformations",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalLoanInformations_UpazillaId",
                schema: "InternalLoan",
                table: "InternalLoanInformations",
                column: "UpazillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalLoanInformations",
                schema: "InternalLoan");
        }
    }
}
