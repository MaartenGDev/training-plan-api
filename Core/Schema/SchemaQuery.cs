using System;
using Core.Services;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaQuery : ObjectGraphType<object>
    {
        public SchemaQuery(ExerciseService exercises)
        {
            Name = "Query";
            Field<ListGraphType<ExerciseType>>(
                "exercises",
                resolve: context => exercises.GetExercisesAsync()
            );

            FieldAsync<ExerciseType>(
                "orderById",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> {Name="exerciseId"}),
                resolve: async context => {
                    return await context.TryAsyncResolve(
                        async c=> await exercises.GetExercisesByIdAsync(c.GetArgument<int>("exerciseId"))
                    );
                }
            );
        }
    }
}