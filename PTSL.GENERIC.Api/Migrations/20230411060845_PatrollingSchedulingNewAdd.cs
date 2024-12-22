using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class PatrollingSchedulingNewAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PatrollingScheduling");

            migrationBuilder.CreateTable(
                name: "PatrollingSchedulingMembers",
                schema: "PatrollingScheduling",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    MemberName = table.Column<string>(type: "varchar(500)", nullable: false),
                    MemberAge = table.Column<int>(type: "integer", nullable: false),
                    MemberGender = table.Column<int>(type: "integer", nullable: false),
                    MemberPhoneNumber = table.Column<string>(type: "varchar(30)", nullable: true),
                    MemberAddress = table.Column<string>(type: "varchar(800)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatrollingSchedulingMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatrollingSchedulings",
                schema: "PatrollingScheduling",
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
                    NgoId = table.Column<long>(type: "bigint", nullable: true),
                    FcvId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatrollingDescription = table.Column<string>(type: "text", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatrollingArea = table.Column<string>(type: "text", nullable: false),
                    AllocatedAmountMonth = table.Column<string>(type: "text", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatrollingSchedulings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulings_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulings_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulings_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulings_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulings_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulings_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulings_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulings_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulings_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulings_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatrollingSchedulingFiles",
                schema: "PatrollingScheduling",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FileNameUrl = table.Column<string>(type: "text", nullable: true),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    PatrollingSchedulingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatrollingSchedulingFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulingFiles_PatrollingSchedulings_PatrollingS~",
                        column: x => x.PatrollingSchedulingId,
                        principalSchema: "PatrollingScheduling",
                        principalTable: "PatrollingSchedulings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatrollingSchedulingParticipentsMaps",
                schema: "PatrollingScheduling",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    SurveyId = table.Column<long>(type: "bigint", nullable: true),
                    PatrollingSchedulingMemberId = table.Column<long>(type: "bigint", nullable: true),
                    ParticipentType = table.Column<int>(type: "integer", nullable: false),
                    PatrollingSchedulingId = table.Column<long>(type: "bigint", nullable: false),
                    ParticipentName = table.Column<string>(type: "text", nullable: true),
                    GenderEnumId = table.Column<int>(type: "integer", nullable: true),
                    PhoneNo = table.Column<string>(type: "text", nullable: true),
                    AmountOfHonoraryAllowance = table.Column<double>(type: "double precision", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatrollingSchedulingParticipentsMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingMe~",
                        column: x => x.PatrollingSchedulingMemberId,
                        principalSchema: "PatrollingScheduling",
                        principalTable: "PatrollingSchedulingMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulingParticipentsMaps_PatrollingSchedulings_~",
                        column: x => x.PatrollingSchedulingId,
                        principalSchema: "PatrollingScheduling",
                        principalTable: "PatrollingSchedulings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatrollingSchedulingParticipentsMaps_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulingFiles_PatrollingSchedulingId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulingFiles",
                column: "PatrollingSchedulingId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulingParticipentsMaps",
                column: "PatrollingSchedulingId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingMe~",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulingParticipentsMaps",
                column: "PatrollingSchedulingMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulingParticipentsMaps_SurveyId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulingParticipentsMaps",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulings_DistrictId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulings_DivisionId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulings_ForestBeatId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulings_ForestCircleId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulings_ForestDivisionId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulings_ForestFcvVcfId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulings_ForestRangeId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulings_NgoId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulings_UnionId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingSchedulings_UpazillaId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                column: "UpazillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatrollingSchedulingFiles",
                schema: "PatrollingScheduling");

            migrationBuilder.DropTable(
                name: "PatrollingSchedulingParticipentsMaps",
                schema: "PatrollingScheduling");

            migrationBuilder.DropTable(
                name: "PatrollingSchedulingMembers",
                schema: "PatrollingScheduling");

            migrationBuilder.DropTable(
                name: "PatrollingSchedulings",
                schema: "PatrollingScheduling");
        }
    }
}
