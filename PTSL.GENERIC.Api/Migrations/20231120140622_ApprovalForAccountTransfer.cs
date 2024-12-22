using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ApprovalForAccountTransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTransferApproval",
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
                    SenderRoleId = table.Column<long>(type: "bigint", nullable: true),
                    ReceiverRoleId = table.Column<long>(type: "bigint", nullable: true),
                    SendingDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SendingTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RowId = table.Column<long>(type: "bigint", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransferApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransferApproval_AccountTransfers_RowId",
                        column: x => x.RowId,
                        principalSchema: "AccountManagement",
                        principalTable: "AccountTransfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransferApproval_UserRoles_ReceiverRoleId",
                        column: x => x.ReceiverRoleId,
                        principalSchema: "System",
                        principalTable: "UserRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTransferApproval_UserRoles_SenderRoleId",
                        column: x => x.SenderRoleId,
                        principalSchema: "System",
                        principalTable: "UserRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTransferApproval_User_ReceiverId",
                        column: x => x.ReceiverId,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTransferApproval_User_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferApproval_ReceiverId",
                table: "AccountTransferApproval",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferApproval_ReceiverRoleId",
                table: "AccountTransferApproval",
                column: "ReceiverRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferApproval_RowId",
                table: "AccountTransferApproval",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferApproval_SenderId",
                table: "AccountTransferApproval",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferApproval_SenderRoleId",
                table: "AccountTransferApproval",
                column: "SenderRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTransferApproval");
        }
    }
}
