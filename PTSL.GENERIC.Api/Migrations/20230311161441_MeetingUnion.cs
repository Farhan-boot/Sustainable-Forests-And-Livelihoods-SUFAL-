using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class MeetingUnion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "Meeting",
                table: "Meetings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_UnionId",
                schema: "Meeting",
                table: "Meetings",
                column: "UnionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Union_UnionId",
                schema: "Meeting",
                table: "Meetings",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Union_UnionId",
                schema: "Meeting",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_UnionId",
                schema: "Meeting",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "Meeting",
                table: "Meetings");
        }
    }
}
