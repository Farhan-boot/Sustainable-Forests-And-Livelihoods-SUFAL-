using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommitteeManagementMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CommitteeDesignationsConfigurationId",
                schema: "BEN",
                table: "CommitteeManagementMember",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagementMember_CommitteeDesignationsConfiguratio~",
                schema: "BEN",
                table: "CommitteeManagementMember",
                column: "CommitteeDesignationsConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeManagementMember_CommitteeDesignationsConfiguratio~",
                schema: "BEN",
                table: "CommitteeManagementMember",
                column: "CommitteeDesignationsConfigurationId",
                principalSchema: "BEN",
                principalTable: "CommitteeDesignationsConfiguration",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeManagementMember_CommitteeDesignationsConfiguratio~",
                schema: "BEN",
                table: "CommitteeManagementMember");

            migrationBuilder.DropIndex(
                name: "IX_CommitteeManagementMember_CommitteeDesignationsConfiguratio~",
                schema: "BEN",
                table: "CommitteeManagementMember");

            migrationBuilder.DropColumn(
                name: "CommitteeDesignationsConfigurationId",
                schema: "BEN",
                table: "CommitteeManagementMember");
        }
    }
}
