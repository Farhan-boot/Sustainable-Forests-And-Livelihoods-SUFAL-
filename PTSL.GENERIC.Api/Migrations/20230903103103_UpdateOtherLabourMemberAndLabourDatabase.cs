using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOtherLabourMemberAndLabourDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpouseName",
                schema: "Labour",
                table: "OtherLabourMembers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Labour",
                table: "LabourDatabases",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherName",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropColumn(
                name: "MotherName",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropColumn(
                name: "SpouseName",
                schema: "Labour",
                table: "OtherLabourMembers");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Labour",
                table: "LabourDatabases");
        }
    }
}
