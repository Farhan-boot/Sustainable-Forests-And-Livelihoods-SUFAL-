using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreatePermissionSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PermissionSettings");

            migrationBuilder.CreateTable(
                name: "PermissionHeaderSettings",
                schema: "PermissionSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ForestCircleId = table.Column<long>(type: "bigint", nullable: false),
                    ForestDivisionId = table.Column<long>(type: "bigint", nullable: false),
                    ForestRangeId = table.Column<long>(type: "bigint", nullable: false),
                    ForestBeatId = table.Column<long>(type: "bigint", nullable: false),
                    ForestFcvVcfId = table.Column<long>(type: "bigint", nullable: false),
                    UserRoleId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleEnumId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionHeaderSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionHeaderSettings_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PermissionHeaderSettings_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PermissionHeaderSettings_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PermissionHeaderSettings_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PermissionHeaderSettings_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PermissionHeaderSettings_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalSchema: "System",
                        principalTable: "UserRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PermissionHeaderSettings_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PermissionRowSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    PermissionHeaderSettingsId = table.Column<long>(type: "bigint", nullable: false),
                    UserRoleId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRowSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionRowSettings_PermissionHeaderSettings_PermissionHe~",
                        column: x => x.PermissionHeaderSettingsId,
                        principalSchema: "PermissionSettings",
                        principalTable: "PermissionHeaderSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRowSettings_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalSchema: "System",
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRowSettings_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "System",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionHeaderSettings_ForestBeatId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionHeaderSettings_ForestCircleId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionHeaderSettings_ForestDivisionId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionHeaderSettings_ForestFcvVcfId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionHeaderSettings_ForestRangeId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionHeaderSettings_UserId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionHeaderSettings_UserRoleId",
                schema: "PermissionSettings",
                table: "PermissionHeaderSettings",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRowSettings_PermissionHeaderSettingsId",
                table: "PermissionRowSettings",
                column: "PermissionHeaderSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRowSettings_UserId",
                table: "PermissionRowSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRowSettings_UserRoleId",
                table: "PermissionRowSettings",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionRowSettings");

            migrationBuilder.DropTable(
                name: "PermissionHeaderSettings",
                schema: "PermissionSettings");
        }
    }
}
