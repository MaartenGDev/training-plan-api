using GraphQL;

namespace Core.Schema
{
    public class TrainingPlanSchema : GraphQL.Types.Schema
    {
        public TrainingPlanSchema(SchemaQuery query, SchemaMutation mutation, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            DependencyResolver = resolver;
        }
    }
}