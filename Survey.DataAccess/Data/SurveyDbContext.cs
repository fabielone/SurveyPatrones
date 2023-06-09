using Microsoft.EntityFrameworkCore;
using Survey.API.Models;

namespace Survey.API.Data
{
    public class SurveyDbContext : DbContext
    {
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
        {
        }

        public DbSet<SurveyItem> Surveys { get; set; }

        // Add DbSets for other models here

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure any additional model configurations here
        }
    }
}
