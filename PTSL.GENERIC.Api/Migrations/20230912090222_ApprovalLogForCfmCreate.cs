using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ApprovalLogForCfmCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ApprovalLog");

            migrationBuilder.CreateTable(
                name: "ApprovalLogForCfm",
                schema: "ApprovalLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: true),
                    ReceiverId = table.Column<long>(type: "bigint", nullable: true),
                    SendingDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SendingTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    CipId = table.Column<long>(type: "bigint", nullable: true),
                    CipTeamId = table.Column<long>(type: "bigint", nullable: true),
                    BeneficiaryProfileId = table.Column<long>(type: "bigint", nullable: true),
                    CommitteeManagementId = table.Column<long>(type: "bigint", nullable: true),
                    InternalLoanInformationId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalLogForCfm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalLogForCfm_CipTeam_CipTeamId",
                        column: x => x.CipTeamId,
                        principalTable: "CipTeam",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApprovalLogForCfm_Cips_CipId",
                        column: x => x.CipId,
                        principalSchema: "BEN",
                        principalTable: "Cips",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApprovalLogForCfm_CommitteeManagement_CommitteeManagementId",
                        column: x => x.CommitteeManagementId,
                        principalSchema: "BEN",
                        principalTable: "CommitteeManagement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApprovalLogForCfm_InternalLoanInformations_InternalLoanInfo~",
                        column: x => x.InternalLoanInformationId,
                        principalSchema: "InternalLoan",
                        principalTable: "InternalLoanInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApprovalLogForCfm_Surveys_BeneficiaryProfileId",
                        column: x => x.BeneficiaryProfileId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApprovalLogForCfm_User_ReceiverId",
                        column: x => x.ReceiverId,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApprovalLogForCfm_User_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalLogForCfm_BeneficiaryProfileId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                column: "BeneficiaryProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalLogForCfm_CipId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                column: "CipId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalLogForCfm_CipTeamId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                column: "CipTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalLogForCfm_CommitteeManagementId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                column: "CommitteeManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalLogForCfm_InternalLoanInformationId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                column: "InternalLoanInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalLogForCfm_ReceiverId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalLogForCfm_SenderId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalLogForCfm",
                schema: "ApprovalLog");
        }
    }
}
