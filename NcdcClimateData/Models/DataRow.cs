using System;

namespace JonDegn.ClimateData
{
    public class DataRow
    {
        public DateTime Date { get; set; }
        public string DataType { get; set; }
        public string Station { get; set; }
        public string Attributes { get; set; }
        public double Value { get; set; }
    }
}
