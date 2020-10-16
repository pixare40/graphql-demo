using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_demo.Types
{
    public class PresidentType : ObjectType<President>
    {
        protected override void Configure(IObjectTypeDescriptor<President> descriptor)
        {
            descriptor.Field(t => t.Id)
                .Type<IntType>();

            descriptor.Field(t => t.Name)
                .Type<StringType>();

            descriptor.Field(t => t.Surname)
                .Type<StringType>();
        }
    }
}
