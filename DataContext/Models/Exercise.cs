using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public ExerciseCategory Category { get; set; }
        public List<WorkoutExercise> Workouts { get; set; }
        public List<WorkshopExercise> Workshops { get; set; }
    }
}