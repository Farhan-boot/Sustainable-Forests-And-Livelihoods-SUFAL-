using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOldCommittee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExecutiveCommittee",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "FcvExecutiveCommitteeMember",
                schema: "BEN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExecutiveCommittee",
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
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: true),
                    EthnicityId = table.Column<long>(type: "bigint", nullable: true),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: true),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: true),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestFcvVcfId = table.Column<long>(type: "bigint", nullable: true),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: true),
                    NgoId = table.Column<long>(type: "bigint", nullable: true),
                    OfficeBearersId = table.Column<long>(type: "bigint", nullable: true),
                    OtherMemberId = table.Column<long>(type: "bigint", nullable: true),
                    SubCommitteeDesignationId = table.Column<long>(type: "bigint", nullable: true),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: true),
                    AccountNumber = table.Column<string>(type: "varchar(500)", nullable: true),
                    AccountOpeningDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AccountType = table.Column<string>(type: "varchar(500)", nullable: true),
                    BankName = table.Column<string>(type: "varchar(500)", nullable: true),
                    BranchName = table.Column<string>(type: "varchar(500)", nullable: true),
                    CellNo = table.Column<string>(type: "varchar(500)", nullable: true),
                    CommitteeEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CommitteeFormDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CommitteeTypeId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    DesignatinId = table.Column<long>(type: "bigint", nullable: true),
                    ExDesignatinId = table.Column<long>(type: "bigint", nullable: true),
                    FatherOrSpouse = table.Column<string>(type: "varchar(500)", nullable: true),
                    GenderId = table.Column<long>(type: "bigint", nullable: true),
                    IsActiveCommittee = table.Column<bool>(type: "boolean", nullable: true),
                    IsFcv = table.Column<bool>(type: "boolean", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameOfBankAC = table.Column<string>(type: "varchar(500)", nullable: true),
                    NidNo = table.Column<string>(type: "varchar(500)", nullable: true),
                    Remark = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutiveCommittee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_CommitteeDesignation_SubCommitteeDesigna~",
                        column: x => x.SubCommitteeDesignationId,
                        principalSchema: "GS",
                        principalTable: "CommitteeDesignation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_Ethnicitys_EthnicityId",
                        column: x => x.EthnicityId,
                        principalSchema: "BEN",
                        principalTable: "Ethnicitys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_OtherCommitteeMembers_OtherMemberId",
                        column: x => x.OtherMemberId,
                        principalSchema: "BEN",
                        principalTable: "OtherCommitteeMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_Surveys_OfficeBearersId",
                        column: x => x.OfficeBearersId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FcvExecutiveCommitteeMember",
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
                    NgoId = table.Column<long>(type: "bigint", nullable: true),
                    BeneficiaryId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ExecutiveMemberTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FcvExecutiveCommitteeMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FcvExecutiveCommitteeMember_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_DistrictId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_DivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_EthnicityId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_ForestBeatId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_ForestCircleId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_ForestDivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_ForestFcvVcfId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_ForestRangeId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_NgoId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_OfficeBearersId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "OfficeBearersId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_OtherMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "OtherMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_SubCommitteeDesignationId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "SubCommitteeDesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_UnionId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_UpazillaId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_FcvExecutiveCommitteeMember_NgoId",
                schema: "BEN",
                table: "FcvExecutiveCommitteeMember",
                column: "NgoId");
        }
    }
}
