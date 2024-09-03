using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Palmfit.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class HeightAndWeightUnitColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeightUnit",
                table: "AppUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeightUnit",
                table: "AppUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeightUnit",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "WeightUnit",
                table: "AppUsers");
        }
    }
}
