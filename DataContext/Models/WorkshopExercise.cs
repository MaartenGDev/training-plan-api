using System.Collections.Generic;

namespace DataContext.Models
{
    public class WorkshopExercise
    {
        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}