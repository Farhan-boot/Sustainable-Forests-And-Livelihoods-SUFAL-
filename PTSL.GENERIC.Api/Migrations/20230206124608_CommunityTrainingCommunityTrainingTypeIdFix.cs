using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class CommunityTrainingCommunityTrainingTypeIdFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CommunityTrainingTypeId",
                schema: "Capacity",
                table: "CommunityTrainings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CommunityTrainingTypeId",
                schema: "Capacity",
                table: "CommunityTrainings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
