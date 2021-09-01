namespace NoaaNcdcClient.Requests
{
    public class DatasetsRequest : ApiRequest<DatasetsRequest>
    {
        public override string Endpoint { get; } = "datasets";

        public DatasetsRequest WithDataTypes(params string[] dataTypeIds)
        {
            SetArrayParam(QueryParameters.DataType, dataTypeIds);
            return this;
        }

        public DatasetsRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam(QueryParameters.Location, locationIds);
            return this;
        }

        public DatasetsRequest WithStations(params string[] stationIds)
        {
            SetArrayParam(QueryParameters.Station, stationIds);
            return this;
        }
    }
}
