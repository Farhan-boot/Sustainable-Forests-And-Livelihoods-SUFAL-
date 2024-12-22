using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class DeparmentalTraining2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityTrainings_CommunityTrainingTypes_CommunityTraining~",
                schema: "Capacity",
                table: "CommunityTrainings");

            //migrationBuilder.EnsureSchema(
            //    name: "Marketing");

            migrationBuilder.AlterColumn<long>(
                name: "CommunityTrainingTypeId",
                schema: "Capacity",
                table: "CommunityTrainings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "CommunityTrainingId",
                schema: "Capacity",
                table: "CommunityTrainingParticipentsMaps",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "CommunityTrainingFiles",
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
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FileNameUrl = table.Column<string>(type: "text", nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    CommunityTrainingId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityTrainingFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityTrainingFiles_CommunityTrainings_CommunityTraining~",
                        column: x => x.CommunityTrainingId,
                        principalSchema: "Capacity",
                        principalTable: "CommunityTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentalTrainingMembers",
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
                    MemberPhoneNumber = table.Column<string>(type: "varchar(30)", nullable: true),
                    MemberGender = table.Column<int>(nullable: false),
                    MemberEmail = table.Column<string>(type: "varchar(200)", nullable: true),
                    MemberNID = table.Column<string>(type: "varchar(100)", nullable: true),
                    MemberDesignation = table.Column<string>(type: "varchar(500)", nullable: true),
                    MemberOrganization = table.Column<string>(type: "varchar(800)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentalTrainingMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentalTrainingTypes",
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
                    table.PrimaryKey("PK_DepartmentalTrainingTypes", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Union",
            //    schema: "GS",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
            //        UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
            //        DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
            //        IsActive = table.Column<bool>(type: "boolean", nullable: false),
            //        CreatedBy = table.Column<long>(nullable: false),
            //        ModifiedBy = table.Column<long>(nullable: true),
            //        DeletedBy = table.Column<long>(nullable: true),
            //        Name = table.Column<string>(type: "varchar(500)", nullable: true),
            //        NameBn = table.Column<string>(type: "varchar(500)", nullable: true),
            //        UpazillaId = table.Column<long>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Union", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Union_Upazilla_UpazillaId",
            //            column: x => x.UpazillaId,
            //            principalSchema: "GS",
            //            principalTable: "Upazilla",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Marketings",
            //    schema: "Marketing",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
            //        UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
            //        DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
            //        IsActive = table.Column<bool>(type: "boolean", nullable: false),
            //        CreatedBy = table.Column<long>(nullable: false),
            //        ModifiedBy = table.Column<long>(nullable: true),
            //        DeletedBy = table.Column<long>(nullable: true),
            //        MarketingName = table.Column<string>(type: "varchar(500)", nullable: true),
            //        MarketingNameBn = table.Column<string>(type: "varchar(500)", nullable: true),
            //        DistrictId = table.Column<long>(nullable: true),
            //        DivisionId = table.Column<long>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Marketings", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Marketings_District_DistrictId",
            //            column: x => x.DistrictId,
            //            principalSchema: "GS",
            //            principalTable: "District",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Marketings_Division_DivisionId",
            //            column: x => x.DivisionId,
            //            principalSchema: "GS",
            //            principalTable: "Division",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateTable(
                name: "DepartmentalTrainings",
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
                    DepartmentalTrainingTypeId = table.Column<long>(nullable: true),
                    TrainingOrganizerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentalTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainings_DepartmentalTrainingTypes_Departmenta~",
                        column: x => x.DepartmentalTrainingTypeId,
                        principalSchema: "Capacity",
                        principalTable: "DepartmentalTrainingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainings_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainings_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainings_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalSchema: "Capacity",
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainings_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainings_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainings_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainings_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainings_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainings_TrainingOrganizers_TrainingOrganizerId",
                        column: x => x.TrainingOrganizerId,
                        principalSchema: "Capacity",
                        principalTable: "TrainingOrganizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainings_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentalTrainingFiles",
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
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FileNameUrl = table.Column<string>(type: "text", nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    DepartmentalTrainingId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentalTrainingFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainingFiles_DepartmentalTrainings_Departmenta~",
                        column: x => x.DepartmentalTrainingId,
                        principalSchema: "Capacity",
                        principalTable: "DepartmentalTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentalTrainingParticipentsMaps",
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
                    DepartmentalTrainingMemberId = table.Column<long>(nullable: false),
                    DepartmentalTrainingId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentalTrainingParticipentsMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainingParticipentsMaps_DepartmentalTrainings_~",
                        column: x => x.DepartmentalTrainingId,
                        principalSchema: "Capacity",
                        principalTable: "DepartmentalTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingMe~",
                        column: x => x.DepartmentalTrainingMemberId,
                        principalSchema: "Capacity",
                        principalTable: "DepartmentalTrainingMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainingParticipentsMaps_CommunityTrainingId",
                schema: "Capacity",
                table: "CommunityTrainingParticipentsMaps",
                column: "CommunityTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTrainingFiles_CommunityTrainingId",
                schema: "Capacity",
                table: "CommunityTrainingFiles",
                column: "CommunityTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainingFiles_DepartmentalTrainingId",
                schema: "Capacity",
                table: "DepartmentalTrainingFiles",
                column: "DepartmentalTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingId",
                schema: "Capacity",
                table: "DepartmentalTrainingParticipentsMaps",
                column: "DepartmentalTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingMe~",
                schema: "Capacity",
                table: "DepartmentalTrainingParticipentsMaps",
                column: "DepartmentalTrainingMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_DepartmentalTrainingTypeId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "DepartmentalTrainingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_DistrictId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_DivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_EventTypeId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_ForestBeatId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_ForestCircleId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_ForestDivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_ForestFcvVcfId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_ForestRangeId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_TrainingOrganizerId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "TrainingOrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentalTrainings_UpazillaId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "UpazillaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Union_UpazillaId",
            //    schema: "GS",
            //    table: "Union",
            //    column: "UpazillaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Marketings_DistrictId",
            //    schema: "Marketing",
            //    table: "Marketings",
            //    column: "DistrictId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Marketings_DivisionId",
            //    schema: "Marketing",
            //    table: "Marketings",
            //    column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityTrainingParticipentsMaps_CommunityTrainings_Commun~",
                schema: "Capacity",
                table: "CommunityTrainingParticipentsMaps",
                column: "CommunityTrainingId",
                principalSchema: "Capacity",
                principalTable: "CommunityTrainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityTrainings_CommunityTrainingTypes_CommunityTraining~",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "CommunityTrainingTypeId",
                principalSchema: "Capacity",
                principalTable: "CommunityTrainingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityTrainingParticipentsMaps_CommunityTrainings_Commun~",
                schema: "Capacity",
                table: "CommunityTrainingParticipentsMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityTrainings_CommunityTrainingTypes_CommunityTraining~",
                schema: "Capacity",
                table: "CommunityTrainings");

            migrationBuilder.DropTable(
                name: "CommunityTrainingFiles",
                schema: "Capacity");

            migrationBuilder.DropTable(
                name: "DepartmentalTrainingFiles",
                schema: "Capacity");

            migrationBuilder.DropTable(
                name: "DepartmentalTrainingParticipentsMaps",
                schema: "Capacity");

            //migrationBuilder.DropTable(
            //    name: "Union",
            //    schema: "GS");

            //migrationBuilder.DropTable(
            //    name: "Marketings",
            //    schema: "Marketing");

            migrationBuilder.DropTable(
                name: "DepartmentalTrainings",
                schema: "Capacity");

            migrationBuilder.DropTable(
                name: "DepartmentalTrainingMembers",
                schema: "Capacity");

            migrationBuilder.DropTable(
                name: "DepartmentalTrainingTypes",
                schema: "Capacity");

            migrationBuilder.DropIndex(
                name: "IX_CommunityTrainingParticipentsMaps_CommunityTrainingId",
                schema: "Capacity",
                table: "CommunityTrainingParticipentsMaps");

            migrationBuilder.DropColumn(
                name: "CommunityTrainingId",
                schema: "Capacity",
                table: "CommunityTrainingParticipentsMaps");

            migrationBuilder.AlterColumn<long>(
                name: "CommunityTrainingTypeId",
                schema: "Capacity",
                table: "CommunityTrainings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityTrainings_CommunityTrainingTypes_CommunityTraining~",
                schema: "Capacity",
                table: "CommunityTrainings",
                column: "CommunityTrainingTypeId",
                principalSchema: "Capacity",
                principalTable: "CommunityTrainingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
