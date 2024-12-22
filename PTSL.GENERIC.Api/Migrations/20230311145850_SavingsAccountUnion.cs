using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class SavingsAccountUnion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "BSA",
                table: "SavingsAccount",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccount_UnionId",
                schema: "BSA",
                table: "SavingsAccount",
                column: "UnionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsAccount_Union_UnionId",
                schema: "BSA",
                table: "SavingsAccount",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavingsAccount_Union_UnionId",
                schema: "BSA",
                table: "SavingsAccount");

            migrationBuilder.DropIndex(
                name: "IX_SavingsAccount_UnionId",
                schema: "BSA",
                table: "SavingsAccount");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "BSA",
                table: "SavingsAccount");
        }
    }
}
