using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace DataContext.Data
{
    public class TrainingPlanContext : DbContext
    {
        public TrainingPlanContext(DbContextOptions options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<TrainingSchedule> TrainingSchedules { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(w => w.Id);
            
            modelBuilder.Entity<Exercise>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<Workshop>()
                .HasKey(w => w.Id);
            
            modelBuilder.Entity<TrainingSchedule>()
                .HasKey(w => w.Id);
            
            modelBuilder.Entity<Workout>()
                .HasKey(w => w.Id);       
            
            modelBuilder.Entity<TrainingScheduleExercise>()
                .HasKey(w => new {w.ExerciseId, w.TrainingScheduleId, w.DateTime});
            
            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(w => new {w.WorkoutId, w.ExerciseId});
            
            modelBuilder.Entity<WorkshopExercise>()
                .HasKey(w => new {w.WorkshopId, w.ExerciseId});
        }
    }
}