using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class DepartmentalTrainingMemberEthnicity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EthnicityId",
                schema: "Capacity",
                table: "DepartmentalTrainingMembers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainingMembers_EthnicityId",
                schema: "Capacity",
                table: "DepartmentalTrainingMembers",
                column: "EthnicityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainingMembers_Ethnicitys_EthnicityId",
                schema: "Capacity",
                table: "DepartmentalTrainingMembers",
                column: "EthnicityId",
                principalSchema: "BEN",
                principalTable: "Ethnicitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainingMembers_Ethnicitys_EthnicityId",
                schema: "Capacity",
                table: "DepartmentalTrainingMembers");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentalTrainingMembers_EthnicityId",
                schema: "Capacity",
                table: "DepartmentalTrainingMembers");

            migrationBuilder.DropColumn(
                name: "EthnicityId",
                schema: "Capacity",
                table: "DepartmentalTrainingMembers");
        }
    }
}
