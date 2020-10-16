using graphql_demo.Interface;
using System.Collections.Generic;

namespace graphql_demo
{
    public class Query
    {
        private readonly IPresidentService _presidentService;
        public Query(IPresidentService presidentService)
        {
            _presidentService = presidentService;
        }

        public List<President> Presidents => _presidentService.GetAll();
    }
}
