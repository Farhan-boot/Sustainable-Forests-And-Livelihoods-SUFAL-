using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ApprovalAddIntoCommittee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CommitteeApprovalBy",
                schema: "BEN",
                table: "CommitteeManagement",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CommitteeApprovalDate",
                schema: "BEN",
                table: "CommitteeManagement",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CommitteeApprovalStatus",
                schema: "BEN",
                table: "CommitteeManagement",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommitteeApprovalBy",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.DropColumn(
                name: "CommitteeApprovalDate",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.DropColumn(
                name: "CommitteeApprovalStatus",
                schema: "BEN",
                table: "CommitteeManagement");
        }
    }
}
