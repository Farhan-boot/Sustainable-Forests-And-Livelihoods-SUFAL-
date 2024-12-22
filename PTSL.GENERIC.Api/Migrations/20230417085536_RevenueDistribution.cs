using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class RevenueDistribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RevenueFeelingOrCutting_FeelingOrCutting_FeelingOrCuttingId",
                schema: "Plantation",
                table: "RevenueFeelingOrCutting");

            migrationBuilder.CreateTable(
                name: "RevenueDistribution",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RevenueFeelingOrCuttingId = table.Column<long>(type: "bigint", nullable: false),
                    RevenueDistributionTypeEnum = table.Column<int>(type: "integer", nullable: false),
                    ShareInPercentage = table.Column<double>(type: "double precision", nullable: false),
                    GovernmentRevenue = table.Column<double>(type: "double precision", nullable: false),
                    RevenueCollected = table.Column<double>(type: "double precision", nullable: false),
                    OutStandingAmount = table.Column<double>(type: "double precision", nullable: false),
                    NumberOrMale = table.Column<int>(type: "integer", nullable: false),
                    NumberOrFemale = table.Column<int>(type: "integer", nullable: false),
                    AmountInHand = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueDistribution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueDistribution_RevenueFeelingOrCutting_RevenueFeelingO~",
                        column: x => x.RevenueFeelingOrCuttingId,
                        principalSchema: "Plantation",
                        principalTable: "RevenueFeelingOrCutting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankDeposit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RevenueDistributionId = table.Column<long>(type: "bigint", nullable: false),
                    DepositAmount = table.Column<double>(type: "double precision", nullable: false),
                    DepositDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDeposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDeposit_RevenueDistribution_RevenueDistributionId",
                        column: x => x.RevenueDistributionId,
                        principalTable: "RevenueDistribution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevenueOrDistributedAmount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RevenueDistributionId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    DateOccurred = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueOrDistributedAmount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueOrDistributedAmount_RevenueDistribution_RevenueDistr~",
                        column: x => x.RevenueDistributionId,
                        principalTable: "RevenueDistribution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankDeposit_RevenueDistributionId",
                table: "BankDeposit",
                column: "RevenueDistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueDistribution_RevenueFeelingOrCuttingId",
                table: "RevenueDistribution",
                column: "RevenueFeelingOrCuttingId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueOrDistributedAmount_RevenueDistributionId",
                table: "RevenueOrDistributedAmount",
                column: "RevenueDistributionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RevenueFeelingOrCutting_FeelingOrCutting_FeelingOrCuttingId",
                schema: "Plantation",
                table: "RevenueFeelingOrCutting",
                column: "FeelingOrCuttingId",
                principalSchema: "Plantation",
                principalTable: "FeelingOrCutting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RevenueFeelingOrCutting_FeelingOrCutting_FeelingOrCuttingId",
                schema: "Plantation",
                table: "RevenueFeelingOrCutting");

            migrationBuilder.DropTable(
                name: "BankDeposit");

            migrationBuilder.DropTable(
                name: "RevenueOrDistributedAmount");

            migrationBuilder.DropTable(
                name: "RevenueDistribution");

            migrationBuilder.AddForeignKey(
                name: "FK_RevenueFeelingOrCutting_FeelingOrCutting_FeelingOrCuttingId",
                schema: "Plantation",
                table: "RevenueFeelingOrCutting",
                column: "FeelingOrCuttingId",
                principalSchema: "Plantation",
                principalTable: "FeelingOrCutting",
                principalColumn: "Id");
        }
    }
}
