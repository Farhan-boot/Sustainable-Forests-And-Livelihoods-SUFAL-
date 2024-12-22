using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AIGFirstAndSecondDisbursmentDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DisbursementDate",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DisbursementDate",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisbursementDate",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "DisbursementDate",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs");
        }
    }
}
