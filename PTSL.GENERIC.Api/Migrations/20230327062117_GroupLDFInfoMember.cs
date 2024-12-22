using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class GroupLDFInfoMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupLDFInfoFormMember_GroupLDFInfoForms_GroupLDFInfoFormId",
                table: "GroupLDFInfoFormMember");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLDFInfoFormMember_IndividualLDFInfoForms_IndividualLDF~",
                table: "GroupLDFInfoFormMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupLDFInfoFormMember",
                table: "GroupLDFInfoFormMember");

            migrationBuilder.RenameTable(
                name: "GroupLDFInfoFormMember",
                newName: "GroupLDFInfoFormMembers",
                newSchema: "AIG");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLDFInfoFormMember_IndividualLDFInfoFormId",
                schema: "AIG",
                table: "GroupLDFInfoFormMembers",
                newName: "IX_GroupLDFInfoFormMembers_IndividualLDFInfoFormId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLDFInfoFormMember_GroupLDFInfoFormId",
                schema: "AIG",
                table: "GroupLDFInfoFormMembers",
                newName: "IX_GroupLDFInfoFormMembers_GroupLDFInfoFormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupLDFInfoFormMembers",
                schema: "AIG",
                table: "GroupLDFInfoFormMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLDFInfoFormMembers_GroupLDFInfoForms_GroupLDFInfoFormId",
                schema: "AIG",
                table: "GroupLDFInfoFormMembers",
                column: "GroupLDFInfoFormId",
                principalSchema: "AIG",
                principalTable: "GroupLDFInfoForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLDFInfoFormMembers_IndividualLDFInfoForms_IndividualLD~",
                schema: "AIG",
                table: "GroupLDFInfoFormMembers",
                column: "IndividualLDFInfoFormId",
                principalSchema: "AIG",
                principalTable: "IndividualLDFInfoForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupLDFInfoFormMembers_GroupLDFInfoForms_GroupLDFInfoFormId",
                schema: "AIG",
                table: "GroupLDFInfoFormMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLDFInfoFormMembers_IndividualLDFInfoForms_IndividualLD~",
                schema: "AIG",
                table: "GroupLDFInfoFormMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupLDFInfoFormMembers",
                schema: "AIG",
                table: "GroupLDFInfoFormMembers");

            migrationBuilder.RenameTable(
                name: "GroupLDFInfoFormMembers",
                schema: "AIG",
                newName: "GroupLDFInfoFormMember");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLDFInfoFormMembers_IndividualLDFInfoFormId",
                table: "GroupLDFInfoFormMember",
                newName: "IX_GroupLDFInfoFormMember_IndividualLDFInfoFormId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLDFInfoFormMembers_GroupLDFInfoFormId",
                table: "GroupLDFInfoFormMember",
                newName: "IX_GroupLDFInfoFormMember_GroupLDFInfoFormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupLDFInfoFormMember",
                table: "GroupLDFInfoFormMember",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLDFInfoFormMember_GroupLDFInfoForms_GroupLDFInfoFormId",
                table: "GroupLDFInfoFormMember",
                column: "GroupLDFInfoFormId",
                principalSchema: "AIG",
                principalTable: "GroupLDFInfoForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLDFInfoFormMember_IndividualLDFInfoForms_IndividualLDF~",
                table: "GroupLDFInfoFormMember",
                column: "IndividualLDFInfoFormId",
                principalSchema: "AIG",
                principalTable: "IndividualLDFInfoForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
