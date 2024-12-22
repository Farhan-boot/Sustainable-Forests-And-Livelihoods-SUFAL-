using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccessListModuleFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessListType",
                schema: "System",
                table: "Accesslist");

            migrationBuilder.DropColumn(
                name: "BaseModule",
                schema: "System",
                table: "Accesslist");

            migrationBuilder.AddColumn<long>(
                name: "ModuleId",
                schema: "System",
                table: "Accesslist",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accesslist_ModuleId",
                schema: "System",
                table: "Accesslist",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accesslist_Module_ModuleId",
                schema: "System",
                table: "Accesslist",
                column: "ModuleId",
                principalSchema: "System",
                principalTable: "Module",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accesslist_Module_ModuleId",
                schema: "System",
                table: "Accesslist");

            migrationBuilder.DropIndex(
                name: "IX_Accesslist_ModuleId",
                schema: "System",
                table: "Accesslist");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                schema: "System",
                table: "Accesslist");

            migrationBuilder.AddColumn<int>(
                name: "AccessListType",
                schema: "System",
                table: "Accesslist",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseModule",
                schema: "System",
                table: "Accesslist",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
