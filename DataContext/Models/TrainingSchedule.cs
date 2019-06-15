using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataContext.Models.Dto;

namespace DataContext.Models
{
    public class TrainingSchedule
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public List<TrainingScheduleExercise> TrainingScheduleExercises { get; set; }
    }
}