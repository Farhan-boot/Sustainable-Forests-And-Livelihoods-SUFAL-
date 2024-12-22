using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class BeneficiarySubmissionHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SubmissionHistoryForMobile");

            migrationBuilder.CreateTable(
                name: "BeneficiarySubmissionHistory",
                schema: "SubmissionHistoryForMobile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    SurveyId = table.Column<long>(type: "bigint", nullable: true),
                    AIGBasicInformationId = table.Column<long>(type: "bigint", nullable: true),
                    InternalLoanInformationId = table.Column<long>(type: "bigint", nullable: true),
                    SavingsAccountId = table.Column<long>(type: "bigint", nullable: true),
                    FileUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiarySubmissionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeneficiarySubmissionHistory_AIGBasicInformations_AIGBasicI~",
                        column: x => x.AIGBasicInformationId,
                        principalSchema: "AIG",
                        principalTable: "AIGBasicInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BeneficiarySubmissionHistory_InternalLoanInformations_Inter~",
                        column: x => x.InternalLoanInformationId,
                        principalSchema: "InternalLoan",
                        principalTable: "InternalLoanInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BeneficiarySubmissionHistory_SavingsAccount_SavingsAccountId",
                        column: x => x.SavingsAccountId,
                        principalSchema: "BSA",
                        principalTable: "SavingsAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BeneficiarySubmissionHistory_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiarySubmissionHistory_AIGBasicInformationId",
                schema: "SubmissionHistoryForMobile",
                table: "BeneficiarySubmissionHistory",
                column: "AIGBasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiarySubmissionHistory_InternalLoanInformationId",
                schema: "SubmissionHistoryForMobile",
                table: "BeneficiarySubmissionHistory",
                column: "InternalLoanInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiarySubmissionHistory_SavingsAccountId",
                schema: "SubmissionHistoryForMobile",
                table: "BeneficiarySubmissionHistory",
                column: "SavingsAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiarySubmissionHistory_SurveyId",
                schema: "SubmissionHistoryForMobile",
                table: "BeneficiarySubmissionHistory",
                column: "SurveyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeneficiarySubmissionHistory",
                schema: "SubmissionHistoryForMobile");
        }
    }
}
