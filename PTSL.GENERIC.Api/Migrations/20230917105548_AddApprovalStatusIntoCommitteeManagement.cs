using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddApprovalStatusIntoCommitteeManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ApprovalStatus",
                schema: "BEN",
                table: "CommitteeManagement",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                schema: "BEN",
                table: "CommitteeManagement");
        }
    }
}
