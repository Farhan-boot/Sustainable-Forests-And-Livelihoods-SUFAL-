using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class MeetingMaleFemale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalFemale",
                schema: "Meeting",
                table: "Meetings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalMale",
                schema: "Meeting",
                table: "Meetings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalMembers",
                schema: "Meeting",
                table: "Meetings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalFemale",
                schema: "Meeting",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "TotalMale",
                schema: "Meeting",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "TotalMembers",
                schema: "Meeting",
                table: "Meetings");
        }
    }
}
