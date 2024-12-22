using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class InternalLoanInformationFileAddNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternalLoanInformationFile_InternalLoanInformations_Intern~",
                table: "InternalLoanInformationFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternalLoanInformationFile",
                table: "InternalLoanInformationFile");

            migrationBuilder.RenameTable(
                name: "InternalLoanInformationFile",
                newName: "InternalLoanInformationFiles",
                newSchema: "InternalLoan");

            migrationBuilder.RenameIndex(
                name: "IX_InternalLoanInformationFile_InternalLoanInformationId",
                schema: "InternalLoan",
                table: "InternalLoanInformationFiles",
                newName: "IX_InternalLoanInformationFiles_InternalLoanInformationId");

            migrationBuilder.AlterColumn<long>(
                name: "InternalLoanInformationId",
                schema: "InternalLoan",
                table: "InternalLoanInformationFiles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternalLoanInformationFiles",
                schema: "InternalLoan",
                table: "InternalLoanInformationFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InternalLoanInformationFiles_InternalLoanInformations_Inter~",
                schema: "InternalLoan",
                table: "InternalLoanInformationFiles",
                column: "InternalLoanInformationId",
                principalSchema: "InternalLoan",
                principalTable: "InternalLoanInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternalLoanInformationFiles_InternalLoanInformations_Inter~",
                schema: "InternalLoan",
                table: "InternalLoanInformationFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternalLoanInformationFiles",
                schema: "InternalLoan",
                table: "InternalLoanInformationFiles");

            migrationBuilder.RenameTable(
                name: "InternalLoanInformationFiles",
                schema: "InternalLoan",
                newName: "InternalLoanInformationFile");

            migrationBuilder.RenameIndex(
                name: "IX_InternalLoanInformationFiles_InternalLoanInformationId",
                table: "InternalLoanInformationFile",
                newName: "IX_InternalLoanInformationFile_InternalLoanInformationId");

            migrationBuilder.AlterColumn<long>(
                name: "InternalLoanInformationId",
                table: "InternalLoanInformationFile",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternalLoanInformationFile",
                table: "InternalLoanInformationFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InternalLoanInformationFile_InternalLoanInformations_Intern~",
                table: "InternalLoanInformationFile",
                column: "InternalLoanInformationId",
                principalSchema: "InternalLoan",
                principalTable: "InternalLoanInformations",
                principalColumn: "Id");
        }
    }
}
