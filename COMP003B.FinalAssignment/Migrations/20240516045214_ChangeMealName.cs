using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.FinalAssignment.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMealName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    CreatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.CreatorId);
                });

            migrationBuilder.CreateTable(
                name: "Dailys",
                columns: table => new
                {
                    DailyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dailys", x => x.DailyId);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    HolidayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.HolidayId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "Seasonals",
                columns: table => new
                {
                    SeasonalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasonals", x => x.SeasonalId);
                });

            migrationBuilder.CreateTable(
                name: "CreatorDaily",
                columns: table => new
                {
                    CreatorsCreatorId = table.Column<int>(type: "int", nullable: false),
                    DailyMealsDailyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatorDaily", x => new { x.CreatorsCreatorId, x.DailyMealsDailyId });
                    table.ForeignKey(
                        name: "FK_CreatorDaily_Creators_CreatorsCreatorId",
                        column: x => x.CreatorsCreatorId,
                        principalTable: "Creators",
                        principalColumn: "CreatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatorDaily_Dailys_DailyMealsDailyId",
                        column: x => x.DailyMealsDailyId,
                        principalTable: "Dailys",
                        principalColumn: "DailyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatorHoliday",
                columns: table => new
                {
                    CreatorsCreatorId = table.Column<int>(type: "int", nullable: false),
                    HolidayMealsHolidayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatorHoliday", x => new { x.CreatorsCreatorId, x.HolidayMealsHolidayId });
                    table.ForeignKey(
                        name: "FK_CreatorHoliday_Creators_CreatorsCreatorId",
                        column: x => x.CreatorsCreatorId,
                        principalTable: "Creators",
                        principalColumn: "CreatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatorHoliday_Holidays_HolidayMealsHolidayId",
                        column: x => x.HolidayMealsHolidayId,
                        principalTable: "Holidays",
                        principalColumn: "HolidayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyRecipe",
                columns: table => new
                {
                    DailyMealsDailyId = table.Column<int>(type: "int", nullable: false),
                    RecipesRecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyRecipe", x => new { x.DailyMealsDailyId, x.RecipesRecipeId });
                    table.ForeignKey(
                        name: "FK_DailyRecipe_Dailys_DailyMealsDailyId",
                        column: x => x.DailyMealsDailyId,
                        principalTable: "Dailys",
                        principalColumn: "DailyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyRecipe_Recipes_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HolidayRecipe",
                columns: table => new
                {
                    HolidayMealsHolidayId = table.Column<int>(type: "int", nullable: false),
                    RecipesRecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayRecipe", x => new { x.HolidayMealsHolidayId, x.RecipesRecipeId });
                    table.ForeignKey(
                        name: "FK_HolidayRecipe_Holidays_HolidayMealsHolidayId",
                        column: x => x.HolidayMealsHolidayId,
                        principalTable: "Holidays",
                        principalColumn: "HolidayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HolidayRecipe_Recipes_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatorSeasonal",
                columns: table => new
                {
                    CreatorsCreatorId = table.Column<int>(type: "int", nullable: false),
                    SeasonalMealsSeasonalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatorSeasonal", x => new { x.CreatorsCreatorId, x.SeasonalMealsSeasonalId });
                    table.ForeignKey(
                        name: "FK_CreatorSeasonal_Creators_CreatorsCreatorId",
                        column: x => x.CreatorsCreatorId,
                        principalTable: "Creators",
                        principalColumn: "CreatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatorSeasonal_Seasonals_SeasonalMealsSeasonalId",
                        column: x => x.SeasonalMealsSeasonalId,
                        principalTable: "Seasonals",
                        principalColumn: "SeasonalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeSeasonal",
                columns: table => new
                {
                    RecipesRecipeId = table.Column<int>(type: "int", nullable: false),
                    SeasonalMealsSeasonalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSeasonal", x => new { x.RecipesRecipeId, x.SeasonalMealsSeasonalId });
                    table.ForeignKey(
                        name: "FK_RecipeSeasonal_Recipes_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeSeasonal_Seasonals_SeasonalMealsSeasonalId",
                        column: x => x.SeasonalMealsSeasonalId,
                        principalTable: "Seasonals",
                        principalColumn: "SeasonalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreatorDaily_DailyMealsDailyId",
                table: "CreatorDaily",
                column: "DailyMealsDailyId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorHoliday_HolidayMealsHolidayId",
                table: "CreatorHoliday",
                column: "HolidayMealsHolidayId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorSeasonal_SeasonalMealsSeasonalId",
                table: "CreatorSeasonal",
                column: "SeasonalMealsSeasonalId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyRecipe_RecipesRecipeId",
                table: "DailyRecipe",
                column: "RecipesRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayRecipe_RecipesRecipeId",
                table: "HolidayRecipe",
                column: "RecipesRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSeasonal_SeasonalMealsSeasonalId",
                table: "RecipeSeasonal",
                column: "SeasonalMealsSeasonalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatorDaily");

            migrationBuilder.DropTable(
                name: "CreatorHoliday");

            migrationBuilder.DropTable(
                name: "CreatorSeasonal");

            migrationBuilder.DropTable(
                name: "DailyRecipe");

            migrationBuilder.DropTable(
                name: "HolidayRecipe");

            migrationBuilder.DropTable(
                name: "RecipeSeasonal");

            migrationBuilder.DropTable(
                name: "Creators");

            migrationBuilder.DropTable(
                name: "Dailys");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Seasonals");
        }
    }
}
