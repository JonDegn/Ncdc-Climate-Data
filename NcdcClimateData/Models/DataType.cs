using System;

namespace JonDegn.ClimateData
{
    /// <summary>
    /// Describes the type of data, acts as a label. If it's 64°f out right now, then the data type is Air Temperature and the data is 64.
    /// </summary>
    public class DataType
    {
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string Name { get; set; }
        public double DataCoverage { get; set; }
        public string Id { get; set; }
    }
}
