using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CipNgo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NgoId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cips_NgoId",
                schema: "BEN",
                table: "Cips",
                column: "NgoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_Ngos_NgoId",
                schema: "BEN",
                table: "Cips",
                column: "NgoId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cips_Ngos_NgoId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropIndex(
                name: "IX_Cips_NgoId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropColumn(
                name: "NgoId",
                schema: "BEN",
                table: "Cips");
        }
    }
}
