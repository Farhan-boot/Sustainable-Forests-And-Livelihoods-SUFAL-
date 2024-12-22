using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccountTransferApprovalOrderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApproval_AccountTransfers_RowId",
                table: "AccountTransferApproval");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTransferApproval",
                table: "AccountTransferApproval");

            migrationBuilder.RenameTable(
                name: "AccountTransferApproval",
                newName: "AccountTransferApprovals",
                newSchema: "AccountManagement");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApproval_RowId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                newName: "IX_AccountTransferApprovals_RowId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApproval_ForwardedToRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                newName: "IX_AccountTransferApprovals_ForwardedToRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApproval_ForwardedToId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                newName: "IX_AccountTransferApprovals_ForwardedToId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApproval_ApprovedByRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                newName: "IX_AccountTransferApprovals_ApprovedByRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApproval_ApprovedById",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                newName: "IX_AccountTransferApprovals_ApprovedById");

            migrationBuilder.AlterColumn<long>(
                name: "ApprovedById",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTransferApprovals",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApprovals_AccountTransfers_RowId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                column: "RowId",
                principalSchema: "AccountManagement",
                principalTable: "AccountTransfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApprovals_UserRoles_ApprovedByRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                column: "ApprovedByRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApprovals_UserRoles_ForwardedToRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                column: "ForwardedToRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApprovals_User_ApprovedById",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                column: "ApprovedById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApprovals_User_ForwardedToId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals",
                column: "ForwardedToId",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApprovals_AccountTransfers_RowId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApprovals_UserRoles_ApprovedByRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApprovals_UserRoles_ForwardedToRoleId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApprovals_User_ApprovedById",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferApprovals_User_ForwardedToId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTransferApprovals",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "AccountManagement",
                table: "AccountTransferApprovals");

            migrationBuilder.RenameTable(
                name: "AccountTransferApprovals",
                schema: "AccountManagement",
                newName: "AccountTransferApproval");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApprovals_RowId",
                table: "AccountTransferApproval",
                newName: "IX_AccountTransferApproval_RowId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApprovals_ForwardedToRoleId",
                table: "AccountTransferApproval",
                newName: "IX_AccountTransferApproval_ForwardedToRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApprovals_ForwardedToId",
                table: "AccountTransferApproval",
                newName: "IX_AccountTransferApproval_ForwardedToId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApprovals_ApprovedByRoleId",
                table: "AccountTransferApproval",
                newName: "IX_AccountTransferApproval_ApprovedByRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferApprovals_ApprovedById",
                table: "AccountTransferApproval",
                newName: "IX_AccountTransferApproval_ApprovedById");

            migrationBuilder.AlterColumn<long>(
                name: "ApprovedById",
                table: "AccountTransferApproval",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTransferApproval",
                table: "AccountTransferApproval",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferApproval_AccountTransfers_RowId",
                table: "AccountTransferApproval",
                column: "RowId",
                principalSchema: "AccountManagement",
                principalTable: "AccountTransfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
