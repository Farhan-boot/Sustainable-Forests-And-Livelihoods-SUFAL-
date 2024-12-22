using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class SubCommitteDesignation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SubCommitteeDesignationId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                nullable: true);

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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    ExecutiveMemberType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCommitteeDesignations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCommittee_SubCommitteeDesignationId",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "SubCommitteeDesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutiveCommittee_SubCommitteeDesignations_SubCommitteeDes~",
                schema: "BEN",
                table: "ExecutiveCommittee",
                column: "SubCommitteeDesignationId",
                principalSchema: "GS",
                principalTable: "SubCommitteeDesignations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutiveCommittee_SubCommitteeDesignations_SubCommitteeDes~",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropTable(
                name: "SubCommitteeDesignations",
                schema: "GS");

            migrationBuilder.DropIndex(
                name: "IX_ExecutiveCommittee_SubCommitteeDesignationId",
                schema: "BEN",
                table: "ExecutiveCommittee");

            migrationBuilder.DropColumn(
                name: "SubCommitteeDesignationId",
                schema: "BEN",
                table: "ExecutiveCommittee");
        }
    }
}
