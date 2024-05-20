using COMP003B.FinalAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIRecipes : Controller
    {
        private List<Recipe> _recipes = new List<Recipe>();

        public APIRecipes()
        {
            _recipes.Add(new Recipe { RecipeId = 1, RecipeName = "Green Bean Cassarole" });
            _recipes.Add(new Recipe {RecipeId = 2, RecipeName = "Chocolate Chip" });
            _recipes.Add(new Recipe {RecipeId = 3, RecipeName = "Tiramisu" });
            _recipes.Add(new Recipe {RecipeId = 4, RecipeName = "Ceasar Salad" });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetAllRecipes()
        {
            return _recipes;
        }

        [HttpGet("(id)")]
        public ActionResult<Recipe> GetRecipeById(int id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }
            return recipe;
        }

        [HttpPost]
        public ActionResult<Recipe> CreateRecipe(Recipe recipe)
        {
            recipe.RecipeId = _recipes.Max(r => r.RecipeId) + 1;
            _recipes.Add(recipe);
            return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.RecipeId }, recipe);
        }

        [HttpPut]
        public ActionResult<Recipe> UpdateRecipe(int id, Recipe updateRecipe)
        {
            var recipe = _recipes.Find(r => r.RecipeId == id);

            if (recipe == null)
            {
                return BadRequest();
            }

            recipe.RecipeName = updateRecipe.RecipeName;

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteRecipe(int id)
        {
            var recipe = _recipes.Find(r => r.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }
            _recipes.Remove(recipe);
            return NoContent();
        }
    }
}
