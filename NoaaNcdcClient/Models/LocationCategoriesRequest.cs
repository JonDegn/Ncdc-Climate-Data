namespace NoaaNcdcClient.Models
{
    public class LocationCategoriesRequest : ApiRequest<LocationCategoriesRequest>
    {
        public override string Endpoint { get; } = "locationcategories";

        public LocationCategoriesRequest WithDatasets(params string[] dataTypeIds)
        {
            SetArrayParam("datasetid", dataTypeIds);
            return this;
        }

    }
}
