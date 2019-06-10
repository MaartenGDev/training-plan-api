using System.Collections.Generic;

namespace DataContext.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<WorkoutExercise> Workouts { get; set; }
        public List<WorkshopExercise> Workshops { get; set; }
    }
}