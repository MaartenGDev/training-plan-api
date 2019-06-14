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
            Description = model.Exercise.Description;
            ImagePath = model.Exercise.ImagePath;
            Workouts = model.Exercise.Workouts;
            Workshops = model.Exercise.Workshops;
        }
    }
}