using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccountDepositApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountDepositApprovalProcess",
                schema: "AccountManagement",
                table: "AccountDeposits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountDepositStatus",
                schema: "AccountManagement",
                table: "AccountDeposits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "NextApprovalOrderNo",
                schema: "AccountManagement",
                table: "AccountDeposits",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountDepositApproval",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ApprovedById = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedByRoleId = table.Column<long>(type: "bigint", nullable: true),
                    ForwardedById = table.Column<long>(type: "bigint", nullable: true),
                    ForwardedByRoleId = table.Column<long>(type: "bigint", nullable: true),
                    ForwardedToId = table.Column<long>(type: "bigint", nullable: true),
                    ForwardedToRoleId = table.Column<long>(type: "bigint", nullable: true),
                    SendingDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    RowId = table.Column<long>(type: "bigint", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDepositApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountDepositApproval_AccountDeposits_RowId",
                        column: x => x.RowId,
                        principalSchema: "AccountManagement",
                        principalTable: "AccountDeposits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountDepositApproval_UserRoles_ApprovedByRoleId",
                        column: x => x.ApprovedByRoleId,
                        principalSchema: "System",
                        principalTable: "UserRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountDepositApproval_UserRoles_ForwardedByRoleId",
                        column: x => x.ForwardedByRoleId,
                        principalSchema: "System",
                        principalTable: "UserRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountDepositApproval_UserRoles_ForwardedToRoleId",
                        column: x => x.ForwardedToRoleId,
                        principalSchema: "System",
                        principalTable: "UserRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountDepositApproval_User_ApprovedById",
                        column: x => x.ApprovedById,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountDepositApproval_User_ForwardedById",
                        column: x => x.ForwardedById,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountDepositApproval_User_ForwardedToId",
                        column: x => x.ForwardedToId,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposits_NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "NextApprovalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposits_NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "NextApprovalUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepositApproval_ApprovedById",
                table: "AccountDepositApproval",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepositApproval_ApprovedByRoleId",
                table: "AccountDepositApproval",
                column: "ApprovedByRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepositApproval_ForwardedById",
                table: "AccountDepositApproval",
                column: "ForwardedById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepositApproval_ForwardedByRoleId",
                table: "AccountDepositApproval",
                column: "ForwardedByRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepositApproval_ForwardedToId",
                table: "AccountDepositApproval",
                column: "ForwardedToId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepositApproval_ForwardedToRoleId",
                table: "AccountDepositApproval",
                column: "ForwardedToRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepositApproval_RowId",
                table: "AccountDepositApproval",
                column: "RowId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposits_UserRoles_NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "NextApprovalUserRoleId",
                principalSchema: "System",
                principalTable: "UserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposits_User_NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "NextApprovalUserId",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposits_UserRoles_NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposits_User_NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropTable(
                name: "AccountDepositApproval");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "AccountDepositApprovalProcess",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "AccountDepositStatus",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "NextApprovalOrderNo",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "NextApprovalUserId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "NextApprovalUserRoleId",
                schema: "AccountManagement",
                table: "AccountDeposits");
        }
    }
}
