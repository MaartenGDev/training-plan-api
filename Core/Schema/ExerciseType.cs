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
        }
    }
}