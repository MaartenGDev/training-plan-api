using System;
using System.Collections.Generic;

namespace DataContext.Models.Dto
{
    public class WorkshopExerciseDto : Exercise
    {
        public WorkshopExerciseDto(WorkshopExercise model)
        {
            Id = model.ExerciseId;
            Name = model.Exercise.Name;
            Category = model.Exercise.Category;
            Workouts = model.Exercise.Workouts;
            Workshops = model.Exercise.Workshops;
        }
    }
}