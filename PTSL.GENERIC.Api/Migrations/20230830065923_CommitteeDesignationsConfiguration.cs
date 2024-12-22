using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CommitteeDesignationsConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommitteeDesignationsConfiguration",
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
                    CommitteesConfigurationId = table.Column<long>(type: "bigint", nullable: true),
                    DesignationName = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeDesignationsConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeDesignationsConfiguration_CommitteesConfiguration_~",
                        column: x => x.CommitteesConfigurationId,
                        principalSchema: "BEN",
                        principalTable: "CommitteesConfiguration",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeDesignationsConfiguration_CommitteesConfigurationId",
                schema: "BEN",
                table: "CommitteeDesignationsConfiguration",
                column: "CommitteesConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommitteeDesignationsConfiguration",
                schema: "BEN");
        }
    }
}
