using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(o => o.Id);
            Field(o => o.Name);
        }
    }
}