using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class LabourDatabaseNullableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_District_DistrictId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_Division_DivisionId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_ForestBeats_ForestBeatId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_ForestCircles_ForestCircleId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_ForestDivisions_ForestDivisionId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_ForestRanges_ForestRangeId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_Upazilla_UpazillaId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.AlterColumn<long>(
                name: "UpazillaId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestRangeId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestDivisionId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestCircleId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestBeatId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DivisionId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DistrictId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_District_DistrictId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_Division_DivisionId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_ForestBeats_ForestBeatId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_ForestCircles_ForestCircleId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_ForestDivisions_ForestDivisionId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_ForestRanges_ForestRangeId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_Upazilla_UpazillaId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_District_DistrictId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_Division_DivisionId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_ForestBeats_ForestBeatId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_ForestCircles_ForestCircleId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_ForestDivisions_ForestDivisionId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_ForestRanges_ForestRangeId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_Upazilla_UpazillaId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.AlterColumn<long>(
                name: "UpazillaId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestRangeId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestDivisionId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestCircleId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestBeatId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DivisionId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DistrictId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_District_DistrictId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_Division_DivisionId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_ForestBeats_ForestBeatId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_ForestCircles_ForestCircleId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_ForestDivisions_ForestDivisionId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_ForestRanges_ForestRangeId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_Upazilla_UpazillaId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
