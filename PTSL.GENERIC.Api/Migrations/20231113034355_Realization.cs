using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class Realization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Realizations",
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
                    CuttingPlantationId = table.Column<long>(type: "bigint", nullable: false),
                    LotNumber = table.Column<string>(type: "text", nullable: false),
                    RealizedAmount = table.Column<double>(type: "double precision", nullable: false),
                    RealizedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VatAndTax = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Realizations_CuttingPlantations_CuttingPlantationId",
                        column: x => x.CuttingPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "CuttingPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Realizations_CuttingPlantationId",
                schema: "SocialForestry",
                table: "Realizations",
                column: "CuttingPlantationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Realizations",
                schema: "SocialForestry");
        }
    }
}
