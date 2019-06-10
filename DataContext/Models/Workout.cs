using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Models
{
    public class Workout
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        public List<WorkoutExercise> Exercises { get; set; }
    }
}