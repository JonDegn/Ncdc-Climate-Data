namespace NoaaNcdcClient.Requests
{
    public class DataTypesRequest : ApiRequest<DataTypesRequest>
    {
        public override string Endpoint { get; } = "datatypes";

        public DataTypesRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam(QueryParameters.Dataset, datasetIds);
            return this;
        }

        public DataTypesRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam(QueryParameters.Location, locationIds);
            return this;
        }

        public DataTypesRequest WithStations(params string[] stationIds)
        {
            SetArrayParam(QueryParameters.Station, stationIds);
            return this;
        }

        public DataTypesRequest WithDataCategories(params string[] dataCategoryIds)
        {
            SetArrayParam(QueryParameters.DataCategory, dataCategoryIds);
            return this;
        }
    }
}
