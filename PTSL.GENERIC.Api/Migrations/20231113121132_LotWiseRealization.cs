using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class LotWiseRealization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LotNumber",
                schema: "SocialForestry",
                table: "Realizations");

            migrationBuilder.RenameColumn(
                name: "VatAndTax",
                schema: "SocialForestry",
                table: "Realizations",
                newName: "TotalSaleValue");

            migrationBuilder.RenameColumn(
                name: "RealizedAmount",
                schema: "SocialForestry",
                table: "Realizations",
                newName: "SaleValueOfVatPercentage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RealizedDate",
                schema: "SocialForestry",
                table: "Realizations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LotWiseSellingInformationId",
                schema: "SocialForestry",
                table: "Realizations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "SaleValueOfLot",
                schema: "SocialForestry",
                table: "Realizations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SaleValueOfTaxPercentage",
                schema: "SocialForestry",
                table: "Realizations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Realizations_LotWiseSellingInformationId",
                schema: "SocialForestry",
                table: "Realizations",
                column: "LotWiseSellingInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Realizations_LotWiseSellingInformations_LotWiseSellingInfor~",
                schema: "SocialForestry",
                table: "Realizations",
                column: "LotWiseSellingInformationId",
                principalSchema: "SocialForestry",
                principalTable: "LotWiseSellingInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Realizations_LotWiseSellingInformations_LotWiseSellingInfor~",
                schema: "SocialForestry",
                table: "Realizations");

            migrationBuilder.DropIndex(
                name: "IX_Realizations_LotWiseSellingInformationId",
                schema: "SocialForestry",
                table: "Realizations");

            migrationBuilder.DropColumn(
                name: "LotWiseSellingInformationId",
                schema: "SocialForestry",
                table: "Realizations");

            migrationBuilder.DropColumn(
                name: "SaleValueOfLot",
                schema: "SocialForestry",
                table: "Realizations");

            migrationBuilder.DropColumn(
                name: "SaleValueOfTaxPercentage",
                schema: "SocialForestry",
                table: "Realizations");

            migrationBuilder.RenameColumn(
                name: "TotalSaleValue",
                schema: "SocialForestry",
                table: "Realizations",
                newName: "VatAndTax");

            migrationBuilder.RenameColumn(
                name: "SaleValueOfVatPercentage",
                schema: "SocialForestry",
                table: "Realizations",
                newName: "RealizedAmount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RealizedDate",
                schema: "SocialForestry",
                table: "Realizations",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "LotNumber",
                schema: "SocialForestry",
                table: "Realizations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
