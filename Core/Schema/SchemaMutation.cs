using System;
using System.Collections.Generic;
using System.Linq;
using Core.Schema.Data;
using Core.Schema.Data.Dto;
using Core.Services;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaMutation : ObjectGraphType<object>
    {
        public SchemaMutation(ExerciseService exercises, TrainingScheduleService trainingSchedules, WorkoutService workoutService,
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
                    var input = context.GetArgument<TrainingScheduleCreateDto>("trainingSchedule");

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
            
            FieldAsync<WorkoutType>(
                "createWorkout",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<WorkoutCreateInputType>>
                    {Name = "workout"}),
                resolve: async context =>
                {
                    var input = context.GetArgument<WorkoutCreateDto>("workout");

                    var trainingSchedule = new Workout
                    {
                        User = await userService.GetUserByIdAsync(1), 
                        Exercises = input.Exercises
                            .Select(
                                exercise => new WorkoutExercise
                                {
                                    ExerciseId = exercise.Id,
                                    Sets = exercise.Sets,
                                    DateTime = exercise.DateTime
                                }).ToList()
                    };

                    return await context.TryAsyncResolve(async c =>
                        await workoutService.CreateAsync(trainingSchedule));
                }
            );
        }
    }
}