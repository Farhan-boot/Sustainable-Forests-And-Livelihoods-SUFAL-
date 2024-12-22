using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NursaryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NurseryRaisingSectors",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseryRaisingSectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NurseryTypes",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NurseryInformations",
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
                    NurseryName = table.Column<string>(type: "text", nullable: false),
                    FinancialYearId = table.Column<long>(type: "bigint", nullable: false),
                    SeedlingRaisingTargetNumber = table.Column<int>(type: "integer", nullable: false),
                    ProjectTypeId = table.Column<long>(type: "bigint", nullable: false),
                    EstablishmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SanctionNo = table.Column<string>(type: "text", nullable: true),
                    NurseryTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    LocationLat = table.Column<double>(type: "double precision", nullable: false),
                    LocationLon = table.Column<double>(type: "double precision", nullable: false),
                    TotalNumberOfBed = table.Column<int>(type: "integer", nullable: false),
                    NumberOfSeedlingsPerBed = table.Column<int>(type: "integer", nullable: false),
                    NurseryRaisingSectorId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseryInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseryInformations_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryInformations_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryInformations_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalSchema: "GS",
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryInformations_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryInformations_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryInformations_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryInformations_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryInformations_NurseryRaisingSectors_NurseryRaisingSec~",
                        column: x => x.NurseryRaisingSectorId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryRaisingSectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NurseryInformations_NurseryTypes_NurseryTypeId",
                        column: x => x.NurseryTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryInformations_ProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "ProjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryInformations_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NurseryInformations_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NurseryRaisedSeedlingInformations",
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
                    NurseryInformationId = table.Column<long>(type: "bigint", nullable: false),
                    NurseryRaisingSectorId = table.Column<long>(type: "bigint", nullable: false),
                    SpeciesName = table.Column<string>(type: "text", nullable: false),
                    ScientificName = table.Column<string>(type: "text", nullable: false),
                    SeedlingRaised = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseryRaisedSeedlingInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseryRaisedSeedlingInformations_NurseryInformations_Nurse~",
                        column: x => x.NurseryInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryRaisedSeedlingInformations_NurseryRaisingSectors_Nur~",
                        column: x => x.NurseryRaisingSectorId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryRaisingSectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_DistrictId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_DivisionId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_FinancialYearId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_ForestBeatId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_ForestCircleId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_ForestDivisionId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_ForestRangeId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_NurseryRaisingSectorId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "NurseryRaisingSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_NurseryTypeId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "NurseryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_ProjectTypeId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_UnionId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryInformations_UpazillaId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryRaisedSeedlingInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "NurseryRaisedSeedlingInformations",
                column: "NurseryInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryRaisedSeedlingInformations_NurseryRaisingSectorId",
                schema: "SocialForestry",
                table: "NurseryRaisedSeedlingInformations",
                column: "NurseryRaisingSectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NurseryRaisedSeedlingInformations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "NurseryInformations",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "NurseryRaisingSectors",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "NurseryTypes",
                schema: "SocialForestry");
        }
    }
}
