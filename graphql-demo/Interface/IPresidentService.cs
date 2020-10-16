using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_demo.Interface
{
    public interface IPresidentService
    {
        List<President> GetAll();
    }
}
