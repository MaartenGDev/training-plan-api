using System;
using System.Collections.Generic;

namespace DataContext.Models
{
    public class TrainingScheduleExercise
    {
        public int TrainingScheduleId{ get; set; }
        public TrainingSchedule TrainingSchedule{ get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public DateTime DateTime { get; set; }
        public string Sets { get; set; }
    }
}