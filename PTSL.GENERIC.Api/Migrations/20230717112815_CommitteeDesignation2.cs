using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CommitteeDesignation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeManagementMember_SubCommitteeDesignations_SubCommi~",
                schema: "BEN",
                table: "CommitteeManagementMember");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_SubCommitteeDesignations_SubCommitteeDes~",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropTable(
                name: "SubCommitteeDesignations",
                schema: "GS");

            migrationBuilder.CreateTable(
                name: "CommitteeDesignation",
                schema: "GS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CommitteeType = table.Column<int>(type: "integer", nullable: false),
                    SubCommitteeType = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeDesignation", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeManagementMember_CommitteeDesignation_SubCommittee~",
                schema: "BEN",
                table: "CommitteeManagementMember",
                column: "SubCommitteeDesignationId",
                principalSchema: "GS",
                principalTable: "CommitteeDesignation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_CommitteeDesignation_SubCommitteeDesigna~",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "SubCommitteeDesignationId",
                principalSchema: "GS",
                principalTable: "CommitteeDesignation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeManagementMember_CommitteeDesignation_SubCommittee~",
                schema: "BEN",
                table: "CommitteeManagementMember");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_CommitteeDesignation_SubCommitteeDesigna~",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropTable(
                name: "CommitteeDesignation",
                schema: "GS");

            migrationBuilder.CreateTable(
                name: "SubCommitteeDesignations",
                schema: "GS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CommitteeType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ExecutiveMemberType = table.Column<int>(type: "integer", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCommitteeDesignations", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeManagementMember_SubCommitteeDesignations_SubCommi~",
                schema: "BEN",
                table: "CommitteeManagementMember",
                column: "SubCommitteeDesignationId",
                principalSchema: "GS",
                principalTable: "SubCommitteeDesignations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_SubCommitteeDesignations_SubCommitteeDes~",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "SubCommitteeDesignationId",
                principalSchema: "GS",
                principalTable: "SubCommitteeDesignations",
                principalColumn: "Id");
        }
    }
}
