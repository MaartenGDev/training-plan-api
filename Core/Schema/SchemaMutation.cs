using System;
using System.Collections.Generic;
using System.Linq;
using Core.Schema.Data;
using Core.Services;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaMutation : ObjectGraphType<object>
    {
        public SchemaMutation(ExerciseService exercises, TrainingScheduleService trainingSchedules,
            UserService userService)
        {
            Name = "Mutation";
            Field<ExerciseType>(
                "createExercise",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ExerciseCreateInputType>> {Name = "exercise"}),
                resolve: context =>
                {
                    var input = context.GetArgument<ExerciseCreateInputType>("exercise");
                    var order = new Exercise {Name = input.Name};
                    return exercises.CreateAsync(order);
                }
            );

            FieldAsync<TrainingScheduleType>(
                "createTrainingSchedule",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<TrainingScheduleCreateInputType>>
                    {Name = "trainingSchedule"}),
                resolve: async context =>
                {
                    var input = context.GetArgument<TrainingSchedule>("trainingSchedule");

                    var trainingSchedule = new TrainingSchedule
                    {
                        Name = input.Name,
                        User = await userService.GetUserByIdAsync(1), 
                        TrainingScheduleExercises = input.ExercisesWithSets
                            .Select(
                                exerciseIdWithSets => new TrainingScheduleExercise
                                {
                                    ExerciseId = exerciseIdWithSets.Id,
                                    Sets = exerciseIdWithSets.Sets
                                }).ToList()
                    };

                    return await context.TryAsyncResolve(async c =>
                        await trainingSchedules.CreateAsync(trainingSchedule));
                }
            );
        }
    }
}