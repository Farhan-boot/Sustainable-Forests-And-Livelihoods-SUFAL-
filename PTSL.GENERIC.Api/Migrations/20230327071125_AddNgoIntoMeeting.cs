using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class AddNgoIntoMeeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NgoId",
                schema: "Meeting",
                table: "Meetings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_NgoId",
                schema: "Meeting",
                table: "Meetings",
                column: "NgoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Ngos_NgoId",
                schema: "Meeting",
                table: "Meetings",
                column: "NgoId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Ngos_NgoId",
                schema: "Meeting",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_NgoId",
                schema: "Meeting",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "NgoId",
                schema: "Meeting",
                table: "Meetings");
        }
    }
}
