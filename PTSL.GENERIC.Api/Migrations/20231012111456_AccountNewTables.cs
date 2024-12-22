using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccountNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDeposits_AccountTransactions_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransfers_AccountTransactions_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransfers_SourceOfFunds_SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropTable(
                name: "AccountTransactions",
                schema: "AccountManagement");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "Purpose",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.RenameColumn(
                name: "AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                newName: "TransferRequestedById");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransfers_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                newName: "IX_AccountTransfers_TransferRequestedById");

            migrationBuilder.RenameColumn(
                name: "AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                newName: "TransactionById");

            migrationBuilder.AlterColumn<long>(
                name: "SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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
                name: "TransferTransactionTime",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "AccountTransferDetailsId",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AmountChangedFrom",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AmountChangedTo",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "AccountAllowedFundExpenses",
                schema: "AccountManagement",
                table: "Accounts",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<double>(
                name: "CurrentBlockAmount",
                schema: "AccountManagement",
                table: "Accounts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

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
                name: "DepositTransactionTime",
                schema: "AccountManagement",
                table: "AccountDeposits",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "AccountTransferDetails",
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
                    AccountTransferId = table.Column<long>(type: "bigint", nullable: false),
                    SourceOfFundId = table.Column<long>(type: "bigint", nullable: false),
                    TransferDetailsAmount = table.Column<double>(type: "double precision", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransferDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransferDetails_AccountTransfers_AccountTransferId",
                        column: x => x.AccountTransferId,
                        principalSchema: "AccountManagement",
                        principalTable: "AccountTransfers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTransferDetails_SourceOfFunds_SourceOfFundId",
                        column: x => x.SourceOfFundId,
                        principalSchema: "AccountManagement",
                        principalTable: "SourceOfFunds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_AccountTransferLogs_AccountTransferDetailsId",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                column: "AccountTransferDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposits_AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposits_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposits_TransactionById",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "TransactionById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferDetails_AccountTransferId",
                schema: "AccountManagement",
                table: "AccountTransferDetails",
                column: "AccountTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferDetails_SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountTransferDetails",
                column: "SourceOfFundId");

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
                name: "FK_AccountDeposits_User_TransactionById",
                schema: "AccountManagement",
                table: "AccountDeposits",
                column: "TransactionById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransferLogs_AccountTransferDetails_AccountTransferD~",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                column: "AccountTransferDetailsId",
                principalSchema: "AccountManagement",
                principalTable: "AccountTransferDetails",
                principalColumn: "Id");

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransfers_SourceOfFunds_SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "SourceOfFundId",
                principalSchema: "AccountManagement",
                principalTable: "SourceOfFunds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransfers_User_TransferRequestedById",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "TransferRequestedById",
                principalSchema: "System",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_AccountDeposits_User_TransactionById",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransferLogs_AccountTransferDetails_AccountTransferD~",
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
                name: "FK_AccountTransfers_SourceOfFunds_SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransfers_User_TransferRequestedById",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropTable(
                name: "AccountTransferDetails",
                schema: "AccountManagement");

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
                name: "IX_AccountTransferLogs_AccountTransferDetailsId",
                schema: "AccountManagement",
                table: "AccountTransferLogs");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropIndex(
                name: "IX_AccountDeposits_TransactionById",
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
                name: "TransferTransactionTime",
                schema: "AccountManagement",
                table: "AccountTransfers");

            migrationBuilder.DropColumn(
                name: "AccountTransferDetailsId",
                schema: "AccountManagement",
                table: "AccountTransferLogs");

            migrationBuilder.DropColumn(
                name: "AmountChangedFrom",
                schema: "AccountManagement",
                table: "AccountTransferLogs");

            migrationBuilder.DropColumn(
                name: "AmountChangedTo",
                schema: "AccountManagement",
                table: "AccountTransferLogs");

            migrationBuilder.DropColumn(
                name: "AccountAllowedFundExpenses",
                schema: "AccountManagement",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CurrentBlockAmount",
                schema: "AccountManagement",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "DepositAmount",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "DepositTransactionTime",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                schema: "AccountManagement",
                table: "AccountDeposits");

            migrationBuilder.RenameColumn(
                name: "TransferRequestedById",
                schema: "AccountManagement",
                table: "AccountTransfers",
                newName: "AccountTransactionId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransfers_TransferRequestedById",
                schema: "AccountManagement",
                table: "AccountTransfers",
                newName: "IX_AccountTransfers_AccountTransactionId");

            migrationBuilder.RenameColumn(
                name: "TransactionById",
                schema: "AccountManagement",
                table: "AccountDeposits",
                newName: "AccountTransactionId");

            migrationBuilder.AlterColumn<long>(
                name: "SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                schema: "AccountManagement",
                table: "AccountTransfers",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                    FinancialYearId = table.Column<long>(type: "bigint", nullable: false),
                    FromAccountId = table.Column<long>(type: "bigint", nullable: false),
                    ToAccountId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionById = table.Column<long>(type: "bigint", nullable: false),
                    AccountTransactionType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    TransactionAmount = table.Column<double>(type: "double precision", nullable: false),
                    TransactionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                name: "FK_AccountTransfers_AccountTransactions_AccountTransactionId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "AccountTransactionId",
                principalSchema: "AccountManagement",
                principalTable: "AccountTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransfers_SourceOfFunds_SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "SourceOfFundId",
                principalSchema: "AccountManagement",
                principalTable: "SourceOfFunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
