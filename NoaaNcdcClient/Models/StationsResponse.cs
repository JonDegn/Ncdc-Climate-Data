using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoaaNcdcClient.Models
{
    public class StationsResponse
    {
        public Metadata Metadata { get; set; }
        public List<Station> Results { get; set; }
    }
}
