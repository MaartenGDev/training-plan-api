using System.Collections.Generic;
using System.Linq;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class ExerciseType : ObjectGraphType<Exercise>
    {
        public ExerciseType()
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field(o => o.Description);
            Field(o => o.ImagePath);
            Field<ExerciseCategoryType>("category", resolve: context => context.Source.Category);
            Field<ListGraphType<WorkoutType>, IEnumerable<Workout>>()  
                .Name("workouts")
                .Resolve(ctx => ctx.Source.Workouts.Select(x => x.Workout));
            
            Field<ListGraphType<WorkshopType>, IEnumerable<Workshop>>()  
                .Name("workshops")
                .Resolve(ctx => ctx.Source.Workshops.Select(x => x.Workshop));
        }
    }
}