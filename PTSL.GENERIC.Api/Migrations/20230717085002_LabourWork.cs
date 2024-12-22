using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class LabourWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabourWorks",
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
                    LabourDatabaseId = table.Column<long>(type: "bigint", nullable: false),
                    WorkType = table.Column<string>(type: "text", nullable: true),
                    ManDays = table.Column<double>(type: "double precision", nullable: false),
                    PaymentAmountPerDay = table.Column<string>(type: "text", nullable: true),
                    TotalAmount = table.Column<double>(type: "double precision", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabourWorks_LabourDatabases_LabourDatabaseId",
                        column: x => x.LabourDatabaseId,
                        principalSchema: "Labour",
                        principalTable: "LabourDatabases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabourWorks_LabourDatabaseId",
                schema: "Labour",
                table: "LabourWorks",
                column: "LabourDatabaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabourWorks",
                schema: "Labour");
        }
    }
}
