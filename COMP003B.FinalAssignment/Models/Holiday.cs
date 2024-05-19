using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace COMP003B.FinalAssignment.Models
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        [Required]
        public string HolidayName { get; set; }
        public int CreatorId { get; set; }
        public int RecipeId { get; set; }

        

        public virtual Recipe? Recipes { get; set; }
        public virtual Creator? Creators { get; set; }
    }
}
