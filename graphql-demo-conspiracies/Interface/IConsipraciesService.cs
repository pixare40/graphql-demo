using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_demo_conspiracies.Interface
{
    public interface IConspiraciesService
    {
        IQueryable<Conspiracy> GetAll();

        IList<Conspiracy> GetByPresident(int presidentId);
    }
}
