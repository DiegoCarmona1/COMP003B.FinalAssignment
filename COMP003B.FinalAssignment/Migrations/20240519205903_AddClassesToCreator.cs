using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.FinalAssignment.Migrations
{
    /// <inheritdoc />
    public partial class AddClassesToCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Holiday",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MealTime",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "Holiday",
                table: "Creators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MealTime",
                table: "Creators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "Creators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Holiday",
                table: "Creators");

            migrationBuilder.DropColumn(
                name: "MealTime",
                table: "Creators");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Creators");

            migrationBuilder.AddColumn<string>(
                name: "Holiday",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MealTime",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
