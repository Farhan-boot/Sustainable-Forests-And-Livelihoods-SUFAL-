using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class PlantationRevenue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiaryPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation");

            migrationBuilder.DropColumn(
                name: "ForestDepartmentPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation");

            migrationBuilder.DropColumn(
                name: "TFFPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation");

            migrationBuilder.CreateTable(
                name: "TypeOfPlantationRevenue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TypeOfPlantationId = table.Column<long>(type: "bigint", nullable: false),
                    RevenueDistributionTypeEnum = table.Column<int>(type: "integer", nullable: false),
                    RevenuePercentage = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPlantationRevenue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeOfPlantationRevenue_TypeOfPlantation_TypeOfPlantationId",
                        column: x => x.TypeOfPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "TypeOfPlantation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfPlantationRevenue_TypeOfPlantationId",
                table: "TypeOfPlantationRevenue",
                column: "TypeOfPlantationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeOfPlantationRevenue");

            migrationBuilder.AddColumn<double>(
                name: "BeneficiaryPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ForestDepartmentPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TFFPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
