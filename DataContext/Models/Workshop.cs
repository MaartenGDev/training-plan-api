using System.Collections.Generic;

namespace DataContext.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WorkshopExercise> Exercises { get; set; }
    }
}