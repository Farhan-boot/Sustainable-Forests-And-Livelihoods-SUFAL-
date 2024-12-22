using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSL.GENERIC.Api.Migrations
{
    /// <inheritdoc />
    public partial class NidBackImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BeneficiaryNIDURL",
                schema: "BEN",
                table: "Surveys",
                newName: "BeneficiaryNIDFrontURL");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryNIDBackURL",
                schema: "BEN",
                table: "Surveys",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiaryNIDBackURL",
                schema: "BEN",
                table: "Surveys");

            migrationBuilder.RenameColumn(
                name: "BeneficiaryNIDFrontURL",
                schema: "BEN",
                table: "Surveys",
                newName: "BeneficiaryNIDURL");
        }
    }
}
