using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class LabourDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Labour");

            migrationBuilder.CreateTable(
                name: "Assignments",
                schema: "Labour",
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
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabourRoles",
                schema: "Labour",
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
                    table.PrimaryKey("PK_LabourRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherLabourMembers",
                schema: "Labour",
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
                    FullName = table.Column<string>(type: "varchar(500)", nullable: false),
                    FatherOrSpouse = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    NID = table.Column<string>(type: "varchar(100)", nullable: true),
                    Address = table.Column<string>(type: "varchar(600)", nullable: true),
                    ForestCircleId = table.Column<long>(nullable: false),
                    ForestDivisionId = table.Column<long>(nullable: false),
                    ForestRangeId = table.Column<long>(nullable: false),
                    ForestBeatId = table.Column<long>(nullable: false),
                    ForestFcvVcfId = table.Column<long>(nullable: false),
                    DivisionId = table.Column<long>(nullable: false),
                    DistrictId = table.Column<long>(nullable: false),
                    UpazillaId = table.Column<long>(nullable: false),
                    UnionId = table.Column<long>(nullable: true),
                    EthnicityId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherLabourMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherLabourMembers_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherLabourMembers_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherLabourMembers_Ethnicitys_EthnicityId",
                        column: x => x.EthnicityId,
                        principalSchema: "BEN",
                        principalTable: "Ethnicitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OtherLabourMembers_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherLabourMembers_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherLabourMembers_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherLabourMembers_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherLabourMembers_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherLabourMembers_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OtherLabourMembers_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabourDatabases",
                schema: "Labour",
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
                    SurveyId = table.Column<long>(nullable: true),
                    OtherLabourMemberId = table.Column<long>(nullable: true),
                    LabourRoleId = table.Column<long>(nullable: false),
                    AssignmentId = table.Column<long>(nullable: true),
                    EthnicityId = table.Column<long>(nullable: true),
                    FatherOrSpouse = table.Column<string>(type: "varchar(500)", nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    NidNo = table.Column<string>(type: "varchar(100)", nullable: true),
                    MobileNumber = table.Column<string>(nullable: false),
                    CodeNo = table.Column<string>(type: "varchar(100)", nullable: true),
                    ManDays = table.Column<string>(type: "varchar(600)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourDatabases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalSchema: "Labour",
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_Ethnicitys_EthnicityId",
                        column: x => x.EthnicityId,
                        principalSchema: "BEN",
                        principalTable: "Ethnicitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_LabourRoles_LabourRoleId",
                        column: x => x.LabourRoleId,
                        principalSchema: "Labour",
                        principalTable: "LabourRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_OtherLabourMembers_OtherLabourMemberId",
                        column: x => x.OtherLabourMemberId,
                        principalSchema: "Labour",
                        principalTable: "OtherLabourMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourDatabases_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabourDatabaseFiles",
                schema: "Labour",
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
                    LabourDatabaseId = table.Column<long>(nullable: false),
                    FileType = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(type: "varchar(500)", nullable: false),
                    FileUrl = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourDatabaseFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabourDatabaseFiles_LabourDatabases_LabourDatabaseId",
                        column: x => x.LabourDatabaseId,
                        principalSchema: "Labour",
                        principalTable: "LabourDatabases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabaseFiles_LabourDatabaseId",
                schema: "Labour",
                table: "LabourDatabaseFiles",
                column: "LabourDatabaseId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_AssignmentId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_DistrictId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_DivisionId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_EthnicityId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_ForestBeatId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_ForestCircleId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_ForestDivisionId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_ForestFcvVcfId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_ForestRangeId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "LabourRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_OtherLabourMemberId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "OtherLabourMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_SurveyId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_UnionId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_UpazillaId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherLabourMembers_DistrictId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherLabourMembers_DivisionId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherLabourMembers_EthnicityId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherLabourMembers_ForestBeatId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherLabourMembers_ForestCircleId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherLabourMembers_ForestDivisionId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherLabourMembers_ForestFcvVcfId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherLabourMembers_ForestRangeId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherLabourMembers_UnionId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherLabourMembers_UpazillaId",
                schema: "Labour",
                table: "OtherLabourMembers",
                column: "UpazillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabourDatabaseFiles",
                schema: "Labour");

            migrationBuilder.DropTable(
                name: "LabourDatabases",
                schema: "Labour");

            migrationBuilder.DropTable(
                name: "Assignments",
                schema: "Labour");

            migrationBuilder.DropTable(
                name: "LabourRoles",
                schema: "Labour");

            migrationBuilder.DropTable(
                name: "OtherLabourMembers",
                schema: "Labour");
        }
    }
}
