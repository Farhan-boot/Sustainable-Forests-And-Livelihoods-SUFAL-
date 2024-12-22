using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccountTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposits_Accounts_AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposits_FinancialYears_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposits_User_DepositedById",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferLogs_User_TransferStatusById",
                schema: "AccountManagement",
                table: "AccountTransferLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransfers_Accounts_FromAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransfers_Accounts_ToAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransfers_FinancialYears_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransfers_User_TransferRequestInitiatedById",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransfers_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransfers_FromAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransfers_ToAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_DepositedById",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropColumn(
                name: "FromAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropColumn(
                name: "ToAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropColumn(
                name: "TransferRequestCreatedDate",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "DepositAmount",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "DepositCreatedDate",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "DepositedById",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.RenameColumn(
                name: "TransferRequestInitiatedById",
                schema: "AccountManagement",
                table: "AccountTransfers",
                newName: "AccountTransactionId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransfers_TransferRequestInitiatedById",
                schema: "AccountManagement",
                table: "AccountTransfers",
                newName: "IX_AccountTransfers_AccountTransactionId");

            migrationBuilder.RenameColumn(
                name: "TransferStatusById",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                newName: "TransferStatusChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferLogs_TransferStatusById",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                newName: "IX_AccountTransferLogs_TransferStatusChangedById");

            migrationBuilder.RenameColumn(
                name: "FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                newName: "AccountTransactionId");

            migrationBuilder.CreateTable(
                name: "AccountTransactions",
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
                    FromAccountId = table.Column<long>(type: "bigint", nullable: false),
                    ToAccountId = table.Column<long>(type: "bigint", nullable: false),
                    FinancialYearId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionAmount = table.Column<double>(type: "double precision", nullable: false),
                    TransactionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TransactionById = table.Column<long>(type: "bigint", nullable: false),
                    AccountTransactionType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransactions_Accounts_FromAccountId",
                        column: x => x.FromAccountId,
                        principalSchema: "AccountManagement",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransactions_Accounts_ToAccountId",
                        column: x => x.ToAccountId,
                        principalSchema: "AccountManagement",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransactions_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalSchema: "GS",
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransactions_User_TransactionById",
                        column: x => x.TransactionById,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposits_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "AccountTransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransactions_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountTransactions",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransactions_FromAccountId",
                schema: "AccountManagement",
                table: "AccountTransactions",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransactions_ToAccountId",
                schema: "AccountManagement",
                table: "AccountTransactions",
                column: "ToAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransactions_TransactionById",
                schema: "AccountManagement",
                table: "AccountTransactions",
                column: "TransactionById");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposits_AccountTransactions_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "AccountTransactionId",
                principalSchema: "AccountManagement",
                principalTable: "AccountTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferLogs_User_TransferStatusChangedById",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                column: "TransferStatusChangedById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransfers_AccountTransactions_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "AccountTransactionId",
                principalSchema: "AccountManagement",
                principalTable: "AccountTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposits_AccountTransactions_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferLogs_User_TransferStatusChangedById",
                schema: "AccountManagement",
                table: "AccountTransferLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransfers_AccountTransactions_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropTable(
                name: "AccountTransactions",
                schema: "AccountManagement");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.RenameColumn(
                name: "AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                newName: "TransferRequestInitiatedById");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransfers_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                newName: "IX_AccountTransfers_TransferRequestInitiatedById");

            migrationBuilder.RenameColumn(
                name: "TransferStatusChangedById",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                newName: "TransferStatusById");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransferLogs_TransferStatusChangedById",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                newName: "IX_AccountTransferLogs_TransferStatusById");

            migrationBuilder.RenameColumn(
                name: "AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                newName: "FinancialYearId");

            migrationBuilder.AddColumn<long>(
                name: "FinancialYearId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FromAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ToAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransferRequestCreatedDate",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "DepositAmount",
                schema: "AccountManagement",
                table: "AccountDeposits",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepositCreatedDate",
                schema: "AccountManagement",
                table: "AccountDeposits",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "DepositedById",
                schema: "AccountManagement",
                table: "AccountDeposits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfers_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfers_FromAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfers_ToAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "ToAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposits_AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposits_DepositedById",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "DepositedById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposits_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "FinancialYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposits_Accounts_AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "AccountId",
                principalSchema: "AccountManagement",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposits_FinancialYears_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "FinancialYearId",
                principalSchema: "GS",
                principalTable: "FinancialYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDeposits_User_DepositedById",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "DepositedById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferLogs_User_TransferStatusById",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                column: "TransferStatusById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransfers_Accounts_FromAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "FromAccountId",
                principalSchema: "AccountManagement",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransfers_Accounts_ToAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "ToAccountId",
                principalSchema: "AccountManagement",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransfers_FinancialYears_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "FinancialYearId",
                principalSchema: "GS",
                principalTable: "FinancialYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransfers_User_TransferRequestInitiatedById",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "TransferRequestInitiatedById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
