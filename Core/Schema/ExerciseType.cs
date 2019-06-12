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
        }
    }
}