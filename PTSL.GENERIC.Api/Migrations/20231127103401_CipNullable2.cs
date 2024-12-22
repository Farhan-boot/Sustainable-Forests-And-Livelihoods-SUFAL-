using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CipNullable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cips_District_DistrictId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_Division_DivisionId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_ForestBeats_ForestBeatId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_ForestCircles_ForestCircleId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_ForestDivisions_ForestDivisionId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_ForestFcvVcfs_ForestFcvVcfId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_ForestRanges_ForestRangeId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_Upazilla_UpazillaId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.AlterColumn<long>(
                name: "UpazillaId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestRangeId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestFcvVcfId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestDivisionId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestCircleId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestBeatId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DivisionId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DistrictId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_District_DistrictId",
                schema: "BEN",
                table: "Cips",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_Division_DivisionId",
                schema: "BEN",
                table: "Cips",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_ForestBeats_ForestBeatId",
                schema: "BEN",
                table: "Cips",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_ForestCircles_ForestCircleId",
                schema: "BEN",
                table: "Cips",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_ForestDivisions_ForestDivisionId",
                schema: "BEN",
                table: "Cips",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_ForestFcvVcfs_ForestFcvVcfId",
                schema: "BEN",
                table: "Cips",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_ForestRanges_ForestRangeId",
                schema: "BEN",
                table: "Cips",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_Upazilla_UpazillaId",
                schema: "BEN",
                table: "Cips",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cips_District_DistrictId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_Division_DivisionId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_ForestBeats_ForestBeatId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_ForestCircles_ForestCircleId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_ForestDivisions_ForestDivisionId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_ForestFcvVcfs_ForestFcvVcfId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_ForestRanges_ForestRangeId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Cips_Upazilla_UpazillaId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.AlterColumn<long>(
                name: "UpazillaId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestRangeId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestFcvVcfId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestDivisionId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestCircleId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestBeatId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DivisionId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DistrictId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_District_DistrictId",
                schema: "BEN",
                table: "Cips",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_Division_DivisionId",
                schema: "BEN",
                table: "Cips",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_ForestBeats_ForestBeatId",
                schema: "BEN",
                table: "Cips",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_ForestCircles_ForestCircleId",
                schema: "BEN",
                table: "Cips",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_ForestDivisions_ForestDivisionId",
                schema: "BEN",
                table: "Cips",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_ForestFcvVcfs_ForestFcvVcfId",
                schema: "BEN",
                table: "Cips",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_ForestRanges_ForestRangeId",
                schema: "BEN",
                table: "Cips",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_Upazilla_UpazillaId",
                schema: "BEN",
                table: "Cips",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
