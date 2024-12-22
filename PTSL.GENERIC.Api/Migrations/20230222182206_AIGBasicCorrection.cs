using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class AIGBasicCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBankAccountInHisOwnName",
                schema: "AIG",
                table: "AIGBasicInformations");

            migrationBuilder.DropColumn(
                name: "IsAgreeToInvestInOwnIncomeActivities",
                schema: "AIG",
                table: "AIGBasicInformations");

            migrationBuilder.DropColumn(
                name: "IsAgreedToKeepIncomeAndExpenditureFund",
                schema: "AIG",
                table: "AIGBasicInformations");

            migrationBuilder.DropColumn(
                name: "IsAttendedEightyPercentageOfMeetings",
                schema: "AIG",
                table: "AIGBasicInformations");

            migrationBuilder.DropColumn(
                name: "IsFirstInstallmentIsCertifiedBySocialAuditCommittee",
                schema: "AIG",
                table: "AIGBasicInformations");

            migrationBuilder.DropColumn(
                name: "IsPayingRegularIncomingInstallments",
                schema: "AIG",
                table: "AIGBasicInformations");

            migrationBuilder.DropColumn(
                name: "ShallAdhereTheCOM",
                schema: "AIG",
                table: "AIGBasicInformations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBankAccountInHisOwnName",
                schema: "AIG",
                table: "AIGBasicInformations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAgreeToInvestInOwnIncomeActivities",
                schema: "AIG",
                table: "AIGBasicInformations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAgreedToKeepIncomeAndExpenditureFund",
                schema: "AIG",
                table: "AIGBasicInformations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAttendedEightyPercentageOfMeetings",
                schema: "AIG",
                table: "AIGBasicInformations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFirstInstallmentIsCertifiedBySocialAuditCommittee",
                schema: "AIG",
                table: "AIGBasicInformations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPayingRegularIncomingInstallments",
                schema: "AIG",
                table: "AIGBasicInformations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShallAdhereTheCOM",
                schema: "AIG",
                table: "AIGBasicInformations",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
