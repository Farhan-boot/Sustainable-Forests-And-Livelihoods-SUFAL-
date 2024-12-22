using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class Repayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepaymentFiles",
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
                    RepaymentId = table.Column<long>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepaymentMonthOfInstallment",
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
                    RepaymentAmount = table.Column<decimal>(nullable: true),
                    RepaymentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentMonthOfInstallment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repayment",
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
                    RoundId = table.Column<long>(nullable: true),
                    BeneficaryId = table.Column<decimal>(nullable: true),
                    TradeId = table.Column<decimal>(nullable: true),
                    TotalRepaymentAmount = table.Column<decimal>(nullable: true),
                    FormDate = table.Column<DateTime>(nullable: true),
                    ToDate = table.Column<DateTime>(nullable: true),
                    MonthlyRepayment = table.Column<decimal>(nullable: true),
                    NumberOfRepaymentInstallment = table.Column<decimal>(nullable: true),
                    RepaymentMonthOfInstallmentId = table.Column<long>(nullable: true),
                    RepaymentFilesId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repayment_AigActivitiesLdfInstallmentInformation_AigActivit~",
                        column: x => x.AigActivitiesLdfInstallmentInformationId,
                        principalSchema: "AIG",
                        principalTable: "AigActivitiesLdfInstallmentInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repayment_RepaymentFiles_RepaymentFilesId",
                        column: x => x.RepaymentFilesId,
                        principalTable: "RepaymentFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repayment_RepaymentMonthOfInstallment_RepaymentMonthOfInsta~",
                        column: x => x.RepaymentMonthOfInstallmentId,
                        principalTable: "RepaymentMonthOfInstallment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repayment_AigActivitiesRound_RoundId",
                        column: x => x.RoundId,
                        principalSchema: "AIG",
                        principalTable: "AigActivitiesRound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repayment_AigActivitiesLdfInstallmentInformationId",
                schema: "AIG",
                table: "Repayment",
                column: "AigActivitiesLdfInstallmentInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Repayment_RepaymentFilesId",
                schema: "AIG",
                table: "Repayment",
                column: "RepaymentFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_Repayment_RepaymentMonthOfInstallmentId",
                schema: "AIG",
                table: "Repayment",
                column: "RepaymentMonthOfInstallmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Repayment_RoundId",
                schema: "AIG",
                table: "Repayment",
                column: "RoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repayment",
                schema: "AIG");

            migrationBuilder.DropTable(
                name: "RepaymentFiles");

            migrationBuilder.DropTable(
                name: "RepaymentMonthOfInstallment");
        }
    }
}
