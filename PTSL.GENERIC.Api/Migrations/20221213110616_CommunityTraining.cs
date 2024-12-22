using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class CommunityTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Capacity");

            migrationBuilder.CreateTable(
                name: "CommunityTrainingMembers",
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
                    MemberName = table.Column<string>(type: "varchar(500)", nullable: false),
                    MemberAge = table.Column<int>(nullable: false),
                    MemberPhoneNumber = table.Column<string>(type: "varchar(30)", nullable: true),
                    MemberAddress = table.Column<string>(type: "varchar(800)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityTrainingMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunityTrainingTypes",
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
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityTrainingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
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
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true),
                    HasTrainingType = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingOrganizers",
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
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingOrganizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunityTrainingParticipentsMaps",
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
                    CommunityTrainingMemberId = table.Column<long>(nullable: true),
                    ParticipentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityTrainingParticipentsMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityTrainingParticipentsMaps_CommunityTrainingMembers_~",
                        column: x => x.CommunityTrainingMemberId,
                        principalSchema: "Capacity",
                        principalTable: "CommunityTrainingMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommunityTrainingParticipentsMaps_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunityTrainings",
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
                    TrainingTitle = table.Column<string>(type: "varchar(500)", nullable: true),
                    TrainingTitleBn = table.Column<string>(type: "varchar(500)", nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TrainingDuration = table.Column<string>(type: "varchar(200)", nullable: false),
                    Location = table.Column<string>(type: "varchar(500)", nullable: true),
                    LocationBn = table.Column<string>(type: "varchar(500)", nullable: true),
                    TrainerName = table.Column<string>(type: "varchar(500)", nullable: true),
                    ForestCircleId = table.Column<long>(nullable: false),
                    ForestDivisionId = table.Column<long>(nullable: false),
                    ForestRangeId = table.Column<long>(nullable: false),
                    ForestBeatId = table.Column<long>(nullable: false),
                    ForestFcvVcfId = table.Column<long>(nullable: false),
                    DivisionId = table.Column<long>(nullable: false),
                    DistrictId = table.Column<long>(nullable: false),
                    UpazillaId = table.Column<long>(nullable: false),
                    EventTypeId = table.Column<long>(nullable: false),
                    CommunityTrainingTypeId = table.Column<long>(nullable: false),
                    TrainingOrganizerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityTrainings_CommunityTrainingTypes_CommunityTraining~",
                        column: x => x.CommunityTrainingTypeId,
                        principalSchema: "Capacity",
                        principalTable: "CommunityTrainingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityTrainings_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityTrainings_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityTrainings_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalSchema: "Capacity",
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityTrainings_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityTrainings_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityTrainings_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityTrainings_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityTrainings_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityTrainings_TrainingOrganizers_TrainingOrganizerId",
                        column: x => x.TrainingOrganizerId,
                        principalSchema: "Capacity",
                        principalTable: "TrainingOrganizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityTrainings_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainingParticipentsMaps_CommunityTrainingMemberId",
                schema: "Capacity",
                table: "CommunityTrainingParticipentsMaps",
                column: "CommunityTrainingMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainingParticipentsMaps_SurveyId",
                schema: "Capacity",
                table: "CommunityTrainingParticipentsMaps",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_CommunityTrainingTypeId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "CommunityTrainingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_DistrictId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_DivisionId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_EventTypeId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_ForestBeatId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_ForestCircleId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_ForestDivisionId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_ForestFcvVcfId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_ForestRangeId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_TrainingOrganizerId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "TrainingOrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainings_UpazillaId",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "UpazillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityTrainingParticipentsMaps",
                schema: "Capacity");

            migrationBuilder.DropTable(
                name: "CommunityTrainings",
                schema: "Capacity");

            migrationBuilder.DropTable(
                name: "CommunityTrainingMembers",
                schema: "Capacity");

            migrationBuilder.DropTable(
                name: "CommunityTrainingTypes",
                schema: "Capacity");

            migrationBuilder.DropTable(
                name: "EventTypes",
                schema: "Capacity");

            migrationBuilder.DropTable(
                name: "TrainingOrganizers",
                schema: "Capacity");
        }
    }
}
