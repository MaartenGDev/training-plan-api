using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Models
{
    public class ExerciseCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}