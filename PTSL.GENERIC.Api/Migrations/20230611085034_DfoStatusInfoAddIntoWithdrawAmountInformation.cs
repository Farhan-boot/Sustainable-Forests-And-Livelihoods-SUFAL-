using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class DfoStatusInfoAddIntoWithdrawAmountInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DfoRemark",
                schema: "BSA",
                table: "WithdrawAmountInformation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DfoStatusId",
                schema: "BSA",
                table: "WithdrawAmountInformation",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DfoRemark",
                schema: "BSA",
                table: "WithdrawAmountInformation");

            migrationBuilder.DropColumn(
                name: "DfoStatusId",
                schema: "BSA",
                table: "WithdrawAmountInformation");
        }
    }
}
