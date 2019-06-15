using System.Collections.Generic;
using DataContext.Models;
using DataContext.Models.Dto;

namespace Core.Schema.Data.Dto
{
    public class TrainingScheduleCreateDto
    {
        public string Name { get; set; }
        public User User { get; set; }
        public List<ExerciseIdWithSetsDto> ExercisesWithSets { get; set; }
    }
}