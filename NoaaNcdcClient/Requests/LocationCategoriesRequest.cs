namespace NoaaNcdcClient.Requests
{
    public class LocationCategoriesRequest : ApiRequest<LocationCategoriesRequest>
    {
        public override string Endpoint { get; } = "locationcategories";

        public LocationCategoriesRequest WithDatasets(params string[] dataTypeIds)
        {
            SetArrayParam(QueryParameters.Dataset, dataTypeIds);
            return this;
        }

    }
}
