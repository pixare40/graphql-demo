using graphql_demo_conspiracies.Interface;
using System.Collections.Generic;
using System.Linq;

namespace graphql_demo_conspiracies
{
    public class Query
    {
        private readonly IConspiraciesService _conspiracyService;
        public Query(IConspiraciesService conspiracyService)
        {
            _conspiracyService = conspiracyService;
        }

        public IQueryable<Conspiracy> Conspiracies => _conspiracyService.GetAll();

        public IEnumerable<Conspiracy> GetByPresident(int presidentId) => _conspiracyService.GetByPresident(presidentId);
    }
}
