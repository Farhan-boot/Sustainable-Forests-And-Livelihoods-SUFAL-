using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class AigActivitiesRoundOfLdfAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AigActivitiesRoundOfLdfAmount",
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
                    AigActivitiesRoundId = table.Column<long>(nullable: true),
                    FirstInstallmentAmount = table.Column<decimal>(nullable: true),
                    FirstInstallmentDate = table.Column<DateTime>(nullable: true),
                    SecondInstallmentAmount = table.Column<decimal>(nullable: true),
                    SecondInstallmentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AigActivitiesRoundOfLdfAmount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AigActivitiesRoundOfLdfAmount_AigActivitiesRound_AigActivit~",
                        column: x => x.AigActivitiesRoundId,
                        principalSchema: "AIG",
                        principalTable: "AigActivitiesRound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesRoundOfLdfAmount_AigActivitiesRoundId",
                schema: "AIG",
                table: "AigActivitiesRoundOfLdfAmount",
                column: "AigActivitiesRoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AigActivitiesRoundOfLdfAmount",
                schema: "AIG");
        }
    }
}
