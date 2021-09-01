using System;

namespace NoaaNcdcClient.Models
{
    public class DataRequest : ApiRequest<DataRequest>
    {
        public override string Endpoint { get; } = "data";

        public DataRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam("datasetid", datasetIds);
            return this;
        }

        public DataRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam("locationid", locationIds);
            return this;
        }

        public DataRequest WithStations(params string[] stationIds)
        {
            SetArrayParam("stationid", stationIds);
            return this;
        }

        public DataRequest WithUnits(Units units)
        {
            SetParam("units", Enum.GetName(units));
            return this;
        }

        public DataRequest WithIncludeMetadata(bool includeMetadata)
        {
            SetParam("includemetadata", includeMetadata.ToString());
            return this;
        }
    }
}
