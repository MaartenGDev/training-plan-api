using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class ExerciseCategoryType : ObjectGraphType<ExerciseCategory>
    {
        public ExerciseCategoryType()
        {
            Field(o => o.Id);
            Field(o => o.Name);
        }
    }
}