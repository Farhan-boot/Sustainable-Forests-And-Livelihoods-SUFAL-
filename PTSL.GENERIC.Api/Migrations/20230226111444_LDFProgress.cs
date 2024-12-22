using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class LDFProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LDFProgresss",
                schema: "AIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    AIGBasicInformationId = table.Column<long>(nullable: false),
                    RepaymentLDFId = table.Column<long>(nullable: false),
                    RepaymentStartDate = table.Column<DateTime>(nullable: false),
                    RepaymentEndDate = table.Column<DateTime>(nullable: false),
                    RepaymentSerial = table.Column<int>(nullable: false),
                    ProgressAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LDFProgresss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LDFProgresss_AIGBasicInformations_AIGBasicInformationId",
                        column: x => x.AIGBasicInformationId,
                        principalSchema: "AIG",
                        principalTable: "AIGBasicInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LDFProgresss_RepaymentLDFs_RepaymentLDFId",
                        column: x => x.RepaymentLDFId,
                        principalSchema: "AIG",
                        principalTable: "RepaymentLDFs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LDFProgresss_AIGBasicInformationId",
                schema: "AIG",
                table: "LDFProgresss",
                column: "AIGBasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_LDFProgresss_RepaymentLDFId",
                schema: "AIG",
                table: "LDFProgresss",
                column: "RepaymentLDFId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LDFProgresss",
                schema: "AIG");
        }
    }
}
