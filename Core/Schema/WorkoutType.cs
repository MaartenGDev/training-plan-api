using System.Collections.Generic;
using System.Linq;
using DataContext.Models;
using DataContext.Models.Dto;
using GraphQL.Types;

namespace Core.Schema
{
    public class WorkoutType : ObjectGraphType<Workout>
    {
        public WorkoutType()
        {
            Field(o => o.Id);
            Field<ListGraphType<WorkoutExerciseType>, IEnumerable<Exercise>>()  
                .Name("exercises")
                .Resolve(ctx => ctx.Source.Exercises.Select(x => new WorkoutExerciseDto(x))); 
        }
    }
}