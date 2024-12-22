using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class TransactionExpenseMonth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpenseDocumentFileURL",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseDocumentFileName",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseMonth",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseMonth",
                schema: "TRANSACTION",
                table: "TransactionExpenses");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseDocumentFileURL",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseDocumentFileName",
                schema: "TRANSACTION",
                table: "TransactionExpenses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
