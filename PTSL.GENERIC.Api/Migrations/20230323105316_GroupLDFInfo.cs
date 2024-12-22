using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class GroupLDFInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupLDFInfoForms",
                schema: "AIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    ForestCircleId = table.Column<long>(nullable: false),
                    ForestDivisionId = table.Column<long>(nullable: false),
                    ForestRangeId = table.Column<long>(nullable: false),
                    ForestBeatId = table.Column<long>(nullable: false),
                    ForestFcvVcfId = table.Column<long>(nullable: false),
                    DivisionId = table.Column<long>(nullable: false),
                    DistrictId = table.Column<long>(nullable: false),
                    UpazillaId = table.Column<long>(nullable: false),
                    UnionId = table.Column<long>(nullable: true),
                    NgoId = table.Column<long>(nullable: true),
                    SubmittedById = table.Column<long>(nullable: false),
                    SubmittedDate = table.Column<DateTime>(nullable: false),
                    DocumentName = table.Column<string>(nullable: true),
                    DocumentNameURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLDFInfoForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoForms_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoForms_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoForms_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoForms_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoForms_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoForms_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoForms_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoForms_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoForms_User_SubmittedById",
                        column: x => x.SubmittedById,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoForms_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoForms_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupLDFInfoFormMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    GroupLDFInfoFormId = table.Column<long>(nullable: false),
                    IndividualLDFInfoFormId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLDFInfoFormMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoFormMember_GroupLDFInfoForms_GroupLDFInfoFormId",
                        column: x => x.GroupLDFInfoFormId,
                        principalSchema: "AIG",
                        principalTable: "GroupLDFInfoForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLDFInfoFormMember_IndividualLDFInfoForms_IndividualLDF~",
                        column: x => x.IndividualLDFInfoFormId,
                        principalSchema: "AIG",
                        principalTable: "IndividualLDFInfoForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoFormMember_GroupLDFInfoFormId",
                table: "GroupLDFInfoFormMember",
                column: "GroupLDFInfoFormId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoFormMember_IndividualLDFInfoFormId",
                table: "GroupLDFInfoFormMember",
                column: "IndividualLDFInfoFormId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoForms_DistrictId",
                schema: "AIG",
                table: "GroupLDFInfoForms",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoForms_DivisionId",
                schema: "AIG",
                table: "GroupLDFInfoForms",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoForms_ForestBeatId",
                schema: "AIG",
                table: "GroupLDFInfoForms",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoForms_ForestCircleId",
                schema: "AIG",
                table: "GroupLDFInfoForms",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoForms_ForestDivisionId",
                schema: "AIG",
                table: "GroupLDFInfoForms",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoForms_ForestFcvVcfId",
                schema: "AIG",
                table: "GroupLDFInfoForms",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoForms_ForestRangeId",
                schema: "AIG",
                table: "GroupLDFInfoForms",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoForms_NgoId",
                schema: "AIG",
                table: "GroupLDFInfoForms",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoForms_SubmittedById",
                schema: "AIG",
                table: "GroupLDFInfoForms",
                column: "SubmittedById");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoForms_UnionId",
                schema: "AIG",
                table: "GroupLDFInfoForms",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLDFInfoForms_UpazillaId",
                schema: "AIG",
                table: "GroupLDFInfoForms",
                column: "UpazillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupLDFInfoFormMember");

            migrationBuilder.DropTable(
                name: "GroupLDFInfoForms",
                schema: "AIG");
        }
    }
}
