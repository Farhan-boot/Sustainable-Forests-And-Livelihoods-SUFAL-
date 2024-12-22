using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class Cip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cips",
                schema: "BEN",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: false),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: false),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: false),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: false),
                    ForestFcvVcfId = table.Column<long>(type: "bigint", nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestVillageName = table.Column<string>(type: "text", nullable: true),
                    HouseholdSerialNo = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryName = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    FatherOrSpouseName = table.Column<string>(type: "text", nullable: true),
                    EthnicityId = table.Column<long>(type: "bigint", nullable: true),
                    NID = table.Column<string>(type: "text", nullable: true),
                    MobileNumber = table.Column<string>(type: "text", nullable: true),
                    HouseType = table.Column<int>(type: "integer", nullable: false),
                    CipWealth = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cips_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cips_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cips_Ethnicitys_EthnicityId",
                        column: x => x.EthnicityId,
                        principalSchema: "BEN",
                        principalTable: "Ethnicitys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cips_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cips_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cips_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cips_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cips_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cips_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cips_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cips_DistrictId",
                schema: "BEN",
                table: "Cips",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_DivisionId",
                schema: "BEN",
                table: "Cips",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_EthnicityId",
                schema: "BEN",
                table: "Cips",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_ForestBeatId",
                schema: "BEN",
                table: "Cips",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_ForestCircleId",
                schema: "BEN",
                table: "Cips",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_ForestDivisionId",
                schema: "BEN",
                table: "Cips",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_ForestFcvVcfId",
                schema: "BEN",
                table: "Cips",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_ForestRangeId",
                schema: "BEN",
                table: "Cips",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_UnionId",
                schema: "BEN",
                table: "Cips",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_UpazillaId",
                schema: "BEN",
                table: "Cips",
                column: "UpazillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cips",
                schema: "BEN");
        }
    }
}
