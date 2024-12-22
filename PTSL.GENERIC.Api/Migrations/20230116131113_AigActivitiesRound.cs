using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class AigActivitiesRound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AigActivitiesRound",
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
                    AigActivitiesLdfInstallmentInformationId = table.Column<long>(nullable: true),
                    FirstRoundLdfAmount = table.Column<decimal>(nullable: true),
                    FirstRoundLdfValidation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AigActivitiesRound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AigActivitiesRound_AigActivitiesLdfInstallmentInformation_A~",
                        column: x => x.AigActivitiesLdfInstallmentInformationId,
                        principalSchema: "AIG",
                        principalTable: "AigActivitiesLdfInstallmentInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesRound_AigActivitiesLdfInstallmentInformationId",
                schema: "AIG",
                table: "AigActivitiesRound",
                column: "AigActivitiesLdfInstallmentInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AigActivitiesRound",
                schema: "AIG");
        }
    }
}
