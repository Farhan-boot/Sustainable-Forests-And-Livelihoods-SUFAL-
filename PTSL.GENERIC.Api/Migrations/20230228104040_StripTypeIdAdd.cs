using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class StripTypeIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StripTypeId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewRaisedPlantation_StripTypeId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "StripTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewRaisedPlantation_StripType_StripTypeId",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                column: "StripTypeId",
                principalSchema: "Plantation",
                principalTable: "StripType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewRaisedPlantation_StripType_StripTypeId",
                schema: "Plantation",
                table: "NewRaisedPlantation");

            migrationBuilder.DropIndex(
                name: "IX_NewRaisedPlantation_StripTypeId",
                schema: "Plantation",
                table: "NewRaisedPlantation");

            migrationBuilder.DropColumn(
                name: "StripTypeId",
                schema: "Plantation",
                table: "NewRaisedPlantation");
        }
    }
}
