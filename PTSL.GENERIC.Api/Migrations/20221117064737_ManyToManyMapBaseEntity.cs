using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class ManyToManyMapBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DisabilityTypeHouseholdMembersMaps",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BFDAssociationHouseholdMembersMaps",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisabilityTypeHouseholdMembersMaps",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BFDAssociationHouseholdMembersMaps",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityTypeHouseholdMembersMaps_DisabilityTypeId",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                column: "DisabilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BFDAssociationHouseholdMembersMaps_BFDAssociationId",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                column: "BFDAssociationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DisabilityTypeHouseholdMembersMaps",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropIndex(
                name: "IX_DisabilityTypeHouseholdMembersMaps_DisabilityTypeId",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BFDAssociationHouseholdMembersMaps",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.DropIndex(
                name: "IX_BFDAssociationHouseholdMembersMaps_BFDAssociationId",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisabilityTypeHouseholdMembersMaps",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                columns: new[] { "DisabilityTypeId", "HouseholdMemberId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BFDAssociationHouseholdMembersMaps",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                columns: new[] { "BFDAssociationId", "HouseholdMemberId" });
        }
    }
}
