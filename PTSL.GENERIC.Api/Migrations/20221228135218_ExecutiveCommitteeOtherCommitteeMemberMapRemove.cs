using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class ExecutiveCommitteeOtherCommitteeMemberMapRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExecutiveCommitteeOtherCommitteeMemberMaps",
                schema: "BEN");

            migrationBuilder.AddColumn<long>(
                name: "OtherMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.CreateTable(
                name: "ExecutiveCommitteeOtherCommitteeMemberMaps",
                schema: "BEN",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ExecutiveCommitteeId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    OtherCommitteeMemberId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutiveCommitteeOtherCommitteeMemberMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecutiveCommitteeOtherCommitteeMemberMaps_ExecutiveCommitt~",
                        column: x => x.ExecutiveCommitteeId,
                        principalSchema: "BEN",
                        principalTable: "ExecutiveCommittee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExecutiveCommitteeOtherCommitteeMemberMaps_OtherCommitteeMe~",
                        column: x => x.OtherCommitteeMemberId,
                        principalSchema: "BEN",
                        principalTable: "OtherCommitteeMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommitteeOtherCommitteeMemberMaps_ExecutiveCommitt~",
                schema: "BEN",
                table: "ExecutiveCommitteeOtherCommitteeMemberMaps",
                column: "ExecutiveCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommitteeOtherCommitteeMemberMaps_OtherCommitteeMe~",
                schema: "BEN",
                table: "ExecutiveCommitteeOtherCommitteeMemberMaps",
                column: "OtherCommitteeMemberId");
        }
    }
}
