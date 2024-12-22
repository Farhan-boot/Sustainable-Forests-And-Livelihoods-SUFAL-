using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class RemovedBadLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstSixtyPercentageLDFs_BadLoanTypes_BadLoanTypeId",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs");

            migrationBuilder.DropForeignKey(
                name: "FK_SecondFourtyPercentageLDFs_BadLoanTypes_BadLoanTypeId",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropTable(
                name: "BadLoanTypes",
                schema: "AIG");

            migrationBuilder.DropIndex(
                name: "IX_SecondFourtyPercentageLDFs_BadLoanTypeId",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropIndex(
                name: "IX_FirstSixtyPercentageLDFs_BadLoanTypeId",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "BadLoanTypeId",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "IsDefaulter",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "BadLoanTypeId",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs");

            migrationBuilder.DropColumn(
                name: "IsDefaulter",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BadLoanTypeId",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaulter",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "BadLoanTypeId",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaulter",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BadLoanTypes",
                schema: "AIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadLoanTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecondFourtyPercentageLDFs_BadLoanTypeId",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                column: "BadLoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstSixtyPercentageLDFs_BadLoanTypeId",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs",
                column: "BadLoanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstSixtyPercentageLDFs_BadLoanTypes_BadLoanTypeId",
                schema: "AIG",
                table: "FirstSixtyPercentageLDFs",
                column: "BadLoanTypeId",
                principalSchema: "AIG",
                principalTable: "BadLoanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SecondFourtyPercentageLDFs_BadLoanTypes_BadLoanTypeId",
                schema: "AIG",
                table: "SecondFourtyPercentageLDFs",
                column: "BadLoanTypeId",
                principalSchema: "AIG",
                principalTable: "BadLoanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
