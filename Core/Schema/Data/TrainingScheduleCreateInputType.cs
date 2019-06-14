using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema.Data
{
    public class TrainingScheduleCreateInputType : InputObjectGraphType<TrainingSchedule>
    {
        public TrainingScheduleCreateInputType()
        {
            Name = "ExerciseInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<ListGraphType<NonNullGraphType<ExerciseIdWithSetsType>>>("exercisesWithSets");
        }
    }
}