using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommitteeManagementAddNewFildForNewLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_CommitteeDesignationsConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "CommitteeDesignationsConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_CommitteesConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "CommitteesConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeManagement_CommitteeTypeConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "CommitteeTypeConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeManagement_CommitteeDesignationsConfiguration_Comm~",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "CommitteeDesignationsConfigurationId",
                principalSchema: "BEN",
                principalTable: "CommitteeDesignationsConfiguration",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeManagement_CommitteeTypeConfiguration_CommitteeTyp~",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "CommitteeTypeConfigurationId",
                principalSchema: "BEN",
                principalTable: "CommitteeTypeConfiguration",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeManagement_CommitteesConfiguration_CommitteesConfi~",
                schema: "BEN",
                table: "CommitteeManagement",
                column: "CommitteesConfigurationId",
                principalSchema: "BEN",
                principalTable: "CommitteesConfiguration",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeManagement_CommitteeDesignationsConfiguration_Comm~",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeManagement_CommitteeTypeConfiguration_CommitteeTyp~",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeManagement_CommitteesConfiguration_CommitteesConfi~",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.DropIndex(
                name: "IX_CommitteeManagement_CommitteeDesignationsConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.DropIndex(
                name: "IX_CommitteeManagement_CommitteesConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement");

            migrationBuilder.DropIndex(
                name: "IX_CommitteeManagement_CommitteeTypeConfigurationId",
                schema: "BEN",
                table: "CommitteeManagement");
        }
    }
}
