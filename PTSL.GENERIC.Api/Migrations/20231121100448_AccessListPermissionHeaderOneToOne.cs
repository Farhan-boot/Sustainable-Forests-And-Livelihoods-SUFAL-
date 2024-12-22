using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccessListPermissionHeaderOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionHeaderSettings_Accesslist_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings");

            migrationBuilder.DropIndex(
                name: "IX_PermissionHeaderSettings_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings");

            migrationBuilder.AlterColumn<long>(
                name: "AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionHeaderSettings_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "AccesslistId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionHeaderSettings_Accesslist_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "AccesslistId",
                principalSchema: "System",
                principalTable: "Accesslist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionHeaderSettings_Accesslist_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings");

            migrationBuilder.DropIndex(
                name: "IX_PermissionHeaderSettings_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings");

            migrationBuilder.AlterColumn<long>(
                name: "AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionHeaderSettings_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "AccesslistId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionHeaderSettings_Accesslist_AccesslistId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "AccesslistId",
                principalSchema: "System",
                principalTable: "Accesslist",
                principalColumn: "Id");
        }
    }
}
