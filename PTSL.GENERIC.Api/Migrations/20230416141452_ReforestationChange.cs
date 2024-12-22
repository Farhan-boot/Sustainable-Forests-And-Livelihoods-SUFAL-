using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ReforestationChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _District_DistrictId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _Division_DivisionId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _ForestBeats_ForestBeatId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _ForestCircles_ForestCircleId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _ForestDivisions_ForestDivisionId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _ForestRanges_ForestRangeId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _NewRaisedPlantation_NewRaisedPlantationId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _Ngos_NgoId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _ProjectNameAndBudget_ProjectNameAndBudgetId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _RotationNumber_RotationNoId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _StripType_StripTypeId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _TypeOfPlantation_TypeOfPlantationId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation _Upazilla_UpazillaId",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reforestation ",
                schema: "Plantation",
                table: "Reforestation ");

            migrationBuilder.RenameTable(
                name: "Reforestation ",
                schema: "Plantation",
                newName: "Reforestation",
                newSchema: "Plantation");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _UpazillaId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_UpazillaId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _TypeOfPlantationId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_TypeOfPlantationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _StripTypeId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_StripTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _RotationNoId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_RotationNoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _ProjectNameAndBudgetId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_ProjectNameAndBudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _NgoId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_NgoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _NewRaisedPlantationId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_NewRaisedPlantationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _ForestRangeId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_ForestRangeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _ForestDivisionId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_ForestDivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _ForestCircleId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_ForestCircleId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _ForestBeatId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_ForestBeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _DivisionId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation _DistrictId",
                schema: "Plantation",
                table: "Reforestation",
                newName: "IX_Reforestation_DistrictId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reforestation",
                schema: "Plantation",
                table: "Reforestation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_District_DistrictId",
                schema: "Plantation",
                table: "Reforestation",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_Division_DivisionId",
                schema: "Plantation",
                table: "Reforestation",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_ForestBeats_ForestBeatId",
                schema: "Plantation",
                table: "Reforestation",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_ForestCircles_ForestCircleId",
                schema: "Plantation",
                table: "Reforestation",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_ForestDivisions_ForestDivisionId",
                schema: "Plantation",
                table: "Reforestation",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_ForestRanges_ForestRangeId",
                schema: "Plantation",
                table: "Reforestation",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_NewRaisedPlantation_NewRaisedPlantationId",
                schema: "Plantation",
                table: "Reforestation",
                column: "NewRaisedPlantationId",
                principalSchema: "Plantation",
                principalTable: "NewRaisedPlantation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_Ngos_NgoId",
                schema: "Plantation",
                table: "Reforestation",
                column: "NgoId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_ProjectNameAndBudget_ProjectNameAndBudgetId",
                schema: "Plantation",
                table: "Reforestation",
                column: "ProjectNameAndBudgetId",
                principalSchema: "Plantation",
                principalTable: "ProjectNameAndBudget",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_RotationNumber_RotationNoId",
                schema: "Plantation",
                table: "Reforestation",
                column: "RotationNoId",
                principalSchema: "Plantation",
                principalTable: "RotationNumber",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_StripType_StripTypeId",
                schema: "Plantation",
                table: "Reforestation",
                column: "StripTypeId",
                principalSchema: "Plantation",
                principalTable: "StripType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_TypeOfPlantation_TypeOfPlantationId",
                schema: "Plantation",
                table: "Reforestation",
                column: "TypeOfPlantationId",
                principalSchema: "Plantation",
                principalTable: "TypeOfPlantation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation_Upazilla_UpazillaId",
                schema: "Plantation",
                table: "Reforestation",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_District_DistrictId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_Division_DivisionId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_ForestBeats_ForestBeatId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_ForestCircles_ForestCircleId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_ForestDivisions_ForestDivisionId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_ForestRanges_ForestRangeId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_NewRaisedPlantation_NewRaisedPlantationId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_Ngos_NgoId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_ProjectNameAndBudget_ProjectNameAndBudgetId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_RotationNumber_RotationNoId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_StripType_StripTypeId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_TypeOfPlantation_TypeOfPlantationId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reforestation_Upazilla_UpazillaId",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reforestation",
                schema: "Plantation",
                table: "Reforestation");

            migrationBuilder.RenameTable(
                name: "Reforestation",
                schema: "Plantation",
                newName: "Reforestation ",
                newSchema: "Plantation");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_UpazillaId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _UpazillaId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_TypeOfPlantationId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _TypeOfPlantationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_StripTypeId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _StripTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_RotationNoId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _RotationNoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_ProjectNameAndBudgetId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _ProjectNameAndBudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_NgoId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _NgoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_NewRaisedPlantationId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _NewRaisedPlantationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_ForestRangeId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _ForestRangeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_ForestDivisionId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _ForestDivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_ForestCircleId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _ForestCircleId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_ForestBeatId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _ForestBeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_DivisionId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Reforestation_DistrictId",
                schema: "Plantation",
                table: "Reforestation ",
                newName: "IX_Reforestation _DistrictId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reforestation ",
                schema: "Plantation",
                table: "Reforestation ",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _District_DistrictId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _Division_DivisionId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _ForestBeats_ForestBeatId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _ForestCircles_ForestCircleId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _ForestDivisions_ForestDivisionId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _ForestRanges_ForestRangeId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _NewRaisedPlantation_NewRaisedPlantationId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "NewRaisedPlantationId",
                principalSchema: "Plantation",
                principalTable: "NewRaisedPlantation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _Ngos_NgoId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "NgoId",
                principalSchema: "BEN",
                principalTable: "Ngos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _ProjectNameAndBudget_ProjectNameAndBudgetId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "ProjectNameAndBudgetId",
                principalSchema: "Plantation",
                principalTable: "ProjectNameAndBudget",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _RotationNumber_RotationNoId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "RotationNoId",
                principalSchema: "Plantation",
                principalTable: "RotationNumber",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _StripType_StripTypeId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "StripTypeId",
                principalSchema: "Plantation",
                principalTable: "StripType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _TypeOfPlantation_TypeOfPlantationId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "TypeOfPlantationId",
                principalSchema: "Plantation",
                principalTable: "TypeOfPlantation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reforestation _Upazilla_UpazillaId",
                schema: "Plantation",
                table: "Reforestation ",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id");
        }
    }
}
