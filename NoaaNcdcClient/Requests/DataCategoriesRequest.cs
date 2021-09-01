namespace NoaaNcdcClient.Requests
{
    public class DataCategoriesRequest : ApiRequest<DataCategoriesRequest>
    {
        public override string Endpoint { get; } = "datacategories";

        public DataCategoriesRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam(QueryParameters.Dataset, datasetIds);
            return this;
        }

        public DataCategoriesRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam(QueryParameters.Location, locationIds);
            return this;
        }

        public DataCategoriesRequest WithStations(params string[] stationIds)
        {
            SetArrayParam(QueryParameters.Station, stationIds);
            return this;
        }
    }
}
