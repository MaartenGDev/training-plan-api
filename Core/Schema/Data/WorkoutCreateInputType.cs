using Core.Schema.Data.Dto;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema.Data
{
    public class WorkoutCreateInputType : InputObjectGraphType<Workout>
    {
        public WorkoutCreateInputType()
        {
            Name = "WorkoutInput";
            Field<ListGraphType<NonNullGraphType<ExerciseIdWithSetsAndDateType>>>("exercises");
        }
    }
}