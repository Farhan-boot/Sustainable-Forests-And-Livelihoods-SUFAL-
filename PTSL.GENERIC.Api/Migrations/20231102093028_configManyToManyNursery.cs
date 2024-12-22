using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class configManyToManyNursery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcernedOfficialMap",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ConcernedOfficialId = table.Column<long>(type: "bigint", nullable: false),
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    NursaryInformationId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernedOfficialMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcernedOfficialMap_ConcernedOfficials_ConcernedOfficialId",
                        column: x => x.ConcernedOfficialId,
                        principalSchema: "SocialForestry",
                        principalTable: "ConcernedOfficials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcernedOfficialMap_NewRaisedPlantations_NewRaisedPlantati~",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConcernedOfficialMap_NurseryInformations_NursaryInformation~",
                        column: x => x.NursaryInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryInformations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InspectionDetailsMap",
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
                    NurseryInformationId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionDetailsMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionDetailsMap_NewRaisedPlantations_NewRaisedPlantati~",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NewRaisedPlantations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionDetailsMap_NurseryInformations_NurseryInformation~",
                        column: x => x.NurseryInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryInformations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcernedOfficialMap_ConcernedOfficialId",
                table: "ConcernedOfficialMap",
                column: "ConcernedOfficialId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcernedOfficialMap_NewRaisedPlantationId",
                table: "ConcernedOfficialMap",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcernedOfficialMap_NursaryInformationId",
                table: "ConcernedOfficialMap",
                column: "NursaryInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDetailsMap_NewRaisedPlantationId",
                table: "InspectionDetailsMap",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDetailsMap_NurseryInformationId",
                table: "InspectionDetailsMap",
                column: "NurseryInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcernedOfficialMap");

            migrationBuilder.DropTable(
                name: "InspectionDetailsMap");
        }
    }
}
