using HotChocolate.Types;

namespace graphql_demo_conspiracies.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.Conspiracies)
                .Type<ListType<ConspiracyType>>();

            descriptor.Field(t => t.GetByPresident(default))
                .Type<ListType<ConspiracyType>>();
        }
    }
}
