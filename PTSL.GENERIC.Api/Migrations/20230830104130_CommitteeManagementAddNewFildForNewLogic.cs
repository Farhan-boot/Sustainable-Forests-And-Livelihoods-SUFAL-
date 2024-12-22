using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CommitteeManagementAddNewFildForNewLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CommitteeDesignationsConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CommitteeTypeConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CommitteesConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommitteeDesignationsConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.DropColumn(
                name: "CommitteeTypeConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.DropColumn(
                name: "CommitteesConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement");
        }
    }
}
