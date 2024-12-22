using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccountManage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AccountManagement");

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "AccountManagement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: false),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: false),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: true),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: true),
                    ForestFcvVcfId = table.Column<long>(type: "bigint", nullable: true),
                    CommitteeTypeId = table.Column<long>(type: "bigint", nullable: true),
                    CommitteeId = table.Column<long>(type: "bigint", nullable: true),
                    BankAccountName = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    AccountType = table.Column<int>(type: "integer", nullable: false),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    BranchName = table.Column<string>(type: "text", nullable: true),
                    OpeningDate = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_CommitteeTypeConfiguration_CommitteeTypeId",
                        column: x => x.CommitteeTypeId,
                        principalSchema: "BEN",
                        principalTable: "CommitteeTypeConfiguration",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_CommitteesConfiguration_CommitteeId",
                        column: x => x.CommitteeId,
                        principalSchema: "BEN",
                        principalTable: "CommitteesConfiguration",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CommitteeId",
                schema: "AccountManagement",
                table: "Accounts",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CommitteeTypeId",
                schema: "AccountManagement",
                table: "Accounts",
                column: "CommitteeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ForestBeatId",
                schema: "AccountManagement",
                table: "Accounts",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ForestCircleId",
                schema: "AccountManagement",
                table: "Accounts",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ForestDivisionId",
                schema: "AccountManagement",
                table: "Accounts",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ForestFcvVcfId",
                schema: "AccountManagement",
                table: "Accounts",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ForestRangeId",
                schema: "AccountManagement",
                table: "Accounts",
                column: "ForestRangeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "AccountManagement");
        }
    }
}
