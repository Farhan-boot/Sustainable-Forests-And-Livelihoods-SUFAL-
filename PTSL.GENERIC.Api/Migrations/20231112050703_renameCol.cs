using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class renameCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributions_NurseryInformations_NurseryInformation~",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "NurseryId",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.AlterColumn<long>(
                name: "NurseryInformationId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributions_NurseryInformations_NurseryInformation~",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "NurseryInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseryDistributions_NurseryInformations_NurseryInformation~",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.AlterColumn<long>(
                name: "NurseryInformationId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "NurseryId",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_NurseryDistributions_NurseryInformations_NurseryInformation~",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                column: "NurseryInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryInformations",
                principalColumn: "Id");
        }
    }
}
