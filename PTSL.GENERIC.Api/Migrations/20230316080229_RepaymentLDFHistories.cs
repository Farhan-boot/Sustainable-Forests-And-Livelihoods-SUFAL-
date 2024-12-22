using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class RepaymentLDFHistories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepaymentLDFHistories",
                schema: "AIG",
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
                    RepaymentLDFId = table.Column<long>(nullable: false),
                    EventUserId = table.Column<long>(nullable: false),
                    EventOccurredDate = table.Column<DateTime>(nullable: false),
                    EventMessage = table.Column<string>(nullable: true),
                    RepaymentLDFEventType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentLDFHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepaymentLDFHistories_User_EventUserId",
                        column: x => x.EventUserId,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepaymentLDFHistories_RepaymentLDFs_RepaymentLDFId",
                        column: x => x.RepaymentLDFId,
                        principalSchema: "AIG",
                        principalTable: "RepaymentLDFs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentLDFHistories_EventUserId",
                schema: "AIG",
                table: "RepaymentLDFHistories",
                column: "EventUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentLDFHistories_RepaymentLDFId",
                schema: "AIG",
                table: "RepaymentLDFHistories",
                column: "RepaymentLDFId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepaymentLDFHistories",
                schema: "AIG");
        }
    }
}
