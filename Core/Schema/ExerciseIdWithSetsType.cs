using DataContext.Models;
using DataContext.Models.Dto;
using GraphQL.Types;

namespace Core.Schema
{
    public class ExerciseIdWithSetsType : InputObjectGraphType<ExerciseIdWithSetsDto>
    {
        public ExerciseIdWithSetsType()
        {
            Field(o => o.Id);
            Field(o => o.Sets);
        }
    }
}