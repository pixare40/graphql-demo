using graphql_demo.Interface;
using System.Collections.Generic;

namespace graphql_demo.Services
{
    public class PresidentService : IPresidentService
    {
        private List<President> authors;
        public PresidentService()
        {
            authors = new List<President>()
            {
                new President{ Id = 37, Name = "Richard", Surname="Nixon"},
                new President{Id= 38, Name= "Gerald", Surname = "Ford"},
                new President{Id=39, Name="Jimmy", Surname="Carter"},
                new President{Id= 40, Name="Ronald", Surname="Reagan"},
                new President{Id= 41, Name="George", Surname="Bush Sr"},
                new President{Id= 42, Name="Bill", Surname="Clinton"},
                new President{Id= 43, Name="George", Surname="Bush"},
                new President{Id= 44, Name="Barrack", Surname="Obama"},
                new President{Id= 45, Name="Donald", Surname="Trump"},
            };
        }

        public List<President> GetAll()
        {
            return authors;
        }
    }
}
