using System.Collections.Generic;

namespace DataContext.Models
{
    public class TrainingSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<TrainingScheduleExercise> TrainingScheduleExercises { get; set; }
    }
}