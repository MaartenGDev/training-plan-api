using System;

namespace Core.Schema.Data.Dto
{
    public class ExerciseIdWithSetsAndDateDto : ExerciseIdWithSetsDto
    {
        public DateTime DateTime { get; set; }
    }
}