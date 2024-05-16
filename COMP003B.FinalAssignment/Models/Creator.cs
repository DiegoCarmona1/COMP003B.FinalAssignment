
using System.ComponentModel.DataAnnotations;

namespace COMP003B.FinalAssignment.Models
{
    public class Creator
    {
        public int CreatorId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Daily>? DailyMeals { get; set; }
        public virtual ICollection<Seasonal>? SeasonalMeals { get; set; }
        public virtual ICollection<Holiday>? HolidayMeals { get; set; }
    }
}
