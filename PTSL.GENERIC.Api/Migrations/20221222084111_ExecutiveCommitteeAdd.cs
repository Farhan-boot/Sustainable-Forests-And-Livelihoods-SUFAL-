using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class ExecutiveCommitteeAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_Ngos_FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_FcvExecutiveCommitteeMember_FcvExecutive~",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_FcvExecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "BeneficiaryId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "FcvExecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AccountOpeningDate",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CellNo",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CircleId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CommitteeTypeId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DesignatinId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EthnicityId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherOrSpouse",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FcvId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestDivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GenderId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFcv",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfBankAC",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NidNo",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OfficeBearersId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OtherMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RangeId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "BeatIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_CircleId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_EthnicityId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_FcvId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_ForestDivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "ForestDivisionId");

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
                name: "IX_ExecutiveCommittee_RangeId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "RangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestBeats_BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "BeatIdId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestCircles_CircleId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "CircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_Ethnicitys_EthnicityId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "EthnicityId",
                principalSchema: "BEN",
                principalTable: "Ethnicitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestFcvVcfs_FcvId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestDivisions_ForestDivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_Ngos_NgoId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "NgoId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_Surveys_OfficeBearersId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "OfficeBearersId",
                principalSchema: "BEN",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestRanges_RangeId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "RangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestBeats_BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestCircles_CircleId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_Ethnicitys_EthnicityId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestFcvVcfs_FcvId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestDivisions_ForestDivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_Ngos_NgoId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_Surveys_OfficeBearersId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestRanges_RangeId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_CircleId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_EthnicityId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_FcvId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_ForestDivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_NgoId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_OfficeBearersId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_RangeId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "AccountOpeningDate",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "AccountType",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "BankName",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "BranchName",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "CellNo",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "CircleId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "CommitteeTypeId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "DesignatinId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "EthnicityId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "FatherOrSpouse",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "FcvId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "ForestDivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "IsFcv",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "NameOfBankAC",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "NidNo",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "OfficeBearersId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "OtherMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "RangeId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "Remark",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.AddColumn<long>(
                name: "BeneficiaryId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FcvExecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvExecutiveCommitteeMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_FcvExecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvExecutiveCommitteeMembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_Ngos_FcvExecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvExecutiveCommitteeMemberId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_FcvExecutiveCommitteeMember_FcvExecutive~",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvExecutiveCommitteeMembersId",
                principalSchema: "BEN",
                principalTable: "FcvExecutiveCommitteeMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
