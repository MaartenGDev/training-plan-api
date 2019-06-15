using System.Collections.Generic;
using System.Linq;
using Core.Services;
using DataContext.Models;
using DataContext.Models.Dto;
using GraphQL.Types;

namespace Core.Schema
{
    public class WorkoutType : ObjectGraphType<Workout>
    {
        public WorkoutType(WorkoutService workoutService)
        {
            Field(o => o.Id);
            Field<ListGraphType<WorkoutExerciseType>, IEnumerable<Exercise>>()  
                .Name("exercises")
                .Resolve(ctx => workoutService.GetWorkoutAsync(ctx.Source.Id).Result.Exercises.Select(x => new WorkoutExerciseDto(x))); 
        }
    }
}