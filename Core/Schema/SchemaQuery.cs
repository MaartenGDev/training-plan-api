using System;
using Core.Services;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaQuery : ObjectGraphType<object>
    {
        public SchemaQuery(ExerciseService exercises, TrainingScheduleService trainingScheduleService)
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
            
        }
    }
}