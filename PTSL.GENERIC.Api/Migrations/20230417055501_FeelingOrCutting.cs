using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class FeelingOrCutting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeelingOrCutting",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    NewRaisedPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: true),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: true),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: true),
                    FcvId = table.Column<long>(type: "bigint", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: true),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    NgoId = table.Column<long>(type: "bigint", nullable: true),
                    StripTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TypeOfPlantationId = table.Column<long>(type: "bigint", nullable: true),
                    PlantationArea = table.Column<string>(type: "text", nullable: true),
                    PlantationYear = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PlantationLocation = table.Column<string>(type: "text", nullable: true),
                    YearOfFelling = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RotationNoId = table.Column<long>(type: "bigint", nullable: true),
                    FellingInformationYearOfFelling = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ResourceQtyTimbar = table.Column<decimal>(type: "numeric", nullable: true),
                    ResourceQtyPole = table.Column<decimal>(type: "numeric", nullable: true),
                    ResourceQtyFuelWood = table.Column<decimal>(type: "numeric", nullable: true),
                    ResourceQtyTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    SaleValueTimbar = table.Column<decimal>(type: "numeric", nullable: true),
                    SaleValuePole = table.Column<decimal>(type: "numeric", nullable: true),
                    SaleValueFuelWood = table.Column<decimal>(type: "numeric", nullable: true),
                    SaleValueTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeelingOrCutting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_NewRaisedPlantation_NewRaisedPlantationId",
                        column: x => x.NewRaisedPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "NewRaisedPlantation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_RotationNumber_RotationNoId",
                        column: x => x.RotationNoId,
                        principalSchema: "Plantation",
                        principalTable: "RotationNumber",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_StripType_StripTypeId",
                        column: x => x.StripTypeId,
                        principalSchema: "Plantation",
                        principalTable: "StripType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_TypeOfPlantation_TypeOfPlantationId",
                        column: x => x.TypeOfPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "TypeOfPlantation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeelingOrCutting_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RevenueFeelingOrCutting",
                schema: "Plantation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    FeelingOrCuttingId = table.Column<long>(type: "bigint", nullable: true),
                    RevenueReceived = table.Column<decimal>(type: "numeric", nullable: true),
                    RevenueReceivedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OutstandingSaleValue = table.Column<decimal>(type: "numeric", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueFeelingOrCutting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueFeelingOrCutting_FeelingOrCutting_FeelingOrCuttingId",
                        column: x => x.FeelingOrCuttingId,
                        principalSchema: "Plantation",
                        principalTable: "FeelingOrCutting",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_DistrictId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_DivisionId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_ForestBeatId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_ForestCircleId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_ForestDivisionId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_ForestRangeId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_NewRaisedPlantationId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "NewRaisedPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_NgoId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_RotationNoId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "RotationNoId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_StripTypeId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "StripTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_TypeOfPlantationId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "TypeOfPlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_UnionId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeelingOrCutting_UpazillaId",
                schema: "Plantation",
                table: "FeelingOrCutting",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueFeelingOrCutting_FeelingOrCuttingId",
                schema: "Plantation",
                table: "RevenueFeelingOrCutting",
                column: "FeelingOrCuttingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevenueFeelingOrCutting",
                schema: "Plantation");

            migrationBuilder.DropTable(
                name: "FeelingOrCutting",
                schema: "Plantation");
        }
    }
}
