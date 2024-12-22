using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CommunityTrainingMaleFemale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalFemale",
                schema: "Capacity",
                table: "CommunityTrainings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalMale",
                schema: "Capacity",
                table: "CommunityTrainings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalParticipants",
                schema: "Capacity",
                table: "CommunityTrainings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalFemale",
                schema: "Capacity",
                table: "CommunityTrainings");

            migrationBuilder.DropColumn(
                name: "TotalMale",
                schema: "Capacity",
                table: "CommunityTrainings");

            migrationBuilder.DropColumn(
                name: "TotalParticipants",
                schema: "Capacity",
                table: "CommunityTrainings");
        }
    }
}
