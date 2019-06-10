using System;
using System.Collections.Generic;

namespace DataContext.Models.Dto
{
    public class TrainingScheduleExerciseDto : Exercise
    {
        public string Sets { get; set; }

        public TrainingScheduleExerciseDto(TrainingScheduleExercise model)
        {
            Id = model.ExerciseId;
            Name = model.Exercise.Name;
            Category = model.Exercise.Category;
            Workouts = model.Exercise.Workouts;
            Workshops = model.Exercise.Workshops;
            Sets = model.Sets;
        }
    }
}