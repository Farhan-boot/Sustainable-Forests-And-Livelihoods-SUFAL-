using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ApprovalTransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendingDate",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.RenameColumn(
                name: "SendingTime",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                newName: "SendingDateTime");

            migrationBuilder.AddColumn<long>(
                name: "NextApprovalOrderNo",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForwardedById",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForwardedByRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfers_NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "NextApprovalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfers_NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "NextApprovalUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferApprovals_ForwardedById",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                column: "ForwardedById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferApprovals_ForwardedByRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                column: "ForwardedByRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApprovals_UserRoles_ForwardedByRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                column: "ForwardedByRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApprovals_User_ForwardedById",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                column: "ForwardedById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransfers_UserRoles_NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "NextApprovalUserRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransfers_User_NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "NextApprovalUserId",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApprovals_UserRoles_ForwardedByRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApprovals_User_ForwardedById",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransfers_UserRoles_NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransfers_User_NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransfers_NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransfers_NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransferApprovals_ForwardedById",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransferApprovals_ForwardedByRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.DropColumn(
                name: "NextApprovalOrderNo",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropColumn(
                name: "NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropColumn(
                name: "NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropColumn(
                name: "ForwardedById",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.DropColumn(
                name: "ForwardedByRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.RenameColumn(
                name: "SendingDateTime",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                newName: "SendingTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "SendingDate",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}
