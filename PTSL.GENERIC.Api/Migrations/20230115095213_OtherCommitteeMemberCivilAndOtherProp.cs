using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class OtherCommitteeMemberCivilAndOtherProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DistrictId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "FatherOrSpouse",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestBeatId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ForestCircleId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ForestDivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ForestRangeId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpazillaId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DistrictId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpazillaId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtherCommitteeMembers_DistrictId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCommitteeMembers_DivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCommitteeMembers_ForestBeatId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCommitteeMembers_ForestCircleId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCommitteeMembers_ForestDivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCommitteeMembers_ForestRangeId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCommitteeMembers_UpazillaId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "UpazillaId");

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
                name: "IX_ExecutiveCommittee_UpazillaId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "UpazillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_District_DistrictId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_Division_DivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_Upazilla_UpazillaId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherCommitteeMembers_District_DistrictId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherCommitteeMembers_Division_DivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherCommitteeMembers_ForestBeats_ForestBeatId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherCommitteeMembers_ForestCircles_ForestCircleId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherCommitteeMembers_ForestDivisions_ForestDivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherCommitteeMembers_ForestRanges_ForestRangeId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherCommitteeMembers_Upazilla_UpazillaId",
                schema: "BEN",
                table: "OtherCommitteeMembers",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_District_DistrictId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_Division_DivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_Upazilla_UpazillaId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherCommitteeMembers_District_DistrictId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherCommitteeMembers_Division_DivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherCommitteeMembers_ForestBeats_ForestBeatId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherCommitteeMembers_ForestCircles_ForestCircleId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherCommitteeMembers_ForestDivisions_ForestDivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherCommitteeMembers_ForestRanges_ForestRangeId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherCommitteeMembers_Upazilla_UpazillaId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropIndex(
                name: "IX_OtherCommitteeMembers_DistrictId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropIndex(
                name: "IX_OtherCommitteeMembers_DivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropIndex(
                name: "IX_OtherCommitteeMembers_ForestBeatId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropIndex(
                name: "IX_OtherCommitteeMembers_ForestCircleId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropIndex(
                name: "IX_OtherCommitteeMembers_ForestDivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropIndex(
                name: "IX_OtherCommitteeMembers_ForestRangeId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropIndex(
                name: "IX_OtherCommitteeMembers_UpazillaId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_DistrictId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_DivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_UpazillaId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropColumn(
                name: "FatherOrSpouse",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropColumn(
                name: "ForestBeatId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropColumn(
                name: "ForestCircleId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropColumn(
                name: "ForestDivisionId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropColumn(
                name: "ForestRangeId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropColumn(
                name: "UpazillaId",
                schema: "BEN",
                table: "OtherCommitteeMembers");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "UpazillaId",
                schema: "BEN",
                table: "ExecutiveCommittee");
        }
    }
}
