using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NgoCircleCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForestCircleId",
                schema: "BEN",
                table: "Ngos");

            migrationBuilder.AddColumn<List<long>>(
                name: "ForestCircleIdList",
                schema: "BEN",
                table: "Ngos",
                type: "bigint[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForestCircleIdList",
                schema: "BEN",
                table: "Ngos");

            migrationBuilder.AddColumn<long>(
                name: "ForestCircleId",
                schema: "BEN",
                table: "Ngos",
                type: "bigint",
                nullable: true);
        }
    }
}
