using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class AddFildNameInBeneficiaryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BeneficiaryId",
                schema: "BEN",
                table: "FcvExecutiveCommitteeMember",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BeneficiaryId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiaryId",
                schema: "BEN",
                table: "FcvExecutiveCommitteeMember");

            migrationBuilder.DropColumn(
                name: "BeneficiaryId",
                schema: "BEN",
                table: "ExecutiveCommittee");
        }
    }
}
