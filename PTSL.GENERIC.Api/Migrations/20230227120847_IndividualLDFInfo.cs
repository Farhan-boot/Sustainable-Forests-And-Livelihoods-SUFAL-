using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class IndividualLDFInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndividualLDFInfoForms",
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
                    ForestCircleId = table.Column<long>(nullable: false),
                    ForestDivisionId = table.Column<long>(nullable: false),
                    ForestRangeId = table.Column<long>(nullable: false),
                    ForestBeatId = table.Column<long>(nullable: false),
                    ForestFcvVcfId = table.Column<long>(nullable: false),
                    DivisionId = table.Column<long>(nullable: false),
                    DistrictId = table.Column<long>(nullable: false),
                    UpazillaId = table.Column<long>(nullable: false),
                    UnionId = table.Column<long>(nullable: true),
                    SurveyId = table.Column<long>(nullable: false),
                    BeneficiaryName = table.Column<string>(nullable: true),
                    BeneficiaryNid = table.Column<string>(nullable: true),
                    BeneficiaryPhone = table.Column<string>(nullable: true),
                    BeneficiaryGender = table.Column<int>(nullable: true),
                    RequestedLoanAmount = table.Column<double>(nullable: false),
                    ApprovedLoanAmount = table.Column<double>(nullable: false),
                    IndividualLDFInfoStatus = table.Column<int>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    DocumentInfoURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualLDFInfoForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualLDFInfoForms_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualLDFInfoForms_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualLDFInfoForms_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualLDFInfoForms_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualLDFInfoForms_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualLDFInfoForms_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualLDFInfoForms_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualLDFInfoForms_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualLDFInfoForms_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualLDFInfoForms_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_DistrictId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_DivisionId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_ForestBeatId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_ForestCircleId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_ForestDivisionId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_ForestFcvVcfId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_ForestRangeId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_SurveyId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_UnionId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_UpazillaId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "UpazillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualLDFInfoForms",
                schema: "AIG");
        }
    }
}
