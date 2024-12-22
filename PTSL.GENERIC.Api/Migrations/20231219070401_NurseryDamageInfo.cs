using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NurseryDamageInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NurseryDamageInformation",
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
                    DateOfOccurrence = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PlantationCauseOfDamageId = table.Column<long>(type: "bigint", nullable: false),
                    DamageDescription = table.Column<string>(type: "text", nullable: true),
                    InspectedByAuthority = table.Column<bool>(type: "boolean", nullable: false),
                    DamageUrl = table.Column<string>(type: "text", nullable: true),
                    InspectionReportUrl = table.Column<string>(type: "text", nullable: true),
                    ActionTaken = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseryDamageInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseryDamageInformation_NurseryInformations_NurseryInforma~",
                        column: x => x.NurseryInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseryDamageInformation_PlantationCauseOfDamages_Plantatio~",
                        column: x => x.PlantationCauseOfDamageId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationCauseOfDamages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDamageInformation_NurseryInformationId",
                table: "NurseryDamageInformation",
                column: "NurseryInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDamageInformation_PlantationCauseOfDamageId",
                table: "NurseryDamageInformation",
                column: "PlantationCauseOfDamageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NurseryDamageInformation");
        }
    }
}
