using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccountTransferApprovalColumnRenameAndApprovalStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApproval_UserRoles_ReceiverRoleId",
                table: "AccountTransferApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApproval_UserRoles_SenderRoleId",
                table: "AccountTransferApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApproval_User_ReceiverId",
                table: "AccountTransferApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApproval_User_SenderId",
                table: "AccountTransferApproval");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransferApproval_ReceiverId",
                table: "AccountTransferApproval");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "AccountTransferApproval");

            migrationBuilder.RenameColumn(
                name: "SenderRoleId",
                table: "AccountTransferApproval",
                newName: "ForwardedToRoleId");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "AccountTransferApproval",
                newName: "ForwardedToId");

            migrationBuilder.RenameColumn(
                name: "ReceiverRoleId",
                table: "AccountTransferApproval",
                newName: "ApprovedByRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApproval_SenderRoleId",
                table: "AccountTransferApproval",
                newName: "IX_AccountTransferApproval_ForwardedToRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApproval_SenderId",
                table: "AccountTransferApproval",
                newName: "IX_AccountTransferApproval_ForwardedToId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApproval_ReceiverRoleId",
                table: "AccountTransferApproval",
                newName: "IX_AccountTransferApproval_ApprovedByRoleId");

            migrationBuilder.AddColumn<int>(
                name: "AccountTransferApprovalProcess",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ApprovedById",
                table: "AccountTransferApproval",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferApproval_ApprovedById",
                table: "AccountTransferApproval",
                column: "ApprovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApproval_UserRoles_ApprovedByRoleId",
                table: "AccountTransferApproval",
                column: "ApprovedByRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApproval_UserRoles_ForwardedToRoleId",
                table: "AccountTransferApproval",
                column: "ForwardedToRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApproval_User_ApprovedById",
                table: "AccountTransferApproval",
                column: "ApprovedById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApproval_User_ForwardedToId",
                table: "AccountTransferApproval",
                column: "ForwardedToId",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApproval_UserRoles_ApprovedByRoleId",
                table: "AccountTransferApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApproval_UserRoles_ForwardedToRoleId",
                table: "AccountTransferApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApproval_User_ApprovedById",
                table: "AccountTransferApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApproval_User_ForwardedToId",
                table: "AccountTransferApproval");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransferApproval_ApprovedById",
                table: "AccountTransferApproval");

            migrationBuilder.DropColumn(
                name: "AccountTransferApprovalProcess",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                table: "AccountTransferApproval");

            migrationBuilder.RenameColumn(
                name: "ForwardedToRoleId",
                table: "AccountTransferApproval",
                newName: "SenderRoleId");

            migrationBuilder.RenameColumn(
                name: "ForwardedToId",
                table: "AccountTransferApproval",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "ApprovedByRoleId",
                table: "AccountTransferApproval",
                newName: "ReceiverRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApproval_ForwardedToRoleId",
                table: "AccountTransferApproval",
                newName: "IX_AccountTransferApproval_SenderRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApproval_ForwardedToId",
                table: "AccountTransferApproval",
                newName: "IX_AccountTransferApproval_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApproval_ApprovedByRoleId",
                table: "AccountTransferApproval",
                newName: "IX_AccountTransferApproval_ReceiverRoleId");

            migrationBuilder.AddColumn<long>(
                name: "ReceiverId",
                table: "AccountTransferApproval",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferApproval_ReceiverId",
                table: "AccountTransferApproval",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApproval_UserRoles_ReceiverRoleId",
                table: "AccountTransferApproval",
                column: "ReceiverRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApproval_UserRoles_SenderRoleId",
                table: "AccountTransferApproval",
                column: "SenderRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApproval_User_ReceiverId",
                table: "AccountTransferApproval",
                column: "ReceiverId",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApproval_User_SenderId",
                table: "AccountTransferApproval",
                column: "SenderId",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
