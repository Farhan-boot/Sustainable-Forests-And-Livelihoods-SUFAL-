using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class RepaymentInternalLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepaymentInternalLoans",
                schema: "InternalLoan",
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
                    InternalLoanInformationId = table.Column<long>(nullable: false),
                    RepaymentAmount = table.Column<decimal>(nullable: true),
                    RepaymentStartDate = table.Column<DateTime>(nullable: true),
                    RepaymentEndDate = table.Column<DateTime>(nullable: true),
                    RepaymentSerial = table.Column<int>(nullable: true),
                    IsPaymentCompleted = table.Column<bool>(nullable: true),
                    PaymentCompletedDateTime = table.Column<DateTime>(nullable: true),
                    IsPaymentCompletedLate = table.Column<bool>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentInternalLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepaymentInternalLoans_InternalLoanInformations_InternalLoa~",
                        column: x => x.InternalLoanInformationId,
                        principalSchema: "InternalLoan",
                        principalTable: "InternalLoanInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentInternalLoans_InternalLoanInformationId",
                schema: "InternalLoan",
                table: "RepaymentInternalLoans",
                column: "InternalLoanInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepaymentInternalLoans",
                schema: "InternalLoan");
        }
    }
}
