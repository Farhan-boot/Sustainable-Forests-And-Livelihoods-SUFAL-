using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class InspectionDetailsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap");

            migrationBuilder.AlterColumn<long>(
                name: "InspectionDetailsId",
                table: "InspectionDetailsMap",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap",
                column: "InspectionDetailsId",
                principalSchema: "SocialForestry",
                principalTable: "InspectionDetailss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap");

            migrationBuilder.AlterColumn<long>(
                name: "InspectionDetailsId",
                table: "InspectionDetailsMap",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDetailsMap_InspectionDetailss_InspectionDetailsId",
                table: "InspectionDetailsMap",
                column: "InspectionDetailsId",
                principalSchema: "SocialForestry",
                principalTable: "InspectionDetailss",
                principalColumn: "Id");
        }
    }
}
