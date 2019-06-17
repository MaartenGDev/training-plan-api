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
        public DbSet<Journey> Journeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(w => w.Id);
            
            modelBuilder.Entity<Exercise>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<ExerciseCategory>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<Workshop>()
                .HasKey(w => w.Id);
            
            modelBuilder.Entity<Journey>()
                .HasKey(w => w.Id);
            
            modelBuilder.Entity<TrainingSchedule>()
                .HasKey(w => w.Id);
            
            modelBuilder.Entity<Workout>()
                .HasKey(w => w.Id);       
            
            modelBuilder.Entity<TrainingScheduleExercise>()
                .HasKey(w => new {w.ExerciseId, w.TrainingScheduleId});
            
            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(w => new {w.WorkoutId, w.ExerciseId, w.DateTime});
            
            modelBuilder.Entity<WorkshopExercise>()
                .HasKey(w => new {w.WorkshopId, w.ExerciseId});
            
            modelBuilder.Entity<JourneyWorkshop>()
                .HasKey(w => new {w.JourneyId, w.WorkshopId});
        }
    }
}