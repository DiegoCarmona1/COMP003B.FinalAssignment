
using System.ComponentModel.DataAnnotations;

namespace COMP003B.FinalAssignment.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        [Required]
        public string RecipeName { get; set; }

        public virtual ICollection<Daily>? DailyMeals { get; set; }
        public virtual ICollection<Seasonal>? SeasonalMeals { get; set; }
        public virtual ICollection<Holiday>? HolidayMeals { get; set; }
    }
}
