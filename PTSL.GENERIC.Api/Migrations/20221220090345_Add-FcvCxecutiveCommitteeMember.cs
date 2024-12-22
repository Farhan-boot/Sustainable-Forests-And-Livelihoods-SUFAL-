using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class AddFcvCxecutiveCommitteeMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FcvCxecutiveCommitteeMember",
                schema: "BEN",
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
                    ExecutiveMemberTypeId = table.Column<long>(nullable: true),
                    NgoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FcvCxecutiveCommitteeMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FcvCxecutiveCommitteeMember_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExecutiveCommittee",
                schema: "BEN",
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
                    NgoId = table.Column<long>(nullable: true),
                    FcvCxecutiveCommitteeMemberId = table.Column<long>(nullable: true),
                    FcvCxecutiveCommitteeMembersId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutiveCommittee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_Ngos_FcvCxecutiveCommitteeMemberId",
                        column: x => x.FcvCxecutiveCommitteeMemberId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExecutiveCommittee_FcvCxecutiveCommitteeMember_FcvCxecutive~",
                        column: x => x.FcvCxecutiveCommitteeMembersId,
                        principalSchema: "BEN",
                        principalTable: "FcvCxecutiveCommitteeMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_FcvCxecutiveCommitteeMemberId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvCxecutiveCommitteeMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_FcvCxecutiveCommitteeMembersId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "FcvCxecutiveCommitteeMembersId");

            migrationBuilder.CreateIndex(
                name: "IX_FcvCxecutiveCommitteeMember_NgoId",
                schema: "BEN",
                table: "FcvCxecutiveCommitteeMember",
                column: "NgoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExecutiveCommittee",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "FcvCxecutiveCommitteeMember",
                schema: "BEN");
        }
    }
}
