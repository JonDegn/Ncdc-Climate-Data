using NoaaNcdcClient.Models;
using System;

namespace NoaaNcdcClient.Requests
{
    public class DataRequest : ApiRequest<DataRequest>
    {
        public override string Endpoint { get; } = "data";

        public DataRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam(QueryParameters.Dataset, datasetIds);
            return this;
        }

        public DataRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam(QueryParameters.Location, locationIds);
            return this;
        }

        public DataRequest WithStations(params string[] stationIds)
        {
            SetArrayParam(QueryParameters.Station, stationIds);
            return this;
        }

        public DataRequest WithUnits(Units units)
        {
            SetParam(QueryParameters.Units, Enum.GetName(units));
            return this;
        }

        public DataRequest WithIncludeMetadata(bool includeMetadata)
        {
            SetParam("includemetadata", includeMetadata.ToString());
            return this;
        }
    }
}
