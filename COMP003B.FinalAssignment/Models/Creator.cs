
using System.ComponentModel.DataAnnotations;

namespace COMP003B.FinalAssignment.Models
{
    public class Creator
    {
        public int CreatorId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<DailyMeal>? DailyMeals { get; set; }
        public virtual ICollection<SeasonalMeal>? SeasonalMeals { get; set; }
        public virtual ICollection<HolidayMeal>? HolidayMeals { get; set; }
    }
}
