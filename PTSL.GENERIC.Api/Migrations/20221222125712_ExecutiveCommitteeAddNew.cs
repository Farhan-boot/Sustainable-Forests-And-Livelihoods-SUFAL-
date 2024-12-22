using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class ExecutiveCommitteeAddNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestBeats_BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.AddColumn<long>(
                name: "BeatId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_BeatId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "BeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestBeats_BeatId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "BeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestBeats_BeatId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_BeatId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "BeatId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.AddColumn<long>(
                name: "BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "BeatIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestBeats_BeatIdId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "BeatIdId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
