using System.Collections.Generic;

namespace DataContext.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public List<WorkoutExercise> Exercices { get; set; }
    }
}