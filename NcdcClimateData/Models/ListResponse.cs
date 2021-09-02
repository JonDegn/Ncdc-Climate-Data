using System.Collections.Generic;

namespace JonDegn.ClimateData
{
    public class ListResponse<T>
    {
        public Metadata Metadata { get; set; }
        public List<T> Results { get; set; }
    }
}
