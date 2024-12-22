using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class PlantationRaisingSector : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PlantationPlantRaisingSectorId",
                schema: "SocialForestry",
                table: "PlantationPlants",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScientificName",
                schema: "SocialForestry",
                table: "PlantationPlants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PlantationPlantRaisingSector",
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
                    table.PrimaryKey("PK_PlantationPlantRaisingSector", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantationPlants_PlantationPlantRaisingSectorId",
                schema: "SocialForestry",
                table: "PlantationPlants",
                column: "PlantationPlantRaisingSectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantationPlants_PlantationPlantRaisingSector_PlantationPla~",
                schema: "SocialForestry",
                table: "PlantationPlants",
                column: "PlantationPlantRaisingSectorId",
                principalTable: "PlantationPlantRaisingSector",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantationPlants_PlantationPlantRaisingSector_PlantationPla~",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropTable(
                name: "PlantationPlantRaisingSector");

            migrationBuilder.DropIndex(
                name: "IX_PlantationPlants_PlantationPlantRaisingSectorId",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropColumn(
                name: "PlantationPlantRaisingSectorId",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropColumn(
                name: "ScientificName",
                schema: "SocialForestry",
                table: "PlantationPlants");
        }
    }
}
