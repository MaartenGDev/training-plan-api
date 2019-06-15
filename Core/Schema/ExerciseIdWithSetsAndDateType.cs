using Core.Schema.Data.Dto;
using DataContext.Models;
using DataContext.Models.Dto;
using GraphQL.Types;

namespace Core.Schema
{
    public class ExerciseIdWithSetsAndDateType : InputObjectGraphType<ExerciseIdWithSetsAndDateDto>
    {
        public ExerciseIdWithSetsAndDateType()
        {
            Field(o => o.Id);
            Field(o => o.Sets);
            Field(o => o.DateTime);
        }
    }
}