using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributions_District_DistrictId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributions_Division_DivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributions_ForestBeats_ForestBeatId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributions_ForestCircles_ForestCircleId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributions_ForestDivisions_ForestDivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributions_ForestRanges_ForestRangeId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributions_Union_UnionId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributions_Upazilla_UpazillaId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropIndex(
                name: "IX_NurseryDistributions_DistrictId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropIndex(
                name: "IX_NurseryDistributions_DivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropIndex(
                name: "IX_NurseryDistributions_ForestBeatId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropIndex(
                name: "IX_NurseryDistributions_ForestCircleId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropIndex(
                name: "IX_NurseryDistributions_ForestDivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropIndex(
                name: "IX_NurseryDistributions_ForestRangeId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropIndex(
                name: "IX_NurseryDistributions_UnionId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropIndex(
                name: "IX_NurseryDistributions_UpazillaId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "ForestBeatId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "ForestCircleId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "ForestDivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "ForestRangeId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "UpazillaId",
                schema: "SocialForestry",
                table: "NurseryDistributions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DistrictId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ForestBeatId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ForestCircleId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ForestDivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ForestRangeId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpazillaId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_DistrictId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_DivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_ForestBeatId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_ForestCircleId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_ForestDivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_ForestRangeId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_UnionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributions_UpazillaId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "UpazillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributions_District_DistrictId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributions_Division_DivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributions_ForestBeats_ForestBeatId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributions_ForestCircles_ForestCircleId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributions_ForestDivisions_ForestDivisionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributions_ForestRanges_ForestRangeId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributions_Union_UnionId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributions_Upazilla_UpazillaId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
