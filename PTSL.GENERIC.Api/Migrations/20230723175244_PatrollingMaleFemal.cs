using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class PatrollingMaleFemal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UnionId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalFemale",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalMale",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalParticipants",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalFemale",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings");

            migrationBuilder.DropColumn(
                name: "TotalMale",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings");

            migrationBuilder.DropColumn(
                name: "TotalParticipants",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings");

            migrationBuilder.AlterColumn<long>(
                name: "UnionId",
                schema: "PatrollingScheduling",
                table: "PatrollingSchedulings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
