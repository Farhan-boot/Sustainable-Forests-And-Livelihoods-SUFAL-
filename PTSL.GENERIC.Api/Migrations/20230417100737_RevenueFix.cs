using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class RevenueFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RevenueOrDistributedAmount",
                newName: "RevenueOrDistributedAmount",
                newSchema: "Plantation");

            migrationBuilder.RenameTable(
                name: "RevenueDistribution",
                newName: "RevenueDistribution",
                newSchema: "Plantation");

            migrationBuilder.RenameTable(
                name: "BankDeposit",
                newName: "BankDeposit",
                newSchema: "Plantation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RevenueOrDistributedAmount",
                schema: "Plantation",
                newName: "RevenueOrDistributedAmount");

            migrationBuilder.RenameTable(
                name: "RevenueDistribution",
                schema: "Plantation",
                newName: "RevenueDistribution");

            migrationBuilder.RenameTable(
                name: "BankDeposit",
                schema: "Plantation",
                newName: "BankDeposit");
        }
    }
}
