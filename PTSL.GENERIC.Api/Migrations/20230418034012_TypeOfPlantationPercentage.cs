using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class TypeOfPlantationPercentage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BeneficiaryPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ForestDepartmentPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TFFPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiaryPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation");

            migrationBuilder.DropColumn(
                name: "ForestDepartmentPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation");

            migrationBuilder.DropColumn(
                name: "TFFPercentage",
                schema: "Plantation",
                table: "TypeOfPlantation");
        }
    }
}
