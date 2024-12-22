using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class RelationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CuttingPlantationId",
                schema: "SocialForestry",
                table: "Reforestations",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ReforestationId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuttingPlantationId",
                schema: "SocialForestry",
                table: "Reforestations");

            migrationBuilder.DropColumn(
                name: "ReforestationId",
                schema: "SocialForestry",
                table: "CuttingPlantations");
        }
    }
}
