using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class distributionTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "BeneficiaryNid",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "DistributedTo",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "DistributionDate",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "NumberofSeedlingTobeDistributed",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.DropColumn(
                name: "SpeciesName",
                schema: "SocialForestry",
                table: "NurseryDistributions");

            migrationBuilder.CreateTable(
                name: "NurseryDistributionDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    NurseryDistributionId = table.Column<long>(type: "bigint", nullable: false),
                    SpeciesName = table.Column<string>(type: "text", nullable: true),
                    DistributionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NumberofSeedlingTobeDistributed = table.Column<long>(type: "bigint", nullable: true),
                    DistributedTo = table.Column<string>(type: "text", nullable: false),
                    BeneficiaryNid = table.Column<string>(type: "text", nullable: false),
                    MobileNo = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseryDistributionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseryDistributionDetails_NurseryDistributions_NurseryDist~",
                        column: x => x.NurseryDistributionId,
                        principalSchema: "SocialForestry",
                        principalTable: "NurseryDistributions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NurseryDistributionDetails_NurseryDistributionId",
                table: "NurseryDistributionDetails",
                column: "NurseryDistributionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NurseryDistributionDetails");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryNid",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DistributedTo",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DistributionDate",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "NumberofSeedlingTobeDistributed",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpeciesName",
                schema: "SocialForestry",
                table: "NurseryDistributions",
                type: "text",
                nullable: true);
        }
    }
}
