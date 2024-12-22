using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class RepaymentLDFTakenAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FirstSixtyPercentRepaymentAmountReceived",
                schema: "AIG",
                table: "RepaymentLDFs",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SecondFortyPercentRepaymentAmountReceived",
                schema: "AIG",
                table: "RepaymentLDFs",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstSixtyPercentRepaymentAmountReceived",
                schema: "AIG",
                table: "RepaymentLDFs");

            migrationBuilder.DropColumn(
                name: "SecondFortyPercentRepaymentAmountReceived",
                schema: "AIG",
                table: "RepaymentLDFs");
        }
    }
}
