using Core.Services;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaQuery : ObjectGraphType<object>
    {
        public SchemaQuery(ExerciseService exercises, TrainingScheduleService trainingScheduleService, WorkshopService workshopService, WorkoutService workoutService)
        {
            Name = "Query";
            Field<ListGraphType<ExerciseType>>(
                "exercises",
                resolve: context => exercises.GetExercisesAsync()
            );

            Field<ListGraphType<TrainingScheduleType>>(
                "trainingSchedules",
                resolve: context => trainingScheduleService.GetTrainingSchedulesAsync()
            );
            
            Field<ListGraphType<WorkshopType>>(
                "workshops",
                resolve: context => workshopService.GetWorkshopsAsync()
            );
            
            Field<ListGraphType<WorkoutType>>(
                "workouts",
                resolve: context => workoutService.GetWorkoutsAsync()
            );
            
            
            FieldAsync<ExerciseType>(
                "exercise",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name="id"}),
                resolve: async context => {
                    return await context.TryAsyncResolve(
                        async c=> await exercises.GetExerciseByIdAsync(c.GetArgument<int>("id"))
                    );
                }
            );
        }
    }
}