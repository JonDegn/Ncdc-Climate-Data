using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoaaNcdcClient.Models
{
    public class Dataset
    {
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string Name { get; set; }
        public double DataCoverage { get; set; }
        public string Id { get; set; }
    }
}
