﻿using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Models
{
    public class Seasonal
    {
        public int SeasonalId { get; set; }
        public string SeasonalName { get; set; }
        public int CreatorId { get; set; }
        public int RecipeId { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Creator> Creators { get; set; }
    }
}
