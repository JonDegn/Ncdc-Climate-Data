using System;

namespace JonDegn.ClimateData
{
    /// <summary>
    /// Locations can be a specific latitude/longitude point such as a station, or a label representing a bounding area such as a city.
    /// </summary>
    public class Location
    {
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string Name { get; set; }
        public double DataCoverage { get; set; }
        public string Id { get; set; }
    }
}
