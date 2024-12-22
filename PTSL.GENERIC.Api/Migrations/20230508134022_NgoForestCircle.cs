using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NgoForestCircle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForestDivisions_Ngos_NgoId",
                schema: "BEN",
                table: "ForestDivisions");

            migrationBuilder.DropIndex(
                name: "IX_ForestDivisions_NgoId",
                schema: "BEN",
                table: "ForestDivisions");

            migrationBuilder.DropColumn(
                name: "NgoId",
                schema: "BEN",
                table: "ForestDivisions");

            migrationBuilder.AddColumn<long>(
                name: "ForestCircleId",
                schema: "BEN",
                table: "Ngos",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForestCircleId",
                schema: "BEN",
                table: "Ngos");

            migrationBuilder.AddColumn<long>(
                name: "NgoId",
                schema: "BEN",
                table: "ForestDivisions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForestDivisions_NgoId",
                schema: "BEN",
                table: "ForestDivisions",
                column: "NgoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForestDivisions_Ngos_NgoId",
                schema: "BEN",
                table: "ForestDivisions",
                column: "NgoId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id");
        }
    }
}
