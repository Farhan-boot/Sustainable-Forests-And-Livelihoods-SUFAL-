using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class LotWiseSaleValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SaleValueOfLot",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SaleValueOfTaxPercentage",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SaleValueOfVatPercentage",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaleValueOfLot",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations");

            migrationBuilder.DropColumn(
                name: "SaleValueOfTaxPercentage",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations");

            migrationBuilder.DropColumn(
                name: "SaleValueOfVatPercentage",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations");
        }
    }
}
