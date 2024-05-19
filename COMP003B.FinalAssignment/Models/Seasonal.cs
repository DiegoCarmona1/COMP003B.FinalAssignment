using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace COMP003B.FinalAssignment.Models
{
    public class Seasonal
    {
        public int SeasonalId { get; set; }
        
        public int CreatorId { get; set; }
        public int RecipeId { get; set; }
        
        public virtual Recipe? Recipes { get; set; }
        public virtual Creator? Creators { get; set; }
    }
}
