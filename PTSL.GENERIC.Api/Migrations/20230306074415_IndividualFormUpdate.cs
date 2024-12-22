using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class IndividualFormUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiaryGender",
                schema: "AIG",
                table: "IndividualLDFInfoForms");

            migrationBuilder.DropColumn(
                name: "BeneficiaryName",
                schema: "AIG",
                table: "IndividualLDFInfoForms");

            migrationBuilder.DropColumn(
                name: "BeneficiaryNid",
                schema: "AIG",
                table: "IndividualLDFInfoForms");

            migrationBuilder.DropColumn(
                name: "BeneficiaryPhone",
                schema: "AIG",
                table: "IndividualLDFInfoForms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<long>(
                name: "NgoId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLDFInfoForms_NgoId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "NgoId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualLDFInfoForms_Ngos_NgoId",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                column: "NgoId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualLDFInfoForms_Ngos_NgoId",
                schema: "AIG",
                table: "IndividualLDFInfoForms");

            migrationBuilder.DropIndex(
                name: "IX_IndividualLDFInfoForms_NgoId",
                schema: "AIG",
                table: "IndividualLDFInfoForms");

            migrationBuilder.DropColumn(
                name: "NgoId",
                schema: "AIG",
                table: "IndividualLDFInfoForms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryGender",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryName",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryNid",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryPhone",
                schema: "AIG",
                table: "IndividualLDFInfoForms",
                type: "text",
                nullable: true);
        }
    }
}
