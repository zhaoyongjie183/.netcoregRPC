using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Data
{
    public class InMemoryData
    {
        public static List<PeopleModel> peopleModels = new List<PeopleModel>() { 
        
            new PeopleModel{ Id=1,Name="张三",Age=18},

            new PeopleModel{ Id=2,Name="李四",Age=19}
        
        };
    }
}
