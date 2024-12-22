using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class SurveyCIPUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cips_CipGeneratedId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_CipGeneratedId",
                schema: "BEN",
                table: "Cips",
                column: "CipGeneratedId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cips_CipGeneratedId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_CipGeneratedId",
                schema: "BEN",
                table: "Cips",
                column: "CipGeneratedId");
        }
    }
}
