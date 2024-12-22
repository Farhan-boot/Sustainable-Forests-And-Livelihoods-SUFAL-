using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccountOpeningDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpeningDate",
                schema: "AccountManagement",
                table: "Accounts");

            migrationBuilder.AddColumn<DateTime>(
                name: "AccountOpeningDate",
                schema: "AccountManagement",
                table: "Accounts",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountOpeningDate",
                schema: "AccountManagement",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "OpeningDate",
                schema: "AccountManagement",
                table: "Accounts",
                type: "text",
                nullable: true);
        }
    }
}
