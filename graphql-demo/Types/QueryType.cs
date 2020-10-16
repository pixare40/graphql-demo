using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Threading.Tasks;

namespace graphql_demo.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.Presidents)
                .Type<ListType<PresidentType>>();
        }
    }
}
