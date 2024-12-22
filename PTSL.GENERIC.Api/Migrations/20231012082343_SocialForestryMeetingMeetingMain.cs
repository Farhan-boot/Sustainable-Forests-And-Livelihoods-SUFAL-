using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class SocialForestryMeetingMeetingMain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialForestryMeetingMembers",
                schema: "SocialForestryMeeting",
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
                    MemberGender = table.Column<int>(type: "integer", nullable: false),
                    MemberPhoneNumber = table.Column<string>(type: "varchar(30)", nullable: true),
                    MemberNID = table.Column<string>(type: "varchar(100)", nullable: true),
                    MemberDesignation = table.Column<string>(type: "varchar(500)", nullable: true),
                    MemberOrganization = table.Column<string>(type: "varchar(800)", nullable: true),
                    EthnicityId = table.Column<long>(type: "bigint", nullable: true),
                    MemberAddress = table.Column<string>(type: "text", nullable: true),
                    PlantationId = table.Column<long>(type: "bigint", nullable: true),
                    PlantationName = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialForestryMeetingMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetingMembers_Ethnicitys_EthnicityId",
                        column: x => x.EthnicityId,
                        principalSchema: "BEN",
                        principalTable: "Ethnicitys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SocialForestryMeetings",
                schema: "SocialForestryMeeting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: true),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: true),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: true),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    NgoId = table.Column<long>(type: "bigint", nullable: true),
                    MeetingTitle = table.Column<string>(type: "varchar(500)", nullable: true),
                    MeetingTitleBn = table.Column<string>(type: "varchar(500)", nullable: true),
                    Venue = table.Column<string>(type: "varchar(500)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MeetingOrganizer = table.Column<string>(type: "varchar(500)", nullable: true),
                    MeetingTypeForSocialForestryMeetingId = table.Column<long>(type: "bigint", nullable: true),
                    TotalMembers = table.Column<int>(type: "integer", nullable: false),
                    TotalMale = table.Column<int>(type: "integer", nullable: false),
                    TotalFemale = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialForestryMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetings_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetings_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetings_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetings_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetings_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetings_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetings_MeetingTypeForSocialForestryMeetings~",
                        column: x => x.MeetingTypeForSocialForestryMeetingId,
                        principalSchema: "SocialForestryMeeting",
                        principalTable: "MeetingTypeForSocialForestryMeetings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetings_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetings_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetings_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SocialForestryMeetingFiles",
                schema: "SocialForestryMeeting",
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
                    SocialForestryMeetingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialForestryMeetingFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetingFiles_SocialForestryMeetings_SocialFor~",
                        column: x => x.SocialForestryMeetingId,
                        principalSchema: "SocialForestryMeeting",
                        principalTable: "SocialForestryMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialForestryMeetingParticipentsMaps",
                schema: "SocialForestryMeeting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    SocialForestryMeetingMemberId = table.Column<long>(type: "bigint", nullable: false),
                    SocialForestryMeetingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialForestryMeetingParticipentsMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetingParticipentsMaps_SocialForestryMeeting~",
                        column: x => x.SocialForestryMeetingId,
                        principalSchema: "SocialForestryMeeting",
                        principalTable: "SocialForestryMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialForestryMeetingParticipentsMaps_SocialForestryMeetin~1",
                        column: x => x.SocialForestryMeetingMemberId,
                        principalSchema: "SocialForestryMeeting",
                        principalTable: "SocialForestryMeetingMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetingFiles_SocialForestryMeetingId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetingFiles",
                column: "SocialForestryMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetingMembers_EthnicityId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetingMembers",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetingParticipentsMaps_SocialForestryMeetin~1",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetingParticipentsMaps",
                column: "SocialForestryMeetingMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetingParticipentsMaps_SocialForestryMeeting~",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetingParticipentsMaps",
                column: "SocialForestryMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetings_DistrictId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetings",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetings_DivisionId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetings",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetings_ForestBeatId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetings",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetings_ForestCircleId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetings",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetings_ForestDivisionId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetings",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetings_ForestRangeId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetings",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetings_MeetingTypeForSocialForestryMeetingId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetings",
                column: "MeetingTypeForSocialForestryMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetings_NgoId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetings",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetings_UnionId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetings",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryMeetings_UpazillaId",
                schema: "SocialForestryMeeting",
                table: "SocialForestryMeetings",
                column: "UpazillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialForestryMeetingFiles",
                schema: "SocialForestryMeeting");

            migrationBuilder.DropTable(
                name: "SocialForestryMeetingParticipentsMaps",
                schema: "SocialForestryMeeting");

            migrationBuilder.DropTable(
                name: "SocialForestryMeetings",
                schema: "SocialForestryMeeting");

            migrationBuilder.DropTable(
                name: "SocialForestryMeetingMembers",
                schema: "SocialForestryMeeting");
        }
    }
}
