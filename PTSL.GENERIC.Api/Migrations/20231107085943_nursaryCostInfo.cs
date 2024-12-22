using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class nursaryCostInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

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
                name: "NurseryCostInformationFile",
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
                    table.PrimaryKey("PK_NurseryCostInformationFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseryCostInformationFile_NurseryCostInformations_NurseryC~",
                        column: x => x.NurseryCostInformationId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryCostInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NurseryCostInformationFile_NurseryCostInformationId",
                table: "NurseryCostInformationFile",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NurseryCostInformationFile");

            migrationBuilder.DropTable(
                name: "NurseryCostInformations",
                schema: "SocialForestry");
        }
    }
}
