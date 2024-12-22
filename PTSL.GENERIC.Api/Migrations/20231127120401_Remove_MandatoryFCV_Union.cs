using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class Remove_MandatoryFCV_Union : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.AlterColumn<long>(
                name: "UnionId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestFcvVcfId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabourDatabases_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Labour",
                table: "LabourDatabases");

            migrationBuilder.AlterColumn<long>(
                name: "UnionId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestFcvVcfId",
                schema: "Labour",
                table: "LabourDatabases",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LabourDatabases_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Labour",
                table: "LabourDatabases",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
