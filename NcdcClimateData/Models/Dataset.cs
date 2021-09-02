using System;

namespace JonDegn.ClimateData
{
    /// <summary>
    /// All of the CDO data are in datasets. The containing dataset must be known before attempting to access its data.
    /// </summary>
    public class Dataset
    {
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string Name { get; set; }
        public double DataCoverage { get; set; }
        public string Id { get; set; }
    }
}
