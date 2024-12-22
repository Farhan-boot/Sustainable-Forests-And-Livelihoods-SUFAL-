using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ExecutiveCommitteeChangeSomeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestBeats_BeatId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestCircles_CircleId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestRanges_RangeId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.RenameColumn(
                name: "RangeId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "ForestRangeId");

            migrationBuilder.RenameColumn(
                name: "CircleId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "ForestCircleId");

            migrationBuilder.RenameColumn(
                name: "BeatId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "ForestBeatId");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutiveCommittee_RangeId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "IX_ExecutiveCommittee_ForestRangeId");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutiveCommittee_CircleId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "IX_ExecutiveCommittee_ForestCircleId");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutiveCommittee_BeatId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "IX_ExecutiveCommittee_ForestBeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestBeats_ForestBeatId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestCircles_ForestCircleId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestRanges_ForestRangeId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestBeats_ForestBeatId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestCircles_ForestCircleId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_ForestRanges_ForestRangeId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.RenameColumn(
                name: "ForestRangeId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "RangeId");

            migrationBuilder.RenameColumn(
                name: "ForestCircleId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "CircleId");

            migrationBuilder.RenameColumn(
                name: "ForestBeatId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "BeatId");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutiveCommittee_ForestRangeId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "IX_ExecutiveCommittee_RangeId");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutiveCommittee_ForestCircleId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "IX_ExecutiveCommittee_CircleId");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutiveCommittee_ForestBeatId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                newName: "IX_ExecutiveCommittee_BeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestBeats_BeatId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "BeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestCircles_CircleId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "CircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_ForestRanges_RangeId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "RangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id");
        }
    }
}
