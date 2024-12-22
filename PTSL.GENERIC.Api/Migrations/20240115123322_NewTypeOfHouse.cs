using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NewTypeOfHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TypeOfHouseId",
                schema: "BEN",
                table: "Surveys",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TypeOfHouseNewId",
                schema: "BEN",
                table: "Cips",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeOfHouses",
                schema: "BEN",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameBn = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfHouses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_TypeOfHouseId",
                schema: "BEN",
                table: "Surveys",
                column: "TypeOfHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cips_TypeOfHouseNewId",
                schema: "BEN",
                table: "Cips",
                column: "TypeOfHouseNewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cips_TypeOfHouses_TypeOfHouseNewId",
                schema: "BEN",
                table: "Cips",
                column: "TypeOfHouseNewId",
                principalSchema: "BEN",
                principalTable: "TypeOfHouses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_TypeOfHouses_TypeOfHouseId",
                schema: "BEN",
                table: "Surveys",
                column: "TypeOfHouseId",
                principalSchema: "BEN",
                principalTable: "TypeOfHouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cips_TypeOfHouses_TypeOfHouseNewId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_TypeOfHouses_TypeOfHouseId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropTable(
                name: "TypeOfHouses",
                schema: "BEN");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_TypeOfHouseId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Cips_TypeOfHouseNewId",
                schema: "BEN",
                table: "Cips");

            migrationBuilder.DropColumn(
                name: "TypeOfHouseId",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "TypeOfHouseNewId",
                schema: "BEN",
                table: "Cips");
        }
    }
}
