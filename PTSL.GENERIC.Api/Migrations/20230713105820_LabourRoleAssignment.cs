using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class LabourRoleAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_Assignments_AssignmentId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_LabourRoles_LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropTable(
                name: "Assignments",
                schema: "Labour");

            migrationBuilder.DropTable(
                name: "LabourRoles",
                schema: "Labour");

            migrationBuilder.DropIndex(
                name: "IX_LabourDatabases_AssignmentId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropIndex(
                name: "IX_LabourDatabases_LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.DropColumn(
                name: "LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AssignmentId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true);

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
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
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
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_AssignmentId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourDatabases_LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "LabourRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_Assignments_AssignmentId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "AssignmentId",
                principalSchema: "Labour",
                principalTable: "Assignments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_LabourRoles_LabourRoleId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "LabourRoleId",
                principalSchema: "Labour",
                principalTable: "LabourRoles",
                principalColumn: "Id");
        }
    }
}
