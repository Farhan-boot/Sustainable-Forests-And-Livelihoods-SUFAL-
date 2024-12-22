using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class LabourDatabaseRemoveUnecessaryColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_LabourRoles_LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_District_DistrictId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_Division_DivisionId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_ForestBeats_ForestBeatId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_ForestCircles_ForestCircleId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_ForestDivisions_ForestDivisionId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_ForestRanges_ForestRangeId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_Upazilla_UpazillaId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropIndex(
                name: "IX_LabourDatabases_OtherLabourMemberId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropColumn(
                name: "FatherOrSpouse",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropColumn(
                name: "FatherOrSpouse",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropColumn(
                name: "ManDays",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropColumn(
                name: "NidNo",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.AlterColumn<long>(
                name: "UpazillaId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestRangeId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestFcvVcfId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestDivisionId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestCircleId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestBeatId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DivisionId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DistrictId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_OtherLabourMemberId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "OtherLabourMemberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_LabourRoles_LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "LabourRoleId",
                principalSchema: "Labour",
                principalTable: "LabourRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_District_DistrictId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_Division_DivisionId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_ForestBeats_ForestBeatId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_ForestCircles_ForestCircleId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_ForestDivisions_ForestDivisionId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_ForestRanges_ForestRangeId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_Upazilla_UpazillaId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_LabourRoles_LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_District_DistrictId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_Division_DivisionId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_ForestBeats_ForestBeatId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_ForestCircles_ForestCircleId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_ForestDivisions_ForestDivisionId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_ForestRanges_ForestRangeId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherLabourMembers_Upazilla_UpazillaId",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropIndex(
                name: "IX_LabourDatabases_OtherLabourMemberId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.AlterColumn<long>(
                name: "UpazillaId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestRangeId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestFcvVcfId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestDivisionId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestCircleId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestBeatId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DivisionId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DistrictId",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "varchar(600)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherOrSpouse",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherOrSpouse",
                schema: "Labour",
                table: "LabourDatabases",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                schema: "Labour",
                table: "LabourDatabases",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ManDays",
                schema: "Labour",
                table: "LabourDatabases",
                type: "varchar(600)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                schema: "Labour",
                table: "LabourDatabases",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NidNo",
                schema: "Labour",
                table: "LabourDatabases",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_OtherLabourMemberId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "OtherLabourMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_LabourRoles_LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "LabourRoleId",
                principalSchema: "Labour",
                principalTable: "LabourRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_District_DistrictId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_Division_DivisionId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_ForestBeats_ForestBeatId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_ForestCircles_ForestCircleId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_ForestDivisions_ForestDivisionId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_ForestRanges_ForestRangeId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherLabourMembers_Upazilla_UpazillaId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
