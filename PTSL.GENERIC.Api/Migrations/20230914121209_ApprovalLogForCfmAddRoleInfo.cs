using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ApprovalLogForCfmAddRoleInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ReceiverRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SenderRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalLogForCfm_ReceiverRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                column: "ReceiverRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalLogForCfm_SenderRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                column: "SenderRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalLogForCfm_UserRoles_ReceiverRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                column: "ReceiverRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalLogForCfm_UserRoles_SenderRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm",
                column: "SenderRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalLogForCfm_UserRoles_ReceiverRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalLogForCfm_UserRoles_SenderRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalLogForCfm_ReceiverRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalLogForCfm_SenderRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm");

            migrationBuilder.DropColumn(
                name: "ReceiverRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm");

            migrationBuilder.DropColumn(
                name: "SenderRoleId",
                schema: "ApprovalLog",
                table: "ApprovalLogForCfm");
        }
    }
}
