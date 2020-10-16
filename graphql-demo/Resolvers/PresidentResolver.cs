using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_demo.Resolvers
{
    [GraphQLResolverOf(typeof(President))]
    public class PresidentResolver
    {
        public int Id([Parent] President president) => president.Id;

        public string Name([Parent] President president) => president.Name;

        public string Surname([Parent] President president) => president.Surname;
    }
}
