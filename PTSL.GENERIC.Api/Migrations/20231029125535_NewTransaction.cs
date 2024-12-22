using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NewTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDetailsForCDFs_TransactionExpenses_TransactionExpens~",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs");

            migrationBuilder.DropTable(
                name: "TransactionExpenses",
                schema: "TRANSACTION");

            migrationBuilder.DropTable(
                name: "TransactionDetails",
                schema: "TRANSACTION");

            migrationBuilder.RenameColumn(
                name: "TransactionExpenseId",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs",
                newName: "TransactionId");

            migrationBuilder.RenameColumn(
                name: "Remakrs",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs",
                newName: "Remarks");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseDetailsForCDFs_TransactionExpenseId",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs",
                newName: "IX_ExpenseDetailsForCDFs_TransactionId");

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                schema: "TRANSACTION",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpenseDate",
                schema: "TRANSACTION",
                table: "Transactions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ExpenseMonth",
                schema: "TRANSACTION",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExpenseYear",
                schema: "TRANSACTION",
                table: "Transactions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestBeatId",
                schema: "TRANSACTION",
                table: "Transactions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "Transactions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestRangeId",
                schema: "TRANSACTION",
                table: "Transactions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FundTypeId",
                schema: "TRANSACTION",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "TotalExpense",
                schema: "TRANSACTION",
                table: "Transactions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpenseDate",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TransactionFiles",
                schema: "TRANSACTION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FileUrl = table.Column<string>(type: "text", nullable: true),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionFiles_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalSchema: "TRANSACTION",
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ForestBeatId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ForestRangeId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FundTypeId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "FundTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionFiles_TransactionId",
                schema: "TRANSACTION",
                table: "TransactionFiles",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDetailsForCDFs_Transactions_TransactionId",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs",
                column: "TransactionId",
                principalSchema: "TRANSACTION",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "AccountId",
                principalSchema: "AccountManagement",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ForestBeats_ForestBeatId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ForestFcvVcfs_ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ForestRanges_ForestRangeId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_FundTypes_FundTypeId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "FundTypeId",
                principalSchema: "TRANSACTION",
                principalTable: "FundTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDetailsForCDFs_Transactions_TransactionId",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_ForestBeats_ForestBeatId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_ForestFcvVcfs_ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_ForestRanges_ForestRangeId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_FundTypes_FundTypeId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionFiles",
                schema: "TRANSACTION");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ForestBeatId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ForestRangeId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_FundTypeId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ExpenseDate",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ExpenseMonth",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ExpenseYear",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ForestBeatId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ForestRangeId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FundTypeId",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TotalExpense",
                schema: "TRANSACTION",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ExpenseDate",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs",
                newName: "TransactionExpenseId");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs",
                newName: "Remakrs");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseDetailsForCDFs_TransactionId",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs",
                newName: "IX_ExpenseDetailsForCDFs_TransactionExpenseId");

            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                schema: "TRANSACTION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    FundTypeId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    TargetAmount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_FundTypes_FundTypeId",
                        column: x => x.FundTypeId,
                        principalSchema: "TRANSACTION",
                        principalTable: "FundTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalSchema: "TRANSACTION",
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionExpenses",
                schema: "TRANSACTION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: true),
                    ForestFcvVcfId = table.Column<long>(type: "bigint", nullable: true),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: true),
                    TransactionDetailsId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    ExpenseAmount = table.Column<double>(type: "double precision", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpenseDocumentFileName = table.Column<string>(type: "text", nullable: true),
                    ExpenseDocumentFileURL = table.Column<string>(type: "text", nullable: true),
                    ExpenseMonth = table.Column<int>(type: "integer", nullable: false),
                    ExpenseYear = table.Column<string>(type: "text", nullable: true),
                    FundTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionExpenses_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionExpenses_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionExpenses_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionExpenses_FundTypes_FundTypeId",
                        column: x => x.FundTypeId,
                        principalSchema: "TRANSACTION",
                        principalTable: "FundTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionExpenses_TransactionDetails_TransactionDetailsId",
                        column: x => x.TransactionDetailsId,
                        principalSchema: "TRANSACTION",
                        principalTable: "TransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_FundTypeId",
                schema: "TRANSACTION",
                table: "TransactionDetails",
                column: "FundTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_TransactionId",
                schema: "TRANSACTION",
                table: "TransactionDetails",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionExpenses_ForestBeatId",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionExpenses_ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionExpenses_ForestRangeId",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionExpenses_FundTypeId",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                column: "FundTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionExpenses_TransactionDetailsId",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                column: "TransactionDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDetailsForCDFs_TransactionExpenses_TransactionExpens~",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs",
                column: "TransactionExpenseId",
                principalSchema: "TRANSACTION",
                principalTable: "TransactionExpenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
