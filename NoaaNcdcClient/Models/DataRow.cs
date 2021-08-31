using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoaaNcdcClient.Models
{
    public class DataRow
    {
        public DateTime Date { get; set; }
        public string DataType { get; set; }
        public string Station { get; set; }
        public string Attributes { get; set; }
        public int Value { get; set; }
    }
}
