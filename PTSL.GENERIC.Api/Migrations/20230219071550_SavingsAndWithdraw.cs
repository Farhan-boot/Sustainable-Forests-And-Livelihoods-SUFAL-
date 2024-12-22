using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class SavingsAndWithdraw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavingsAmountInformation",
                schema: "BSA",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    SavingsAccountId = table.Column<long>(nullable: true),
                    SavingsDate = table.Column<DateTime>(nullable: true),
                    SavingsAmount = table.Column<double>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsAmountInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsAmountInformation_SavingsAccount_SavingsAccountId",
                        column: x => x.SavingsAccountId,
                        principalSchema: "BSA",
                        principalTable: "SavingsAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawAmountInformation",
                schema: "BSA",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    SavingsAccountId = table.Column<long>(nullable: true),
                    WithdrawDate = table.Column<DateTime>(nullable: true),
                    WithdrawAmount = table.Column<double>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawAmountInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WithdrawAmountInformation_SavingsAccount_SavingsAccountId",
                        column: x => x.SavingsAccountId,
                        principalSchema: "BSA",
                        principalTable: "SavingsAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAmountInformation_SavingsAccountId",
                schema: "BSA",
                table: "SavingsAmountInformation",
                column: "SavingsAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawAmountInformation_SavingsAccountId",
                schema: "BSA",
                table: "WithdrawAmountInformation",
                column: "SavingsAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavingsAmountInformation",
                schema: "BSA");

            migrationBuilder.DropTable(
                name: "WithdrawAmountInformation",
                schema: "BSA");
        }
    }
}
