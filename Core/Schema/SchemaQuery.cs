using Core.Services;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaQuery : ObjectGraphType<object>
    {
        public SchemaQuery(ExerciseService exercises, TrainingScheduleService trainingScheduleService, WorkshopService workshopService, WorkoutService workoutService, JourneyService journeyService)
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
            
            Field<ListGraphType<JourneyType>>(
                "journeys",
                resolve: context => journeyService.GetJourneysAsync()
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
            
            FieldAsync<JourneyType>(
                "journey",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name="id"}),
                resolve: async context => {
                    return await context.TryAsyncResolve(
                        async c=> await journeyService.GetJourneyByIdAsync(c.GetArgument<int>("id"))
                    );
                }
            );
        }
    }
}