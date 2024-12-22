using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class ArchiveModuleCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Archive");

            migrationBuilder.CreateTable(
                name: "RegistrationArchive",
                schema: "Archive",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: true),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: true),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: true),
                    ForestFcvVcfId = table.Column<long>(type: "bigint", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    UpazillaId = table.Column<long>(type: "bigint", nullable: true),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    ArchiveName = table.Column<string>(type: "varchar(500)", nullable: true),
                    DocumentDescription = table.Column<string>(type: "varchar(500)", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationArchive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationArchive_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationArchive_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationArchive_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationArchive_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationArchive_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationArchive_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationArchive_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationArchive_Union_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "GS",
                        principalTable: "Union",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationArchive_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegistrationArchiveFile",
                schema: "Archive",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RegistrationArchiveId = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "varchar(500)", nullable: true),
                    DocumentUrl = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationArchiveFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationArchiveFile_RegistrationArchive_RegistrationArc~",
                        column: x => x.RegistrationArchiveId,
                        principalSchema: "Archive",
                        principalTable: "RegistrationArchive",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchive_DistrictId",
                schema: "Archive",
                table: "RegistrationArchive",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchive_DivisionId",
                schema: "Archive",
                table: "RegistrationArchive",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchive_ForestBeatId",
                schema: "Archive",
                table: "RegistrationArchive",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchive_ForestCircleId",
                schema: "Archive",
                table: "RegistrationArchive",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchive_ForestDivisionId",
                schema: "Archive",
                table: "RegistrationArchive",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchive_ForestFcvVcfId",
                schema: "Archive",
                table: "RegistrationArchive",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchive_ForestRangeId",
                schema: "Archive",
                table: "RegistrationArchive",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchive_UnionId",
                schema: "Archive",
                table: "RegistrationArchive",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchive_UpazillaId",
                schema: "Archive",
                table: "RegistrationArchive",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchiveFile_RegistrationArchiveId",
                schema: "Archive",
                table: "RegistrationArchiveFile",
                column: "RegistrationArchiveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationArchiveFile",
                schema: "Archive");

            migrationBuilder.DropTable(
                name: "RegistrationArchive",
                schema: "Archive");
        }
    }
}
