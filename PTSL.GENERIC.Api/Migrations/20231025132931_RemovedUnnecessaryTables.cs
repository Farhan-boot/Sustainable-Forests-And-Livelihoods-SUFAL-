using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUnnecessaryTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantationPlants_PlantationPlantRaisingSector_PlantationPla~",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantations_FinancialYears_FinancialYearId",
                schema: "SocialForestry",
                table: "Plantations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantations_ProjectTypes_ProjectTypeId",
                schema: "SocialForestry",
                table: "Plantations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantations_SocialForestryNgos_SocialForestryNgoId",
                schema: "SocialForestry",
                table: "Plantations");

            migrationBuilder.DropTable(
                name: "PlantationPlantRaisingSector");

            migrationBuilder.DropIndex(
                name: "IX_PlantationPlants_PlantationPlantRaisingSectorId",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropColumn(
                name: "ExpectedCuttingYear",
                schema: "SocialForestry",
                table: "Plantations");

            migrationBuilder.DropColumn(
                name: "RotationInYear",
                schema: "SocialForestry",
                table: "Plantations");

            migrationBuilder.DropColumn(
                name: "PlantationPlantRaisingSectorId",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.RenameColumn(
                name: "FinancialYearId",
                schema: "SocialForestry",
                table: "Plantations",
                newName: "CreatedFinancialYearId");

            migrationBuilder.RenameIndex(
                name: "IX_Plantations_FinancialYearId",
                schema: "SocialForestry",
                table: "Plantations",
                newName: "IX_Plantations_CreatedFinancialYearId");

            migrationBuilder.AlterColumn<long>(
                name: "SocialForestryNgoId",
                schema: "SocialForestry",
                table: "Plantations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "SheetNo",
                schema: "SocialForestry",
                table: "Plantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "ProjectTypeId",
                schema: "SocialForestry",
                table: "Plantations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "PlotNo",
                schema: "SocialForestry",
                table: "Plantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "MoujaAndJLNumber",
                schema: "SocialForestry",
                table: "Plantations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ExpectedCuttingYear",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlantationArea",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PlantationUnitId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PlantedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProjectTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "RotationInYear",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "SocialForestryNgoId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_PlantationUnitId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_PlantedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantedFinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_ProjectTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantations_SocialForestryNgoId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "SocialForestryNgoId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_FinancialYears_PlantedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantedFinancialYearId",
                principalSchema: "GS",
                principalTable: "FinancialYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_PlantationUnits_PlantationUnitId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "PlantationUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_ProjectTypes_ProjectTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "ProjectTypeId",
                principalSchema: "SocialForestry",
                principalTable: "ProjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantations_SocialForestryNgos_SocialForestryNgoId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                column: "SocialForestryNgoId",
                principalSchema: "SocialForestry",
                principalTable: "SocialForestryNgos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantations_FinancialYears_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "CreatedFinancialYearId",
                principalSchema: "GS",
                principalTable: "FinancialYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantations_ProjectTypes_ProjectTypeId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "ProjectTypeId",
                principalSchema: "SocialForestry",
                principalTable: "ProjectTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantations_SocialForestryNgos_SocialForestryNgoId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "SocialForestryNgoId",
                principalSchema: "SocialForestry",
                principalTable: "SocialForestryNgos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_FinancialYears_PlantedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_PlantationUnits_PlantationUnitId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_ProjectTypes_ProjectTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantations_SocialForestryNgos_SocialForestryNgoId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantations_FinancialYears_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "Plantations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantations_ProjectTypes_ProjectTypeId",
                schema: "SocialForestry",
                table: "Plantations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantations_SocialForestryNgos_SocialForestryNgoId",
                schema: "SocialForestry",
                table: "Plantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_PlantationUnitId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_PlantedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_ProjectTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantations_SocialForestryNgoId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "ExpectedCuttingYear",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PlantationArea",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PlantationUnitId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PlantedFinancialYearId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "RotationInYear",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "SocialForestryNgoId",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.RenameColumn(
                name: "CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "Plantations",
                newName: "FinancialYearId");

            migrationBuilder.RenameIndex(
                name: "IX_Plantations_CreatedFinancialYearId",
                schema: "SocialForestry",
                table: "Plantations",
                newName: "IX_Plantations_FinancialYearId");

            migrationBuilder.AlterColumn<long>(
                name: "SocialForestryNgoId",
                schema: "SocialForestry",
                table: "Plantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SheetNo",
                schema: "SocialForestry",
                table: "Plantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProjectTypeId",
                schema: "SocialForestry",
                table: "Plantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlotNo",
                schema: "SocialForestry",
                table: "Plantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MoujaAndJLNumber",
                schema: "SocialForestry",
                table: "Plantations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpectedCuttingYear",
                schema: "SocialForestry",
                table: "Plantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RotationInYear",
                schema: "SocialForestry",
                table: "Plantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "PlantationPlantRaisingSectorId",
                schema: "SocialForestry",
                table: "PlantationPlants",
                type: "bigint",
                nullable: true);

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
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Plantations_FinancialYears_FinancialYearId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "FinancialYearId",
                principalSchema: "GS",
                principalTable: "FinancialYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantations_ProjectTypes_ProjectTypeId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "ProjectTypeId",
                principalSchema: "SocialForestry",
                principalTable: "ProjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantations_SocialForestryNgos_SocialForestryNgoId",
                schema: "SocialForestry",
                table: "Plantations",
                column: "SocialForestryNgoId",
                principalSchema: "SocialForestry",
                principalTable: "SocialForestryNgos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
