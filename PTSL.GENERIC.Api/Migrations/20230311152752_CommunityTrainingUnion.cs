using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class CommunityTrainingUnion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "Capacity",
                table: "CommunityTrainings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_UnionId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "UnionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityTrainings_Union_UnionId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityTrainings_Union_UnionId",
                schema: "Capacity",
                table: "CommunityTrainings");

            migrationBuilder.DropIndex(
                name: "IX_CommunityTrainings_UnionId",
                schema: "Capacity",
                table: "CommunityTrainings");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "Capacity",
                table: "CommunityTrainings");
        }
    }
}
