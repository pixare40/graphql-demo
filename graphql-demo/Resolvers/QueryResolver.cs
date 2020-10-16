using HotChocolate;
using System.Collections.Generic;

namespace graphql_demo.Resolvers
{
    [GraphQLResolverOf(typeof(Query))]
    public class QueryResolver
    {
        public List<President> President([Parent]Query query)
        {
            return query.Presidents;
        }
    }
}
