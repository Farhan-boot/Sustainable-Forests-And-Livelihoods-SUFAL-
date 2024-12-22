using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class AIG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AIGBasicInformations",
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
                    ForestCircleId = table.Column<long>(nullable: false),
                    ForestDivisionId = table.Column<long>(nullable: false),
                    ForestRangeId = table.Column<long>(nullable: false),
                    ForestBeatId = table.Column<long>(nullable: false),
                    ForestFcvVcfId = table.Column<long>(nullable: false),
                    DivisionId = table.Column<long>(nullable: false),
                    DistrictId = table.Column<long>(nullable: false),
                    UpazillaId = table.Column<long>(nullable: false),
                    UnionId = table.Column<long>(nullable: true),
                    NgoId = table.Column<long>(nullable: false),
                    SurveyId = table.Column<long>(nullable: false),
                    IsRecievedTrainingInTrade = table.Column<bool>(nullable: false),
                    TradeId = table.Column<long>(nullable: true),
                    TotalAllocatedLoanAmount = table.Column<double>(nullable: false),
                    MaximumRepaymentMonth = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ServiceChargePercentage = table.Column<double>(nullable: false),
                    SecurityChargePercentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIGBasicInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_Trade_TradeId",
                        column: x => x.TradeId,
                        principalSchema: "BEN",
                        principalTable: "Trade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AIGBasicInformations_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BadLoanTypes",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadLoanTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FirstSixtyPercentageLDFs",
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
                    HasGrace = table.Column<bool>(nullable: false),
                    ServiceChargeAmount = table.Column<double>(nullable: false),
                    SecurityChargeAmount = table.Column<double>(nullable: false),
                    BadLoanTypeId = table.Column<long>(nullable: true),
                    IsDefaulter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstSixtyPercentageLDFs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirstSixtyPercentageLDFs_AIGBasicInformations_AIGBasicInfor~",
                        column: x => x.AIGBasicInformationId,
                        principalSchema: "AIG",
                        principalTable: "AIGBasicInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FirstSixtyPercentageLDFs_BadLoanTypes_BadLoanTypeId",
                        column: x => x.BadLoanTypeId,
                        principalSchema: "AIG",
                        principalTable: "BadLoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecondFourtyPercentageLDFs",
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
                    ServiceChargeAmount = table.Column<double>(nullable: false),
                    SecurityChargeAmount = table.Column<double>(nullable: false),
                    BadLoanTypeId = table.Column<long>(nullable: true),
                    IsDefaulter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondFourtyPercentageLDFs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondFourtyPercentageLDFs_AIGBasicInformations_AIGBasicInf~",
                        column: x => x.AIGBasicInformationId,
                        principalSchema: "AIG",
                        principalTable: "AIGBasicInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecondFourtyPercentageLDFs_BadLoanTypes_BadLoanTypeId",
                        column: x => x.BadLoanTypeId,
                        principalSchema: "AIG",
                        principalTable: "BadLoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepaymentLDFs",
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
                    FirstSixtyPercentageLDFId = table.Column<long>(nullable: true),
                    SecondFourtyPercentageLDFId = table.Column<long>(nullable: true),
                    RepaymentAmount = table.Column<double>(nullable: false),
                    RepaymentStartDate = table.Column<DateTime>(nullable: false),
                    RepaymentEndDate = table.Column<DateTime>(nullable: false),
                    RepaymentMonthEnumId = table.Column<int>(nullable: false),
                    IsPaymentCompleted = table.Column<bool>(nullable: false),
                    PaymentCompletedDateTime = table.Column<DateTime>(nullable: true),
                    IsPaymentCompletedLate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentLDFs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepaymentLDFs_FirstSixtyPercentageLDFs_FirstSixtyPercentage~",
                        column: x => x.FirstSixtyPercentageLDFId,
                        principalSchema: "AIG",
                        principalTable: "FirstSixtyPercentageLDFs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepaymentLDFs_SecondFourtyPercentageLDFs_SecondFourtyPercen~",
                        column: x => x.SecondFourtyPercentageLDFId,
                        principalSchema: "AIG",
                        principalTable: "SecondFourtyPercentageLDFs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_DistrictId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_DivisionId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_ForestBeatId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_ForestCircleId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_ForestDivisionId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_ForestFcvVcfId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_ForestRangeId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_NgoId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_SurveyId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_TradeId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_UnionId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGBasicInformations_UpazillaId",
                schema: "AIG",
                table: "AIGBasicInformations",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstSixtyPercentageLDFs_AIGBasicInformationId",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs",
                column: "AIGBasicInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FirstSixtyPercentageLDFs_BadLoanTypeId",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs",
                column: "BadLoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentLDFs_FirstSixtyPercentageLDFId",
                schema: "AIG",
                table: "RepaymentLDFs",
                column: "FirstSixtyPercentageLDFId");

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentLDFs_SecondFourtyPercentageLDFId",
                schema: "AIG",
                table: "RepaymentLDFs",
                column: "SecondFourtyPercentageLDFId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondFourtyPercentageLDFs_AIGBasicInformationId",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                column: "AIGBasicInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecondFourtyPercentageLDFs_BadLoanTypeId",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                column: "BadLoanTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepaymentLDFs",
                schema: "AIG");

            migrationBuilder.DropTable(
                name: "FirstSixtyPercentageLDFs",
                schema: "AIG");

            migrationBuilder.DropTable(
                name: "SecondFourtyPercentageLDFs",
                schema: "AIG");

            migrationBuilder.DropTable(
                name: "AIGBasicInformations",
                schema: "AIG");

            migrationBuilder.DropTable(
                name: "BadLoanTypes",
                schema: "AIG");
        }
    }
}
