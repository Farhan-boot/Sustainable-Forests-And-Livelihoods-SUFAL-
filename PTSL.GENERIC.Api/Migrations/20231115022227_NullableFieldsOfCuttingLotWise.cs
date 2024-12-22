using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NullableFieldsOfCuttingLotWise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWiseFuelWoodU~",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWisePoleUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWiseTimberUni~",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations");

            migrationBuilder.AlterColumn<string>(
                name: "TenderNotificationInformation",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "LotWiseTimberUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "LotWisePoleUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "LotWiseFuelWoodUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "ContractorNID",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ContractorMobileNumber",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "MarkedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "MarkedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "MarkedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "MarkedFuelWoodUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "MarkedPoleUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "MarkedTimberUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWiseFuelWoodU~",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                column: "LotWiseFuelWoodUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWisePoleUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                column: "LotWisePoleUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWiseTimberUni~",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                column: "LotWiseTimberUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations");

            migrationBuilder.DropForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWiseFuelWoodU~",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWisePoleUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWiseTimberUni~",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations");

            migrationBuilder.AlterColumn<string>(
                name: "TenderNotificationInformation",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LotWiseTimberUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LotWisePoleUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LotWiseFuelWoodUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContractorNID",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContractorMobileNumber",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MarkedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MarkedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MarkedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedFuelWoodUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "MarkedFuelWoodUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedPoleUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "MarkedPoleUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingPlantations_PlantationUnits_MarkedTimberUnitId",
                schema: "SocialForestry",
                table: "CuttingPlantations",
                column: "MarkedTimberUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWiseFuelWoodU~",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                column: "LotWiseFuelWoodUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWisePoleUnitId",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                column: "LotWisePoleUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LotWiseSellingInformations_PlantationUnits_LotWiseTimberUni~",
                schema: "SocialForestry",
                table: "LotWiseSellingInformations",
                column: "LotWiseTimberUnitId",
                principalSchema: "SocialForestry",
                principalTable: "PlantationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
