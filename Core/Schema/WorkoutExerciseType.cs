using DataContext.Models;
using DataContext.Models.Dto;
using GraphQL.Types;

namespace Core.Schema
{
    public class WorkoutExerciseType : ObjectGraphType<WorkoutExerciseDto>
    {
        public WorkoutExerciseType()
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field(o => o.Description);
            Field(o => o.ImagePath);
            Field(o => o.DateTime);
            Field(o => o.Sets);
            Field<ExerciseCategoryType>("category", resolve: context => context.Source.Category);
        }
    }
}