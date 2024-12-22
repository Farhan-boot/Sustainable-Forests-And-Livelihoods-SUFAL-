using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class Meeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Meeting");

            migrationBuilder.CreateTable(
                name: "MeetingMembers",
                schema: "Meeting",
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
                    MemberName = table.Column<string>(type: "text", nullable: false),
                    MemberGender = table.Column<int>(nullable: false),
                    MemberAge = table.Column<int>(nullable: false),
                    MemberPhone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingTypes",
                schema: "Meeting",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                schema: "Meeting",
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
                    MeetingTitle = table.Column<string>(type: "text", nullable: false),
                    MeetingDate = table.Column<DateTime>(nullable: false),
                    MeetingTypeId = table.Column<long>(nullable: false),
                    ForestCircleId = table.Column<long>(nullable: false),
                    ForestDivisionId = table.Column<long>(nullable: false),
                    ForestRangeId = table.Column<long>(nullable: false),
                    ForestBeatId = table.Column<long>(nullable: false),
                    ForestFcvVcfId = table.Column<long>(nullable: false),
                    DivisionId = table.Column<long>(nullable: false),
                    DistrictId = table.Column<long>(nullable: false),
                    UpazillaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_MeetingTypes_MeetingTypeId",
                        column: x => x.MeetingTypeId,
                        principalSchema: "Meeting",
                        principalTable: "MeetingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingParticipantsMaps",
                schema: "Capacity",
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
                    SurveyId = table.Column<long>(nullable: true),
                    MeetingMemberId = table.Column<long>(nullable: true),
                    ParticipentType = table.Column<int>(nullable: false),
                    MeetingId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingParticipantsMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingParticipantsMaps_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalSchema: "Meeting",
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingParticipantsMaps_MeetingMembers_MeetingMemberId",
                        column: x => x.MeetingMemberId,
                        principalSchema: "Meeting",
                        principalTable: "MeetingMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingParticipantsMaps_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingFiles",
                schema: "Meeting",
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
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FileNameUrl = table.Column<string>(type: "text", nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    MeetingId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingFiles_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalSchema: "Meeting",
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingParticipantsMaps_MeetingId",
                schema: "Capacity",
                table: "MeetingParticipantsMaps",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingParticipantsMaps_MeetingMemberId",
                schema: "Capacity",
                table: "MeetingParticipantsMaps",
                column: "MeetingMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingParticipantsMaps_SurveyId",
                schema: "Capacity",
                table: "MeetingParticipantsMaps",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingFiles_MeetingId",
                schema: "Meeting",
                table: "MeetingFiles",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_DistrictId",
                schema: "Meeting",
                table: "Meetings",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_DivisionId",
                schema: "Meeting",
                table: "Meetings",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ForestBeatId",
                schema: "Meeting",
                table: "Meetings",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ForestCircleId",
                schema: "Meeting",
                table: "Meetings",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ForestDivisionId",
                schema: "Meeting",
                table: "Meetings",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ForestFcvVcfId",
                schema: "Meeting",
                table: "Meetings",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ForestRangeId",
                schema: "Meeting",
                table: "Meetings",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_MeetingTypeId",
                schema: "Meeting",
                table: "Meetings",
                column: "MeetingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_UpazillaId",
                schema: "Meeting",
                table: "Meetings",
                column: "UpazillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingParticipantsMaps",
                schema: "Capacity");

            migrationBuilder.DropTable(
                name: "MeetingFiles",
                schema: "Meeting");

            migrationBuilder.DropTable(
                name: "MeetingMembers",
                schema: "Meeting");

            migrationBuilder.DropTable(
                name: "Meetings",
                schema: "Meeting");

            migrationBuilder.DropTable(
                name: "MeetingTypes",
                schema: "Meeting");
        }
    }
}
