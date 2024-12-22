using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccountTransferDeposit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SourceOfFunds",
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceOfFunds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountDeposits",
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
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    FinancialYearId = table.Column<long>(type: "bigint", nullable: false),
                    SourceOfFundId = table.Column<long>(type: "bigint", nullable: false),
                    DepositedById = table.Column<long>(type: "bigint", nullable: false),
                    DepositDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DepositAmount = table.Column<double>(type: "double precision", nullable: false),
                    DepositCreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountDeposits_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "AccountManagement",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountDeposits_FinancialYears_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "GS",
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountDeposits_SourceOfFunds_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "AccountManagement",
                        principalTable: "SourceOfFunds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountDeposits_User_DepositedById",
                        column: x => x.DepositedById,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransfers",
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
                    SourceOfFundId = table.Column<long>(type: "bigint", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TransferAmount = table.Column<double>(type: "double precision", nullable: false),
                    TransferRequestCreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TransferRequestInitiatedById = table.Column<long>(type: "bigint", nullable: false),
                    AccountTransferStatus = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransfers_Accounts_FromAccountId",
                        column: x => x.FromAccountId,
                        principalSchema: "AccountManagement",
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTransfers_Accounts_ToAccountId",
                        column: x => x.ToAccountId,
                        principalSchema: "AccountManagement",
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTransfers_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalSchema: "GS",
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransfers_SourceOfFunds_SourceOfFundId",
                        column: x => x.SourceOfFundId,
                        principalSchema: "AccountManagement",
                        principalTable: "SourceOfFunds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransfers_User_TransferRequestInitiatedById",
                        column: x => x.TransferRequestInitiatedById,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransferLogs",
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
                    TransferStatusById = table.Column<long>(type: "bigint", nullable: false),
                    AccountTransferStatus = table.Column<int>(type: "integer", nullable: false),
                    StatusCreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransferLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransferLogs_AccountTransfers_AccountTransferId",
                        column: x => x.AccountTransferId,
                        principalSchema: "AccountManagement",
                        principalTable: "AccountTransfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransferLogs_User_TransferStatusById",
                        column: x => x.TransferStatusById,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_AccountTransferLogs_AccountTransferId",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                column: "AccountTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferLogs_TransferStatusById",
                schema: "AccountManagement",
                table: "AccountTransferLogs",
                column: "TransferStatusById");

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
                name: "IX_AccountTransfers_SourceOfFundId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "SourceOfFundId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfers_ToAccountId",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "ToAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfers_TransferRequestInitiatedById",
                schema: "AccountManagement",
                table: "AccountTransfers",
                column: "TransferRequestInitiatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountDeposits",
                schema: "AccountManagement");

            migrationBuilder.DropTable(
                name: "AccountTransferLogs",
                schema: "AccountManagement");

            migrationBuilder.DropTable(
                name: "AccountTransfers",
                schema: "AccountManagement");

            migrationBuilder.DropTable(
                name: "SourceOfFunds",
                schema: "AccountManagement");
        }
    }
}
