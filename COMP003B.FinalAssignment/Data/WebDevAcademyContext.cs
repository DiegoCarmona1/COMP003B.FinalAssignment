using COMP003B.FinalAssignment.Models;
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
        public DbSet<Daily> Dailys { get; set; }
        public DbSet<Seasonal> Seasonals { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
    }
}

