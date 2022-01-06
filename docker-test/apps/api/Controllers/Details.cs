using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class Details
    {

            private DetailsContext context;
            public int id { get; set; }
            public DateTime date { get; set; }
            public double temperatureC { get; set; }
            public double temperatureF { get; set; }
            public string summary { get; set; }

        
        }
}
