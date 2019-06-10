using System;
using System.Collections.Generic;

namespace DataContext.Models.Dto
{
    public class WorkoutExerciseDto : Exercise
    {
        public DateTime DateTime { get; set; }
        public string Sets { get; set; }
        
        public WorkoutExerciseDto(WorkoutExercise model)
        {
            Id = model.ExerciseId;
            Name = model.Exercise.Name;
            Category = model.Exercise.Category;
            Description = model.Exercise.Description;
            Workouts = model.Exercise.Workouts;
            Workshops = model.Exercise.Workshops;
            DateTime = model.DateTime;
            Sets = model.Sets;
        }
    }
}