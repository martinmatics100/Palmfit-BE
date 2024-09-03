using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Palmfit.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class termsAndConditionColumnAddedForAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcceptsTerms",
                table: "AppUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptsTerms",
                table: "AppUsers");
        }
    }
}
