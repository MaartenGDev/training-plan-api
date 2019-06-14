using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema.Data
{
    public class ExerciseCreateInputType : InputObjectGraphType<Exercise>
    {
        public ExerciseCreateInputType()
        {
            Name = "ExerciseInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}