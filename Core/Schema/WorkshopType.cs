using System.Linq;
using DataContext.Models;
using DataContext.Models.Dto;
using GraphQL.Types;

namespace Core.Schema
{
    public class WorkshopType : ObjectGraphType<Workshop>
    {
        public WorkshopType()
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field<ListGraphType<ExerciseType>>("exercises", resolve: context => context.Source.Exercises.Select(x => new WorkshopExerciseDto(x)));
        }
    }
}