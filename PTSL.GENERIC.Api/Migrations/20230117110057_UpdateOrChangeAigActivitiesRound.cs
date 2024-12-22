using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class UpdateOrChangeAigActivitiesRound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstRoundLdfAmount",
                schema: "AIG",
                table: "AigActivitiesRound");

            migrationBuilder.DropColumn(
                name: "FirstRoundLdfValidation",
                schema: "AIG",
                table: "AigActivitiesRound");

            migrationBuilder.AddColumn<decimal>(
                name: "FirstLoanAmount",
                schema: "AIG",
                table: "AigActivitiesRound",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstLoanDate",
                schema: "AIG",
                table: "AigActivitiesRound",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RoundLdfAmount",
                schema: "AIG",
                table: "AigActivitiesRound",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoundLdfValidation",
                schema: "AIG",
                table: "AigActivitiesRound",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SecondLoanAmount",
                schema: "AIG",
                table: "AigActivitiesRound",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecondLoanDate",
                schema: "AIG",
                table: "AigActivitiesRound",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstLoanAmount",
                schema: "AIG",
                table: "AigActivitiesRound");

            migrationBuilder.DropColumn(
                name: "FirstLoanDate",
                schema: "AIG",
                table: "AigActivitiesRound");

            migrationBuilder.DropColumn(
                name: "RoundLdfAmount",
                schema: "AIG",
                table: "AigActivitiesRound");

            migrationBuilder.DropColumn(
                name: "RoundLdfValidation",
                schema: "AIG",
                table: "AigActivitiesRound");

            migrationBuilder.DropColumn(
                name: "SecondLoanAmount",
                schema: "AIG",
                table: "AigActivitiesRound");

            migrationBuilder.DropColumn(
                name: "SecondLoanDate",
                schema: "AIG",
                table: "AigActivitiesRound");

            migrationBuilder.AddColumn<decimal>(
                name: "FirstRoundLdfAmount",
                schema: "AIG",
                table: "AigActivitiesRound",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstRoundLdfValidation",
                schema: "AIG",
                table: "AigActivitiesRound",
                type: "text",
                nullable: true);
        }
    }
}
