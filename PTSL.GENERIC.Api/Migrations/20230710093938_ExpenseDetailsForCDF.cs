using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseDetailsForCDF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpenseYear",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestBeatId",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ForestRangeId",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenseDetailsForCDFs",
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
                    TransactionExpenseId = table.Column<long>(type: "bigint", nullable: false),
                    ExpenseScheme = table.Column<string>(type: "text", nullable: true),
                    ExpenseAmount = table.Column<double>(type: "double precision", nullable: false),
                    DocumentFileURL = table.Column<string>(type: "text", nullable: true),
                    Remakrs = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDetailsForCDFs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseDetailsForCDFs_TransactionExpenses_TransactionExpens~",
                        column: x => x.TransactionExpenseId,
                        principalSchema: "TRANSACTION",
                        principalTable: "TransactionExpenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_ExpenseDetailsForCDFs_TransactionExpenseId",
                schema: "TRANSACTION",
                table: "ExpenseDetailsForCDFs",
                column: "TransactionExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionExpenses_ForestBeats_ForestBeatId",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionExpenses_ForestFcvVcfs_ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionExpenses_ForestRanges_ForestRangeId",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionExpenses_ForestBeats_ForestBeatId",
                schema: "TRANSACTION",
                table: "TransactionExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionExpenses_ForestFcvVcfs_ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "TransactionExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionExpenses_ForestRanges_ForestRangeId",
                schema: "TRANSACTION",
                table: "TransactionExpenses");

            migrationBuilder.DropTable(
                name: "ExpenseDetailsForCDFs",
                schema: "TRANSACTION");

            migrationBuilder.DropIndex(
                name: "IX_TransactionExpenses_ForestBeatId",
                schema: "TRANSACTION",
                table: "TransactionExpenses");

            migrationBuilder.DropIndex(
                name: "IX_TransactionExpenses_ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "TransactionExpenses");

            migrationBuilder.DropIndex(
                name: "IX_TransactionExpenses_ForestRangeId",
                schema: "TRANSACTION",
                table: "TransactionExpenses");

            migrationBuilder.DropColumn(
                name: "ExpenseYear",
                schema: "TRANSACTION",
                table: "TransactionExpenses");

            migrationBuilder.DropColumn(
                name: "ForestBeatId",
                schema: "TRANSACTION",
                table: "TransactionExpenses");

            migrationBuilder.DropColumn(
                name: "ForestFcvVcfId",
                schema: "TRANSACTION",
                table: "TransactionExpenses");

            migrationBuilder.DropColumn(
                name: "ForestRangeId",
                schema: "TRANSACTION",
                table: "TransactionExpenses");
        }
    }
}
