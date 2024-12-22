using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class RemoveOldAIG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepaymentFiles");

            migrationBuilder.DropTable(
                name: "AigActivitiesLdfInstallmentInformationFiles",
                schema: "AIG");

            migrationBuilder.DropTable(
                name: "AigActivitiesRoundFiles",
                schema: "AIG");

            migrationBuilder.DropTable(
                name: "AigActivitiesRoundOfLdfAmount",
                schema: "AIG");

            migrationBuilder.DropTable(
                name: "RepaymentMonthOfInstallment",
                schema: "AIG");

            migrationBuilder.DropTable(
                name: "Repayment",
                schema: "AIG");

            migrationBuilder.DropTable(
                name: "AigActivitiesRound",
                schema: "AIG");

            migrationBuilder.DropTable(
                name: "AigActivitiesLdfInstallmentInformation",
                schema: "AIG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AigActivitiesLdfInstallmentInformation",
                schema: "AIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeneficiaryId = table.Column<long>(type: "bigint", nullable: true),
                    CivilDistrictId = table.Column<long>(type: "bigint", nullable: true),
                    CivilDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    CivilUpazillaId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: true),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: true),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestFcvVcfId = table.Column<long>(type: "bigint", nullable: true),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsRecievedTrainingInThisTrade = table.Column<bool>(type: "boolean", nullable: true),
                    IsTakenAnyLoan = table.Column<bool>(type: "boolean", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    NgoId = table.Column<long>(type: "bigint", nullable: true),
                    TradeId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AigActivitiesLdfInstallmentInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_Surveys_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_District_CivilDistri~",
                        column: x => x.CivilDistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_Division_CivilDivisi~",
                        column: x => x.CivilDivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_Upazilla_CivilUpazil~",
                        column: x => x.CivilUpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_ForestBeats_ForestBe~",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_ForestCircles_Forest~",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_ForestDivisions_Fore~",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_ForestFcvVcfs_Forest~",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_ForestRanges_ForestR~",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformation_Trade_TradeId",
                        column: x => x.TradeId,
                        principalSchema: "BEN",
                        principalTable: "Trade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AigActivitiesLdfInstallmentInformationFiles",
                schema: "AIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AigActivitiesLdfInstallmentInformationId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AigActivitiesLdfInstallmentInformationFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AigActivitiesLdfInstallmentInformationFiles_AigActivitiesLd~",
                        column: x => x.AigActivitiesLdfInstallmentInformationId,
                        principalSchema: "AIG",
                        principalTable: "AigActivitiesLdfInstallmentInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AigActivitiesRound",
                schema: "AIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AigActivitiesLdfInstallmentInformationId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    FirstLoanAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    FirstLoanDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    RepaymentInterestPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    RoundLdfAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    RoundLdfValidation = table.Column<string>(type: "text", nullable: true),
                    SecondLoanAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    SecondLoanDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "AigActivitiesRoundFiles",
                schema: "AIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AigActivitiesRoundId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AigActivitiesRoundFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AigActivitiesRoundFiles_AigActivitiesRound_AigActivitiesRou~",
                        column: x => x.AigActivitiesRoundId,
                        principalSchema: "AIG",
                        principalTable: "AigActivitiesRound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AigActivitiesRoundOfLdfAmount",
                schema: "AIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AigActivitiesRoundId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    FirstInstallmentAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    FirstInstallmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    SecondInstallmentAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    SecondInstallmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Repayment",
                schema: "AIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AigActivitiesLdfInstallmentInformationId = table.Column<long>(type: "bigint", nullable: true),
                    BeneficaryId = table.Column<decimal>(type: "numeric", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    FormDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    MonthlyRepayment = table.Column<decimal>(type: "numeric", nullable: true),
                    NumberOfRepaymentInstallment = table.Column<decimal>(type: "numeric", nullable: true),
                    RepaymentFilesId = table.Column<long>(type: "bigint", nullable: true),
                    RoundId = table.Column<long>(type: "bigint", nullable: true),
                    ToDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TotalRepaymentAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    TradeId = table.Column<decimal>(type: "numeric", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
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
                        name: "FK_Repayment_AigActivitiesRound_RoundId",
                        column: x => x.RoundId,
                        principalSchema: "AIG",
                        principalTable: "AigActivitiesRound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepaymentFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    RepaymentFilesId = table.Column<long>(type: "bigint", nullable: true),
                    RepaymentId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepaymentFiles_Repayment_RepaymentId",
                        column: x => x.RepaymentId,
                        principalSchema: "AIG",
                        principalTable: "Repayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepaymentMonthOfInstallment",
                schema: "AIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    RepaymentAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    RepaymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RepaymentId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentMonthOfInstallment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepaymentMonthOfInstallment_Repayment_RepaymentId",
                        column: x => x.RepaymentId,
                        principalSchema: "AIG",
                        principalTable: "Repayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentFiles_RepaymentId",
                table: "RepaymentFiles",
                column: "RepaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_BeneficiaryId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "BeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_CivilDistrictId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "CivilDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_CivilDivisionId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "CivilDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_CivilUpazillaId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "CivilUpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_ForestBeatId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_ForestCircleId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_ForestDivisionId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_ForestFcvVcfId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_ForestRangeId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_NgoId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformation_TradeId",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformation",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesLdfInstallmentInformationFiles_AigActivitiesLd~",
                schema: "AIG",
                table: "AigActivitiesLdfInstallmentInformationFiles",
                column: "AigActivitiesLdfInstallmentInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesRound_AigActivitiesLdfInstallmentInformationId",
                schema: "AIG",
                table: "AigActivitiesRound",
                column: "AigActivitiesLdfInstallmentInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesRoundFiles_AigActivitiesRoundId",
                schema: "AIG",
                table: "AigActivitiesRoundFiles",
                column: "AigActivitiesRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_AigActivitiesRoundOfLdfAmount_AigActivitiesRoundId",
                schema: "AIG",
                table: "AigActivitiesRoundOfLdfAmount",
                column: "AigActivitiesRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Repayment_AigActivitiesLdfInstallmentInformationId",
                schema: "AIG",
                table: "Repayment",
                column: "AigActivitiesLdfInstallmentInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Repayment_RoundId",
                schema: "AIG",
                table: "Repayment",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentMonthOfInstallment_RepaymentId",
                schema: "AIG",
                table: "RepaymentMonthOfInstallment",
                column: "RepaymentId");
        }
    }
}
