using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCommitteeManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommitteeManagement",
                schema: "BEN",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: false),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: false),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: false),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: false),
                    NgoId = table.Column<long>(type: "bigint", nullable: false),
                    CommitteeTypeId = table.Column<int>(type: "integer", nullable: false),
                    SubCommitteeTypeId = table.Column<int>(type: "integer", nullable: true),
                    CommitteeFormDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CommitteeEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NameOfBankAC = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    AccountType = table.Column<string>(type: "text", nullable: true),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    BranchName = table.Column<string>(type: "text", nullable: true),
                    AccountOpeningDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    IsInActiveCommittee = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeManagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeManagement_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommitteeManagement_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommitteeManagement_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommitteeManagement_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommitteeManagement_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommitteeManagement_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommitteeManagement_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommitteeManagement_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommitteeManagement_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommitteeManagementMember",
                schema: "BEN",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true),
                    CommitteeManagementId = table.Column<long>(type: "bigint", nullable: false),
                    ExecutiveDesignationId = table.Column<int>(type: "integer", nullable: true),
                    SubCommitteeDesignationId = table.Column<long>(type: "bigint", nullable: true),
                    SurveyId = table.Column<long>(type: "bigint", nullable: true),
                    OtherCommitteeMemberId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeManagementMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeManagementMember_CommitteeManagement_CommitteeMana~",
                        column: x => x.CommitteeManagementId,
                        principalSchema: "BEN",
                        principalTable: "CommitteeManagement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommitteeManagementMember_OtherCommitteeMembers_OtherCommit~",
                        column: x => x.OtherCommitteeMemberId,
                        principalSchema: "BEN",
                        principalTable: "OtherCommitteeMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommitteeManagementMember_SubCommitteeDesignations_SubCommi~",
                        column: x => x.SubCommitteeDesignationId,
                        principalSchema: "GS",
                        principalTable: "SubCommitteeDesignations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommitteeManagementMember_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_DistrictId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_DivisionId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_ForestBeatId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_ForestCircleId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_ForestDivisionId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_ForestRangeId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_NgoId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_UnionId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_UpazillaId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagementMember_CommitteeManagementId",
                schema: "BEN",
                table: "CommitteeManagementMember",
                column: "CommitteeManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagementMember_OtherCommitteeMemberId",
                schema: "BEN",
                table: "CommitteeManagementMember",
                column: "OtherCommitteeMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagementMember_SubCommitteeDesignationId",
                schema: "BEN",
                table: "CommitteeManagementMember",
                column: "SubCommitteeDesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagementMember_SurveyId",
                schema: "BEN",
                table: "CommitteeManagementMember",
                column: "SurveyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommitteeManagementMember",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "CommitteeManagement",
                schema: "BEN");
        }
    }
}
