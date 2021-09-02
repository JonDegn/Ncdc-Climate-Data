namespace JonDegn.ClimateData
{
    public class LocationCategoriesRequest : ApiRequest<LocationCategoriesRequest>
    {
        public override string Endpoint { get; } = "locationcategories";

        /// <summary>
        /// Optional. Accepts a valid dataset id or a list of dataset ids. Location categories returned will be supported by dataset(s) specified.
        /// </summary>
        /// <param name="datasetIds">The dataset ids.</param>
        public LocationCategoriesRequest WithDatasets(params string[] dataTypeIds)
        {
            SetArrayParam(QueryParameters.Dataset, dataTypeIds);
            return this;
        }

    }
}
