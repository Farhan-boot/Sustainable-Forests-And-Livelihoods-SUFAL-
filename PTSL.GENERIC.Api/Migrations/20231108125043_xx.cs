using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class xx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostInformations_NurseryInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap");

            migrationBuilder.DropIndex(
                name: "IX_CostInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations");

            migrationBuilder.DropColumn(
                name: "NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations");

            migrationBuilder.AlterColumn<long>(
                name: "InspectionDetailsId",
                table: "InspectionDetailsMap",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            /*
            migrationBuilder.CreateTable(
                name: "NurseryCostInformations",
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
                    CostTypeId = table.Column<long>(type: "bigint", nullable: true),
                    CostDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CostAmount = table.Column<double>(type: "double precision", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseryCostInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseryCostInformations_CostTypes_CostTypeId",
                        column: x => x.CostTypeId,
                        principalSchema: "SocialForestry",
                        principalTable: "CostTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NurseryCostInformations_NurseryInformations_NurseryInformat~",
                        column: x => x.NurseryInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NurseryCostInformationFiles",
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
                    NurseryCostInformationId = table.Column<long>(type: "bigint", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseryCostInformationFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseryCostInformationFiles_NurseryCostInformations_Nursery~",
                        column: x => x.NurseryCostInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryCostInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NurseryCostInformationFiles_NurseryCostInformationId",
                schema: "SocialForestry",
                table: "NurseryCostInformationFiles",
                column: "NurseryCostInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryCostInformations_CostTypeId",
                schema: "SocialForestry",
                table: "NurseryCostInformations",
                column: "CostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryCostInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "NurseryCostInformations",
                column: "NurseryInformationId");
            */

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap",
                column: "InspectionDetailsId",
                principalSchema: "SocialForestry",
                principalTable: "InspectionDetailss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap");

            migrationBuilder.DropTable(
                name: "NurseryCostInformationFiles",
                schema: "SocialForestry");

            migrationBuilder.DropTable(
                name: "NurseryCostInformations",
                schema: "SocialForestry");

            migrationBuilder.AlterColumn<long>(
                name: "InspectionDetailsId",
                table: "InspectionDetailsMap",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations",
                column: "NurseryInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostInformations_NurseryInformations_NurseryInformationId",
                schema: "SocialForestry",
                table: "CostInformations",
                column: "NurseryInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryInformations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap",
                column: "InspectionDetailsId",
                principalSchema: "SocialForestry",
                principalTable: "InspectionDetailss",
                principalColumn: "Id");
        }
    }
}
