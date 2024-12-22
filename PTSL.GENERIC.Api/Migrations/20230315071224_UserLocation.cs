using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class UserLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "System",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                schema: "System",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "System",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "DistrictId",
                schema: "System",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DivisionId",
                schema: "System",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestBeatId",
                schema: "System",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestCircleId",
                schema: "System",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestDivisionId",
                schema: "System",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestFcvVcfId",
                schema: "System",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestRangeId",
                schema: "System",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "System",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpazillaId",
                schema: "System",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_DistrictId",
                schema: "System",
                table: "User",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DivisionId",
                schema: "System",
                table: "User",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ForestBeatId",
                schema: "System",
                table: "User",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ForestCircleId",
                schema: "System",
                table: "User",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ForestDivisionId",
                schema: "System",
                table: "User",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ForestFcvVcfId",
                schema: "System",
                table: "User",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ForestRangeId",
                schema: "System",
                table: "User",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UnionId",
                schema: "System",
                table: "User",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UpazillaId",
                schema: "System",
                table: "User",
                column: "UpazillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_District_DistrictId",
                schema: "System",
                table: "User",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Division_DivisionId",
                schema: "System",
                table: "User",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ForestBeats_ForestBeatId",
                schema: "System",
                table: "User",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ForestCircles_ForestCircleId",
                schema: "System",
                table: "User",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ForestDivisions_ForestDivisionId",
                schema: "System",
                table: "User",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ForestFcvVcfs_ForestFcvVcfId",
                schema: "System",
                table: "User",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ForestRanges_ForestRangeId",
                schema: "System",
                table: "User",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Union_UnionId",
                schema: "System",
                table: "User",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Upazilla_UpazillaId",
                schema: "System",
                table: "User",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_District_DistrictId",
                schema: "System",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Division_DivisionId",
                schema: "System",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ForestBeats_ForestBeatId",
                schema: "System",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ForestCircles_ForestCircleId",
                schema: "System",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ForestDivisions_ForestDivisionId",
                schema: "System",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ForestFcvVcfs_ForestFcvVcfId",
                schema: "System",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ForestRanges_ForestRangeId",
                schema: "System",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Union_UnionId",
                schema: "System",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Upazilla_UpazillaId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DistrictId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DivisionId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ForestBeatId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ForestCircleId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ForestDivisionId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ForestFcvVcfId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ForestRangeId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UnionId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UpazillaId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ForestBeatId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ForestCircleId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ForestDivisionId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ForestFcvVcfId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ForestRangeId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpazillaId",
                schema: "System",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "System",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                schema: "System",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "System",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
