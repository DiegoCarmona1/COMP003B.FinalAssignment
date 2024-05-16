using COMP003B.FinalAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.FinalAssignment.Data
{
    public class WebDevAcademyContext : DbContext
    {
        public WebDevAcademyContext(DbContextOptions<WebDevAcademyContext> options)
            : base(options)

        {
        }

        public DbSet<Creator> Creators { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<DailyMeal> DailyMeals { get; set; }
        public DbSet<SeasonalMeal> SeasonalMeals { get; set; }
        public DbSet<HolidayMeal> HolidayMeals { get; set; }
    }
}

