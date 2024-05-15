using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace COMP003B.FinalAssignment.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        [Required]
        public string RecipeName { get; set; }

        public virtual ICollection<DailyMeal>? DailyMeals { get; set; }
        public virtual ICollection<SeasonalMeal>? SeasonalMeals { get; set; }
        public virtual ICollection<HolidayMeal>? HolidayMeals { get; set; }
    }
}
