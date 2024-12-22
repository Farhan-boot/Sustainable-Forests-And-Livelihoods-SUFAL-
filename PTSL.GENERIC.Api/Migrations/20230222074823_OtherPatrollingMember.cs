using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class OtherPatrollingMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OtherPatrollingMemberId",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GenderId",
                table: "PatrollingPaymentInformetion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParticipentName",
                table: "PatrollingPaymentInformetion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "PatrollingPaymentInformetion",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OtherPatrollingMember",
                schema: "Patrolling",
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
                    EthnicityId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherPatrollingMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherPatrollingMember_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherPatrollingMember_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherPatrollingMember_Ethnicitys_EthnicityId",
                        column: x => x.EthnicityId,
                        principalSchema: "BEN",
                        principalTable: "Ethnicitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OtherPatrollingMember_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherPatrollingMember_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherPatrollingMember_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherPatrollingMember_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherPatrollingMember_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherPatrollingMember_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatrollingScheduleInformetion_OtherPatrollingMemberId",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion",
                column: "OtherPatrollingMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPatrollingMember_DistrictId",
                schema: "Patrolling",
                table: "OtherPatrollingMember",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPatrollingMember_DivisionId",
                schema: "Patrolling",
                table: "OtherPatrollingMember",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPatrollingMember_EthnicityId",
                schema: "Patrolling",
                table: "OtherPatrollingMember",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPatrollingMember_ForestBeatId",
                schema: "Patrolling",
                table: "OtherPatrollingMember",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPatrollingMember_ForestCircleId",
                schema: "Patrolling",
                table: "OtherPatrollingMember",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPatrollingMember_ForestDivisionId",
                schema: "Patrolling",
                table: "OtherPatrollingMember",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPatrollingMember_ForestFcvVcfId",
                schema: "Patrolling",
                table: "OtherPatrollingMember",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPatrollingMember_ForestRangeId",
                schema: "Patrolling",
                table: "OtherPatrollingMember",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPatrollingMember_UpazillaId",
                schema: "Patrolling",
                table: "OtherPatrollingMember",
                column: "UpazillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatrollingScheduleInformetion_OtherPatrollingMember_OtherPa~",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion",
                column: "OtherPatrollingMemberId",
                principalSchema: "Patrolling",
                principalTable: "OtherPatrollingMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatrollingScheduleInformetion_OtherPatrollingMember_OtherPa~",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion");

            migrationBuilder.DropTable(
                name: "OtherPatrollingMember",
                schema: "Patrolling");

            migrationBuilder.DropIndex(
                name: "IX_PatrollingScheduleInformetion_OtherPatrollingMemberId",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion");

            migrationBuilder.DropColumn(
                name: "OtherPatrollingMemberId",
                schema: "Patrolling",
                table: "PatrollingScheduleInformetion");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "PatrollingPaymentInformetion");

            migrationBuilder.DropColumn(
                name: "ParticipentName",
                table: "PatrollingPaymentInformetion");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "PatrollingPaymentInformetion");
        }
    }
}
