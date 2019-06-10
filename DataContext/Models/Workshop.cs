using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<WorkshopExercise> Exercises { get; set; }
    }
}