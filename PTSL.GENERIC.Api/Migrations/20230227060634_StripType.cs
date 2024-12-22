using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class StripType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StripType",
                schema: "Plantation",
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
                    TypeOfPlantationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripType_TypeOfPlantation_TypeOfPlantationId",
                        column: x => x.TypeOfPlantationId,
                        principalSchema: "Plantation",
                        principalTable: "TypeOfPlantation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StripType_TypeOfPlantationId",
                schema: "Plantation",
                table: "StripType",
                column: "TypeOfPlantationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StripType",
                schema: "Plantation");
        }
    }
}
