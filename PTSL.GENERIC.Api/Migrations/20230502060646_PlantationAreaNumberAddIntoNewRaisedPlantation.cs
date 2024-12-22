using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class PlantationAreaNumberAddIntoNewRaisedPlantation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PlantationAreaNumber",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlantationAreaNumber",
                schema: "Plantation",
                table: "NewRaisedPlantation");
        }
    }
}
