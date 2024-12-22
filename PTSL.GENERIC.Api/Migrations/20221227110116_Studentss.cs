using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class Studentss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_District_DistrictId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_Division_DivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_ForestBeats_ForestBeatId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_ForestCircles_ForestCircleId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_ForestDivisions_ForestDivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_ForestRanges_ForestRangeId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_Upazilla_UpazillaId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.EnsureSchema(
                name: "Student");

            migrationBuilder.AlterColumn<long>(
                name: "UpazillaId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestRangeId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestFcvVcfId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestDivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestCircleId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ForestBeatId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DistrictId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "Student",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    Email = table.Column<string>(type: "varchar(500)", nullable: true),
                    RollNumber = table.Column<string>(type: "varchar(500)", nullable: true),
                    AccountNumber = table.Column<string>(type: "varchar(500)", nullable: true),
                    Batch = table.Column<long>(nullable: true),
                    Semester = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_District_DistrictId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_Division_DivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_ForestBeats_ForestBeatId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_ForestCircles_ForestCircleId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_ForestDivisions_ForestDivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_ForestRanges_ForestRangeId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_Upazilla_UpazillaId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_District_DistrictId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_Division_DivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_ForestBeats_ForestBeatId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_ForestCircles_ForestCircleId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_ForestDivisions_ForestDivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_ForestRanges_ForestRangeId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentalTrainings_Upazilla_UpazillaId",
                schema: "Capacity",
                table: "DepartmentalTrainings");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "Student");

            migrationBuilder.AlterColumn<long>(
                name: "UpazillaId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestRangeId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestFcvVcfId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestDivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestCircleId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ForestBeatId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DistrictId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_District_DistrictId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_Division_DivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_ForestBeats_ForestBeatId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestBeatId",
                principalSchema: "BEN",
                principalTable: "ForestBeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_ForestCircles_ForestCircleId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestCircleId",
                principalSchema: "BEN",
                principalTable: "ForestCircles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_ForestDivisions_ForestDivisionId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestDivisionId",
                principalSchema: "BEN",
                principalTable: "ForestDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_ForestFcvVcfs_ForestFcvVcfId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestFcvVcfId",
                principalSchema: "BEN",
                principalTable: "ForestFcvVcfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_ForestRanges_ForestRangeId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "ForestRangeId",
                principalSchema: "BEN",
                principalTable: "ForestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentalTrainings_Upazilla_UpazillaId",
                schema: "Capacity",
                table: "DepartmentalTrainings",
                column: "UpazillaId",
                principalSchema: "GS",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
