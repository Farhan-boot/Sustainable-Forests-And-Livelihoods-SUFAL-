using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class RotationNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RotationNo",
                schema: "SocialForestry",
                table: "Reforestations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RotationNo",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RotationNo",
                schema: "SocialForestry",
                table: "Reforestations");

            migrationBuilder.DropColumn(
                name: "RotationNo",
                schema: "SocialForestry",
                table: "CuttingPlantations");
        }
    }
}
