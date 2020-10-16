using graphql_demo_conspiracies.Interface;
using System.Collections.Generic;
using System.Linq;

namespace graphql_demo_conspiracies.Services
{
    public class ConsipraciesService : IConspiraciesService
    {
        private List<Conspiracy> conspiracies;

        public ConsipraciesService()
        {
            conspiracies = new List<Conspiracy>
            {
                new Conspiracy{Id=1, Name="Libya", PresidentId=44, Description=""},
                new Conspiracy{Id=2, Name="Watergate", PresidentId=37},
                new Conspiracy{Id=3, Name="Monica Lewinski Scandal", PresidentId=42},
                new Conspiracy{Id=4, Name="Born in Kenya", PresidentId=44},
                new Conspiracy{Id=5, Name="Obamagate", PresidentId=44},
                new Conspiracy{Id=6, Name="Iran", PresidentId=44},
                new Conspiracy{Id=7, Name="#Trump2020", PresidentId=45},
                new Conspiracy{Id=8, Name="War on Terror", PresidentId=44},
            };
        }

        public IQueryable<Conspiracy> GetAll()
        {
            return conspiracies.AsQueryable();
        }

        public IList<Conspiracy> GetByPresident(int presidentId)
        {
            return conspiracies.Where(c => c.PresidentId == presidentId).ToList();
        }
    }
}
