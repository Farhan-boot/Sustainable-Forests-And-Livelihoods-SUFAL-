using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class PatrollingScheduleInformetion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatrollingScheduleInformetion",
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
                    Date = table.Column<DateTime>(nullable: true),
                    PatrollingDescription = table.Column<DateTime>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    PatrollingArea = table.Column<string>(nullable: true),
                    AllocatedAmountMonth = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatrollingScheduleInformetion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatrollingScheduleInformetion_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatrollingScheduleInformetion_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatrollingScheduleInformetion_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatrollingScheduleInformetion_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatrollingScheduleInformetion_ForestDivisions_ForestDivisio~",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatrollingScheduleInformetion_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatrollingScheduleInformetion_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatrollingScheduleInformetion_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatrollingPaymentInformetion",
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
                    PatrollingScheduleInformetionId = table.Column<long>(nullable: true),
                    SurveyId = table.Column<long>(nullable: true),
                    AmountOfHonoraryAllowance = table.Column<double>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatrollingPaymentInformetion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatrollingPaymentInformetion_PatrollingScheduleInformetion_~",
                        column: x => x.PatrollingScheduleInformetionId,
                        principalTable: "PatrollingScheduleInformetion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatrollingPaymentInformetion_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingPaymentInformetion_PatrollingScheduleInformetionId",
                table: "PatrollingPaymentInformetion",
                column: "PatrollingScheduleInformetionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingPaymentInformetion_SurveyId",
                table: "PatrollingPaymentInformetion",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingScheduleInformetion_DistrictId",
                table: "PatrollingScheduleInformetion",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingScheduleInformetion_DivisionId",
                table: "PatrollingScheduleInformetion",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingScheduleInformetion_ForestBeatId",
                table: "PatrollingScheduleInformetion",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingScheduleInformetion_ForestCircleId",
                table: "PatrollingScheduleInformetion",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingScheduleInformetion_ForestDivisionId",
                table: "PatrollingScheduleInformetion",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingScheduleInformetion_ForestRangeId",
                table: "PatrollingScheduleInformetion",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingScheduleInformetion_NgoId",
                table: "PatrollingScheduleInformetion",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingScheduleInformetion_UpazillaId",
                table: "PatrollingScheduleInformetion",
                column: "UpazillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatrollingPaymentInformetion");

            migrationBuilder.DropTable(
                name: "PatrollingScheduleInformetion");
        }
    }
}
