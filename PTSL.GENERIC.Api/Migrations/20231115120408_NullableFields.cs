using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantationPlants_NurseryRaisedSeedlingInformations_NurseryR~",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.AlterColumn<long>(
                name: "NurseryRaisedSeedlingInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NurseryImage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantationImage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InspectionFile",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantationPlants_NurseryRaisedSeedlingInformations_NurseryR~",
                schema: "SocialForestry",
                table: "PlantationPlants",
                column: "NurseryRaisedSeedlingInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryRaisedSeedlingInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantationPlants_NurseryRaisedSeedlingInformations_NurseryR~",
                schema: "SocialForestry",
                table: "PlantationPlants");

            migrationBuilder.DropColumn(
                name: "NurseryImage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.DropColumn(
                name: "PlantationImage",
                schema: "SocialForestry",
                table: "NewRaisedPlantations");

            migrationBuilder.AlterColumn<long>(
                name: "NurseryRaisedSeedlingInformationId",
                schema: "SocialForestry",
                table: "PlantationPlants",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "InspectionFile",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                schema: "SocialForestry",
                table: "InspectionDetailss",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantationPlants_NurseryRaisedSeedlingInformations_NurseryR~",
                schema: "SocialForestry",
                table: "PlantationPlants",
                column: "NurseryRaisedSeedlingInformationId",
                principalSchema: "SocialForestry",
                principalTable: "NurseryRaisedSeedlingInformations",
                principalColumn: "Id");
        }
    }
}
