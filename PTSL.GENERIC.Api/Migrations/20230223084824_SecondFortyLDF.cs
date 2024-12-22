using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class SecondFortyLDF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DidNotBreakTheTenPrinciples",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasInvestedSeventyPercentageOfTheLoan",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncomeExpenditureFundLoansUpdatedAndCertified",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAttendedRegularMeetings",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLivelihoodDevelopmentFundCertifiedAndApproved",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaidTheLoanInstallmentThreeConsecutiveMonths",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "LDFAmount",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DidNotBreakTheTenPrinciples",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "HasInvestedSeventyPercentageOfTheLoan",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "IncomeExpenditureFundLoansUpdatedAndCertified",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "IsAttendedRegularMeetings",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "IsLivelihoodDevelopmentFundCertifiedAndApproved",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "IsPaidTheLoanInstallmentThreeConsecutiveMonths",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "LDFAmount",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");
        }
    }
}
