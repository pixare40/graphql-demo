using HotChocolate.Types;

namespace graphql_demo_conspiracies.Types
{
    public class ConspiracyType : ObjectType<Conspiracy>
    {
        protected override void Configure(IObjectTypeDescriptor<Conspiracy> descriptor)
        {
            descriptor.Field(t => t.Id)
                .Type<IntType>();

            descriptor.Field(t => t.Name)
                .Type<StringType>();

            descriptor.Field(t => t.PresidentId)
                .Type<IntType>();

            descriptor.Field(t => t.Description)
                .Type<StringType>();
        }
    }
}
