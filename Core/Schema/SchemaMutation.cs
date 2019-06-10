using System;
using Core.Schema.Data;
using Core.Services;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaMutation : ObjectGraphType<object>
    {
        public SchemaMutation(ExerciseService exercises)
        {
            Name = "Mutation";
            Field<ExerciseType>(
                "createExercise",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ExerciseCreateInputType>> { Name = "exercise" }),
                resolve: context =>
                {
                    var input = context.GetArgument<ExerciseCreateInputType>("exercise");
                    var order = new Exercise {Name = input.Name};
                    return exercises.CreateAsync(order);
                }
            );
        }
    }
}