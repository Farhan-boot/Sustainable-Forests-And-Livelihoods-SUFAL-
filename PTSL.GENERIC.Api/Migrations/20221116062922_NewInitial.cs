using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class NewInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BEN");

            migrationBuilder.EnsureSchema(
                name: "System");

            migrationBuilder.EnsureSchema(
                name: "GS");

            migrationBuilder.CreateTable(
                name: "AssetTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BFDAssociations",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BFDAssociations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessIncomeSourceTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessIncomeSourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisabilityTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnergyTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ethnicitys",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethnicitys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenditureTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenditureTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForestCircles",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForestCircles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImmovableAssetTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmovableAssetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveStockTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveStockTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManualIncomeSourceTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualIncomeSourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaturalIncomeSourceTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalIncomeSourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ngos",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ngos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherIncomeSourceTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherIncomeSourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationWithHeadHouseHoldTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationWithHeadHouseHoldTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SafetyNets",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyNets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VulnerabilitySituationTypes",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VulnerabilitySituationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "GS",
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
                    CategoryName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                schema: "GS",
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
                    ColorName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                schema: "GS",
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
                    DivisionName = table.Column<string>(type: "varchar(100)", nullable: false),
                    DivisionNameBangla = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accesslist",
                schema: "System",
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
                    ControllerName = table.Column<string>(type: "varchar(100)", nullable: false),
                    ActionName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Mask = table.Column<string>(type: "varchar(100)", nullable: false),
                    AccessStatus = table.Column<byte>(type: "smallint", nullable: false),
                    IsVisible = table.Column<byte>(type: "smallint", nullable: false),
                    IconClass = table.Column<string>(type: "varchar(100)", nullable: false),
                    BaseModule = table.Column<int>(type: "int", nullable: false),
                    BaseModuleIndex = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesslist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessMapper",
                schema: "System",
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
                    AccessList = table.Column<string>(type: "varchar(500)", nullable: false),
                    RoleStatus = table.Column<byte>(type: "smallint", nullable: false),
                    IsVisible = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessMapper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                schema: "System",
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
                    ModuleName = table.Column<string>(type: "varchar(100)", nullable: false),
                    ModuleIcon = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsVisible = table.Column<byte>(nullable: false),
                    MenueOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PmsGroup",
                schema: "System",
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
                    GroupName = table.Column<string>(type: "varchar(40)", nullable: false),
                    GroupDescription = table.Column<string>(type: "varchar(250)", nullable: false),
                    GroupStatus = table.Column<byte>(type: "smallint", nullable: false),
                    IsVisible = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmsGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                schema: "System",
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
                    GroupName = table.Column<string>(type: "varchar(40)", nullable: false),
                    ModuleActionNames = table.Column<string>(type: "varchar(500)", nullable: false),
                    IsUsed = table.Column<byte>(type: "smallint", nullable: false),
                    IsDefault = table.Column<byte>(type: "smallint", nullable: false),
                    IsVisible = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "System",
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
                    RoleName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForestDivisions",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    ForestCircleId = table.Column<long>(nullable: false),
                    NgoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForestDivisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForestDivisions_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForestDivisions_Ngos_NgoId",
                        column: x => x.NgoId,
                        principalSchema: "BEN",
                        principalTable: "Ngos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District",
                schema: "GS",
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
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "System",
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
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    RoleName = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(100)", nullable: false),
                    UserEmail = table.Column<string>(type: "varchar(50)", nullable: false),
                    UserPassword = table.Column<string>(type: "varchar(100)", nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    UserPhone = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserGroup = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserStatus = table.Column<int>(type: "int", nullable: false),
                    PmsGroupID = table.Column<long>(nullable: false),
                    GroupID = table.Column<long>(type: "bigint", nullable: true),
                    UserRolesId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserGroup_GroupID",
                        column: x => x.GroupID,
                        principalSchema: "System",
                        principalTable: "UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_PmsGroup_PmsGroupID",
                        column: x => x.PmsGroupID,
                        principalSchema: "System",
                        principalTable: "PmsGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserRoles_UserRolesId",
                        column: x => x.UserRolesId,
                        principalSchema: "System",
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForestRanges",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    ForestDivisionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForestRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForestRanges_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upazilla",
                schema: "GS",
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
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    DistrictId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upazilla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upazilla_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForestBeats",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    ForestRangeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForestBeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForestBeats_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForestFcvVcfs",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    ForestBeatId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForestFcvVcfs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForestFcvVcfs_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    SurveyDate = table.Column<DateTime>(nullable: false),
                    Deviceid = table.Column<string>(type: "varchar(100)", nullable: true),
                    Subscriberid = table.Column<string>(type: "varchar(100)", nullable: true),
                    Simserial = table.Column<string>(type: "varchar(100)", nullable: true),
                    Phonenumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    DetailsInfo = table.Column<string>(type: "varchar(50)", nullable: true),
                    ForestCircleId = table.Column<long>(nullable: false),
                    ForestDivisionId = table.Column<long>(nullable: false),
                    ForestRangeId = table.Column<long>(nullable: false),
                    ForestBeatId = table.Column<long>(nullable: false),
                    ForestFcvVcfId = table.Column<long>(nullable: false),
                    ForestVillageName = table.Column<string>(type: "varchar(100)", nullable: true),
                    ForestVillageNameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    BeneficiaryId = table.Column<string>(type: "varchar(50)", nullable: false),
                    BeneficiaryHouseholdSerialNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    BeneficiaryName = table.Column<string>(type: "varchar(100)", nullable: true),
                    BeneficiaryNameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    BeneficiaryNid = table.Column<string>(type: "varchar(50)", nullable: false),
                    BeneficiaryPhone = table.Column<string>(type: "varchar(20)", nullable: true),
                    BeneficiaryPhoneBn = table.Column<string>(type: "varchar(20)", nullable: true),
                    BeneficiaryGender = table.Column<short>(type: "smallint", nullable: false),
                    BeneficiaryEthnicityId = table.Column<long>(nullable: true),
                    BeneficiaryEthnicityTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    BeneficiaryAge = table.Column<string>(type: "varchar(20)", nullable: true),
                    BeneficiaryAgeBn = table.Column<string>(type: "varchar(20)", nullable: true),
                    BeneficiaryFatherName = table.Column<string>(type: "varchar(100)", nullable: true),
                    BeneficiaryFatherNameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    BeneficiaryMotherName = table.Column<string>(type: "varchar(100)", nullable: true),
                    BeneficiaryMotherNameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    BeneficiarySpouseName = table.Column<string>(type: "varchar(100)", nullable: true),
                    BeneficiarySpouseNameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    HeadOfHouseholdName = table.Column<string>(type: "varchar(100)", nullable: true),
                    HeadOfHouseholdNameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    HeadOfHouseholdGender = table.Column<short>(type: "smallint", nullable: true),
                    PresentVillageName = table.Column<string>(type: "varchar(100)", nullable: true),
                    PresentVillageNameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    PresentPostOfficeName = table.Column<string>(type: "varchar(100)", nullable: true),
                    PresentPostOfficeNameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    PresentDivisionId = table.Column<long>(nullable: false),
                    PresentDistrictId = table.Column<long>(nullable: false),
                    PresentUpazillaId = table.Column<long>(nullable: false),
                    PresentUnion = table.Column<string>(type: "varchar(200)", nullable: true),
                    IsPermanentSameAsPresent = table.Column<bool>(nullable: false),
                    PermanentVillageName = table.Column<string>(type: "varchar(100)", nullable: true),
                    PermanentVillageNameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    PermanentPostOfficeName = table.Column<string>(type: "varchar(100)", nullable: true),
                    PermanentPostOfficeNameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    PermanentDivisionId = table.Column<long>(nullable: true),
                    PermanentDistrictId = table.Column<long>(nullable: true),
                    PermanentUpazillaId = table.Column<long>(nullable: true),
                    PermanentUnion = table.Column<string>(type: "varchar(100)", nullable: true),
                    PermanentUnionBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    BeneficiaryLatitude = table.Column<double>(nullable: true),
                    BeneficiaryLongitude = table.Column<double>(nullable: true),
                    BeneficiaryAltitude = table.Column<double>(nullable: true),
                    BeneficiaryPrecision = table.Column<double>(nullable: true),
                    BeneficiaryHouseFrontImage = table.Column<string>(type: "varchar(100)", nullable: true),
                    BeneficiaryHouseFrontImageURL = table.Column<string>(type: "varchar(500)", nullable: true),
                    GrandTotalLandOccupancy = table.Column<double>(nullable: false),
                    BeneficiaryHouseType = table.Column<int>(nullable: false),
                    GrandTotalLivestockCost = table.Column<double>(nullable: false),
                    GrandTotalAssetsCost = table.Column<double>(nullable: false),
                    GrandTotalImmovableAnnualReturn = table.Column<double>(nullable: false),
                    GrandTotalEnergyUsesMonthly = table.Column<double>(nullable: false),
                    IsProblemToAccessHealthService = table.Column<bool>(nullable: false),
                    NearestHealthServiceLocation = table.Column<string>(type: "varchar(100)", nullable: true),
                    NearestHealthServiceDistance = table.Column<double>(nullable: false),
                    IsProblemToAccessDrinkingWater = table.Column<bool>(nullable: false),
                    NearestDrinkingWaterDistance = table.Column<double>(nullable: false),
                    SourceofDrySeasonWaterEnumList = table.Column<string>(type: "varchar(50)", nullable: true),
                    SourceofDrySeasonWaterTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    SourceofWetSeasonWaterEnumList = table.Column<string>(type: "varchar(50)", nullable: true),
                    SourceofWetSeasonWaterTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    NearestGrowthCenter = table.Column<string>(type: "varchar(100)", nullable: true),
                    NearestGrowthCenterDistance = table.Column<double>(nullable: false),
                    IsProblemToAccessEducation = table.Column<bool>(nullable: false),
                    HasEducationalInstituteNearby = table.Column<bool>(nullable: false),
                    EducationalInstituteDistance = table.Column<double>(nullable: false),
                    EducationalInstituteAccessibilityEnum = table.Column<short>(type: "smallint", nullable: false),
                    SanitationFacilitiesEnum = table.Column<short>(type: "smallint", nullable: false),
                    PotentialSkillName1 = table.Column<string>(type: "varchar(100)", nullable: true),
                    PotentialSkillName2 = table.Column<string>(type: "varchar(100)", nullable: true),
                    PotentialSkillName3 = table.Column<string>(type: "varchar(100)", nullable: true),
                    PotentialSpecialSkill = table.Column<string>(type: "varchar(100)", nullable: true),
                    PotentialSkillsRemarks = table.Column<string>(type: "varchar(100)", nullable: true),
                    ForestMngmtSatisfactionEnum = table.Column<short>(type: "smallint", nullable: false),
                    ForestMngmtEffectivenessEnum = table.Column<short>(type: "smallint", nullable: false),
                    ForestDependencyEnum = table.Column<short>(type: "smallint", nullable: false),
                    IsHearedAboutCfm = table.Column<bool>(nullable: false),
                    IsParticipatedInCfm = table.Column<bool>(nullable: false),
                    WillCfmImproveForestMngmnt = table.Column<bool>(nullable: false),
                    WillCfmImproveWellBeing = table.Column<bool>(nullable: false),
                    DicisionTakerEnum = table.Column<short>(type: "smallint", nullable: false),
                    ProductiveAssetsOwnerGender = table.Column<short>(type: "smallint", nullable: false),
                    CropTypeDecisionGender = table.Column<short>(type: "smallint", nullable: false),
                    DecisionToTransferAssetsGender = table.Column<short>(type: "smallint", nullable: false),
                    FamilyNeedsDeciderGender = table.Column<short>(type: "smallint", nullable: false),
                    AccessorToCreditGender = table.Column<short>(type: "smallint", nullable: false),
                    ControllerOfCreditGender = table.Column<short>(type: "smallint", nullable: false),
                    OfficeBearerGender = table.Column<short>(type: "smallint", nullable: false),
                    MorePaymentGetterGender = table.Column<short>(type: "smallint", nullable: false),
                    CanAccessLegalSupportForGbv = table.Column<bool>(nullable: true),
                    CanUnsufructsRights = table.Column<bool>(nullable: true),
                    FaceLiveAndLivelihoodChallanges = table.Column<bool>(nullable: true),
                    HasLlfmInterest = table.Column<bool>(nullable: true),
                    GrandTotalNetIncomeAgriculture = table.Column<double>(nullable: false),
                    GrandTotalLandArea = table.Column<double>(nullable: false),
                    GrandTotalGrossMarginAgriculture = table.Column<double>(nullable: false),
                    GrandTotalAnnualPhysicalIncome = table.Column<double>(nullable: false),
                    GrandTotalWildResourceIncome = table.Column<double>(nullable: false),
                    GrandTotalOtherIncome = table.Column<double>(nullable: false),
                    GrandTotalBusinessIncome = table.Column<double>(nullable: false),
                    NoOfMaleInsideCountry = table.Column<int>(nullable: false),
                    SentIncomeOfMaleInYearInsideCountry = table.Column<double>(nullable: false),
                    NoOfFemaleInsideCountry = table.Column<int>(nullable: false),
                    SentIncomeOfFemaleInYearInsideCountry = table.Column<double>(nullable: false),
                    NoOfMaleOutsideCountry = table.Column<int>(nullable: false),
                    SentIncomeOfMaleInYearOutsideCountry = table.Column<double>(nullable: false),
                    NoOfFemaleOutsideCountry = table.Column<int>(nullable: false),
                    SentIncomeOfFemaleInYearOutsideCountry = table.Column<double>(nullable: false),
                    PersonalSavingsOfAllMembers = table.Column<double>(nullable: false),
                    HouseShareInSavings = table.Column<double>(nullable: false),
                    BorrowedFromBank = table.Column<double>(nullable: false),
                    BorrowedFromNGO = table.Column<double>(nullable: false),
                    GrantsFromNGO = table.Column<double>(nullable: false),
                    GrantsFromGob = table.Column<double>(nullable: false),
                    BorrowedFromCoOperatives = table.Column<double>(nullable: false),
                    BorrowedFromNonRelatives = table.Column<double>(nullable: false),
                    BorrowedFromRelatives = table.Column<double>(nullable: false),
                    SaleOfProducts = table.Column<double>(nullable: false),
                    OtherFinanceName = table.Column<string>(type: "varchar(100)", nullable: true),
                    OtherFinanceAmount = table.Column<double>(nullable: false),
                    GrandTotalHouseholdExpenditure = table.Column<double>(nullable: false),
                    HouseholdFoodCondition = table.Column<short>(type: "smallint", nullable: true),
                    FoodCrisisMonth = table.Column<DateTime>(nullable: true),
                    FoodyPersonInFoodCrisis = table.Column<short>(type: "smallint", nullable: true),
                    NotesImage = table.Column<string>(type: "varchar(100)", nullable: true),
                    NotesImageUrl = table.Column<string>(type: "varchar(500)", nullable: true),
                    NameOfTheEnumerator = table.Column<string>(type: "varchar(100)", nullable: true),
                    CellPhoneNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    DataCollectionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Ethnicitys_BeneficiaryEthnicityId",
                        column: x => x.BeneficiaryEthnicityId,
                        principalSchema: "BEN",
                        principalTable: "Ethnicitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Surveys_ForestBeats_ForestBeatId",
                        column: x => x.ForestBeatId,
                        principalSchema: "BEN",
                        principalTable: "ForestBeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveys_ForestCircles_ForestCircleId",
                        column: x => x.ForestCircleId,
                        principalSchema: "BEN",
                        principalTable: "ForestCircles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveys_ForestDivisions_ForestDivisionId",
                        column: x => x.ForestDivisionId,
                        principalSchema: "BEN",
                        principalTable: "ForestDivisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveys_ForestFcvVcfs_ForestFcvVcfId",
                        column: x => x.ForestFcvVcfId,
                        principalSchema: "BEN",
                        principalTable: "ForestFcvVcfs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveys_ForestRanges_ForestRangeId",
                        column: x => x.ForestRangeId,
                        principalSchema: "BEN",
                        principalTable: "ForestRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveys_District_PermanentDistrictId",
                        column: x => x.PermanentDistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveys_Division_PermanentDivisionId",
                        column: x => x.PermanentDivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveys_Upazilla_PermanentUpazillaId",
                        column: x => x.PermanentUpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveys_District_PresentDistrictId",
                        column: x => x.PresentDistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveys_Division_PresentDivisionId",
                        column: x => x.PresentDivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveys_Upazilla_PresentUpazillaId",
                        column: x => x.PresentUpazillaId,
                        principalSchema: "GS",
                        principalTable: "Upazilla",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnnualHouseholdExpenditures",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    ExpenditureTypeId = table.Column<long>(nullable: true),
                    ExpenditureTypeTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    ExpenditureCost = table.Column<double>(nullable: false),
                    ExpenditureRemarks = table.Column<string>(type: "varchar(200)", nullable: true),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualHouseholdExpenditures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualHouseholdExpenditures_ExpenditureTypes_ExpenditureTyp~",
                        column: x => x.ExpenditureTypeId,
                        principalSchema: "BEN",
                        principalTable: "ExpenditureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnualHouseholdExpenditures_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    AssetTypeId = table.Column<long>(nullable: false),
                    AssetTypeTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    AssetQuantity = table.Column<double>(nullable: false),
                    AssetsCost = table.Column<double>(nullable: false),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTypes_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalSchema: "BEN",
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Businesss",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    BusinessIncomeSourceTypeId = table.Column<long>(nullable: true),
                    BusinessIncomeSourceTypeTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    BusinessGrossValueOfSales = table.Column<double>(nullable: false),
                    BusinessTotalCashCosts = table.Column<double>(nullable: false),
                    TotalNetIncome = table.Column<double>(nullable: false),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesss_BusinessIncomeSourceTypes_BusinessIncomeSourceTyp~",
                        column: x => x.BusinessIncomeSourceTypeId,
                        principalSchema: "BEN",
                        principalTable: "BusinessIncomeSourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Businesss_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnergyUses",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    EnergyTypeId = table.Column<long>(nullable: false),
                    EnergyUseTypeTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    EnergyUsesMonthly = table.Column<double>(nullable: false),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyUses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyUses_EnergyTypes_EnergyTypeId",
                        column: x => x.EnergyTypeId,
                        principalSchema: "BEN",
                        principalTable: "EnergyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnergyUses_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExistingSkills",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    SkillName = table.Column<string>(type: "varchar(100)", nullable: true),
                    SkillLevelEnum = table.Column<short>(type: "smallint", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(200)", nullable: true),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExistingSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExistingSkills_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodSecurityItems",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    FoodItemId = table.Column<long>(nullable: false),
                    FoodItemTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    FoodAvilableMonthInYear = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(type: "varchar(100)", nullable: true),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodSecurityItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodSecurityItems_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalSchema: "BEN",
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodSecurityItems_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrossMarginIncomeAndCostStatuses",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    ProductName = table.Column<string>(type: "varchar(100)", nullable: true),
                    LandArea = table.Column<double>(nullable: false),
                    MeasurementOfProduct = table.Column<string>(type: "varchar(100)", nullable: true),
                    TotalProductionHousehold = table.Column<double>(nullable: false),
                    TotalCostOfProduction = table.Column<double>(nullable: false),
                    TotalConsumption = table.Column<double>(nullable: false),
                    QuantitySold = table.Column<double>(nullable: false),
                    TotalValueSold = table.Column<double>(nullable: false),
                    ValueSoldPerQuantity = table.Column<double>(nullable: false),
                    ProductionValueSoldPerQuantity = table.Column<double>(nullable: false),
                    TotalNetIncome = table.Column<double>(nullable: false),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrossMarginIncomeAndCostStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrossMarginIncomeAndCostStatuses_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdMembers",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    FullName = table.Column<string>(type: "varchar(100)", nullable: true),
                    FullNameBn = table.Column<string>(type: "varchar(100)", nullable: true),
                    RelationWithHeadHouseHoldTypeId = table.Column<long>(nullable: false),
                    RelationWithHeadHouseHoldTypeTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    Gender = table.Column<short>(type: "smallint", nullable: false),
                    Age = table.Column<string>(type: "varchar(20)", nullable: true),
                    AgeBn = table.Column<string>(type: "varchar(20)", nullable: true),
                    MaritalSatus = table.Column<short>(type: "smallint", nullable: false),
                    MaritalSatusTxt = table.Column<string>(type: "varchar(50)", nullable: true),
                    EducationLevel = table.Column<short>(type: "smallint", nullable: false),
                    MainOccupationId = table.Column<long>(nullable: false),
                    MainOccupationTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    SecondaryOccupationId = table.Column<long>(nullable: false),
                    SecondOccupationTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    BFDAssociationTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    HasDisability = table.Column<bool>(nullable: false),
                    SafetyNetTypeId = table.Column<long>(nullable: false),
                    SafetyNetTypeTxt = table.Column<string>(nullable: true),
                    SubmissionTime = table.Column<DateTime>(nullable: false),
                    SubmittedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    Notes = table.Column<string>(type: "varchar(100)", nullable: true),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseholdMembers_Occupations_MainOccupationId",
                        column: x => x.MainOccupationId,
                        principalSchema: "BEN",
                        principalTable: "Occupations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HouseholdMembers_RelationWithHeadHouseHoldTypes_RelationWit~",
                        column: x => x.RelationWithHeadHouseHoldTypeId,
                        principalSchema: "BEN",
                        principalTable: "RelationWithHeadHouseHoldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseholdMembers_SafetyNets_SafetyNetTypeId",
                        column: x => x.SafetyNetTypeId,
                        principalSchema: "BEN",
                        principalTable: "SafetyNets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseholdMembers_Occupations_SecondaryOccupationId",
                        column: x => x.SecondaryOccupationId,
                        principalSchema: "BEN",
                        principalTable: "Occupations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HouseholdMembers_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImmovableAssets",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    ImmovableAssetTypeId = table.Column<long>(nullable: false),
                    ImmovableAssetsTypeTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    ImmovableAnnualReturn = table.Column<double>(nullable: false),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmovableAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmovableAssets_ImmovableAssetTypes_ImmovableAssetTypeId",
                        column: x => x.ImmovableAssetTypeId,
                        principalSchema: "BEN",
                        principalTable: "ImmovableAssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImmovableAssets_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandOccupancies",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    LandClassificationEnum = table.Column<short>(type: "smallint", nullable: false),
                    LandClassificationTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    Homesteads = table.Column<double>(nullable: false),
                    ProductiveLand = table.Column<double>(nullable: false),
                    FallowLand = table.Column<double>(nullable: false),
                    ProductiveWetland = table.Column<double>(nullable: false),
                    FallowWetland = table.Column<double>(nullable: false),
                    OthersLand = table.Column<double>(nullable: false),
                    TotalLand = table.Column<double>(nullable: false),
                    SubmissionTime = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(type: "varchar(100)", nullable: true),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandOccupancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandOccupancies_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiveStocks",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    LiveStockTypeId = table.Column<long>(nullable: false),
                    LivestockTypeTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    LiveStockQuantity = table.Column<double>(nullable: false),
                    LivestockCost = table.Column<double>(nullable: false),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiveStocks_LiveStockTypes_LiveStockTypeId",
                        column: x => x.LiveStockTypeId,
                        principalSchema: "BEN",
                        principalTable: "LiveStockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiveStocks_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManualPhysicalWorks",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    ManualIncomeSourceTypeId = table.Column<long>(nullable: true),
                    ManualIncomeSourceTypeTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    NoOfMale = table.Column<int>(nullable: false),
                    NoOfFemale = table.Column<int>(nullable: false),
                    NoOfActiveMonth = table.Column<int>(nullable: false),
                    AvgNoPersonActivePerMonth = table.Column<int>(nullable: false),
                    AvgDailyIncome = table.Column<double>(nullable: false),
                    TotalPerson = table.Column<double>(nullable: false),
                    TotalAnnualIncome = table.Column<double>(nullable: false),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualPhysicalWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualPhysicalWorks_ManualIncomeSourceTypes_ManualIncomeSou~",
                        column: x => x.ManualIncomeSourceTypeId,
                        principalSchema: "BEN",
                        principalTable: "ManualIncomeSourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManualPhysicalWorks_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NaturalResourcesIncomeAndCostStatuses",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    NaturalIncomeSourceTypeId = table.Column<long>(nullable: true),
                    NoOfMale = table.Column<int>(nullable: false),
                    NoOfFemale = table.Column<int>(nullable: false),
                    NoOfActiveMonth = table.Column<int>(nullable: false),
                    AvgNoPersonActivePerMonth = table.Column<double>(nullable: false),
                    TotalManDaysForCollection = table.Column<double>(nullable: false),
                    Unit = table.Column<string>(type: "varchar(80)", nullable: true),
                    TotalProduced = table.Column<double>(nullable: false),
                    TotalConsumption = table.Column<double>(nullable: false),
                    QuantitySold = table.Column<double>(nullable: false),
                    ValueProduceSold = table.Column<double>(nullable: false),
                    CostOfActivity = table.Column<double>(nullable: false),
                    ValueSoldPerActivity = table.Column<double>(nullable: false),
                    ProducedValueSoldActivity = table.Column<double>(nullable: false),
                    ActivityPerValueSold = table.Column<double>(nullable: false),
                    TotalNetIncome = table.Column<double>(nullable: false),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalResourcesIncomeAndCostStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaturalResourcesIncomeAndCostStatuses_NaturalIncomeSourceTy~",
                        column: x => x.NaturalIncomeSourceTypeId,
                        principalSchema: "BEN",
                        principalTable: "NaturalIncomeSourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NaturalResourcesIncomeAndCostStatuses_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherIncomeSources",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    OtherIncomeSourceTypeId = table.Column<long>(nullable: true),
                    OtherIncomeSourceTypeTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    GrossValueOfSales = table.Column<double>(nullable: false),
                    TotalCashCosts = table.Column<double>(nullable: false),
                    TotalNetIncome = table.Column<double>(nullable: false),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherIncomeSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherIncomeSources_OtherIncomeSourceTypes_OtherIncomeSource~",
                        column: x => x.OtherIncomeSourceTypeId,
                        principalSchema: "BEN",
                        principalTable: "OtherIncomeSourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OtherIncomeSources_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VulnerabilitySituations",
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
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    VulnerabilitySituationTypeId = table.Column<long>(nullable: true),
                    VulnerabilitySituationTypeTxt = table.Column<string>(type: "varchar(100)", nullable: true),
                    EventName = table.Column<string>(type: "varchar(100)", nullable: true),
                    MonetaryLoss = table.Column<double>(nullable: true),
                    HowDidRecover = table.Column<string>(type: "varchar(200)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(200)", nullable: true),
                    SurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VulnerabilitySituations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VulnerabilitySituations_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "BEN",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VulnerabilitySituations_VulnerabilitySituationTypes_Vulnera~",
                        column: x => x.VulnerabilitySituationTypeId,
                        principalSchema: "BEN",
                        principalTable: "VulnerabilitySituationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BFDAssociationHouseholdMembersMaps",
                schema: "BEN",
                columns: table => new
                {
                    BFDAssociationId = table.Column<long>(nullable: false),
                    HouseholdMemberId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BFDAssociationHouseholdMembersMaps", x => new { x.BFDAssociationId, x.HouseholdMemberId });
                    table.ForeignKey(
                        name: "FK_BFDAssociationHouseholdMembersMaps_BFDAssociations_BFDAssoc~",
                        column: x => x.BFDAssociationId,
                        principalSchema: "BEN",
                        principalTable: "BFDAssociations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BFDAssociationHouseholdMembersMaps_HouseholdMembers_Househo~",
                        column: x => x.HouseholdMemberId,
                        principalSchema: "BEN",
                        principalTable: "HouseholdMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisabilityTypeHouseholdMembersMaps",
                schema: "BEN",
                columns: table => new
                {
                    DisabilityTypeId = table.Column<long>(nullable: false),
                    HouseholdMemberId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilityTypeHouseholdMembersMaps", x => new { x.DisabilityTypeId, x.HouseholdMemberId });
                    table.ForeignKey(
                        name: "FK_DisabilityTypeHouseholdMembersMaps_DisabilityTypes_Disabili~",
                        column: x => x.DisabilityTypeId,
                        principalSchema: "BEN",
                        principalTable: "DisabilityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisabilityTypeHouseholdMembersMaps_HouseholdMembers_Househo~",
                        column: x => x.HouseholdMemberId,
                        principalSchema: "BEN",
                        principalTable: "HouseholdMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnualHouseholdExpenditures_ExpenditureTypeId",
                schema: "BEN",
                table: "AnnualHouseholdExpenditures",
                column: "ExpenditureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualHouseholdExpenditures_SurveyId",
                schema: "BEN",
                table: "AnnualHouseholdExpenditures",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetTypeId",
                schema: "BEN",
                table: "Assets",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SurveyId",
                schema: "BEN",
                table: "Assets",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_BFDAssociationHouseholdMembersMaps_HouseholdMemberId",
                schema: "BEN",
                table: "BFDAssociationHouseholdMembersMaps",
                column: "HouseholdMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesss_BusinessIncomeSourceTypeId",
                schema: "BEN",
                table: "Businesss",
                column: "BusinessIncomeSourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesss_SurveyId",
                schema: "BEN",
                table: "Businesss",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityTypeHouseholdMembersMaps_HouseholdMemberId",
                schema: "BEN",
                table: "DisabilityTypeHouseholdMembersMaps",
                column: "HouseholdMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyUses_EnergyTypeId",
                schema: "BEN",
                table: "EnergyUses",
                column: "EnergyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyUses_SurveyId",
                schema: "BEN",
                table: "EnergyUses",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistingSkills_SurveyId",
                schema: "BEN",
                table: "ExistingSkills",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSecurityItems_FoodItemId",
                schema: "BEN",
                table: "FoodSecurityItems",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSecurityItems_SurveyId",
                schema: "BEN",
                table: "FoodSecurityItems",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ForestBeats_ForestRangeId",
                schema: "BEN",
                table: "ForestBeats",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ForestDivisions_ForestCircleId",
                schema: "BEN",
                table: "ForestDivisions",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_ForestDivisions_NgoId",
                schema: "BEN",
                table: "ForestDivisions",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_ForestFcvVcfs_ForestBeatId",
                schema: "BEN",
                table: "ForestFcvVcfs",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_ForestRanges_ForestDivisionId",
                schema: "BEN",
                table: "ForestRanges",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_GrossMarginIncomeAndCostStatuses_SurveyId",
                schema: "BEN",
                table: "GrossMarginIncomeAndCostStatuses",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdMembers_MainOccupationId",
                schema: "BEN",
                table: "HouseholdMembers",
                column: "MainOccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdMembers_RelationWithHeadHouseHoldTypeId",
                schema: "BEN",
                table: "HouseholdMembers",
                column: "RelationWithHeadHouseHoldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdMembers_SafetyNetTypeId",
                schema: "BEN",
                table: "HouseholdMembers",
                column: "SafetyNetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdMembers_SecondaryOccupationId",
                schema: "BEN",
                table: "HouseholdMembers",
                column: "SecondaryOccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdMembers_SurveyId",
                schema: "BEN",
                table: "HouseholdMembers",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmovableAssets_ImmovableAssetTypeId",
                schema: "BEN",
                table: "ImmovableAssets",
                column: "ImmovableAssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmovableAssets_SurveyId",
                schema: "BEN",
                table: "ImmovableAssets",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_LandOccupancies_SurveyId",
                schema: "BEN",
                table: "LandOccupancies",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveStocks_LiveStockTypeId",
                schema: "BEN",
                table: "LiveStocks",
                column: "LiveStockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveStocks_SurveyId",
                schema: "BEN",
                table: "LiveStocks",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualPhysicalWorks_ManualIncomeSourceTypeId",
                schema: "BEN",
                table: "ManualPhysicalWorks",
                column: "ManualIncomeSourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualPhysicalWorks_SurveyId",
                schema: "BEN",
                table: "ManualPhysicalWorks",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalResourcesIncomeAndCostStatuses_NaturalIncomeSourceTy~",
                schema: "BEN",
                table: "NaturalResourcesIncomeAndCostStatuses",
                column: "NaturalIncomeSourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalResourcesIncomeAndCostStatuses_SurveyId",
                schema: "BEN",
                table: "NaturalResourcesIncomeAndCostStatuses",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncomeSources_OtherIncomeSourceTypeId",
                schema: "BEN",
                table: "OtherIncomeSources",
                column: "OtherIncomeSourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncomeSources_SurveyId",
                schema: "BEN",
                table: "OtherIncomeSources",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_BeneficiaryEthnicityId",
                schema: "BEN",
                table: "Surveys",
                column: "BeneficiaryEthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_ForestBeatId",
                schema: "BEN",
                table: "Surveys",
                column: "ForestBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_ForestCircleId",
                schema: "BEN",
                table: "Surveys",
                column: "ForestCircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_ForestDivisionId",
                schema: "BEN",
                table: "Surveys",
                column: "ForestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_ForestFcvVcfId",
                schema: "BEN",
                table: "Surveys",
                column: "ForestFcvVcfId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_ForestRangeId",
                schema: "BEN",
                table: "Surveys",
                column: "ForestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PermanentDistrictId",
                schema: "BEN",
                table: "Surveys",
                column: "PermanentDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PermanentDivisionId",
                schema: "BEN",
                table: "Surveys",
                column: "PermanentDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PermanentUpazillaId",
                schema: "BEN",
                table: "Surveys",
                column: "PermanentUpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PresentDistrictId",
                schema: "BEN",
                table: "Surveys",
                column: "PresentDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PresentDivisionId",
                schema: "BEN",
                table: "Surveys",
                column: "PresentDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PresentUpazillaId",
                schema: "BEN",
                table: "Surveys",
                column: "PresentUpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_VulnerabilitySituations_SurveyId",
                schema: "BEN",
                table: "VulnerabilitySituations",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_VulnerabilitySituations_VulnerabilitySituationTypeId",
                schema: "BEN",
                table: "VulnerabilitySituations",
                column: "VulnerabilitySituationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_District_DivisionId",
                schema: "GS",
                table: "District",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Upazilla_DistrictId",
                schema: "GS",
                table: "Upazilla",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupID",
                schema: "System",
                table: "User",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_User_PmsGroupID",
                schema: "System",
                table: "User",
                column: "PmsGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRolesId",
                schema: "System",
                table: "User",
                column: "UserRolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnualHouseholdExpenditures",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "Assets",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "BFDAssociationHouseholdMembersMaps",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "Businesss",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "DisabilityTypeHouseholdMembersMaps",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "EnergyUses",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "ExistingSkills",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "FoodSecurityItems",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "GrossMarginIncomeAndCostStatuses",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "ImmovableAssets",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "LandOccupancies",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "LiveStocks",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "ManualPhysicalWorks",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "NaturalResourcesIncomeAndCostStatuses",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "OtherIncomeSources",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "VulnerabilitySituations",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Color",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Accesslist",
                schema: "System");

            migrationBuilder.DropTable(
                name: "AccessMapper",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "System");

            migrationBuilder.DropTable(
                name: "User",
                schema: "System");

            migrationBuilder.DropTable(
                name: "ExpenditureTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "AssetTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "BFDAssociations",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "BusinessIncomeSourceTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "DisabilityTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "HouseholdMembers",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "EnergyTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "FoodItems",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "ImmovableAssetTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "LiveStockTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "ManualIncomeSourceTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "NaturalIncomeSourceTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "OtherIncomeSourceTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "VulnerabilitySituationTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "UserGroup",
                schema: "System");

            migrationBuilder.DropTable(
                name: "PmsGroup",
                schema: "System");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Occupations",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "RelationWithHeadHouseHoldTypes",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "SafetyNets",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "Surveys",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "Ethnicitys",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "ForestFcvVcfs",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "Upazilla",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "ForestBeats",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "District",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "ForestRanges",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "Division",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "ForestDivisions",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "ForestCircles",
                schema: "BEN");

            migrationBuilder.DropTable(
                name: "Ngos",
                schema: "BEN");
        }
    }
}
