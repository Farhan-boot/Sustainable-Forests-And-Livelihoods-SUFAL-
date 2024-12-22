using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NewRaisedPlantationChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFundManagementSubCommiteeFormed",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSocialForestryCommiteeFormed",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RotationInYear",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YearOfFelling",
                schema: "Plantation",
                table: "NewRaisedPlantation",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFundManagementSubCommiteeFormed",
                schema: "Plantation",
                table: "NewRaisedPlantation");

            migrationBuilder.DropColumn(
                name: "IsSocialForestryCommiteeFormed",
                schema: "Plantation",
                table: "NewRaisedPlantation");

            migrationBuilder.DropColumn(
                name: "RotationInYear",
                schema: "Plantation",
                table: "NewRaisedPlantation");

            migrationBuilder.DropColumn(
                name: "YearOfFelling",
                schema: "Plantation",
                table: "NewRaisedPlantation");
        }
    }
}
