namespace NoaaNcdcClient.Requests
{
    public class LocationsRequest : ApiRequest<LocationsRequest>
    {
        public override string Endpoint { get; } = "locations";

        public LocationsRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam(QueryParameters.Dataset, datasetIds);
            return this;
        }

        public LocationsRequest WithLocationCategories(params string[] locationCategoryIds)
        {
            SetArrayParam(QueryParameters.LocationCategory, locationCategoryIds);
            return this;
        }

        public LocationsRequest WithDataCategories(params string[] dataCategoryIds)
        {
            SetArrayParam(QueryParameters.DataCategory, dataCategoryIds);
            return this;
        }
    }
}
