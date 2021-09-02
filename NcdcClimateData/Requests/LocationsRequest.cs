namespace JonDegn.ClimateData
{
    public class LocationsRequest : ApiRequest<LocationsRequest>
    {
        public override string Endpoint { get; } = "locations";

        /// <summary>
        /// Optional. Accepts a valid dataset id or a list of dataset ids. Locations returned will be supported by dataset(s) specified.
        /// </summary>
        /// <param name="datasetIds">The dataset ids.</param>
        public LocationsRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam(QueryParameters.Dataset, datasetIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid location id or a list of location category ids. Locations returned will be in the location category(ies) specified.
        /// </summary>
        /// <param name="locationCategoryIds">The location categories.</param>
        public LocationsRequest WithLocationCategories(params string[] locationCategoryIds)
        {
            SetArrayParam(QueryParameters.LocationCategory, locationCategoryIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid data category id or a list of data category ids. Locations returned will be associated with the data category(ies) specified.
        /// </summary>
        /// <param name="dataCategoryIds"></param>
        /// <returns></returns>
        public LocationsRequest WithDataCategories(params string[] dataCategoryIds)
        {
            SetArrayParam(QueryParameters.DataCategory, dataCategoryIds);
            return this;
        }
    }
}
