using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NurseryInfoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseryInformations_NurseryRaisingSectors_NurseryRaisingSec~",
                schema: "SocialForestry",
                table: "NurseryInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_NurseryRaisedSeedlingInformations_NurseryRaisingSectors_Nur~",
                schema: "SocialForestry",
                table: "NurseryRaisedSeedlingInformations");

            migrationBuilder.DropIndex(
                name: "IX_NurseryRaisedSeedlingInformations_NurseryRaisingSectorId",
                schema: "SocialForestry",
                table: "NurseryRaisedSeedlingInformations");

            migrationBuilder.DropColumn(
                name: "NurseryRaisingSectorId",
                schema: "SocialForestry",
                table: "NurseryRaisedSeedlingInformations");

            migrationBuilder.AlterColumn<string>(
                name: "SanctionNo",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NurseryRaisingSectorId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "LocationLon",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "LocationLat",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryInformations_NurseryRaisingSectors_NurseryRaisingSec~",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "NurseryRaisingSectorId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryRaisingSectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseryInformations_NurseryRaisingSectors_NurseryRaisingSec~",
                schema: "SocialForestry",
                table: "NurseryInformations");

            migrationBuilder.AddColumn<long>(
                name: "NurseryRaisingSectorId",
                schema: "SocialForestry",
                table: "NurseryRaisedSeedlingInformations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "SanctionNo",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "NurseryRaisingSectorId",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "LocationLon",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "LocationLat",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "SocialForestry",
                table: "NurseryInformations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_NurseryRaisedSeedlingInformations_NurseryRaisingSectorId",
                schema: "SocialForestry",
                table: "NurseryRaisedSeedlingInformations",
                column: "NurseryRaisingSectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryInformations_NurseryRaisingSectors_NurseryRaisingSec~",
                schema: "SocialForestry",
                table: "NurseryInformations",
                column: "NurseryRaisingSectorId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryRaisingSectors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryRaisedSeedlingInformations_NurseryRaisingSectors_Nur~",
                schema: "SocialForestry",
                table: "NurseryRaisedSeedlingInformations",
                column: "NurseryRaisingSectorId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryRaisingSectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
