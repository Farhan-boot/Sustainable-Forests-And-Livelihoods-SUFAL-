using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NewRaisedPlantationAddUnion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_UnionId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "UnionId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantation_Union_UnionId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantation_Union_UnionId",
                schema: "Plantation",
                table: "NewRaisedPlantation");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantation_UnionId",
                schema: "Plantation",
                table: "NewRaisedPlantation");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "Plantation",
                table: "NewRaisedPlantation");
        }
    }
}
