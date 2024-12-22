using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CommitteesConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommitteesConfiguration",
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
                    CommitteeTypeConfigurationId = table.Column<long>(type: "bigint", nullable: true),
                    CommitteeName = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteesConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteesConfiguration_CommitteeTypeConfiguration_Committe~",
                        column: x => x.CommitteeTypeConfigurationId,
                        principalSchema: "BEN",
                        principalTable: "CommitteeTypeConfiguration",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommitteesConfiguration_CommitteeTypeConfigurationId",
                schema: "BEN",
                table: "CommitteesConfiguration",
                column: "CommitteeTypeConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommitteesConfiguration",
                schema: "BEN");
        }
    }
}
