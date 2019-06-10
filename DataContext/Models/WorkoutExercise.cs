using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Models
{
    public class WorkoutExercise
    {
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        [Required]
        public string Sets { get; set; }
        public DateTime DateTime { get; set; }
    }
}