using System;

namespace JonDegn.ClimateData
{
    /// <summary>
    /// Stations are where the data comes from (for most datasets) and can be considered the smallest granual of location data. If the desired station is known, all of its data can quickly be viewed
    /// </summary>
    public class Station
    {
        public double Elevation { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; }
        public double DataCoverage { get; set; }
        public string Id { get; set; }
        public string ElevationUnit { get; set; }
        public double Longitude { get; set; }
    }
}
