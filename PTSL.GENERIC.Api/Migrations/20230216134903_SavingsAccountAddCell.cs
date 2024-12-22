using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class SavingsAccountAddCell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountTypeId",
                schema: "BSA",
                table: "SavingsAccount",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountLimit",
                schema: "BSA",
                table: "SavingsAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                schema: "BSA",
                table: "SavingsAccount");

            migrationBuilder.DropColumn(
                name: "AmountLimit",
                schema: "BSA",
                table: "SavingsAccount");
        }
    }
}
