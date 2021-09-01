using System;

namespace NoaaNcdcClient.Models
{
    public class Location
    {
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string Name { get; set; }
        public double DataCoverage { get; set; }
        public string Id { get; set; }
    }
}
