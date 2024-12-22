using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class SurveyFcvAddedDateAndIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FcvVcfAddedDate",
                schema: "BEN",
                table: "Surveys",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_BeneficiaryId",
                schema: "BEN",
                table: "Surveys",
                column: "BeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_CipGeneratedId",
                schema: "BEN",
                table: "Cips",
                column: "CipGeneratedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Surveys_BeneficiaryId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Cips_CipGeneratedId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropColumn(
                name: "FcvVcfAddedDate",
                schema: "BEN",
                table: "Surveys");
        }
    }
}
