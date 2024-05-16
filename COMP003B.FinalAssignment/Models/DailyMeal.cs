

namespace COMP003B.FinalAssignment.Models
{
    public class DailyMeal 
    {
        public int DailyId { get; set; }
        public int CreatorId { get; set; }
        public int RecipeId { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Creator> Creators { get; set; }
    }
}
