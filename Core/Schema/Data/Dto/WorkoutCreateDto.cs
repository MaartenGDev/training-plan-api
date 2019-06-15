using System.Collections.Generic;
using DataContext.Models;
using DataContext.Models.Dto;

namespace Core.Schema.Data.Dto
{
    public class WorkoutCreateDto
    {
        public string Name { get; set; }
        public User User { get; set; }
        public List<ExerciseIdWithSetsAndDateDto> Exercises { get; set; }
    }
}