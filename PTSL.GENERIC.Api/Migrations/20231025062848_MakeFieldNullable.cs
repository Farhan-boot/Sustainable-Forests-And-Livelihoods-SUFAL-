using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class MakeFieldNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialForestryBeneficiarys_Ethnicitys_EthnicityId",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys");

            migrationBuilder.AlterColumn<long>(
                name: "EthnicityId",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialForestryBeneficiarys_Ethnicitys_EthnicityId",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys",
                column: "EthnicityId",
                principalSchema: "BEN",
                principalTable: "Ethnicitys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialForestryBeneficiarys_Ethnicitys_EthnicityId",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys");

            migrationBuilder.AlterColumn<long>(
                name: "EthnicityId",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialForestryBeneficiarys_Ethnicitys_EthnicityId",
                schema: "SocialForestry",
                table: "SocialForestryBeneficiarys",
                column: "EthnicityId",
                principalSchema: "BEN",
                principalTable: "Ethnicitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
