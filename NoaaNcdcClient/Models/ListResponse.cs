using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoaaNcdcClient.Models
{
    public class ListResponse<T>
    {
        public Metadata Metadata { get; set; }
        public List<T> Results { get; set; }
    }
}
