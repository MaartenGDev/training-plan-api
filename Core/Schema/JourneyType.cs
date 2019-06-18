using System.Linq;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class JourneyType : ObjectGraphType<Journey>
    {
        public JourneyType()
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field<ListGraphType<WorkshopType>>("workshops", resolve: context => context.Source.Workshops.Select(x => x.Workshop));
        }
    }
}