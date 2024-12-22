using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ShareDistribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.AlterColumn<long>(
                name: "ProducedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProducedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProducedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "DistributionFundTypes",
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameBn = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionFundTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DistributionPercentages",
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
                    DistributionFundTypeId = table.Column<long>(type: "bigint", nullable: false),
                    PlantationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Percentage = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionPercentages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistributionPercentages_DistributionFundTypes_DistributionF~",
                        column: x => x.DistributionFundTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "DistributionFundTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistributionPercentages_PlantationTypes_PlantationTypeId",
                        column: x => x.PlantationTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "PlantationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShareDistributions",
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
                    DistributionFundTypeId = table.Column<long>(type: "bigint", nullable: false),
                    SharePercentage = table.Column<double>(type: "double precision", nullable: false),
                    DepositedRevenueAmount = table.Column<double>(type: "double precision", nullable: false),
                    DepositDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    DepositFile = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShareDistributions_CuttingPlantations_CuttingPlantationId",
                        column: x => x.CuttingPlantationId,
                        principalSchema: "SocialForestry",
                        principalTable: "CuttingPlantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShareDistributions_DistributionFundTypes_DistributionFundTy~",
                        column: x => x.DistributionFundTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "DistributionFundTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistributedToBeneficiarys",
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
                    ShareDistributionId = table.Column<long>(type: "bigint", nullable: false),
                    SocialForestryBeneficiaryId = table.Column<long>(type: "bigint", nullable: false),
                    DepositedRevenueAmount = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributedToBeneficiarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistributedToBeneficiarys_ShareDistributions_ShareDistribut~",
                        column: x => x.ShareDistributionId,
                        principalSchema: "SocialForestry",
                        principalTable: "ShareDistributions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistributedToBeneficiarys_SocialForestryBeneficiarys_Social~",
                        column: x => x.SocialForestryBeneficiaryId,
                        principalSchema: "SocialForestry",
                        principalTable: "SocialForestryBeneficiarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistributedToBeneficiarys_ShareDistributionId",
                schema: "SocialForestry",
                table: "DistributedToBeneficiarys",
                column: "ShareDistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedToBeneficiarys_SocialForestryBeneficiaryId",
                schema: "SocialForestry",
                table: "DistributedToBeneficiarys",
                column: "SocialForestryBeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributionPercentages_DistributionFundTypeId",
                schema: "SocialForestry",
                table: "DistributionPercentages",
                column: "DistributionFundTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributionPercentages_PlantationTypeId",
                schema: "SocialForestry",
                table: "DistributionPercentages",
                column: "PlantationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShareDistributions_CuttingPlantationId",
                schema: "SocialForestry",
                table: "ShareDistributions",
                column: "CuttingPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShareDistributions_DistributionFundTypeId",
                schema: "SocialForestry",
                table: "ShareDistributions",
                column: "DistributionFundTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "ProducedFuelWoodUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "ProducedPoleUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "ProducedTimberUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropTable(
                name: "DistributedToBeneficiarys",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "DistributionPercentages",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "ShareDistributions",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "DistributionFundTypes",
                schema: "SocialForestry");

            migrationBuilder.AlterColumn<long>(
                name: "ProducedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProducedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProducedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "ProducedFuelWoodUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "ProducedPoleUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_ProducedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "ProducedTimberUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
