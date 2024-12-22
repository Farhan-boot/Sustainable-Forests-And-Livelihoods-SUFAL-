using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CommitteeFormDateAndCommitteeFormEndDateAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CommitteeEndDate",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CommitteeFormDate",
                schema: "BEN",
                table: "ExecutiveCommittee",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommitteeEndDate",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "CommitteeFormDate",
                schema: "BEN",
                table: "ExecutiveCommittee");
        }
    }
}
