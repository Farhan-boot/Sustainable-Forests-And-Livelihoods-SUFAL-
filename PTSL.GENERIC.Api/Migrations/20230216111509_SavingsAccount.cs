using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class SavingsAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BSA");

            migrationBuilder.CreateTable(
                name: "SavingsAccount",
                schema: "BSA",
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
                    SurveyId = table.Column<long>(nullable: true),
                    StatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsAccount_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavingsAccount_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavingsAccount_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavingsAccount_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavingsAccount_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavingsAccount_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavingsAccount_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavingsAccount_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavingsAccount_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccount_DistrictId",
                schema: "BSA",
                table: "SavingsAccount",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccount_DivisionId",
                schema: "BSA",
                table: "SavingsAccount",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccount_ForestBeatId",
                schema: "BSA",
                table: "SavingsAccount",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccount_ForestCircleId",
                schema: "BSA",
                table: "SavingsAccount",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccount_ForestDivisionId",
                schema: "BSA",
                table: "SavingsAccount",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccount_ForestRangeId",
                schema: "BSA",
                table: "SavingsAccount",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccount_NgoId",
                schema: "BSA",
                table: "SavingsAccount",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccount_SurveyId",
                schema: "BSA",
                table: "SavingsAccount",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccount_UpazillaId",
                schema: "BSA",
                table: "SavingsAccount",
                column: "UpazillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavingsAccount",
                schema: "BSA");
        }
    }
}
