using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class SocialForestryTrainingAllTableDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialForestryTrainingMembers",
                schema: "SocialForestryTraining",
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
                    table.PrimaryKey("PK_SocialForestryTrainingMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainingMembers_Ethnicitys_EthnicityId",
                        column: x => x.EthnicityId,
                        principalSchema: "BEN",
                        principalTable: "Ethnicitys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SocialForestryTrainings",
                schema: "SocialForestryTraining",
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
                    TrainingTitle = table.Column<string>(type: "varchar(500)", nullable: true),
                    TrainingTitleBn = table.Column<string>(type: "varchar(500)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TrainingDuration = table.Column<string>(type: "varchar(200)", nullable: true),
                    TrainerName = table.Column<string>(type: "varchar(500)", nullable: true),
                    Location = table.Column<string>(type: "varchar(500)", nullable: true),
                    LocationBn = table.Column<string>(type: "varchar(500)", nullable: true),
                    FinancialYearForTrainingId = table.Column<long>(type: "bigint", nullable: true),
                    EventTypeForTrainingId = table.Column<long>(type: "bigint", nullable: true),
                    TrainingOrganizerForTrainingId = table.Column<long>(type: "bigint", nullable: true),
                    TrainerDesignationForTrainingId = table.Column<long>(type: "bigint", nullable: true),
                    TotalMembers = table.Column<int>(type: "integer", nullable: false),
                    TotalMale = table.Column<int>(type: "integer", nullable: false),
                    TotalFemale = table.Column<int>(type: "integer", nullable: false),
                    TrainerAddress = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialForestryTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_EventTypeForTrainings_EventTypeForT~",
                        column: x => x.EventTypeForTrainingId,
                        principalSchema: "SocialForestryTraining",
                        principalTable: "EventTypeForTrainings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_FinancialYearForTrainings_Financial~",
                        column: x => x.FinancialYearForTrainingId,
                        principalSchema: "SocialForestryTraining",
                        principalTable: "FinancialYearForTrainings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_TrainerDesignationForTrainings_Trai~",
                        column: x => x.TrainerDesignationForTrainingId,
                        principalSchema: "SocialForestryTraining",
                        principalTable: "TrainerDesignationForTrainings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_TrainingOrganizerForTrainings_Train~",
                        column: x => x.TrainingOrganizerForTrainingId,
                        principalSchema: "SocialForestryTraining",
                        principalTable: "TrainingOrganizerForTrainings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainings_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SocialForestryTrainingFiles",
                schema: "SocialForestryTraining",
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
                    SocialForestryTrainingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialForestryTrainingFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainingFiles_SocialForestryTrainings_SocialF~",
                        column: x => x.SocialForestryTrainingId,
                        principalSchema: "SocialForestryTraining",
                        principalTable: "SocialForestryTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialForestryTrainingParticipentsMaps",
                schema: "SocialForestryTraining",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    SocialForestryTrainingMemberId = table.Column<long>(type: "bigint", nullable: false),
                    SocialForestryTrainingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialForestryTrainingParticipentsMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainingParticipentsMaps_SocialForestryTraini~",
                        column: x => x.SocialForestryTrainingId,
                        principalSchema: "SocialForestryTraining",
                        principalTable: "SocialForestryTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialForestryTrainingParticipentsMaps_SocialForestryTrain~1",
                        column: x => x.SocialForestryTrainingMemberId,
                        principalSchema: "SocialForestryTraining",
                        principalTable: "SocialForestryTrainingMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainingFiles_SocialForestryTrainingId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainingFiles",
                column: "SocialForestryTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainingMembers_EthnicityId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainingMembers",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainingParticipentsMaps_SocialForestryTrain~1",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainingParticipentsMaps",
                column: "SocialForestryTrainingMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainingParticipentsMaps_SocialForestryTraini~",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainingParticipentsMaps",
                column: "SocialForestryTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_DistrictId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_DivisionId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_EventTypeForTrainingId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "EventTypeForTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_FinancialYearForTrainingId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "FinancialYearForTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_ForestBeatId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_ForestCircleId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_ForestDivisionId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_ForestRangeId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_TrainerDesignationForTrainingId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "TrainerDesignationForTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_TrainingOrganizerForTrainingId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "TrainingOrganizerForTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_UnionId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialForestryTrainings_UpazillaId",
                schema: "SocialForestryTraining",
                table: "SocialForestryTrainings",
                column: "UpazillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialForestryTrainingFiles",
                schema: "SocialForestryTraining");

            migrationBuilder.DropTable(
                name: "SocialForestryTrainingParticipentsMaps",
                schema: "SocialForestryTraining");

            migrationBuilder.DropTable(
                name: "SocialForestryTrainings",
                schema: "SocialForestryTraining");

            migrationBuilder.DropTable(
                name: "SocialForestryTrainingMembers",
                schema: "SocialForestryTraining");
        }
    }
}
