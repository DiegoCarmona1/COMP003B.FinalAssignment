using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace COMP003B.FinalAssignment.Models
{
    public class Creator
    {
        public int CreatorId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string MealTime { get; set; }
        [Required]
        public string Holiday { get; set; }
        [Required]
        public string Season { get; set; }

        public virtual ICollection<Daily>? DailyMeals { get; set; }
        public virtual ICollection<Seasonal>? SeasonalMeals { get; set; }
        public virtual ICollection<Holiday>? HolidayMeals { get; set; }
    }
}
