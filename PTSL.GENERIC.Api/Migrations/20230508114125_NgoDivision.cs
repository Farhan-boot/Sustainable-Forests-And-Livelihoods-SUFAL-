using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NgoDivision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ForestDivisionId",
                schema: "BEN",
                table: "Ngos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ngos_ForestDivisionId",
                schema: "BEN",
                table: "Ngos",
                column: "ForestDivisionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ngos_ForestDivisions_ForestDivisionId",
                schema: "BEN",
                table: "Ngos",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ngos_ForestDivisions_ForestDivisionId",
                schema: "BEN",
                table: "Ngos");

            migrationBuilder.DropIndex(
                name: "IX_Ngos_ForestDivisionId",
                schema: "BEN",
                table: "Ngos");

            migrationBuilder.DropColumn(
                name: "ForestDivisionId",
                schema: "BEN",
                table: "Ngos");
        }
    }
}
