using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class PlantationRevenue2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeOfPlantationRevenue_TypeOfPlantation_TypeOfPlantationId",
                table: "TypeOfPlantationRevenue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfPlantationRevenue",
                table: "TypeOfPlantationRevenue");

            migrationBuilder.RenameTable(
                name: "TypeOfPlantationRevenue",
                newName: "TypeOfPlantationRevenues",
                newSchema: "Plantation");

            migrationBuilder.RenameIndex(
                name: "IX_TypeOfPlantationRevenue_TypeOfPlantationId",
                schema: "Plantation",
                table: "TypeOfPlantationRevenues",
                newName: "IX_TypeOfPlantationRevenues_TypeOfPlantationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfPlantationRevenues",
                schema: "Plantation",
                table: "TypeOfPlantationRevenues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeOfPlantationRevenues_TypeOfPlantation_TypeOfPlantationId",
                schema: "Plantation",
                table: "TypeOfPlantationRevenues",
                column: "TypeOfPlantationId",
                principalSchema: "Plantation",
                principalTable: "TypeOfPlantation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeOfPlantationRevenues_TypeOfPlantation_TypeOfPlantationId",
                schema: "Plantation",
                table: "TypeOfPlantationRevenues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfPlantationRevenues",
                schema: "Plantation",
                table: "TypeOfPlantationRevenues");

            migrationBuilder.RenameTable(
                name: "TypeOfPlantationRevenues",
                schema: "Plantation",
                newName: "TypeOfPlantationRevenue");

            migrationBuilder.RenameIndex(
                name: "IX_TypeOfPlantationRevenues_TypeOfPlantationId",
                table: "TypeOfPlantationRevenue",
                newName: "IX_TypeOfPlantationRevenue_TypeOfPlantationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfPlantationRevenue",
                table: "TypeOfPlantationRevenue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeOfPlantationRevenue_TypeOfPlantation_TypeOfPlantationId",
                table: "TypeOfPlantationRevenue",
                column: "TypeOfPlantationId",
                principalSchema: "Plantation",
                principalTable: "TypeOfPlantation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
