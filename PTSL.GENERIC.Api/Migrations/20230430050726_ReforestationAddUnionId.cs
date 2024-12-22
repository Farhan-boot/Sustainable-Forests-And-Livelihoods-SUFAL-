using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ReforestationAddUnionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "Plantation",
                table: "Reforestation",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reforestation_UnionId",
                schema: "Plantation",
                table: "Reforestation",
                column: "UnionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_Union_UnionId",
                schema: "Plantation",
                table: "Reforestation",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_Union_UnionId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropIndex(
                name: "IX_Reforestation_UnionId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "Plantation",
                table: "Reforestation");
        }
    }
}
