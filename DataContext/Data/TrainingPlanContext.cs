using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace DataContext.Data
{
    public class TrainingPlanContext : DbContext
    {
        public TrainingPlanContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Exercise> Exercises { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
                .HasKey(e => e.Id);
        }
    }
}