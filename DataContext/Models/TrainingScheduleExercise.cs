using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Models
{
    public class TrainingScheduleExercise
    {
        public int TrainingScheduleId{ get; set; }
        public TrainingSchedule TrainingSchedule{ get; set; }
        public int ExerciseId { get; set; }
        [Required]
        public Exercise Exercise { get; set; }
        [Required]
        public string Sets { get; set; }
    }
}