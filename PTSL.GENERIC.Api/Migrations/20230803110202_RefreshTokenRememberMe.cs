using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenRememberMe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RememberMe",
                schema: "System",
                table: "RefreshToken",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_Token",
                schema: "System",
                table: "RefreshToken",
                column: "Token");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_Token",
                schema: "System",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "RememberMe",
                schema: "System",
                table: "RefreshToken");
        }
    }
}
