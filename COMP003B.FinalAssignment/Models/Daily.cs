using COMP003B.FinalAssignment.Migrations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace COMP003B.FinalAssignment.Models
{
    public class Daily 
    {
        public int DailyId { get; set; }
        
        public int CreatorId { get; set; }
        public int RecipeId { get; set; }
        
        public virtual Recipe? Recipes { get; set; }
        public virtual Creator? Creators { get; set; }
    }
}
